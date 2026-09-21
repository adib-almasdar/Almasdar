using CommonLib.Data;
using eLibrary.Models;
using eLibrary.Services;
using eLibrary.Services.Interface;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace eLibrary.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly ICategoriesService _categoriesService;

        public CategoriesController(ApplicationDbContext context, ICategoriesService categoriesService)
        {
            _context = context;
            _categoriesService = categoriesService;
        }
        // GET: api/<CategoriesController>
        [HttpGet]
        public IActionResult Get()
        {
            var Categories = (from x in _context.ElMCategories
                              where x.IsDeleted != true
                              select x).ToList();
            return Ok(Categories);
        }

        // GET api/<CategoriesController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var CategoriesById = _context.ElMCategories.Where(x => x.Id == id).FirstOrDefault();
            return Ok(CategoriesById);
        }

        // POST api/<CategoriesController>
        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Post([FromForm] IFormFile file, [FromForm] CategoryModel categoryModel, string email)
        {
            string blobUrl = String.Empty;
            if (HttpContext.Request.HasFormContentType)
            {
                var data = await HttpContext.Request.ReadFormAsync();
                blobUrl = await _categoriesService.StartDocumentUploadProcess(data, categoryModel);

            }

            _context.ElMCategories.Add(new ElMCategory()
            {
                Title = categoryModel.Title,
                ArabicTitle = categoryModel.ArabicTitle,
                CreatedBy = categoryModel.CreatedBy,
                CreatedDate = DateTime.UtcNow,
                ThumbnailUrl = blobUrl,
                LastModifiedBy = email,
                LastModifiedDate = DateTime.UtcNow,
                IsDeleted = false
            });
            _context.SaveChanges();
            categoryModel.ThumbnailUrl = blobUrl;
            return Ok(categoryModel);
        }

        // PUT api/<CategoriesController>/5
        [HttpPut("{id}")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Put([FromForm] CategoryModel categoryModel, int id, string email)
        {
            string blobUrl = String.Empty;
            var elMCategory = new ElMCategory();

            if (HttpContext.Request.HasFormContentType)
            {
                var data = await HttpContext.Request.ReadFormAsync();
                elMCategory = (from x in _context.ElMCategories
                               where x.Id == id
                               select x).First();

                if (categoryModel.Title == null)
                {
                    categoryModel.Title = elMCategory.Title;
                }

                blobUrl = await _categoriesService.StartDocumentUploadProcess(data, categoryModel);
            }

            elMCategory.Title = categoryModel.Title == null ? elMCategory.Title : categoryModel.Title;
            elMCategory.ArabicTitle = categoryModel.ArabicTitle == null ? elMCategory.ArabicTitle : categoryModel.ArabicTitle;
            elMCategory.ThumbnailUrl = blobUrl == String.Empty ? elMCategory.ThumbnailUrl : blobUrl;
            elMCategory.LastModifiedBy = email;
            elMCategory.LastModifiedDate = DateTime.UtcNow;
            _context.SaveChanges();
            return Ok();
        }

        //DELETE api/<CategoriesController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, string email)
        {
            //Check if any Books exist with the mentioned Category
            int total = _context.ElTBooks.Count(b => b.Category == id && b.IsDeleted!=true);
            if (total == 0)
            {

                //Soft Delete Category from DB
                var elMCategory = new ElMCategory();
                elMCategory = (from x in _context.ElMCategories
                               where x.Id == id
                               select x).First();
                elMCategory.IsDeleted = true;
                elMCategory.LastModifiedBy = email;
                elMCategory.LastModifiedDate = DateTime.UtcNow;
                elMCategory.DeletedBy = email;
                elMCategory.DeletedOn = DateTime.UtcNow;
                _context.SaveChanges();
                return Ok();
            }
            else
            {
                return StatusCode(403, "Books existing with mentioned Category.");
            }
        }
    }
}
