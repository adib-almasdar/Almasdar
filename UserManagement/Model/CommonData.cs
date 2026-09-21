using CommonLib.Data;
using System.Numerics;

namespace UserManagement.Model
{
    public class CommonData
    {
        public int? Id { get; set; }
        public int? EmployeeId { get; set; }
        public string? Name { get; set; }
        public List<int>? RoleIds { get; set; }
        public List<int>? RemovedRoleIds { get; set; }
        public int? ApplicationId { get; set; }
        public string? EmailId { get; set; }
        public string? CreatedBy { get; set; }
        public string? ModifiedBy { get; set; }
        public string? Department { get; set; }
    }
    public class login
    {
        public string? ApplicationName { get; set; }
        public string? EmailId { get; set; }
    }
    public class Filterdata
    {
        public int? ID { get; set; }
        public int? EmployeeId { get; set; }
        public string? Name { get; set; }
        public string? EmailId { get; set; }
        public int? Role { get; set; }
        public string? Createdby { get; set; }
        public bool? Status { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
    public class AssignRole
    {
        public int? UserId { get; set; }
        public List<int>? RoleId { get; set; }
        public string? createdby { get; set; }
        public string? deletedby { get; set; }
    }
    public class IDEMTestingModel
    {
        public int? EmployeeId { get; set; }
        public string? Name { get; set; }
        public string? EmailId { get; set; }
        public string? CreatedBy { get; set; }
        public string? ModifiedBy { get; set; }
        public string? Department { get; set; }
    }
}
