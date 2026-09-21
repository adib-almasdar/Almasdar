using CommonLib.Data;
using eLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Security.Policy;
using static System.Reflection.Metadata.BlobBuilder;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace eLibrary.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavouriteBookController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public FavouriteBookController(ApplicationDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        [Route("GetbyEmail")]
        public IActionResult GetbyEmail(string email, string? Author, string? Publication, string? Category, string? SubCategory, int? Year, string? Country, string? Language, bool? IsGeneralView = false)
        {
            if (IsGeneralView == false)
            {
                var result = from favbks in _context.ElTFavouriteBooks
                             join bks in _context.ElTBooks on favbks.BookId equals bks.BookId
                             join subCat in _context.ElMSubCategories on bks.SubCategory equals subCat.Id
                             join C in _context.ElMCategories on bks.Category equals C.Id
                             join lang in _context.ElMLanguages on bks.Language equals lang.Id
                             join country in _context.ElMCountries on bks.Country equals country.Id into countryJoin
                             from countries in countryJoin.DefaultIfEmpty()
                             where favbks.UserEmail == email && favbks.IsDeleted == false && bks.IsDeleted == false
                             orderby favbks.FavouriteDate descending
                             select new
                             {
                                 favbks.Id,
                                 favbks.BookId,
                                 favbks.UserEmail,
                                 favbks.FavouriteDate,
                                 bks.BookTitleArabic,
                                 bks.BookTitleEnglish,
                                 bks.Author,
                                 bks.ThumbnailUrl,
                                 bks.BookUrl,
                                 bks.Description,
                                 bks.Publication,
                                 bks.SubCategory,
                                 bks.UpdatedDate,
                                 bks.Year,
                                 bks.Country,
                                 bks.Language,
                                 SubCategoryTitle = subCat.Title,
                                 LanguageTitle = lang.Title,
                                 CountryTitle = countries != null ? countries.Title : null, // Handle null country
                                 CategoryTitle = C.Title

                             };

                if (!string.IsNullOrEmpty(Author))
                {
                    result = result.Where(r => r.Author == Author);
                }

                if (!string.IsNullOrEmpty(Publication))
                {
                    result = result.Where(r => r.Publication == Publication);
                }

                if (!string.IsNullOrEmpty(SubCategory))
                {
                    result = result.Where(r => r.SubCategoryTitle == SubCategory);
                }

                if (Year.HasValue)
                {
                    result = result.Where(r => r.Year == Year.Value);
                }

                if (!string.IsNullOrEmpty(Country))
                {
                    result = result.Where(r => r.CountryTitle == Country);
                }

                if (!string.IsNullOrEmpty(Language))
                {
                    result = result.Where(r => r.LanguageTitle == Language);
                }

                if (!string.IsNullOrEmpty(Category))
                {
                    result = result.Where(r => r.CategoryTitle == Category);
                }

                return Ok(result);
            }
            else
            {
                var result = from favbks in _context.ElTFavouriteBooks
                             join bks in _context.ElTBooks on favbks.BookId equals bks.BookId
                             join subCat in _context.ElMSubCategories on bks.SubCategory equals subCat.Id
                             join C in _context.ElMCategories on bks.Category equals C.Id
                             join lang in _context.ElMLanguages on bks.Language equals lang.Id
                             join country in _context.ElMCountries on bks.Country equals country.Id into countryJoin
                             from countries in countryJoin.DefaultIfEmpty()
                             where favbks.UserEmail == email && favbks.IsDeleted == false && bks.IsDeleted == false && bks.VisibilityOfBook == "Public"
                             orderby favbks.FavouriteDate descending
                             select new
                             {
                                 favbks.Id,
                                 favbks.BookId,
                                 favbks.UserEmail,
                                 favbks.FavouriteDate,
                                 bks.BookTitleArabic,
                                 bks.BookTitleEnglish,
                                 bks.Author,
                                 bks.ThumbnailUrl,
                                 bks.BookUrl,
                                 bks.Description,
                                 bks.Publication,
                                 bks.SubCategory,
                                 bks.UpdatedDate,
                                 bks.Year,
                                 bks.Country,
                                 bks.Language,
                                 SubCategoryTitle = subCat.Title,
                                 LanguageTitle = lang.Title,
                                 CountryTitle = countries != null ? countries.Title : null, // Handle null country
                                 CategoryTitle = C.Title

                             };

                if (!string.IsNullOrEmpty(Author))
                {
                    result = result.Where(r => r.Author == Author);
                }

                if (!string.IsNullOrEmpty(Publication))
                {
                    result = result.Where(r => r.Publication == Publication);
                }

                if (!string.IsNullOrEmpty(SubCategory))
                {
                    result = result.Where(r => r.SubCategoryTitle == SubCategory);
                }

                if (Year.HasValue)
                {
                    result = result.Where(r => r.Year == Year.Value);
                }

                if (!string.IsNullOrEmpty(Country))
                {
                    result = result.Where(r => r.CountryTitle == Country);
                }

                if (!string.IsNullOrEmpty(Language))
                {
                    result = result.Where(r => r.LanguageTitle == Language);
                }

                if (!string.IsNullOrEmpty(Category))
                {
                    result = result.Where(r => r.CategoryTitle == Category);
                }

                return Ok(result);
            }

        }

        // POST api/<FavouriteBookController>
        [HttpPost]
        public IActionResult Post([FromBody] FavouriteBookModel favouriteBookModel)
        {
            _context.ElTFavouriteBooks.Add(new ElTFavouriteBook()
            {
                BookId = favouriteBookModel.BookID,
                UserEmail = favouriteBookModel.UserEmail,
                FavouriteDate = DateTime.UtcNow,
                IsDeleted = false
            });
            _context.SaveChanges();
            return Ok(favouriteBookModel);
        }

        // DELETE api/<FavouriteBookController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, string? email, int? bookid)
        {
            if (String.IsNullOrEmpty(email))
            {
                var elTFavouriteBook = new ElTFavouriteBook();
                elTFavouriteBook = (from x in _context.ElTFavouriteBooks
                                    where x.Id == id && x.IsDeleted != true
                                    select x).FirstOrDefault();
                elTFavouriteBook.IsDeleted = true;
                _context.SaveChanges();
            }
            else
            {
                var elTFavouriteBook = new ElTFavouriteBook();
                elTFavouriteBook = (from x in _context.ElTFavouriteBooks
                                    where x.UserEmail == email && x.BookId == bookid && x.IsDeleted != true
                                    select x).FirstOrDefault();
                elTFavouriteBook.IsDeleted = true;
                _context.SaveChanges();
            }

            return Ok();

        }

        [HttpGet]
        [Route("GetFavouriteBooksFiltersData")]
        public IActionResult GetFavouriteBooksFiltersData(string email, int? categoryId, bool? IsGeneralView = false)
        {
            if (IsGeneralView == false)
            {
                //Get All Fav Books
                var result = from books in _context.ElTBooks
                             join subC in _context.ElMSubCategories on books.SubCategory equals subC.Id
                             join countries in _context.ElMCountries on books.Country equals countries.Id into countryJoin
                             from countries in countryJoin.DefaultIfEmpty()
                             join lang in _context.ElMLanguages on books.Language equals lang.Id
                             where _context.ElTFavouriteBooks
                                   .Where(fb => fb.UserEmail == email && fb.IsDeleted == false && books.IsDeleted != true)
                                   .Select(fb => fb.BookId)
                                   .Contains(books.BookId)
                             select new
                             {
                                 books.BookId,
                                 books.Author,
                                 books.Publication,
                                 books.Year,
                                 SubCategoryTitle = subC.Title,
                                 CountryTitle = countries != null ? countries.Title : null,
                                 LanguageTitle = lang.Title
                             };

                List<string> commonSubCategory = new List<string>();
                List<string> subCategories = new List<string>();

                if (categoryId != null)
                {
                    subCategories = _context.ElMSubCategories
                         .Where(subCategory => subCategory.CategoryId == categoryId)
                         .Select(subCategory => subCategory.Title).ToList();


                    List<string> Authors = (from kvp in result select kvp.Author).Distinct().ToList();
                    List<string> Publications = (from kvp in result select kvp.Publication).Distinct().ToList();
                    List<int?> Year = (from kvp in result select kvp.Year).Distinct().ToList();
                    List<string> SubCategory = (from kvp in result select kvp.SubCategoryTitle).Distinct().ToList();
                    List<string> Country = (from kvp in result select kvp.CountryTitle).Distinct().ToList();
                    List<string> Language = (from kvp in result select kvp.LanguageTitle).Distinct().ToList();

                    commonSubCategory = subCategories.Intersect(SubCategory).ToList();

                    List<FavouriteBookFilters> filters = new List<FavouriteBookFilters>();
                    filters.Add(new FavouriteBookFilters());
                    filters[0].Authors = Authors;
                    filters[0].Publications = Publications;
                    filters[0].Year = Year;
                    filters[0].SubCategory = commonSubCategory;
                    filters[0].Country = Country;
                    filters[0].Language = Language;

                    return Ok(filters);
                }
                else
                {
                    List<string> Authors = (from kvp in result select kvp.Author).Distinct().ToList();
                    List<string> Publications = (from kvp in result select kvp.Publication).Distinct().ToList();
                    List<int?> Year = (from kvp in result select kvp.Year).Distinct().ToList();
                    List<string> SubCategory = (from kvp in result select kvp.SubCategoryTitle).Distinct().ToList();
                    List<string> Country = (from kvp in result select kvp.CountryTitle).Distinct().ToList();
                    List<string> Language = (from kvp in result select kvp.LanguageTitle).Distinct().ToList();

                    List<FavouriteBookFilters> filters = new List<FavouriteBookFilters>();
                    filters.Add(new FavouriteBookFilters());
                    filters[0].Authors = Authors;
                    filters[0].Publications = Publications;
                    filters[0].Year = Year;
                    filters[0].SubCategory = SubCategory;
                    filters[0].Country = Country;
                    filters[0].Language = Language;

                    return Ok(filters);
                }
            }
            else
            {
                //Get All Fav Books
                var result = from books in _context.ElTBooks
                             join subC in _context.ElMSubCategories on books.SubCategory equals subC.Id
                             join countries in _context.ElMCountries on books.Country equals countries.Id into countryJoin
                             from countries in countryJoin.DefaultIfEmpty()
                             join lang in _context.ElMLanguages on books.Language equals lang.Id
                             where _context.ElTFavouriteBooks
                                   .Where(fb => fb.UserEmail == email && fb.IsDeleted == false && books.IsDeleted != true && books.VisibilityOfBook == "Public")
                                   .Select(fb => fb.BookId)
                                   .Contains(books.BookId)
                             select new
                             {
                                 books.BookId,
                                 books.Author,
                                 books.Publication,
                                 books.Year,
                                 SubCategoryTitle = subC.Title,
                                 CountryTitle = countries != null ? countries.Title : null,
                                 LanguageTitle = lang.Title
                             };

                List<string> commonSubCategory = new List<string>();
                List<string> subCategories = new List<string>();

                if (categoryId != null)
                {
                    subCategories = _context.ElMSubCategories
                         .Where(subCategory => subCategory.CategoryId == categoryId)
                         .Select(subCategory => subCategory.Title).ToList();


                    List<string> Authors = (from kvp in result select kvp.Author).Distinct().ToList();
                    List<string> Publications = (from kvp in result select kvp.Publication).Distinct().ToList();
                    List<int?> Year = (from kvp in result select kvp.Year).Distinct().ToList();
                    List<string> SubCategory = (from kvp in result select kvp.SubCategoryTitle).Distinct().ToList();
                    List<string> Country = (from kvp in result select kvp.CountryTitle).Distinct().ToList();
                    List<string> Language = (from kvp in result select kvp.LanguageTitle).Distinct().ToList();

                    commonSubCategory = subCategories.Intersect(SubCategory).ToList();

                    List<FavouriteBookFilters> filters = new List<FavouriteBookFilters>();
                    filters.Add(new FavouriteBookFilters());
                    filters[0].Authors = Authors;
                    filters[0].Publications = Publications;
                    filters[0].Year = Year;
                    filters[0].SubCategory = commonSubCategory;
                    filters[0].Country = Country;
                    filters[0].Language = Language;

                    return Ok(filters);
                }
                else
                {
                    List<string> Authors = (from kvp in result select kvp.Author).Distinct().ToList();
                    List<string> Publications = (from kvp in result select kvp.Publication).Distinct().ToList();
                    List<int?> Year = (from kvp in result select kvp.Year).Distinct().ToList();
                    List<string> SubCategory = (from kvp in result select kvp.SubCategoryTitle).Distinct().ToList();
                    List<string> Country = (from kvp in result select kvp.CountryTitle).Distinct().ToList();
                    List<string> Language = (from kvp in result select kvp.LanguageTitle).Distinct().ToList();

                    List<FavouriteBookFilters> filters = new List<FavouriteBookFilters>();
                    filters.Add(new FavouriteBookFilters());
                    filters[0].Authors = Authors;
                    filters[0].Publications = Publications;
                    filters[0].Year = Year;
                    filters[0].SubCategory = SubCategory;
                    filters[0].Country = Country;
                    filters[0].Language = Language;

                    return Ok(filters);
                }
            }

        }



    }

    public class FavouriteBookFilters
    {
        public List<string> Authors { get; set; }
        public List<string> Publications { get; set; }
        public List<int?> Year { get; set; }
        public List<string> SubCategory { get; set; }
        public List<string> Country { get; set; }
        public List<string> Language { get; set; }

    }


}
