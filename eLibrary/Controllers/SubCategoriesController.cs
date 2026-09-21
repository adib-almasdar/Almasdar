using CommonLib.Data;
using eLibrary.Models;
using eLibrary.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace eLibrary.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubCategoriesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly ISubCategoriesService _subCategoriesService;

        public SubCategoriesController(ApplicationDbContext context, ISubCategoriesService subCategoriesService)
        {
            _context = context;
            _subCategoriesService = subCategoriesService;
        }
        // GET: api/<SubCategoriesController>
        [HttpGet]
        public IActionResult Get()
        {
            //var subCategoriess = (from x in _context.ElMSubCategories
            //                     where x.IsDeleted != true
            //                     select x).ToList();

            var subCategories = (from subcat in _context.ElMSubCategories
                                 where subcat.IsDeleted != true
                                 join cat in _context.ElMCategories
                                 on subcat.CategoryId equals cat.Id
                                 select new
                                 {
                                     subcat.Id,
                                     subcat.Title,
                                     subcat.CreatedDate,
                                     subcat.CreatedBy,
                                     subcat.ThumbnailUrl,
                                     subcat.CategoryId,
                                     subcat.IsDeleted,
                                     subcat.LastModifiedBy,
                                     subcat.LastModifiedDate,
                                     CategoryName = cat.Title
                                 }).ToList();


            return Ok(subCategories);
        }
        // GET api/<SubCategoriesController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            //var subCategoriesById = _context.ElMSubCategories.Where(x => x.Id == id).FirstOrDefault();

            var subCategoriesById = (from subcat in _context.ElMSubCategories
                                   where subcat.Id == id
                                   join cat in _context.ElMCategories
                                   on subcat.CategoryId equals cat.Id
                                   select new
                                   {
                                       subcat.Id,
                                       subcat.Title,
                                       subcat.CreatedDate,
                                       subcat.CreatedBy,
                                       subcat.ThumbnailUrl,
                                       subcat.CategoryId,
                                       subcat.IsDeleted,
                                       subcat.LastModifiedBy,
                                       subcat.LastModifiedDate,
                                       CategoryName = cat.Title
                                   }).FirstOrDefault();

            return Ok(subCategoriesById);
        }

        [HttpGet]
        [Route("GetbyCategoryId")]

        public IActionResult GetbyCategoryId(int CategoryId)
        {
            var subCategoriesById = _context.ElMSubCategories.Where(x => x.CategoryId == CategoryId);
            return Ok(subCategoriesById);

        }


        // POST api/<SubCategoriesController>
        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Post([FromForm] IFormFile file, [FromForm] SubCategoryModel subcategoryModel, string email)
        {
            string blobUrl = String.Empty;
            if (HttpContext.Request.HasFormContentType)
            {
                var data = await HttpContext.Request.ReadFormAsync();
                blobUrl = await _subCategoriesService.StartDocumentUploadProcess(data, subcategoryModel);

            }

            _context.ElMSubCategories.Add(new ElMSubCategory()
            {
                Title = subcategoryModel.Title,
                CreatedBy = subcategoryModel.CreatedBy,
                CreatedDate = DateTime.UtcNow,
                ThumbnailUrl = blobUrl,
                CategoryId = subcategoryModel.CategoryId,
                LastModifiedBy = email,
                LastModifiedDate = DateTime.UtcNow,
                IsDeleted = false
            });
            _context.SaveChanges();
            subcategoryModel.ThumbnailUrl = blobUrl;

            return Ok(subcategoryModel);
        }
        // PUT api/<SubCategoriesController>/5
        [HttpPut("{id}")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Put([FromForm] SubCategoryModel subcategoryModel, int id, string email)
        {
            string blobUrl = String.Empty;
            var elMSubCategory = new ElMSubCategory();

            if (HttpContext.Request.HasFormContentType)
            {
                var data = await HttpContext.Request.ReadFormAsync();
                elMSubCategory = (from x in _context.ElMSubCategories
                                  where x.Id == id
                                  select x).First();

                if (subcategoryModel.Title == null)
                {
                    subcategoryModel.Title = elMSubCategory.Title;
                }

                blobUrl = await _subCategoriesService.StartDocumentUploadProcess(data, subcategoryModel);

            }

            elMSubCategory.Title = subcategoryModel.Title == null ? elMSubCategory.Title : subcategoryModel.Title;
            elMSubCategory.ThumbnailUrl = blobUrl == String.Empty ? elMSubCategory.ThumbnailUrl : blobUrl;
            elMSubCategory.LastModifiedBy = email;
            elMSubCategory.LastModifiedDate = DateTime.UtcNow;

            _context.SaveChanges();
            return Ok();
        }

        // DELETE api/<SubCategoriesController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, string email)
        {
            //Check if any Books exist with the mentioned SubCategory
            int total = _context.ElTBooks.Count(b => b.SubCategory == id && b.IsDeleted != true);
            if (total == 0)
            {
                //Soft Delete SubCategory from DB
                var elMSubCategory = new ElMSubCategory();
                elMSubCategory = (from x in _context.ElMSubCategories
                                  where x.Id == id
                                  select x).First();
                elMSubCategory.IsDeleted = true;
                elMSubCategory.LastModifiedBy = email;
                elMSubCategory.LastModifiedDate = DateTime.UtcNow;
                elMSubCategory.DeletedBy = email;
                elMSubCategory.DeletedOn = DateTime.UtcNow;
                _context.SaveChanges();
                return Ok();
            }
            else
            {
                return StatusCode(403, "Books existing with mentioned SubCategory.");
            }
        }
    }
}
