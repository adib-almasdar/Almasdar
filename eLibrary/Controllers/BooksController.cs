using Azure.Storage.Files.DataLake;
using Azure.Storage.Files.DataLake.Models;
using CommonLib;
using CommonLib.Data;
using eLibrary.Models;
using eLibrary.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Net;
using System.Net.Mime;
using System.Net.WebSockets;
using System.Text;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace eLibrary.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IBooksService _booksService;
        private readonly ILogger<BooksController> _logger;
        public BooksController(ApplicationDbContext context, IBooksService booksService, ILogger<BooksController> logger)
        {
            _context = context;
            _booksService = booksService;
            _logger = logger;
        }


        [HttpGet]
        [Route("GetNewArrivals")]
        public IActionResult GetNewArrivals(string? Author, string? Publication, string? SubCategory, string? Category, int? Year, string? Country, string? Language, bool? IsGeneralView = false)
        {
            if (IsGeneralView == false)
            {
                //var result = from books in _context.ElTBooks
                //             join subC in _context.ElMSubCategories on books.SubCategory equals subC.Id
                //             join C in _context.ElMCategories on books.Category equals C.Id
                //             join countries in _context.ElMCountries on books.Country equals countries.Id
                //             join lang in _context.ElMLanguages on books.Language equals lang.Id
                //             where books.UpdatedDate >= DateTime.Today.AddDays(-1) &&
                //                   books.UpdatedDate <= DateTime.Now &&
                //                   books.IsDeleted == false
                //             orderby books.UpdatedDate descending
                //             select new
                //             {
                //                 books,
                //                 SubCategoryTitle = subC.Title,
                //                 CountryTitle = countries.Title,
                //                 LanguageTitle = lang.Title,
                //                 CategoryTitle = C.Title
                //             };

                var result = from books in _context.ElTBooks
                             join subC in _context.ElMSubCategories on books.SubCategory equals subC.Id
                             join C in _context.ElMCategories on books.Category equals C.Id
                             join countries in _context.ElMCountries on books.Country equals countries.Id into countryJoin
                             from countries in countryJoin.DefaultIfEmpty()  // Left join for countries
                             join lang in _context.ElMLanguages on books.Language equals lang.Id
                             where books.UpdatedDate >= DateTime.Today.AddDays(-1) &&
                                   books.UpdatedDate <= DateTime.Now &&
                                   books.IsDeleted == false
                             orderby books.UpdatedDate descending
                             select new
                             {
                                 books,
                                 SubCategoryTitle = subC.Title,
                                 CountryTitle = countries != null ? countries.Title : null, // Handle null country
                                 LanguageTitle = lang.Title,
                                 CategoryTitle = C.Title
                             };


                if (!string.IsNullOrEmpty(Author))
                {
                    result = result.Where(r => r.books.Author == Author);
                }

                if (!string.IsNullOrEmpty(Publication))
                {
                    result = result.Where(r => r.books.Publication == Publication);
                }

                if (!string.IsNullOrEmpty(SubCategory))
                {
                    result = result.Where(r => r.SubCategoryTitle == SubCategory);
                }

                if (Year.HasValue)
                {
                    result = result.Where(r => r.books.Year == Year.Value);
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
                //var result = from books in _context.ElTBooks
                //             join subC in _context.ElMSubCategories on books.SubCategory equals subC.Id
                //             join C in _context.ElMCategories on books.Category equals C.Id
                //             join countries in _context.ElMCountries on books.Country equals countries.Id
                //             join lang in _context.ElMLanguages on books.Language equals lang.Id
                //             where books.UpdatedDate >= DateTime.Today.AddDays(-1) &&
                //                   books.UpdatedDate <= DateTime.Now &&
                //                   books.IsDeleted == false && books.VisibilityOfBook == "Public"
                //             orderby books.UpdatedDate descending
                //             select new
                //             {
                //                 books,
                //                 SubCategoryTitle = subC.Title,
                //                 CountryTitle = countries.Title,
                //                 LanguageTitle = lang.Title,
                //                 CategoryTitle = C.Title
                //             };

                var result = from books in _context.ElTBooks
                             join subC in _context.ElMSubCategories on books.SubCategory equals subC.Id
                             join C in _context.ElMCategories on books.Category equals C.Id
                             join countries in _context.ElMCountries on books.Country equals countries.Id into countryJoin
                             from countries in countryJoin.DefaultIfEmpty()  // Left join for countries
                             join lang in _context.ElMLanguages on books.Language equals lang.Id
                             where books.UpdatedDate >= DateTime.Today.AddDays(-1) &&
                                   books.UpdatedDate <= DateTime.Now &&
                                   books.IsDeleted == false && books.VisibilityOfBook == "Public"
                             orderby books.UpdatedDate descending
                             select new
                             {
                                 books,
                                 SubCategoryTitle = subC.Title,
                                 CountryTitle = countries != null ? countries.Title : null, // Handle null country
                                 LanguageTitle = lang.Title,
                                 CategoryTitle = C.Title
                             };


                if (!string.IsNullOrEmpty(Author))
                {
                    result = result.Where(r => r.books.Author == Author);
                }

                if (!string.IsNullOrEmpty(Publication))
                {
                    result = result.Where(r => r.books.Publication == Publication);
                }

                if (!string.IsNullOrEmpty(SubCategory))
                {
                    result = result.Where(r => r.SubCategoryTitle == SubCategory);
                }

                if (Year.HasValue)
                {
                    result = result.Where(r => r.books.Year == Year.Value);
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

        [HttpGet]
        [Route("GetNewArrivalsFiltersData")]
        public IActionResult GetNewArrivalsFiltersData(int? categoryId, bool? IsGeneralView = false)
        {
            if (IsGeneralView == false)
            {
                var result = from books in _context.ElTBooks
                             join subC in _context.ElMSubCategories on books.SubCategory equals subC.Id
                             join countries in _context.ElMCountries on books.Country equals countries.Id into countryJoin
                             from countries in countryJoin.DefaultIfEmpty()
                             join lang in _context.ElMLanguages on books.Language equals lang.Id
                             where books.UpdatedDate >= DateTime.Today.AddDays(-1) &&
                                   books.UpdatedDate <= DateTime.Now &&
                                   books.IsDeleted == false
                             orderby books.UpdatedDate descending
                             select new
                             {
                                 books.Author,
                                 books.Publication,
                                 books.Year,
                                 SubCategoryTitle = subC.Title,
                                 CountryTitle = countries != null ? countries.Title : null, // Handle null country
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
                var result = from books in _context.ElTBooks
                             join subC in _context.ElMSubCategories on books.SubCategory equals subC.Id
                             join countries in _context.ElMCountries on books.Country equals countries.Id into countryJoin
                             from countries in countryJoin.DefaultIfEmpty()
                             join lang in _context.ElMLanguages on books.Language equals lang.Id
                             where books.UpdatedDate >= DateTime.Today.AddDays(-1) &&
                                   books.UpdatedDate <= DateTime.Now &&
                                   books.IsDeleted == false && books.VisibilityOfBook == "Public"
                             orderby books.UpdatedDate descending
                             select new
                             {
                                 books.Author,
                                 books.Publication,
                                 books.Year,
                                 SubCategoryTitle = subC.Title,
                                 CountryTitle = countries != null ? countries.Title : null, // Handle null country
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
        [Route("GetAllCount")]
        public IActionResult GetAllCount()
        {
            var count = _context.ElTBooks.Count(b => b.IsDeleted == null || b.IsDeleted == false);
            return StatusCode(200, new
            {
                TotalBooks = count
            });

        }
        // GET api/<BooksController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id, bool? IsGeneralView = false)
        {
            //List<ElTBook> list;
            //string sqlQuery = "EXEC spGetBookDetailsbyID " + id;
            //List<SqlParameter> parms = new List<SqlParameter>();

            //list = _context.ElTBooks.FromSqlRaw<ElTBook>(sqlQuery, parms.ToArray()).ToList();
            //return Ok(list);


            var parentBook = (from b in _context.ElTBooks
                              where b.BookId == id
                              select new { Book = b, BookTypeforReference = "ParentBook" })
              .FirstOrDefault();

            if (IsGeneralView == false)
            {
                var linkedBooks = (from b in _context.ElTBooks
                                   join l in _context.ElTLinkedBooks on b.BookId equals l.ReferBookId
                                   where l.BookId == id
                                   select new { Book = b, BookTypeforReference = "LinkedBook" });

                var result = parentBook != null ? new List<object> { parentBook } : new List<object>();
                result.AddRange(linkedBooks);

                return Ok(result);
            }
            else
            {
                var linkedBooks = (from b in _context.ElTBooks
                                   join l in _context.ElTLinkedBooks on b.BookId equals l.ReferBookId
                                   where l.BookId == id && b.VisibilityOfBook == "Public"
                                   select new { Book = b, BookTypeforReference = "LinkedBook" });

                var result = parentBook != null ? new List<object> { parentBook } : new List<object>();
                result.AddRange(linkedBooks);

                return Ok(result);
            }

        }

        // GET api/<BooksController>
        [HttpGet]
        public IActionResult GetAllBooks()
        {
            var query = from book in _context.ElTBooks
                        where book.IsDeleted == false
                        select new
                        {
                            BookId = book.BookId,
                            BookTitleEnglish = book.BookTitleEnglish,
                            BookTitleArabic = book.BookTitleArabic,
                            VolumeNumber = book.VolumeNumber,
                            Version = book.Version,
                        };

            // Execute the query and get the result
            var result = query.ToList();
            return Ok(result);

        }

        /// <summary>
        /// For Uploading/Editing Book
        /// </summary>
        /// <param name="bookModel"></param>
        /// <returns></returns>
        [RequestFormLimits(ValueLengthLimit = int.MaxValue, MultipartBodyLengthLimit = int.MaxValue)]
        [DisableRequestSizeLimit]
        [HttpPost]
        [Route("UploadBook")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> UploadBooks([FromForm] BookModel bookModel)
        {
            if (bookModel.BookID != null)
            {
                string[] blobUrls = new string[3];

                if (HttpContext.Request.HasFormContentType)
                {
                    var data = await HttpContext.Request.ReadFormAsync();
                    bookModel.UpdatedDate = DateTime.UtcNow;

                    //Get BookDetails by BookID from DB
                    var bookInfo = _context.ElTBooks
                             .Where(b => b.BookId == bookModel.BookID)
                             .Select(b => new { b.UniqueFolderName, b.BookUrl })
                             .FirstOrDefault();

                    bookModel.UniqueFolderName = bookInfo.UniqueFolderName.ToString();
                    bookModel.BookUrl = bookInfo.BookUrl.ToString();

                    //Update metadata in Blob
                    Array.Copy(await _booksService.StartBookEditProcess(data, bookModel), blobUrls, 3);

                }

                //Create new record in BooksHistory table in DB
                var query = from s in _context.ElTBooks
                            where s.BookId == bookModel.BookID
                            select new ElTBooksHistory
                            {
                                BookId = s.BookId,
                                Category = s.Category,
                                SubCategory = s.SubCategory,
                                BookType = s.BookType,
                                BookTitleArabic = s.BookTitleArabic,
                                BookTitleEnglish = s.BookTitleEnglish,
                                Author = s.Author,
                                VolumeNumber = s.VolumeNumber,
                                Version = s.Version,
                                Country = s.Country,
                                Language = s.Language,
                                Year = s.Year,
                                VisibilityOfBook = s.VisibilityOfBook,
                                Description = s.Description,
                                UpdatedDate = s.UpdatedDate,
                                UploadedBy = s.UploadedBy,
                                ApproverName = s.ApproverName,
                                ApproverDateTime = s.ApproverDateTime,
                                ApprovalAttachmentsUrl = s.ApprovalAttachmentsUrl,
                                ArabicKeywords = s.ArabicKeywords,
                                EnglishKeywords = s.EnglishKeywords,
                                ThumbnailUrl = s.ThumbnailUrl,
                                BookUrl = s.BookUrl,
                                UniqueFolderName = s.UniqueFolderName,
                                Publication = s.Publication,
                                LastModifiedBy = bookModel.UploadedBy,
                                LastModifiedDate = DateTime.UtcNow,
                                IsDownloadable = s.IsDownloadable,
                                IsPrintable = s.IsPrintable,
                            };

                _context.ElTBooksHistories.AddRange(query);
                _context.SaveChanges();

                //Update in el_t_Books table in DB
                var record = _context.ElTBooks.FirstOrDefault(t => t.BookId == bookModel.BookID);

                bookModel.BookUrl = blobUrls[0];
                bookModel.ThumbnailUrl = blobUrls[1];
                bookModel.ApprovalAttachmentsUrl = blobUrls[2];

                if (record != null)
                {
                    // Modify the appropriate property or properties
                    record.Category = bookModel.Category == null ? record.Category : bookModel.Category;
                    record.SubCategory = bookModel.SubCategory == null ? record.SubCategory : bookModel.SubCategory;
                    record.BookType = bookModel.BookType == null ? record.BookType : bookModel.BookType;
                    record.BookTitleArabic = bookModel.BookTitleArabic == null ? record.BookTitleArabic : bookModel.BookTitleArabic;
                    record.BookTitleEnglish = bookModel.BookTitleEnglish == null ? record.BookTitleEnglish : bookModel.BookTitleEnglish;
                    record.Author = bookModel.Author == null ? record.Author : bookModel.Author;
                    record.VolumeNumber = bookModel.VolumeNumber == null ? record.VolumeNumber : bookModel.VolumeNumber;
                    record.Publication = bookModel.Publication == null ? record.Publication : bookModel.Publication;
                    record.Version = bookModel.Version == null ? record.Version : bookModel.Version;
                    record.Country = bookModel.Country == null ? record.Country : bookModel.Country;
                    record.Language = bookModel.Language == null ? record.Language : bookModel.Language;
                    record.Year = bookModel.Year == null ? record.Year : bookModel.Year;
                    record.VisibilityOfBook = bookModel.VisibilityOfBook == null ? record.VisibilityOfBook : bookModel.VisibilityOfBook;
                    record.Description = bookModel.Description == null ? record.Description : bookModel.Description;
                    record.UpdatedDate = DateTime.UtcNow;
                    record.UploadedBy = bookModel.UploadedBy == null ? record.UploadedBy : bookModel.UploadedBy;
                    record.ApproverName = bookModel.ApproverName == null ? record.ApproverName : bookModel.ApproverName;
                    record.ApproverDateTime = bookModel.ApproverDateTime == null ? record.ApproverDateTime : bookModel.ApproverDateTime;
                    record.ApprovalAttachmentsUrl = bookModel.ApprovalAttachmentsUrl == null || bookModel.ApprovalAttachmentsUrl == "" ? record.ApprovalAttachmentsUrl : bookModel.ApprovalAttachmentsUrl;
                    record.ArabicKeywords = bookModel.ArabicKeywords == null ? record.ArabicKeywords : bookModel.ArabicKeywords;
                    record.EnglishKeywords = bookModel.EnglishKeywords == null ? record.EnglishKeywords : bookModel.EnglishKeywords;
                    record.ThumbnailUrl = bookModel.ThumbnailUrl == null || bookModel.ThumbnailUrl == "" ? record.ThumbnailUrl : bookModel.ThumbnailUrl;
                    record.BookUrl = bookModel.BookUrl == null || bookModel.BookUrl == "" ? record.BookUrl : bookModel.BookUrl;
                    record.UniqueFolderName = bookModel.UniqueFolderName == null ? record.UniqueFolderName : bookModel.UniqueFolderName;

                    record.Author = bookModel.Author == "null" ? "" : bookModel.Author;
                    record.VolumeNumber = bookModel.VolumeNumber == "null" ? "" : bookModel.VolumeNumber;
                    record.Publication = bookModel.Publication == "null" ? "" : bookModel.Publication;
                    record.Version = bookModel.Version == "null" ? "" : bookModel.Version;
                    record.Description = bookModel.Description == "null" ? "" : bookModel.Description;
                    record.ArabicKeywords = bookModel.ArabicKeywords == "null" ? "" : bookModel.ArabicKeywords;
                    record.EnglishKeywords = bookModel.EnglishKeywords == "null" ? "" : bookModel.EnglishKeywords;
                    record.IsDownloadable = bookModel.IsDownloadable == null ? record.IsDownloadable : bookModel.IsDownloadable;
                    record.IsPrintable = bookModel.IsPrintable == null ? record.IsPrintable : bookModel.IsPrintable;


                    _context.SaveChanges();
                }

                //Delete unlinked books
                if (bookModel.UnLinkedBooksId != null)
                {
                    _booksService.DeleteItemInLinkedBooks(Convert.ToInt32(bookModel.BookID), bookModel.UnLinkedBooksId);
                }

                //Create new Item in Linked Books
                if (bookModel.LinkedBooksId != null)
                {
                    bool isLinked = _booksService.CreateItemInLinkedBooks(Convert.ToInt32(bookModel.BookID), bookModel.LinkedBooksId);
                }


            }
            else
            {
                string[] blobUrls = new string[3];
                string uniqueFolderName = DateTime.UtcNow.Ticks.ToString();

                if (HttpContext.Request.HasFormContentType)
                {
                    var data = await HttpContext.Request.ReadFormAsync();
                    bookModel.UpdatedDate = DateTime.UtcNow;
                    bookModel.UniqueFolderName = uniqueFolderName;

                    Array.Copy(await _booksService.StartBookUploadProcess(data, bookModel), blobUrls, 3);
                }

                ElTBook newBook = new ElTBook
                {
                    Category = bookModel.Category,
                    SubCategory = bookModel.SubCategory,
                    BookType = bookModel.BookType,
                    BookTitleArabic = bookModel.BookTitleArabic,
                    BookTitleEnglish = bookModel.BookTitleEnglish,
                    Author = bookModel.Author,
                    VolumeNumber = bookModel.VolumeNumber,
                    Publication = bookModel.Publication,
                    Version = bookModel.Version,
                    Country = bookModel.Country,
                    Language = bookModel.Language,
                    Year = bookModel.Year,
                    VisibilityOfBook = bookModel.VisibilityOfBook,
                    Description = bookModel.Description,
                    UpdatedDate = bookModel.UpdatedDate,
                    UploadedBy = bookModel.UploadedBy,
                    ApproverName = bookModel.ApproverName,
                    ApprovalAttachmentsUrl = blobUrls[2],
                    ApproverDateTime = bookModel.ApproverDateTime,
                    ArabicKeywords = bookModel.ArabicKeywords,
                    EnglishKeywords = bookModel.EnglishKeywords,
                    ThumbnailUrl = blobUrls[1],
                    BookUrl = blobUrls[0],
                    IsDeleted = false,
                    UniqueFolderName = uniqueFolderName,
                    IsDownloadable = bookModel.IsDownloadable,
                    IsPrintable = bookModel.IsPrintable
                };
                _context.ElTBooks.Add(newBook);
                _context.SaveChanges();

                bookModel.BookID = newBook.BookId;
                bookModel.BookUrl = blobUrls[0];
                bookModel.ThumbnailUrl = blobUrls[1];
                bookModel.ApprovalAttachmentsUrl = blobUrls[2];

                //Create new Item in Linked Books
                if (bookModel.LinkedBooksId != null)
                {
                    bool isLinked = _booksService.CreateItemInLinkedBooks(Convert.ToInt32(bookModel.BookID), bookModel.LinkedBooksId);
                }

            }

            return Ok(bookModel);
        }

        [HttpGet]
        [Route("GetCurrentUAETime")]
        public static DateTime GetCurrentUAETime()
        {
            // Get current UTC time
            DateTime utcNow = DateTime.UtcNow;

            // Define the UAE time zone (Gilf Standard Zone)
            TimeZoneInfo uaeTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Arabian Standard Time");

            //Convert UTC time to UAE local time
            DateTime uaelocalTime = TimeZoneInfo.ConvertTimeFromUtc(utcNow, uaeTimeZone);

            return uaelocalTime;
        }
        /// <summary>
        /// Search Books API
        /// </summary>
        /// <param name="searchBook"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("SearchBooks")]
        public IActionResult SearchBooks([FromBody] SearchElibraryBookMetadata searchBook)
        {
            BookSearchModel searchResults = _booksService.SearchBooks(searchBook.Query, searchBook.Filter, searchBook.Top, searchBook.Skip, searchBook.IsGeneralView);
            return Ok(searchResults);
        }

        // DELETE api/<BooksController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, string email, string reason)
        {
            var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")
                  ?? "Development";

            var configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: false)
                .AddJsonFile($"appsettings.{environment}.json", optional: true, reloadOnChange: false)
                .Build();
            // Read the file path from the configuration
            string logicAppUrl = configuration["LogicAppUrl"];


            var result = (from usm in _context.UserRoleMappings
                          join r in _context.Roles on usm.RoleId equals r.RoleId
                          join app in _context.Applications on r.ApplicationId equals app.ApplicationId
                          join u in _context.Users on usm.UserId equals u.Id
                          where r.Name == "ISCG Staff Admin" && app.ApplicationName == "Sharia Repository"
                          select u.EmailId).ToList();

            string approverEmails = string.Join(";", result);


            //Send for Approval
            var elTBook = new ElTBook();
            elTBook = (from x in _context.ElTBooks
                       where x.BookId == id
                       select x).First();

            string rawEmailBody = "<html>\r\n<body>  \r\n<br/>Dear Approver,\r\n<br/><br/>Your approval is required to process the deletion request of the book in E-Library. Below are the details of the book:\r\n<br/><p><b>Book Name:<<BookName>></b></p>\r\n<p><b>Author:</b><<Author>></p>\r\n<p><b>Book Url:</b><a href=\"<<Book Url>>\">Click here</a>\r\n</p>\r\n<p><b>Deleting Reason:</b><<DeletingReason>></p>\r\n<p><b>Deletion Requested By:</b><<RequestedBy>></p>\r\n<br/>\r\nThank you.\r\n</body>\r\n</html>";

            string emailBody = rawEmailBody.Replace("<<BookName>>", elTBook.BookTitleEnglish).Replace("<<Author>>", elTBook.Author).Replace("<<Book Url>>", elTBook.BookUrl).Replace("<<DeletingReason>>", reason).Replace("<<RequestedBy>>", email);

            var client = new RestClient(logicAppUrl);
            var request = new RestRequest("", Method.Post);
            request.Timeout = Timeout.InfiniteTimeSpan;
            request.AddHeader("Content-Type", "application/json");

            EmailDetails emailDetails = new EmailDetails();
            emailDetails.From = "AlMasdar Admin Team";
            emailDetails.To = approverEmails;
            emailDetails.Subject = "Delete Book (E-Library) - Approval Request";
            emailDetails.Body = emailBody;
            emailDetails.Id = id;
            emailDetails.Email = email;
            emailDetails.Reason = reason;
            emailDetails.EmailType = "Approval Email";
            string emailFinalDetails = JsonConvert.SerializeObject(emailDetails);

            request.AddParameter("application/json", emailFinalDetails, ParameterType.RequestBody);
            var response = client.Execute(request);

            var response2 = JsonConvert.SerializeObject(response);

            //RestResponse response = client.Execute(request);
            //return Ok("Request Received.");
            return Ok(response2);
        }

        [HttpDelete]
        [Route("FinalDelete")]
        public async Task<IActionResult> FinalDelete(int id, string email, string reason)
        {
            var elTBook = new ElTBook();
            elTBook = (from x in _context.ElTBooks
                       where x.BookId == id
                       select x).First();

            //Soft Deleting from Database Table
            elTBook.IsDeleted = true;
            elTBook.DeletedBy = email;
            elTBook.DeletingReason = reason;
            elTBook.DeletedOn = DateTime.UtcNow;

            //Deleting from Linked 
            var linkedDocumentsToDelete = _context.ElTLinkedBooks.Where(x => x.BookId == id || x.ReferBookId == id);
            _context.ElTLinkedBooks.RemoveRange(linkedDocumentsToDelete);

            _context.SaveChanges();

            string uniqueFolderName = elTBook.UniqueFolderName;

            //Deleting from Blob Storage and Removing from Search Index
            _booksService.DeleteBookfromAzureBlobAndSearchIndex(uniqueFolderName);

            ////Store book deletion data in DB

            //if (HttpContext.Request.HasFormContentType)
            //{
            //    var data = await HttpContext.Request.ReadFormAsync();

            //    string bloburl= await _booksService.StartDeletionAttachementUploadProcess(data);
            //}


            return Ok();
        }

        [HttpGet]
        [Route("GetAllAuthors")]
        public IActionResult GetAllAuthors()
        {
            var result = (from book in _context.ElTBooks
                          where book.IsDeleted == false
                          select book.Author).Distinct().ToList();
            return StatusCode(200, result);
        }

        [HttpGet]
        [Route("GetAllYears")]
        public IActionResult GetAllYears()
        {
            var result = (from book in _context.ElTBooks
                          where book.IsDeleted == false
                          select book.Year).Distinct().ToList();
            return StatusCode(200, result);
        }

        [HttpGet]
        [Route("GetAllVolumes")]
        public IActionResult GetAllVolumes()
        {
            var result = (from book in _context.ElTBooks
                          where book.IsDeleted == false
                          select book.VolumeNumber).Distinct().ToList();
            return StatusCode(200, result);

        }

        [HttpGet]
        [Route("GetAllPublications")]
        public IActionResult GetAllPublications()
        {
            var result = (from book in _context.ElTBooks
                          where book.IsDeleted == false
                          select book.Publication).Distinct().ToList();
            return StatusCode(200, result);
        }


        //[HttpDelete]
        //[Route("DeleteBooksfromSearchIndex")]
        //public IActionResult DeleteBooksfromSearchIndex()
        //{



        //    return StatusCode(200, result);
        //}

        [HttpGet]
        [Route("GetBooksByCategory")]
        public IActionResult GetBooksByCategory(int categoryId, string? Author, string? Publication, string? SubCategory, int? Year, string? Country, string? Language, int top = 10, int skip = 0, bool? IsGeneralView = false)
        {
            if (IsGeneralView == false)
            {
                var result2 = _context.ElTBooks
    .Join(_context.ElMSubCategories,
        book => book.SubCategory,
        subC => subC.Id,
        (book, subC) => new { Book = book, SubCategory = subC })
    .Join(_context.ElMCountries,
        joined => joined.Book.Country,
        country => country.Id,
        (joined, country) => new { joined.Book, joined.SubCategory, Country = country })
    .Join(_context.ElMLanguages,
        joined => joined.Book.Language,
        lang => lang.Id,
        (joined, lang) => new { joined.Book, joined.SubCategory, joined.Country, Language = lang })
    .Where(joined => joined.Book.IsDeleted == false && joined.Book.Category == categoryId)
    .OrderByDescending(joined => joined.Book.UpdatedDate)
    //.Skip(skip)
    //.Take(top)
    .Select(joined => new
    {
        joined.Book,
        SubCategoryTitle = joined.SubCategory.Title,
        CountryTitle = joined.Country.Title,
        LanguageTitle = joined.Language.Title,
        TotalRows = _context.ElTBooks.Count(book => book.IsDeleted == false && book.Category == categoryId)
    })
    .ToList();

                if (!string.IsNullOrEmpty(Author))
                {
                    result2 = result2.Where(r => r.Book.Author == Author).ToList();
                }

                if (!string.IsNullOrEmpty(Publication))
                {
                    result2 = result2.Where(r => r.Book.Publication == Publication).ToList();
                }

                if (!string.IsNullOrEmpty(SubCategory))
                {
                    result2 = result2.Where(r => r.SubCategoryTitle == SubCategory).ToList();
                }

                if (Year.HasValue)
                {
                    result2 = result2.Where(r => r.Book.Year == Year.Value).ToList();
                }

                if (!string.IsNullOrEmpty(Country))
                {
                    result2 = result2.Where(r => r.CountryTitle == Country).ToList();
                }

                if (!string.IsNullOrEmpty(Language))
                {
                    result2 = result2.Where(r => r.LanguageTitle == Language).ToList();
                }

                var finalResult = result2.Skip(skip).Take(top).ToList();


                if (result2.Count > 0)
                {
                    return StatusCode(200, new
                    {
                        result = finalResult,
                        TotalBooks = result2.Count
                    });
                }
                else
                {
                    return StatusCode(200, new
                    {
                        result = finalResult,
                        TotalBooks = 0
                    });
                }

            }
            else
            {
                var result2 = _context.ElTBooks
    .Join(_context.ElMSubCategories,
        book => book.SubCategory,
        subC => subC.Id,
        (book, subC) => new { Book = book, SubCategory = subC })
    .Join(_context.ElMCountries,
        joined => joined.Book.Country,
        country => country.Id,
        (joined, country) => new { joined.Book, joined.SubCategory, Country = country })
    .Join(_context.ElMLanguages,
        joined => joined.Book.Language,
        lang => lang.Id,
        (joined, lang) => new { joined.Book, joined.SubCategory, joined.Country, Language = lang })
    .Where(joined => joined.Book.IsDeleted == false && joined.Book.Category == categoryId && joined.Book.VisibilityOfBook == "Public")
    .OrderByDescending(joined => joined.Book.UpdatedDate)
    //.Skip(skip)
    //.Take(top)
    .Select(joined => new
    {
        joined.Book,
        SubCategoryTitle = joined.SubCategory.Title,
        CountryTitle = joined.Country.Title,
        LanguageTitle = joined.Language.Title,
        TotalRows = _context.ElTBooks.Count(book => book.IsDeleted == false && book.Category == categoryId && book.VisibilityOfBook == "Public")
    })
    .ToList();

                if (!string.IsNullOrEmpty(Author))
                {
                    result2 = result2.Where(r => r.Book.Author == Author).ToList();
                }

                if (!string.IsNullOrEmpty(Publication))
                {
                    result2 = result2.Where(r => r.Book.Publication == Publication).ToList();
                }

                if (!string.IsNullOrEmpty(SubCategory))
                {
                    result2 = result2.Where(r => r.SubCategoryTitle == SubCategory).ToList();
                }

                if (Year.HasValue)
                {
                    result2 = result2.Where(r => r.Book.Year == Year.Value).ToList();
                }

                if (!string.IsNullOrEmpty(Country))
                {
                    result2 = result2.Where(r => r.CountryTitle == Country).ToList();
                }

                if (!string.IsNullOrEmpty(Language))
                {
                    result2 = result2.Where(r => r.LanguageTitle == Language).ToList();
                }

                var finalResult = result2.Skip(skip).Take(top).ToList();


                if (result2.Count > 0)
                {
                    return StatusCode(200, new
                    {
                        result = finalResult,
                        TotalBooks = result2.Count()
                    });
                }
                else
                {
                    return StatusCode(200, new
                    {
                        result = finalResult,
                        TotalBooks = 0
                    });
                }

            }


        }                                                                           

        [HttpGet]
        [Route("GetBooksByCategoryFiltersData")]
        public IActionResult GetBooksByCategoryFiltersData(int? categoryId, bool? IsGeneralView = false)
        {
            if (IsGeneralView == false)
            {
                var result = _context.ElTBooks
   .Join(_context.ElMSubCategories,
       book => book.SubCategory,
       subC => subC.Id,
       (book, subC) => new { Book = book, SubCategory = subC })
   .Join(_context.ElMCountries,
       joined => joined.Book.Country,
       country => country.Id,
       (joined, country) => new { joined.Book, joined.SubCategory, Country = country })
   .Join(_context.ElMLanguages,
       joined => joined.Book.Language,
       lang => lang.Id,
       (joined, lang) => new { joined.Book, joined.SubCategory, joined.Country, Language = lang })
   .Where(joined => joined.Book.IsDeleted == false && joined.Book.Category == categoryId)
   .OrderByDescending(joined => joined.Book.UpdatedDate)
   .Select(joined => new
   {
       joined.Book,
       SubCategoryTitle = joined.SubCategory.Title,
       CountryTitle = joined.Country.Title,
       LanguageTitle = joined.Language.Title,
       TotalRows = _context.ElTBooks.Count(book => book.IsDeleted == false && book.Category == categoryId)
   })
   .ToList();

                List<string> commonSubCategory = new List<string>();
                List<string> subCategories = new List<string>();

                if (categoryId != null)
                {
                    subCategories = _context.ElMSubCategories
                         .Where(subCategory => subCategory.CategoryId == categoryId)
                         .Select(subCategory => subCategory.Title).ToList();

                    List<string> Authors = (from kvp in result select kvp.Book.Author).Distinct().ToList();
                    List<string> Publications = (from kvp in result select kvp.Book.Publication).Distinct().ToList();
                    List<int?> Year = (from kvp in result select kvp.Book.Year).Distinct().ToList();
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
                    List<string> Authors = (from kvp in result select kvp.Book.Author).Distinct().ToList();
                    List<string> Publications = (from kvp in result select kvp.Book.Publication).Distinct().ToList();
                    List<int?> Year = (from kvp in result select kvp.Book.Year).Distinct().ToList();
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
                var result = _context.ElTBooks
   .Join(_context.ElMSubCategories,
       book => book.SubCategory,
       subC => subC.Id,
       (book, subC) => new { Book = book, SubCategory = subC })
   .Join(_context.ElMCountries,
       joined => joined.Book.Country,
       country => country.Id,
       (joined, country) => new { joined.Book, joined.SubCategory, Country = country })
   .Join(_context.ElMLanguages,
       joined => joined.Book.Language,
       lang => lang.Id,
       (joined, lang) => new { joined.Book, joined.SubCategory, joined.Country, Language = lang })
   .Where(joined => joined.Book.IsDeleted == false && joined.Book.Category == categoryId && joined.Book.VisibilityOfBook == "Public")
   .OrderByDescending(joined => joined.Book.UpdatedDate)
   .Select(joined => new
   {
       joined.Book,
       SubCategoryTitle = joined.SubCategory.Title,
       CountryTitle = joined.Country.Title,
       LanguageTitle = joined.Language.Title,
       TotalRows = _context.ElTBooks.Count(book => book.IsDeleted == false && book.Category == categoryId && book.VisibilityOfBook == "Public")
   })
   .ToList();

                List<string> commonSubCategory = new List<string>();
                List<string> subCategories = new List<string>();

                if (categoryId != null)
                {
                    subCategories = _context.ElMSubCategories
                         .Where(subCategory => subCategory.CategoryId == categoryId)
                         .Select(subCategory => subCategory.Title).ToList();

                    List<string> Authors = (from kvp in result select kvp.Book.Author).Distinct().ToList();
                    List<string> Publications = (from kvp in result select kvp.Book.Publication).Distinct().ToList();
                    List<int?> Year = (from kvp in result select kvp.Book.Year).Distinct().ToList();
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
                    List<string> Authors = (from kvp in result select kvp.Book.Author).Distinct().ToList();
                    List<string> Publications = (from kvp in result select kvp.Book.Publication).Distinct().ToList();
                    List<int?> Year = (from kvp in result select kvp.Book.Year).Distinct().ToList();
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
        [Route("TestLogicApp")]
        public IActionResult TestLogicApp()
        {
            var client = new RestClient("https://prod-12.uaenorth.logic.azure.com:443/workflows/4a026a89ae6348949e39842a83665140/triggers/manual/paths/invoke?api-version=2016-10-01&sp=%2Ftriggers%2Fmanual%2Frun&sv=1.0&sig=rDY8cnqvtyC-Vk4ZAishZ-u4_82rWzAIyIheSk1rpcY");
            var request = new RestRequest("", Method.Post);
            request.Timeout = Timeout.InfiniteTimeSpan;
            request.AddHeader("Content-Type", "application/json");

            EmailDetails emailDetails = new EmailDetails();
            emailDetails.From = "AlMasdar Admin Team";
            emailDetails.To = "soubhagya.satapathy@acuvate.com";
            emailDetails.Subject = "Delete Book (E-Library) - Approval Request";
            emailDetails.Body = "TestLogicApp now";
            emailDetails.Id = 3;
            emailDetails.Email = "random@email.com";
            emailDetails.Reason = "test reason it is";
            string emailFinalDetails = JsonConvert.SerializeObject(emailDetails);

            request.AddParameter("application/json", emailFinalDetails, ParameterType.RequestBody);
            RestResponse response = client.Execute(request);
            return Ok(response);

        }

        //[HttpGet]
        //[Route("GetBlobData")]
        //public dynamic GetBlobData(string url)
        //{
        //    DataLakeFileClient fileClient = _booksService.DownloadFile(url);

        //    var downloadResponse = fileClient.OpenRead();
        //    byte[] byteData = _booksService.StreamToByteArray(downloadResponse);

        //    Uri uri = new Uri(url);
        //    string filename = System.IO.Path.GetFileName(uri.LocalPath);

        //    if (filename.EndsWith(".pdf"))
        //    {
        //        var contentDisposition = new ContentDisposition
        //        {
        //            FileName = filename,
        //            Inline = true // Display the file inline in the browser
        //        };
        //        Response.Headers.Add("Content-Disposition", contentDisposition.ToString());
        //        return new FileStreamResult(new MemoryStream(byteData), "application/pdf");

        //    }
        //    else
        //    {
        //        return File(byteData, "image/jpeg");
        //    }

        //}

        [HttpGet]
        [Route("GetBlobData")]
        public IActionResult GetBlobData(string url)
        {
            DataLakeFileClient fileClient = _booksService.DownloadFile(url);

            var downloadResponse = fileClient.OpenRead();
            byte[] byteData = _booksService.StreamToByteArray(downloadResponse);

            Uri uri = new Uri(url);
            string filename = System.IO.Path.GetFileName(uri.LocalPath);

            // Determine the MIME type based on file extension
            string mimeType;
            if (filename.EndsWith(".pdf"))
            {
                mimeType = "application/pdf";
            }
            else if (filename.EndsWith(".bmp"))
            {
                mimeType = "image/bmp";
            }
            else if (filename.EndsWith(".docx"))
            {
                mimeType = "application/vnd.openxmlformats-officedocument.wordprocessingml.document";
            }
            else if (filename.EndsWith(".msg"))
            {
                mimeType = "application/vnd.ms-outlook";
            }
            else if (filename.EndsWith(".eml"))
            {
                mimeType = "message/rfc822";
            }
            else if (filename.EndsWith(".png"))
            {
                mimeType = "image/png";
            }
            else if (filename.EndsWith(".jpg") || filename.EndsWith(".jpeg"))
            {
                mimeType = "image/jpeg";
            }
            else
            {
                // Default to octet-stream for unknown file types
                mimeType = "application/octet-stream";
            }

            var contentDisposition = new ContentDisposition
            {
                FileName = filename,
                Inline = true // Set to false to force download
            };

            // Set the Content-Disposition header
            Response.Headers.Add("Content-Disposition", contentDisposition.ToString());

            // Return a FileStreamResult with the appropriate MIME type
            return new FileStreamResult(new MemoryStream(byteData), mimeType);
        }


        //[HttpGet]
        //[Route("translate")]
        //public dynamic Translate(string arabicText)
        //{
        //    string text= _booksService.TranslateToEnglish(arabicText);
        //    return text;
        //}

        [HttpDelete]
        [Route("ClearContainer")]
        public IActionResult ClearContainer()
        {
            bool IsSuccess = _booksService.DeleteElibContainerData();

            if (IsSuccess)
            {
                return StatusCode(200, new
                {
                    Message = "Container data deleted successfully",
                });
            }
            else
            {
                return StatusCode(500, new
                {
                    Message = "Unsuccessfull Operation",
                });
            }

        }



        public static string RemoveSpecialCharacters(string str)
        {
            StringBuilder sb = new StringBuilder();
            foreach (char c in str)
            {
                if ((c >= '0' && c <= '9') || (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z') || c == '.' || c == '_' || c == ' ' || c == '-' || c == ',')
                {
                    sb.Append(c);
                }
            }
            return sb.ToString();
        }
        [HttpDelete]
        [Route("ClearSearchIndex")]
        public IActionResult ClearSearchIndex()
        {
            bool IsSuccess = _booksService.DeleteBooksFromSearchIndex();

            if (IsSuccess)
            {
                return StatusCode(200, new
                {
                    Message = "Search index data deleted successfully",
                });
            }
            else
            {
                return StatusCode(500, new
                {
                    Message = "Unsuccessfull Operation",
                });
            }

        }

        /// <summary>
        /// Custom API endpoint to decode and split the Category metadata from Base64 encoded string to a list of strings.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPost("SplitCategoryMetadata")]
        public IActionResult SplitCategoryMetadata([FromBody] SearchSkillRequest request)
        {
            var response = new SearchSkillResponse();
            _logger.LogInformation(
        "SplitCategoryMetadata controller action was reached.");
            var errorlog = new ErrorLog
            {
                Apiurl = "SplitCategoryMetadata controller action was reached.",
                Path = "Custom skill set API call"
            };
            _context.ErrorLogs.Add(errorlog);
            _context.SaveChanges();
            foreach (var record in request.Values)
            {
                response.Values.Add(new SearchSkillResponseRecord
                {
                    RecordId = record.RecordId,
                    Data = new SearchSkillResponseData
                    {
                        CategoryDecoded = DecodeAndSplit(record.Data.Category)
                    }
                });
            }
            return Ok(response);
        }

        /// <summary>
        /// logic to decode the Base64 encoded string and split it into a list of strings.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private static List<string> DecodeAndSplit(string? value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return new List<string>();

            try
            {
                // Decode Base64
                byte[] bytes = Convert.FromBase64String(value);
                string decoded = Encoding.UTF8.GetString(bytes);

                return decoded
                .Split(',', StringSplitOptions.RemoveEmptyEntries)
                .Select(x => x.Trim())
                .Where(x => !string.IsNullOrWhiteSpace(x))
                .Distinct(StringComparer.OrdinalIgnoreCase).ToList();
            }
            catch
            {
                // if the value is not valid Base64, treat it as plain text
                return value
                .Split(',', StringSplitOptions.RemoveEmptyEntries)
                .Select(x => x.Trim())
                .Where(x => !string.IsNullOrWhiteSpace(x))
                .Distinct(StringComparer.OrdinalIgnoreCase).ToList();
            }
        }





    }
    public class FileInfo
    {
        public PathProperties Properties { get; set; }
        public Stream Stream { get; set; }
        public long Length { get; set; }
        public string Name { get; set; }
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
    public class EmailDetails
    {
        public string From { get; set; }
        public string To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public int Id { get; set; }
        public string Email { get; set; }
        public string Reason { get; set; }
        public string EmailType { get; set; }


    }
}
