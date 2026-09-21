using CommonLib.Data;
using eLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using System.Linq;



namespace eLibrary.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MyRecentViewController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public MyRecentViewController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: api/<MyRecenetViewController>
        [HttpGet("GetByUserEmail/{userEmail}")]
        public IActionResult GetRecentViewDetails(string userEmail)
        {
            var results = from book in _context.ElTBooks
                          join recentView in _context.ElTRecentViews on book.BookId equals recentView.BookId
                          where recentView.UserEmail == userEmail && book.IsDeleted == false

                          select new
                          {
                              BookId = book.BookId,
                              BookTitleArabic = book.BookTitleArabic,
                              BookTitleEnglish = book.BookTitleEnglish,
                              Author = book.Author,
                              Year = book.Year,
                              ThumbnailUrl = book.ThumbnailUrl,
                              Description = book.Description,
                              RecentViewId = recentView.Id,
                              UserEmail = recentView.UserEmail,
                              PageNumber = recentView.PageNumber,
                              ViewDate = recentView.ViewDate,
                              SubCategory = book.SubCategory,
                              Publication = book.Publication,
                              Country = book.Country,
                              Language = book.Language,
                              Version = book.Version,
                              approverDateTime = book.ApproverDateTime

                          };



            int totalCount = results.Count();

            return Ok(new { TotalCount = totalCount, Data = results });
        }




        [HttpPost]
        public IActionResult Create(MyRecenetViewModel recentViews)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var recentView = new ElTRecentView
            {

                BookId = recentViews.BookId,
                UserEmail = recentViews.UserEmail,
                PageNumber = recentViews.PageNumber,
                ViewDate = DateTime.UtcNow,

            };

            var result = _context.ElTRecentViews
        .Where(view => view.UserEmail == recentViews.UserEmail && view.BookId == recentViews.BookId)
        .ToList();

            if (result.Count > 0)
            {
                var id = result[result.Count - 1].Id;
                var recordToUpdate = _context.ElTRecentViews.FirstOrDefault(x => x.Id == id);

                if (recordToUpdate != null)
                {
                    // Update the status property
                    recordToUpdate.BookId = recentViews.BookId;
                    recordToUpdate.UserEmail = recentViews.UserEmail;
                    recordToUpdate.PageNumber = recentViews.PageNumber;
                    recordToUpdate.ViewDate = DateTime.UtcNow;
                    // Save changes to the database
                    _context.SaveChanges();
                }
            }
            else
            {
                _context.ElTRecentViews.Add(recentView);
                _context.SaveChanges();
            }

            return Ok(recentView);
        }


        [HttpGet("{userEmail}")]
        public IActionResult GetRecentViewDetails(string userEmail, string? Publication, string? Category, string? SubCategory, int? Year, string? Country, string? Language, string? Author, string bookTitle = "all", string timeRange = "today", int count = -1, bool? IsGeneralView = false)
        {
            DateTime startDate;
            if (timeRange.ToLower() == "all")
            {
                startDate = DateTime.MinValue;
            }
            else
            {
                switch (timeRange.ToLower())
                {
                    case "today":
                        startDate = DateTime.Today;
                        break;
                    case "thisweek":
                        startDate = DateTime.Today.AddDays(-((int)DateTime.Today.DayOfWeek - 1));
                        break;
                    case "thismonth":
                        startDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
                        break;
                    case "lastsixmonths":
                        startDate = DateTime.Today.AddMonths(-6);
                        break;
                    default:
                        return BadRequest("Invalid time range specified.");
                }
            }

            if (IsGeneralView == false)
            {

                var results = from book in _context.ElTBooks
                              join recentView in _context.ElTRecentViews on book.BookId equals recentView.BookId
                              join subC in _context.ElMSubCategories on book.SubCategory equals subC.Id
                              join C in _context.ElMCategories on book.Category equals C.Id
                              join countries in _context.ElMCountries on book.Country equals countries.Id into countryJoin
                              from countries in countryJoin.DefaultIfEmpty()
                              join lang in _context.ElMLanguages on book.Language equals lang.Id
                              where recentView.UserEmail == userEmail
                                  && (bookTitle.ToLower() == "all" || book.BookTitleEnglish.ToLower().Contains(bookTitle.ToLower()) || book.BookTitleArabic.ToLower().Contains(bookTitle.ToLower()))
                                  && (startDate == DateTime.MinValue || recentView.ViewDate >= startDate) && book.IsDeleted == false
                              select new
                              {
                                  BookId = book.BookId,
                                  BookTitleArabic = book.BookTitleArabic,
                                  BookTitleEnglish = book.BookTitleEnglish,
                                  Author = book.Author,
                                  Year = book.Year,
                                  ThumbnailUrl = book.ThumbnailUrl,
                                  Publication = book.Publication,
                                  Description = book.Description,
                                  RecentViewId = recentView.Id,
                                  UserEmail = recentView.UserEmail,
                                  PageNumber = recentView.PageNumber,
                                  ViewDate = recentView.ViewDate,
                                  SubCategoryTitle = subC.Title,
                                  CountryTitle = countries != null ? countries.Title : null,
                                  LanguageTitle = lang.Title,
                                  CategoryTitle = C.Title
                              };

                if (!string.IsNullOrEmpty(Author))
                {
                    results = results.Where(r => r.Author == Author);
                }

                if (!string.IsNullOrEmpty(Publication))
                {
                    results = results.Where(r => r.Publication == Publication);
                }

                if (!string.IsNullOrEmpty(SubCategory))
                {
                    results = results.Where(r => r.SubCategoryTitle == SubCategory);
                }

                if (Year.HasValue)
                {
                    results = results.Where(r => r.Year == Year.Value);
                }

                if (!string.IsNullOrEmpty(Country))
                {
                    results = results.Where(r => r.CountryTitle == Country);
                }

                if (!string.IsNullOrEmpty(Language))
                {
                    results = results.Where(r => r.LanguageTitle == Language);
                }
                if (!string.IsNullOrEmpty(Category))
                {
                    results = results.Where(r => r.CategoryTitle == Category);
                }


                results = results.GroupBy(p => p.BookId).Select(grp => grp.FirstOrDefault());

                //int totalCount = results.Count();

                //if (count == -1)
                //{
                //    count = totalCount;
                //}

                //var result = results.Take(count).ToList();

                var result = results.ToList();

                int totalCount = result.Count;

                if (result == null)
                {
                    return NotFound();
                }

                return Ok(new { TotalCount = totalCount, Data = result });

            }
            else
            {

                var results = from book in _context.ElTBooks
                              join recentView in _context.ElTRecentViews on book.BookId equals recentView.BookId
                              join subC in _context.ElMSubCategories on book.SubCategory equals subC.Id
                              join C in _context.ElMCategories on book.Category equals C.Id
                              join countries in _context.ElMCountries on book.Country equals countries.Id into countryJoin
                              from countries in countryJoin.DefaultIfEmpty()
                              join lang in _context.ElMLanguages on book.Language equals lang.Id
                              where recentView.UserEmail == userEmail
                                  && (bookTitle.ToLower() == "all" || book.BookTitleEnglish.ToLower().Contains(bookTitle.ToLower()) || book.BookTitleArabic.ToLower().Contains(bookTitle.ToLower()))
                                  && (startDate == DateTime.MinValue || recentView.ViewDate >= startDate) && book.IsDeleted == false && book.VisibilityOfBook == "Public"
                              select new
                              {
                                  BookId = book.BookId,
                                  BookTitleArabic = book.BookTitleArabic,
                                  BookTitleEnglish = book.BookTitleEnglish,
                                  Author = book.Author,
                                  Year = book.Year,
                                  ThumbnailUrl = book.ThumbnailUrl,
                                  Publication = book.Publication,
                                  Description = book.Description,
                                  RecentViewId = recentView.Id,
                                  UserEmail = recentView.UserEmail,
                                  PageNumber = recentView.PageNumber,
                                  ViewDate = recentView.ViewDate,
                                  SubCategoryTitle = subC.Title,
                                  CountryTitle = countries != null ? countries.Title : null,
                                  LanguageTitle = lang.Title,
                                  CategoryTitle = C.Title
                              };

                if (!string.IsNullOrEmpty(Author))
                {
                    results = results.Where(r => r.Author == Author);
                }

                if (!string.IsNullOrEmpty(Publication))
                {
                    results = results.Where(r => r.Publication == Publication);
                }

                if (!string.IsNullOrEmpty(SubCategory))
                {
                    results = results.Where(r => r.SubCategoryTitle == SubCategory);
                }

                if (Year.HasValue)
                {
                    results = results.Where(r => r.Year == Year.Value);
                }

                if (!string.IsNullOrEmpty(Country))
                {
                    results = results.Where(r => r.CountryTitle == Country);
                }

                if (!string.IsNullOrEmpty(Language))
                {
                    results = results.Where(r => r.LanguageTitle == Language);
                }
                if (!string.IsNullOrEmpty(Category))
                {
                    results = results.Where(r => r.CategoryTitle == Category);
                }

                results = results.GroupBy(p => p.BookId).Select(grp => grp.FirstOrDefault());


                //int totalCount = results.Count();

                //if (count == -1)
                //{
                //    count = totalCount;
                //}

                //var result = results.Take(count).ToList();

                var result = results.ToList();

                int totalCount = result.Count;

                if (result == null)
                {
                    return NotFound();
                }

                return Ok(new { TotalCount = totalCount, Data = result });

            }

        }

        [HttpGet]
        [Route("GetRecentViewsFiltersData")]
        public IActionResult GetRecentViewsFiltersData(string email, int? categoryId, string bookTitle = "all", string timeRange = "today", int count = -1, bool? IsGeneralView = false)
        {
            DateTime startDate;
            if (timeRange.ToLower() == "all")
            {
                startDate = DateTime.MinValue;
            }
            else
            {
                switch (timeRange.ToLower())
                {
                    case "today":
                        startDate = DateTime.Today;
                        break;
                    case "thisweek":
                        startDate = DateTime.Today.AddDays(-((int)DateTime.Today.DayOfWeek - 1));
                        break;
                    case "thismonth":
                        startDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
                        break;
                    case "lastsixmonths":
                        startDate = DateTime.Today.AddMonths(-6);
                        break;
                    default:
                        return BadRequest("Invalid time range specified.");
                }
            }

            if (IsGeneralView == false)
            {
                var result = from book in _context.ElTBooks
                             join recentView in _context.ElTRecentViews on book.BookId equals recentView.BookId
                             join subC in _context.ElMSubCategories on book.SubCategory equals subC.Id
                             join countries in _context.ElMCountries on book.Country equals countries.Id into countryJoin
                             from countries in countryJoin.DefaultIfEmpty()
                             join lang in _context.ElMLanguages on book.Language equals lang.Id
                             where recentView.UserEmail == email
                                 && (bookTitle.ToLower() == "all" || book.BookTitleEnglish.ToLower().Contains(bookTitle.ToLower()) || book.BookTitleArabic.ToLower().Contains(bookTitle.ToLower()))
                                 && (startDate == DateTime.MinValue || recentView.ViewDate >= startDate) && book.IsDeleted == false
                             select new
                             {
                                 BookId = book.BookId,
                                 BookTitleArabic = book.BookTitleArabic,
                                 BookTitleEnglish = book.BookTitleEnglish,
                                 Author = book.Author,
                                 Year = book.Year,
                                 ThumbnailUrl = book.ThumbnailUrl,
                                 Publication = book.Publication,
                                 Description = book.Description,
                                 RecentViewId = recentView.Id,
                                 UserEmail = recentView.UserEmail,
                                 PageNumber = recentView.PageNumber,
                                 ViewDate = recentView.ViewDate,
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

                    List<NewArrivalBookFilters> filters = new List<NewArrivalBookFilters>();
                    filters.Add(new NewArrivalBookFilters());
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

                    List<NewArrivalBookFilters> filters = new List<NewArrivalBookFilters>();
                    filters.Add(new NewArrivalBookFilters());
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
                var result = from book in _context.ElTBooks
                             join recentView in _context.ElTRecentViews on book.BookId equals recentView.BookId
                             join subC in _context.ElMSubCategories on book.SubCategory equals subC.Id
                             join countries in _context.ElMCountries on book.Country equals countries.Id into countryJoin
                             from countries in countryJoin.DefaultIfEmpty()
                             join lang in _context.ElMLanguages on book.Language equals lang.Id
                             where recentView.UserEmail == email
                                 && (bookTitle.ToLower() == "all" || book.BookTitleEnglish.ToLower().Contains(bookTitle.ToLower()) || book.BookTitleArabic.ToLower().Contains(bookTitle.ToLower()))
                                 && (startDate == DateTime.MinValue || recentView.ViewDate >= startDate) && book.IsDeleted == false && book.VisibilityOfBook == "Public"
                             select new
                             {
                                 BookId = book.BookId,
                                 BookTitleArabic = book.BookTitleArabic,
                                 BookTitleEnglish = book.BookTitleEnglish,
                                 Author = book.Author,
                                 Year = book.Year,
                                 ThumbnailUrl = book.ThumbnailUrl,
                                 Publication = book.Publication,
                                 Description = book.Description,
                                 RecentViewId = recentView.Id,
                                 UserEmail = recentView.UserEmail,
                                 PageNumber = recentView.PageNumber,
                                 ViewDate = recentView.ViewDate,
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

                    List<NewArrivalBookFilters> filters = new List<NewArrivalBookFilters>();
                    filters.Add(new NewArrivalBookFilters());
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

                    List<NewArrivalBookFilters> filters = new List<NewArrivalBookFilters>();
                    filters.Add(new NewArrivalBookFilters());
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

        [HttpGet]
        [Route("GetBookLastReadingHistory")]
        public IActionResult GetBookLastReadingHistory(string email, int bookId)
        {
            var recentViews = _context.ElTRecentViews
            .Where(view => view.UserEmail == email && view.BookId == bookId)
    .ToList();

            return Ok(recentViews);
        }

        public class NewArrivalBookFilters
        {
            public List<string> Authors { get; set; }
            public List<string> Publications { get; set; }
            public List<int?> Year { get; set; }
            public List<string> SubCategory { get; set; }
            public List<string> Country { get; set; }
            public List<string> Language { get; set; }

        }



    }
}
