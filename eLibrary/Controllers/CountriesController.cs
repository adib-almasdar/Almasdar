using CommonLib.Data;
using eLibrary.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace eLibrary.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public CountriesController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: api/<CountriesController>
        [HttpGet]
        public IActionResult Get()
        {
            var elMCountries = (from x in _context.ElMCountries
                                where x.IsDeleted != true
                                select x).ToList();
            return Ok(elMCountries);
        }

        // GET api/<CountriesController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var elMCountrybyId = _context.ElMCountries.Where(x => x.Id == id).FirstOrDefault();
            return Ok(elMCountrybyId);

        }

        // POST api/<CountriesController>
        [HttpPost]
        public IActionResult Post([FromBody] CountryModel countryModel, string email)
        {
            _context.ElMCountries.Add(new ElMCountry()
            {
                Title = countryModel.Title,
                CreatedBy = countryModel.CreatedBy,
                CreatedDate = DateTime.UtcNow,
                LastModifiedBy = email,
                LastModifiedDate = DateTime.UtcNow,
                IsDeleted = false
            });
            _context.SaveChanges();
            return Ok(countryModel);
        }

        // PUT api/<CountriesController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] CountryModel countryModel, string email)
        {
            var elMCountry = new ElMCountry();
            elMCountry = (from x in _context.ElMCountries
                          where x.Id == id
                          select x).First();

            elMCountry.Title = countryModel.Title;
            elMCountry.LastModifiedBy = email;
            elMCountry.LastModifiedDate = DateTime.UtcNow;
            _context.SaveChanges();
            return Ok();
        }

        // DELETE api/<CountriesController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, string email)
        {
            //Check if any Books exist with the mentioned Country
            int total = _context.ElTBooks.Count(b => b.Country == id);
            if (total == 0)
            {
                //Soft Delete Country from DB
                var elMCountry = new ElMCountry();
                elMCountry = (from x in _context.ElMCountries
                              where x.Id == id
                              select x).First();
                elMCountry.IsDeleted = true;
                elMCountry.LastModifiedBy = email;
                elMCountry.LastModifiedDate = DateTime.UtcNow;
                elMCountry.DeletedBy = email;
                elMCountry.DeletedOn = DateTime.UtcNow;
                _context.SaveChanges();
                return Ok();
            }
            else
            {
                return StatusCode(403, "Books existing with mentioned Country.");
            }
        }
    }
}
