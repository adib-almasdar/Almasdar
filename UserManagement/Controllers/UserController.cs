using CommonLib.Data;
using Microsoft.AspNetCore.Authorization;
//using CommonLib.Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using RestSharp;
using System.Linq;
using System.Text.RegularExpressions;
using UserManagement.Model;
using static Azure.Core.HttpHeader;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UserManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public UserController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: api/<UserController>

        [HttpGet]
        [Route("ListofRolesForReport")]
        public IActionResult ListofRolesForReport(string? query, string? applicationIds)
        {
            // If applicationIds is provided and not empty
            if (!string.IsNullOrEmpty(applicationIds))
            {
                // Split the comma-separated string into a list of integers
                var applicationIdList = applicationIds.Split(',')
                                                       .Select(id => int.TryParse(id, out var result) ? result : (int?)null)
                                                       .Where(id => id.HasValue)
                                                       .Select(id => id.Value)
                                                       .ToList();

                if (applicationIdList.Any())
                {
                    var rolesQuery = _context.Roles.Where(r => applicationIdList.Contains((int)r.ApplicationId));

                    // If query is provided, filter roles by name
                    if (!string.IsNullOrEmpty(query))
                    {
                        rolesQuery = rolesQuery.Where(r => r.Name.Contains(query));
                    }

                    var roles = rolesQuery.Select(r => new { r.RoleId, r.Name }).ToList();
                    return Ok(roles);
                }
                else
                {
                    return BadRequest("Invalid application IDs provided.");
                }
            }
            else
            {
                // If applicationIds is not provided, join all roles with applications
                var listRolesQuery = _context.Roles.Join(_context.Applications, r => r.ApplicationId, a => a.ApplicationId, (r, a) => new { r.Name, r.RoleId, a.ApplicationId, a.ApplicationName });

                // If query is provided, filter roles by name
                if (!string.IsNullOrEmpty(query))
                {
                    listRolesQuery = listRolesQuery.Where(x => x.Name.Contains(query));
                }

                var listRoles = listRolesQuery.ToList();
                return Ok(listRoles);
            }
        }

        [HttpGet]
        [Route("ListofApplicationsForReport")]
        public IActionResult ListofApplicationsForReport(string? query, string? roleIds)
        {
            // If roleIds is provided and not empty
            if (!string.IsNullOrEmpty(roleIds))
            {
                // Split the comma-separated string into a list of integers
                var roleIdList = roleIds.Split(',')
                                        .Select(id => int.TryParse(id, out var result) ? result : (int?)null)
                                        .Where(id => id.HasValue)
                                        .Select(id => id.Value)
                                        .ToList();

                if (roleIdList.Any())
                {
                    // Join Roles and Applications, filter by roleIdList, and include application name
                    var listApplicationsQuery = _context.Roles
                                                        .Where(r => roleIdList.Contains(r.RoleId)) // Filter roles by RoleId
                                                        .Join(_context.Applications, r => r.ApplicationId, a => a.ApplicationId,
                                                              (r, a) => new { a.ApplicationId, a.ApplicationName })
                                                        .Distinct(); // Ensure no duplicate applications

                    // If query is provided, filter applications by name
                    if (!string.IsNullOrEmpty(query))
                    {
                        listApplicationsQuery = listApplicationsQuery.Where(x => x.ApplicationName.Contains(query));
                    }

                    var listApplications = listApplicationsQuery.ToList();
                    return Ok(listApplications);
                }
                else
                {
                    return BadRequest("Invalid role IDs provided.");
                }
            }
            else
            {
                // If roleIds is not provided, return all applications associated with roles
                var listApplicationsQuery = _context.Roles
                                                    .Join(_context.Applications, r => r.ApplicationId, a => a.ApplicationId,
                                                          (r, a) => new { a.ApplicationId, a.ApplicationName })
                                                    .Distinct(); // Ensure no duplicate applications

                // If query is provided, filter applications by name
                if (!string.IsNullOrEmpty(query))
                {
                    listApplicationsQuery = listApplicationsQuery.Where(x => x.ApplicationName.Contains(query));
                }

                var listApplications = listApplicationsQuery.ToList();
                return Ok(listApplications);
            }
        }


        [HttpGet]
        [Route("GetUserAvailabilityByEmailId")]
        public IActionResult GetUserAvailabilityByEmailId(string email)
        {
            string accessToken = GetGraphAccessToken();

            if (accessToken != null && accessToken != "Error")
            {
                string url = "https://graph.microsoft.com/v1.0/users/" + email + "/mailboxSettings/automaticRepliesSetting";

                var options = new RestClientOptions(url)
                {
                    Timeout = Timeout.InfiniteTimeSpan,
                };
                var client = new RestClient(options);
                var request = new RestRequest(url, Method.Get);
                request.AddHeader("Authorization", "Bearer " + accessToken);
                RestResponse response = client.Execute(request);

                // Parse the response to extract business phone
                if (response.IsSuccessful)
                {
                    var jsonResponse = JObject.Parse(response.Content);

                    string status = jsonResponse["status"].ToString();

                    if (!string.IsNullOrEmpty(status))
                    {
                        return Ok(new { status = status });
                    }
                    else
                    {
                        return NotFound("Status field not found in the response.");
                    }
                }
                else
                {
                    return Forbid("Error");
                }
            }
            else
            {
                return Forbid("Error");
            }

        }

        [HttpGet]
        [Route("GetUserDetailsByEmailId")]
        public IActionResult GetUserDetailsByEmailId(string email)
        {
            string accessToken = GetGraphAccessToken();

            if (accessToken != null && accessToken != "Error")
            {
                string url = "https://graph.microsoft.com/v1.0/users?$filter=mail eq '" + email + "'&$select=mail,displayName,businessPhones,department,officeLocation";

                var options = new RestClientOptions(url)
                {
                    Timeout = Timeout.InfiniteTimeSpan,
                };
                var client = new RestClient(options);
                var request = new RestRequest(url, Method.Get);
                request.AddHeader("Authorization", "Bearer " + accessToken);
                RestResponse response = client.Execute(request);

                // Parse the response to extract business phone
                if (response.IsSuccessful)
                {
                    var jsonResponse = JObject.Parse(response.Content);
                    return Ok(response.Content);
                }
                else
                {
                    return Forbid("Error");
                }
            }
            else
            {
                return Forbid("Error");
            }

        }

        [HttpGet]
        [Route("GetGraphAccessToken")]
        public static string GetGraphAccessToken()
        {
            var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")
                  ?? "Development";

            var configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: false)
                .AddJsonFile($"appsettings.{environment}.json", optional: true, reloadOnChange: false)
                .Build();
            // Read the file path from the configuration
            string TenantId = configuration["AzureAd:TenantId"];
            string ClientId = configuration["AzureAd:ClientId"];
            string ClientSecret = configuration["AzureAd:ClientSecret"];

            // Construct the URL dynamically
            var url = $"https://login.microsoftonline.com/{TenantId}/oauth2/v2.0/token";

            var options = new RestClientOptions(url)
            {
                Timeout = Timeout.InfiniteTimeSpan,
            };
            var client = new RestClient(options);
            var request = new RestRequest(url, Method.Post);
            request.AlwaysMultipartFormData = true;
            request.AddParameter("client_id", ClientId);
            request.AddParameter("client_secret", ClientSecret);
            request.AddParameter("scope", "https://graph.microsoft.com/.default");
            request.AddParameter("grant_type", "client_credentials");
            RestResponse response = client.Execute(request);

            // Parse the response to extract the access token
            if (response.IsSuccessful)
            {
                var jsonResponse = JObject.Parse(response.Content);
                string accessToken = jsonResponse["access_token"]?.ToString();
                return accessToken;
            }
            else
            {
                return "Error";

            }
        }

        [HttpGet]
        [Route("ListofEmployeeIdsForReport")]
        public IActionResult ListofEmployeeIdsForReport(string? query, string? roleIds, string? applicationIds, bool? isDeleted)
        {
            // Parse the comma-separated values for employeeIds, roleIds, and applicationIds

            var roleIdList = roleIds?.Split(',').Select(x => x.Trim()).ToList();
            var applicationIdList = applicationIds?.Split(',').Select(x => x.Trim()).ToList();

            // Start building the query based on the provided filters
            var result = _context.UserRoleMappings.AsQueryable();

            // Join with Roles table based on roleId and filter by applicationIdList if provided
            if (applicationIdList != null && applicationIdList.Any())
            {
                result = result.Join(_context.Roles, urm => urm.RoleId, r => r.RoleId, (urm, r) => new { urm, r })
                             .Where(x => applicationIdList.Contains(x.r.ApplicationId.ToString()))
                             .Select(x => x.urm); // Keep only UserRoleMappings from the join
            }

            // Filter by roleId if provided
            if (roleIdList != null && roleIdList.Any())
            {
                result = result.Where(urm => roleIdList.Contains(urm.RoleId.ToString()));
            }

            if (!string.IsNullOrEmpty(query))
            {
                if (query.Contains(","))
                {
                    var employeeIdList = query?.Split(',').Select(x => x.Trim()).ToList();
                    // Filter by employeeId if provided
                    if (employeeIdList != null && employeeIdList.Any())
                    {
                        result = result.Join(_context.Users, urm => urm.UserId, u => u.Id, (urm, u) => new { urm, u })
                                     .Where(x => employeeIdList.Contains(x.u.EmployeeId.ToString()))
                                     .Select(x => x.urm); // Keep only UserRoleMappings after the join
                    }

                }
                else
                {
                    // Filter by employeeId as a partial match (substring match)
                    result = result.Join(_context.Users, urm => urm.UserId, u => u.Id, (urm, u) => new { urm, u })
                                   .Where(x => x.u.EmployeeId.ToString().Contains(query)) // Contains checks for substring
                                   .Select(x => x.urm); // Keep only UserRoleMappings after the join
                }

            }


            // Filter by IsDeleted if provided
            if (isDeleted != null)
            {
                result = result.Where(urm => urm.User.IsDeleted == isDeleted);
            }

            // Execute the query and select the required fields (EmployeeId and UserId)
            var userRoleMappings = result
    .GroupBy(x => x.User.EmployeeId)
    .Select(g => new { UserId = g.First().UserId, EmployeeId = g.Key })
    .ToList();

            // Return the result
            return Ok(userRoleMappings);
        }


        [HttpGet]
        [Route("ListofEmployeesForReport")]
        public IActionResult ListofEmployeesForReport(string? query, string? roleIds, string? applicationIds, bool? isDeleted)
        {
            // Parse the comma-separated values for employeeIds, roleIds, and applicationIds

            var roleIdList = roleIds?.Split(',').Select(x => x.Trim()).ToList();
            var applicationIdList = applicationIds?.Split(',').Select(x => x.Trim()).ToList();

            // Start building the query based on the provided filters
            var result = _context.UserRoleMappings.AsQueryable();

            // Join with Roles table based on roleId and filter by applicationIdList if provided
            if (applicationIdList != null && applicationIdList.Any())
            {
                result = result.Join(_context.Roles, urm => urm.RoleId, r => r.RoleId, (urm, r) => new { urm, r })
                             .Where(x => applicationIdList.Contains(x.r.ApplicationId.ToString()))
                             .Select(x => x.urm); // Keep only UserRoleMappings from the join
            }

            // Filter by roleId if provided
            if (roleIdList != null && roleIdList.Any())
            {
                result = result.Where(urm => roleIdList.Contains(urm.RoleId.ToString()));
            }

            if (!string.IsNullOrEmpty(query))
            {
                if (query.Contains(","))
                {
                    var employeeIdList = query?.Split(',').Select(x => x.Trim()).ToList();
                    // Filter by employeeId if provided
                    if (employeeIdList != null && employeeIdList.Any())
                    {
                        result = result.Join(_context.Users, urm => urm.UserId, u => u.Id, (urm, u) => new { urm, u })
                                     .Where(x => employeeIdList.Contains(x.u.EmployeeId.ToString()))
                                     .Select(x => x.urm); // Keep only UserRoleMappings after the join
                    }

                }
                else
                {
                    // Filter by employeeId as a partial match (substring match)
                    result = result.Join(_context.Users, urm => urm.UserId, u => u.Id, (urm, u) => new { urm, u })
                                   .Where(x => x.u.EmployeeId.ToString().Contains(query)) // Contains checks for substring
                                   .Select(x => x.urm); // Keep only UserRoleMappings after the join
                }

            }


            // Filter by IsDeleted if provided
            if (isDeleted != null)
            {
                result = result.Where(urm => urm.User.IsDeleted == isDeleted);
            }

            // Join with Users to get EmployeeName, CreatedOn, DeletedOn, Status
            var finalResult = (result.Join(_context.Users, urm => urm.UserId, u => u.Id, (urm, u) => new { urm, u })
                           .Join(_context.Roles, x => x.urm.RoleId, r => r.RoleId, (x, r) => new { x.urm, x.u, r })
                           .Join(_context.Applications, x => x.r.ApplicationId, a => a.ApplicationId, (x, a) => new
                           {
                               EmployeeId = x.u.EmployeeId,
                               EmployeeName = x.u.Name,
                               x.u.CreatedDate,
                               x.u.DeletedDate,
                               UserStatus = (bool)x.u.IsDeleted ? "Deleted" : "Active",
                               ApplicationName = a.ApplicationName,
                               RoleName = x.r.Name,
                               x.u.Id
                           })).ToList();

            // Return the result
            return Ok(new
            {
                finalResult = finalResult,
                total = finalResult.Count
            });
        }


        [HttpGet]
        [Route("ListofRoles")]
        public IActionResult GetRoles()
        {
            var listRoles = _context.Roles.Join(_context.Applications, r => r.ApplicationId, a => a.ApplicationId, (r, a) => new { r.Name, r.Description, r.CreatedBy, r.CreatedDate, a.ApplicationName });
            return Ok(listRoles);
        }

        [HttpGet]
        [Route("RolesByUserEmailId")]
        public async Task<ActionResult<List<Role>>> getroles(string emailId)
        {
            var users = (from ur in _context.UserRoleMappings
                         join u in _context.Users on ur.UserId equals u.Id
                         where (u.IsActive == true && u.IsDeleted == false && u.EmailId == emailId)
                         join r in _context.Roles on ur.RoleId equals r.RoleId
                         join x in _context.Applications on r.ApplicationId equals x.ApplicationId
                         select new { RoleId = r.RoleId, Role = r.Name }).ToList();
            return Ok(users);
        }
        [HttpGet]
        [Route("UserList")]
        public IActionResult UserList()
        {
            var users = (from ur in _context.UserRoleMappings
                         join u in _context.Users on ur.UserId equals u.Id
                         where (u.IsDeleted == false && u.IsActive == true)
                         join r in _context.Roles on ur.RoleId equals r.RoleId
                         join x in _context.Applications on r.ApplicationId equals x.ApplicationId
                         select new { u.Id, UserName = u.Name, EmailId = u.EmailId, EmployeeId = u.EmployeeId, Status = u.IsActive, CreatedBy = u.CreatedBy, CreatedDate = u.CreatedDate, ModifiedDate = u.ModifiedDate, Department = u.Department, Role = new { r.Name, x.ApplicationName } })
                        .GroupBy(x => x.Id, (key, g) => new { ID = key, UserName = g.First().UserName, EmailId = g.First().EmailId, EmployeeId = g.First().EmployeeId, Status = g.First().Status, Createdby = g.First().CreatedBy, CreatedDate = g.First().CreatedDate, ModifiedDate = g.First().ModifiedDate, Department = g.First().Department, Roles = g.Select(x => x.Role).ToList() }).OrderByDescending(x => x.ModifiedDate);
            return Ok(users);
        }


        [HttpGet]
        [Route("Application")]
        public IActionResult Application()
        {
            var applications = _context.Applications.ToList();
            return Ok(applications);
        }
        [HttpGet]
        [Route("RolesByApplication")]
        public IActionResult RolesByApplication(int applicationId)
        {
            var roles = _context.Roles.Where(r => r.ApplicationId == applicationId).Select(r => new { r.RoleId, r.Name }).ToList();
            return Ok(roles);
        }
        [HttpPost]
        [Route("AddUser")]
        public IActionResult AddUser([FromBody] CommonData user)
        {
            var IsuserExit = _context.Users.Where(x => x.IsDeleted == false && x.EmailId == user.EmailId && x.IsActive == true).FirstOrDefault();
            if (IsuserExit is not null)
            {
                return Ok("User alreday exist.");
            }
            var userdata = new User();
            userdata.EmployeeId = user.EmployeeId;
            userdata.Name = user.Name;
            userdata.EmailId = user.EmailId;
            userdata.IsActive = true;
            userdata.CreatedBy = user.CreatedBy;
            userdata.CreatedDate = DateTime.UtcNow;
            userdata.ModifiedDate = DateTime.UtcNow;
            userdata.IsDeleted = false;
            userdata.Department = user.Department;
            _context.Users.AddAsync(userdata);
            _context.SaveChanges();
            foreach (var item in user.RoleIds)
            {
                _context.UserRoleMappings.Add(new UserRoleMapping() { UserId = userdata.Id, RoleId = item, CreatedBy = user.CreatedBy, CreatedDate = DateTime.UtcNow });
            }
            _context.SaveChanges();

            return Ok(user);
        }
        [HttpGet]
        [Route("getUserByUserId")]
        public IActionResult getUserByUserId(int UserId)
        {
            var users = (from ur in _context.UserRoleMappings
                         join u in _context.Users on ur.UserId equals u.Id
                         where (u.IsActive == true && u.IsDeleted == false && u.Id == UserId)
                         join r in _context.Roles on ur.RoleId equals r.RoleId
                         join x in _context.Applications on r.ApplicationId equals x.ApplicationId
                         select new { u.Id, UserName = u.Name, EmailId = u.EmailId, EmployeeId = u.EmployeeId, CreatedBy = u.CreatedBy, CreatedDate = u.CreatedDate, Department = u.Department, Role = new { r.RoleId, r.Name, x.ApplicationId, x.ApplicationName } })
                         .GroupBy(x => x.Id, (key, g) => new { ID = key, UserName = g.First().UserName, EmailId = g.First().EmailId, EmployeeId = g.First().EmployeeId, Createdby = g.First().CreatedBy, CreatedDate = g.First().CreatedDate, Department = g.First().Department, Roles = g.Select(x => x.Role).ToList() });
            return Ok(users);
        }
        [HttpPut]
        [Route("UpdateUserRole")]
        public void UpdateUserRole([FromBody] CommonData user)
        {
            List<int> ints = new List<int>();
            if (user.RemovedRoleIds != null && user.RemovedRoleIds.Count > 0)
            {
                foreach (var item in user.RemovedRoleIds)
                {
                    foreach (var id in user.RoleIds)
                    {
                        if (item == id)
                        {
                            ints.Add(item);
                        }
                    }
                }
            }
            if (ints != null && ints.Count > 0)
            {
                foreach (var i in ints)
                {
                    user.RemovedRoleIds.Remove(i);
                }
            }
            if (user.RemovedRoleIds != null && user.RemovedRoleIds.Count > 0)
            {
                foreach (var item in user.RemovedRoleIds)
                {
                    var userrole = _context.UserRoleMappings.FirstOrDefault(u => u.RoleId == item && u.UserId == user.Id);
                    var userroledata = _context.UserRoleMappings.Where(u => u.RoleId == item && u.UserId == user.Id).Select(x => new { CreatedBy = x.CreatedBy, CreatedDate = x.CreatedDate }).FirstOrDefault();
                    if (userrole != null)
                    {
                        _context.UserRoleMappings.Remove(userrole);
                        _context.SaveChanges();
                        _context.Rolehistories.Add(new Rolehistory
                        {
                            RoleId = item,
                            UserId = user.Id,
                            DeletedBy = user.CreatedBy,
                            DeletedDate = DateTime.UtcNow,
                            CreatedBy = userroledata.CreatedBy,
                            CreatedDate = userroledata.CreatedDate,
                        });
                        _context.SaveChanges();
                    }
                }
            }
            if (user.RoleIds != null && user.RoleIds.Count > 0)
            {
                var userdata = _context.UserRoleMappings.Where(u => u.UserId == user.Id).ToList();
                //if (userdata != null && userdata.Count > 0)
                //{
                foreach (var item in userdata)
                {
                    _context.UserRoleMappings.Remove(item);
                    _context.SaveChanges();
                }
                foreach (var item in user.RoleIds)
                {
                    _context.UserRoleMappings.Add(new UserRoleMapping
                    {
                        UserId = user.Id,
                        RoleId = item,
                        CreatedBy = user.CreatedBy,
                        CreatedDate = DateTime.UtcNow
                    });
                    _context.SaveChanges();
                }
                var usrrole = (from x in _context.Users
                               where x.Id == user.Id
                               select x).First();
                usrrole.ModifiedDate = DateTime.UtcNow;
                usrrole.ModifiedBy = user.CreatedBy;
                _context.SaveChanges(); 
            }
        }
        [HttpPut]
        [Route("RemoveUser")]
        public IActionResult RemoveUser(int id, bool IsActive)
        {
            var user = new User();
            user = (from x in _context.Users
                    where x.Id == id
                    select x).First();
            user.IsActive = IsActive;
            user.ModifiedDate = DateTime.UtcNow;
            _context.SaveChanges();
            return Ok();
        }
        [HttpPut("Delete")]
        public IActionResult Delete(int id, string deletedby)
        {
            var data = _context.Users.First(x => x.Id == id);
            data.IsDeleted = true;
            data.DeletedDate = DateTime.UtcNow;
            data.DeletedBy = deletedby;
            _context.SaveChanges();
            return Ok();
        }
        [HttpGet]
        [Route("GetDetailsByEmailId")]
        public IActionResult GetDetailsByEmailId(string EmailId)
        {             
            var users = (from ur in _context.UserRoleMappings
                         join u in _context.Users on ur.UserId equals u.Id
                         where (u.IsActive == true && u.IsDeleted == false && u.EmailId == EmailId)
                         join r in _context.Roles on ur.RoleId equals r.RoleId
                         join x in _context.Applications on r.ApplicationId equals x.ApplicationId
                         select new { u.Id, UserName = u.Name, EmailId = u.EmailId, EmployeeId = u.EmployeeId, CreatedBy = u.CreatedBy, CreatedDate = u.CreatedDate, Department = u.Department, Role = new { r.RoleId, r.Name, x.ApplicationId, x.ApplicationName } })
                     .GroupBy(x => x.Id, (key, g) => new { ID = key, UserName = g.First().UserName, EmailId = g.First().EmailId, EmployeeId = g.First().EmployeeId, Createdby = g.First().CreatedBy, CreatedDate = g.First().CreatedDate, Department = g.First().Department, Roles = g.Select(x => x.Role).ToList() });
            _context.LoginActivities.Add(new LoginActivity
            {
                EmailId = EmailId,
                LoginDateTime = DateTime.UtcNow,
            });
            _context.SaveChanges();
            return Ok(users);
        }
        [HttpPost]
        public IActionResult InsertLoginActivity(login commonData)
        {
            var loginactivity = _context.LoginActivities.Add(new LoginActivity()
            {
                EmailId = commonData.EmailId,
                LoginDateTime = DateTime.UtcNow,
                ApplicationName = commonData.ApplicationName,
            });
            _context.SaveChanges();
            return Ok(loginactivity);
        }
        [HttpGet]
        [Route("GetEmailIdbyRole")]
        public IActionResult GetEmailId(string role)
        {
            var data = (from ur in _context.UserRoleMappings
                        join u in _context.Users on ur.UserId equals u.Id
                        where (u.IsActive == true && u.IsDeleted == false)
                        join r in _context.Roles on ur.RoleId equals r.RoleId
                        where (r.Name == role)
                        select new { id = u.Id, UserEmailId = u.EmailId })
                            .GroupBy(x => x.id, (key, g) => new
                            {
                                Userid = key,
                                UserEmailId = g.First().UserEmailId
                            }).ToList();
            return Ok(data);
        }
        [HttpGet]
        [Route("FilterUserManagement")]
        public IActionResult FilterUserManagement(int? EmployeeId, string? Name, string? EmailId, int? RoleId, string? CreatedBy, DateTime? CreatedDate, bool? Status, string? department)
        {
            var data = (from ur in _context.UserRoleMappings
                        join u in _context.Users on ur.UserId equals u.Id
                        join r in _context.Roles on ur.RoleId equals r.RoleId
                        join x in _context.Applications on r.ApplicationId equals x.ApplicationId
                        select new { u.Id, UserName = u.Name, EmailId = u.EmailId, EmployeeId = u.EmployeeId, Status = u.IsActive, CreatedBy = u.CreatedBy, CreatedDate = u.CreatedDate, Department = u.Department, Role = new { r.Name, r.RoleId, x.ApplicationName } })
                       .GroupBy(x => x.Id, (key, g) => new
                       {
                           ID = key,
                           UserName = g.First().UserName,
                           EmailId = g.First().EmailId,
                           EmployeeId = g.First().EmployeeId,
                           Status = g.First().Status,
                           Createdby = g.First().CreatedBy,
                           CreatedDate = g.First().CreatedDate.ToString(),
                           Department = g.First().Department,
                           Roles = g.Select(x => x.Role).ToList()
                       }).ToList();
            if (EmployeeId != null)
            {
                data = data.Where(x => x.EmployeeId == EmployeeId).ToList();
            }
            if (Name != null)
            {
                data = data.Where(x => x.UserName.ToLower().Contains(Name)).ToList();
            }
            if (EmailId != null)
            {
                data = data.Where(x => x.EmailId.ToLower().Contains(EmailId)).ToList();
            }
            if (CreatedBy != null)
            {
                data = data.Where(x => x.Createdby.ToLower().Contains(CreatedBy)).ToList();
            }
            if (RoleId != null)
            {
                var tempdata = data;
                foreach (var x in tempdata.ToList())
                {
                    var foundItem = x.Roles.SingleOrDefault(item => item.RoleId == RoleId);
                    if (foundItem == null)
                    {
                        int index = data.FindIndex(y => y.ID == x.ID);
                        data.RemoveAt(index);
                    }

                }
            }
            if (CreatedDate != null)
            {
                data = data.Where(x => x.CreatedDate.Contains(CreatedDate.Value.ToString("yyyy-MM-dd"))).ToList();
            }
            if (Status != null)
            {
                data = data.Where(x => x.Status == Status).ToList();
            }
            if (department is not null)
            {
                data = data.Where(x => x.Department.ToLower().Contains(department)).ToList();
            }
            return Ok(data);
        }
        [HttpGet]
        [Route("SearchUserByEmployeeId")]
        public IActionResult SearchUserByEmployeeId(string query)
        {
            var employeeIDs = _context.Users
                            .Where(u => u.EmployeeId.ToString().Contains(query) && u.IsActive == true && u.IsDeleted == false)
                            .Select(u => u.EmployeeId).Distinct().ToList();
            return Ok(employeeIDs);
        }
        [HttpGet]
        [Route("SearchUserByEmail")]
        public IActionResult SearchUserByEmail(string query)
        {
            var emails = _context.Users
                        .Where(u => u.EmailId.Contains(query) && u.IsActive == true && u.IsDeleted == false)
                        .Select(u => u.EmailId).Distinct().ToList();
            return Ok(emails);
        }
        [HttpGet]
        [Route("SearchUserByName")]
        public IActionResult SearchUserByName(string query)
        {
            var names = _context.Users
                        .Where(u => u.Name.Contains(query) && u.IsActive == true && u.IsDeleted == false)
                        .Select(u => u.Name).Distinct().ToList();
            return Ok(names);
        }

        [HttpGet]
        [Route("SearchRoles")]
        public IActionResult SearchRoles(string query)
        {
            var names = _context.Roles
                        .Where(u => u.Name.Contains(query))
                        .Select(u => u.Name).Distinct().ToList();
            return Ok(names);
        }

        [HttpGet]
        [Route("SearchCreatedBy")]
        public IActionResult SearchCreatedBy(string query)
        {
            var names = _context.Users
                        .Where(u => u.CreatedBy.Contains(query) && u.IsActive == true && u.IsDeleted == false)
                        .Select(u => u.CreatedBy).Distinct().ToList();
            return Ok(names);
        }

        [HttpGet]
        [Route("GetISCGStaff")]
        public IActionResult GetISCGStaff(string? shariastaff)
        {
            var data = (from ur in _context.UserRoleMappings
                        join u in _context.Users on ur.UserId equals u.Id
                        where (u.IsActive == true && u.IsDeleted == false)
                        join r in _context.Roles on ur.RoleId equals r.RoleId
                        where (r.Name == "ISCG Staff - Helpdesk")
                        select new { ID = u.Id, Name = u.Name, EmailID = u.EmailId });
            if (shariastaff != null)
            {
                data = data.Where(x => x.Name.Contains(shariastaff));
            }
            return Ok(data);
        }
        [HttpGet]
        [Route("Getshariastaffandmaager")]
        public IActionResult Getshariastaffandmaager(string? shariastaff)
        {
            var data = (from ur in _context.UserRoleMappings
                        join u in _context.Users on ur.UserId equals u.Id
                        where (u.IsActive == true && u.IsDeleted == false)
                        join r in _context.Roles on ur.RoleId equals r.RoleId
                        //where (r.Name == "ISCG Staff" || r.Name == "Helpdesk Manager")
                        where (r.Name == "ISCG Staff-ShariaResearch" || r.Name == "Helpdesk Manager-Sharia Research")
                        select new { ID = u.Id, Name = u.Name, EmailID = u.EmailId });
            if (shariastaff != null)
            {
                data = data.Where(x => x.Name.Contains(shariastaff));
            }
            return Ok(data);
        }
        [HttpGet]
        [Route("GetDepartment")]
        public IActionResult GetDepartment(string? department)
        {
            var data = _context.Users.Where(x => x.IsActive == true && x.IsDeleted == false).Select(x => new { Department = x.Department }).Distinct();
            if (department != null)
            {
                data = data.Where(x => x.Department.Contains(department));
            }
            return Ok(data);
        }
        [HttpGet("CheckUserEmployeeId")]
        public IActionResult CheckUserEmployeeId(int employeeId)
        {
            var data = _context.Users.Where(x => x.EmployeeId == employeeId && x.IsDeleted == false).ToList();
            if (data != null && data.Count > 0)
            {
                return Ok("User exist");
            }
            else
            {
                return Ok("User does not exist");
            }
        }
        [HttpGet]
        [Route("GetApplication")]
        public IActionResult GetApplication()
        {
            var apps = _context.ApplicationModules.ToList();
            return Ok(apps);
        }
        [HttpGet("DepartmentList")]
        public IActionResult DepartmentList()
        {
            var data = _context.Users.Select(x => new { Department = x.Department }).Distinct().ToList();
            return Ok(data);
        }
        #region  Api created for Documentation Purpose
        [Authorize]
        [HttpPost("CreateUser")]
        public IActionResult CreateUser([FromBody] IDEMTestingModel user)
        {
            if (Request.HttpContext.User.Identity.IsAuthenticated)
            {
                if ((!string.IsNullOrEmpty(user.Name)) && (!string.IsNullOrEmpty(user.EmailId)) && (!string.IsNullOrEmpty(user.Department)) && (!string.IsNullOrEmpty(user.CreatedBy)) && (user.EmployeeId > 0))
                {
                    var IsExist = _context.Users.Where(x => x.EmailId == user.EmailId && x.IsDeleted == false && x.EmployeeId == user.EmployeeId).FirstOrDefault();
                    if (IsExist == null)
                    {

                        var userdata = new User();
                        userdata.EmployeeId = user.EmployeeId;
                        userdata.Name = user.Name;
                        userdata.EmailId = user.EmailId;
                        userdata.CreatedBy = user.CreatedBy;
                        userdata.IsActive = true;
                        userdata.IsDeleted = false;
                        userdata.CreatedDate = DateTime.UtcNow;
                        userdata.ModifiedDate = DateTime.UtcNow;
                        userdata.Department = user.Department;
                        _context.Users.Add(userdata);
                        _context.SaveChanges();
                        if (userdata.Id == 0)
                        {
                            return StatusCode(200, new
                            {
                                Message = "Data not Submitted"
                            });
                        }
                        return StatusCode(200, new
                        {
                            Message = "Data submitted successfully"
                        });
                    }
                    else
                    {
                        return StatusCode(200, new
                        {
                            Message = "User already exist"
                        });
                    }
                }
                else
                {
                    return StatusCode(400, new
                    {
                        Message = "All fields are mandatory."
                    });
                }
            }
            else
            {
                return Unauthorized("Unauthorized access");
            }
        }
        [Authorize]
        [HttpGet("GetUsers")]
        public IActionResult GetUser()
        {
            if (Request.HttpContext.User.Identity.IsAuthenticated)
            {
                var users = (from u in _context.Users
                             join ur in _context.UserRoleMappings on u.Id equals ur.UserId into urgroup
                             from ur in urgroup.DefaultIfEmpty()
                             where (u.IsDeleted == false)
                             join r in _context.Roles on ur.RoleId equals r.RoleId into rgroup
                             from r in rgroup.DefaultIfEmpty()
                             select new { u.Id, UserName = u.Name, EmailId = u.EmailId, EmployeeId = u.EmployeeId, Status = u.IsActive, CreatedBy = u.CreatedBy, CreatedDate = u.CreatedDate, ModifiedDate = u.ModifiedDate, Role = new { Role = r.Name } })
                      .GroupBy(x => x.Id, (key, g) => new
                      {
                          ID = key,
                          UserName = g.First().UserName,
                          EmailId = g.First().EmailId,
                          EmployeeId = g.First().EmployeeId,
                          Status = g.First().Status,
                          Createdby = g.First().CreatedBy,
                          CreatedDate = g.First().CreatedDate,
                          ModifiedDate = g.First().ModifiedDate,
                          Roles = g.Select(x => x.Role).ToList()
                      }).OrderByDescending(x => x.CreatedDate);
                return Ok(users);
            }
            else
            {
                return Unauthorized("Unauthorized access");
            }
        }
        [Authorize]
        [HttpGet("GetUserByID")]
        public IActionResult GetUserByID(int UserId)
        {
            if (Request.HttpContext.User.Identity.IsAuthenticated)
            {
                var users = (from ur in _context.UserRoleMappings.Where(x => x.UserId == UserId)
                             join u in _context.Users on ur.UserId equals u.Id
                             where (u.IsDeleted == false)
                             join r in _context.Roles on ur.RoleId equals r.RoleId
                             select new { u.Id, UserName = u.Name, EmailId = u.EmailId, EmployeeId = u.EmployeeId, CreatedBy = u.CreatedBy, CreatedDate = u.CreatedDate, Role = new { Role = r.Name, } })
                             .GroupBy(x => x.Id, (key, g) => new { ID = key, UserName = g.First().UserName, EmailId = g.First().EmailId, EmployeeId = g.First().EmployeeId, Createdby = g.First().CreatedBy, CreatedDate = g.First().CreatedDate, Roles = g.Select(x => x.Role).ToList() });
                return Ok(users);
            }
            else
            {
                return Unauthorized("Unauthorized access");
            }
        }
        [Authorize]
        [HttpPut("updateuser")]
        public IActionResult UpdateUser(int id, [FromBody] IDEMTestingModel common)
        {
            if (Request.HttpContext.User.Identity.IsAuthenticated)
            {
                if (common.EmployeeId > 0 && (!string.IsNullOrEmpty(common.Name)) && (!string.IsNullOrEmpty(common.EmailId) && (!string.IsNullOrEmpty(common.ModifiedBy))) && (!string.IsNullOrEmpty(common.Department)))
                {
                    var userdata = _context.Users.First(x => x.Id == id);
                    userdata.EmployeeId = common.EmployeeId;
                    userdata.Name = common.Name;
                    userdata.EmailId = common.EmailId;
                    userdata.ModifiedDate = DateTime.UtcNow;
                    userdata.ModifiedBy = common.ModifiedBy;
                    userdata.Department = common.Department;
                    _context.SaveChanges();
                    return StatusCode(200, new
                    {
                        Message = "Successfully submitted"
                    });
                }
                else
                {
                    return StatusCode(400, new
                    {
                        Message = "All fields are mandatory."
                    });
                }
            }
            else
            {
                return Unauthorized("Unauthorized access");
            }
        }
        [Authorize]
        [HttpPost("AssignRole")]
        public IActionResult AssignRole([FromBody] AssignRole assignRole)
        {
            if (Request.HttpContext.User.Identity.IsAuthenticated)
            {
                if (assignRole.UserId > 0 && (assignRole.RoleId.Count > 0 && (!string.IsNullOrEmpty(assignRole.createdby))))
                {
                    var userrolemapping = new UserRoleMapping();
                    foreach (var item in assignRole.RoleId)
                    {
                        var data = _context.UserRoleMappings.FirstOrDefault(x => x.UserId == assignRole.UserId && x.RoleId == item);
                        if (data is not null)
                        {
                            return StatusCode(200, new
                            {
                                Message = "Role has been already assigned to user"
                            });
                        }
                        userrolemapping.UserId = assignRole.UserId;
                        userrolemapping.RoleId = item;
                        userrolemapping.CreatedDate = DateTime.UtcNow;
                        userrolemapping.CreatedBy = assignRole.createdby;
                    }
                    _context.UserRoleMappings.Add(userrolemapping);
                    _context.SaveChanges();
                    return StatusCode(200, new
                    {
                        Message = "User role assigned successfully."
                    });
                }
                else
                {
                    return StatusCode(400, new
                    {
                        Message = "All fields are mandatory."
                    });
                }
            }
            else
            {
                return Unauthorized("Unauthorized access");
            }
        }
        [Authorize]
        [HttpPut("unassignRole")]
        public IActionResult unassignRole(AssignRole assignRole, int userid)
        {
            if (Request.HttpContext.User.Identity.IsAuthenticated)
            {
                if (assignRole.RoleId.Count > 0 && (!string.IsNullOrEmpty(assignRole.deletedby)))
                {
                    var rolehistory = new Rolehistory();
                    var data = _context.UserRoleMappings.FirstOrDefault(x => x.UserId == userid);
                    if (data == null)
                    {
                        return NoContent();
                    }
                    else
                    {
                        foreach (var item in assignRole.RoleId)
                        {
                            var removedata = _context.UserRoleMappings.First(x => x.RoleId == item && x.UserId == userid);
                            if (removedata == null)
                            {
                                return StatusCode(200, new
                                {
                                    Message = "This role is not assigned to User"
                                });
                            }
                            _context.UserRoleMappings.Remove(removedata);
                            _context.SaveChanges();
                            _context.Rolehistories.Add(new Rolehistory
                            {
                                UserId = assignRole.UserId,
                                RoleId = item,
                                DeletedBy = assignRole.deletedby,
                                DeletedDate = DateTime.UtcNow
                            });
                            _context.SaveChanges();
                        }
                    }
                    return StatusCode(200, new
                    {
                        Message = "User role unassigned successfully."
                    });
                }
                else
                {
                    return StatusCode(400, new
                    {
                        Message = "All fields are mandatory."
                    });
                }
            }
            else
            {
                return Unauthorized("Unauthorized access");
            }
        }
        [Authorize]
        [HttpPut("deleteuser")]
        public IActionResult DeleteUser(int id, string deletedby)
        {
            if (Request.HttpContext.User.Identity.IsAuthenticated)
            {
                var data = _context.Users.First(x => x.Id == id);
                data.IsDeleted = true;
                data.DeletedDate = DateTime.UtcNow;
                data.DeletedBy = deletedby;
                _context.SaveChanges();
                return StatusCode(200, new
                {
                    Message = "User successfully deleted"
                });
            }
            else
            {
                return Unauthorized("Unauthorized access");
            }
        }
        [Authorize]
        [HttpGet("GetRoles")]
        public IActionResult GetUserRoles()
        {
            if (Request.HttpContext.User.Identity.IsAuthenticated)
            {
                var data = _context.Roles.Select(x => new
                {
                    RoleId = x.RoleId,
                    RoleName = x.Name
                }).ToList();
                if (data.Count == 0)
                {
                    return StatusCode(200, new
                    {
                        Message = "No record found"
                    });
                }
                return Ok(data);
            }
            else
            {
                return Unauthorized("Unauthorized access");
            }
        }
        [Authorize]
        [HttpPut]
        [Route("AssignedOrUnassignedUser")]
        public IActionResult AssignedOrUnassignedUser(int id, bool IsActive)
        {
            if (Request.HttpContext.User.Identity.IsAuthenticated)
            {
                var user = new User();
                user = (from x in _context.Users
                        where x.Id == id
                        select x).First();
                user.IsActive = IsActive;
                user.ModifiedDate = DateTime.UtcNow;
                _context.SaveChanges();
                return StatusCode(200, new
                {
                    Message = "User status updated successfully"
                });
            }
            else
            {
                return Unauthorized("Unauthorized access");
            }
        }
        #endregion
    }

}
