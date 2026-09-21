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
    public class LanguagesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly ILanguagesService _languagesService;

        public LanguagesController(ApplicationDbContext context, ILanguagesService languagesService)
        {
            _context = context;
            _languagesService = languagesService;
        }
        // GET: api/<LanguagesController>
        [HttpGet]
        public IActionResult Get()
        {
            var elMLanguages = (from x in _context.ElMLanguages
                                where x.IsDeleted != true
                                select x).ToList();
            return Ok(elMLanguages);

        }
        // GET api/<LanguagesController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var elMLanguagebyId = _context.ElMLanguages.Where(x => x.Id == id).FirstOrDefault();
            return Ok(elMLanguagebyId);
        }
        // POST api/<LanguagesController>
        [HttpPost]
        public async Task<IActionResult> Post([FromForm] IFormFile file, [FromForm] LanguageModel languageModel, string email)
        {
            string blobUrl = String.Empty;
            if (HttpContext.Request.HasFormContentType)
            {
                var data = await HttpContext.Request.ReadFormAsync();
                blobUrl = await _languagesService.StartDocumentUploadProcess(data, languageModel);

            }

            _context.ElMLanguages.Add(new ElMLanguage()
            {
                Title = languageModel.Title,
                CreatedBy = languageModel.CreatedBy,
                CreatedDate = DateTime.UtcNow,
                ThumbnailUrl = blobUrl,
                LastModifiedBy = email,
                LastModifiedDate = DateTime.UtcNow,
                IsDeleted = false
            });
            _context.SaveChanges();
            languageModel.ThumbnailUrl = blobUrl;
            return Ok(languageModel);
        }
        // PUT api/<LanguagesController>/5
        [HttpPut("{id}")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Put([FromForm] LanguageModel languageModel, int id, string email)
        {
            string blobUrl = String.Empty;
            var elMLanguage = new ElMLanguage();

            if (HttpContext.Request.HasFormContentType)
            {
                var data = await HttpContext.Request.ReadFormAsync();
                elMLanguage = (from x in _context.ElMLanguages
                               where x.Id == id
                               select x).First();

                if (languageModel.Title == null)
                {
                    languageModel.Title = elMLanguage.Title;
                }

                blobUrl = await _languagesService.StartDocumentUploadProcess(data, languageModel);
            }

            elMLanguage.Title = languageModel.Title;
            elMLanguage.ThumbnailUrl = blobUrl;
            elMLanguage.LastModifiedBy = email;
            elMLanguage.LastModifiedDate = DateTime.UtcNow;
            _context.SaveChanges();
            return Ok();
        }

        // DELETE api/<LanguagesController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, string email)
        {
            //Check if any Books exist with the mentioned Language
            int total = _context.ElTBooks.Count(b => b.Language == id);
            if (total == 0)
            {
                //Soft Delete Language from DB
                var elMLanguage = new ElMLanguage();
                elMLanguage = (from x in _context.ElMLanguages
                               where x.Id == id
                               select x).First();
                elMLanguage.IsDeleted = true;
                elMLanguage.LastModifiedBy = email;
                elMLanguage.LastModifiedDate = DateTime.UtcNow;
                elMLanguage.DeletedBy = email;
                elMLanguage.DeletedOn = DateTime.UtcNow;
                _context.SaveChanges();
                return Ok();
            }
            else
            {
                return StatusCode(403, "Books existing with mentioned Language.");
            }
        }
    }
}
