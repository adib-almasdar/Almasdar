using CommonLib.Data;
using eLibrary.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RestSharp;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace eLibrary.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AceDashboardController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AceDashboardController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: api/<AceDashboardController>
        [HttpGet]
        [Route("GetCountByLanguage")]
        public IActionResult GetbyLanguage(bool? IsGeneralView = false)
        {
            if (IsGeneralView == false)
            {
                var result = from lan in _context.ElMLanguages
                             join hyb in (
                                 from bs in _context.ElTBooks
                                 join ls in _context.ElMLanguages on bs.Language equals ls.Id
                                 where bs.IsDeleted == false
                                 group bs by bs.Language into g
                                 select new
                                 {
                                     Lang = g.Key,
                                     TotalBooks = g.Count()
                                 }
                             ) on lan.Id equals hyb.Lang into temp
                             from hyb in temp.DefaultIfEmpty()
                             where lan.IsDeleted == false
                             select new
                             {
                                 lan.Title,
                                 LanguageId = lan.Id,
                                 TotalBooks = hyb.TotalBooks != null ? hyb.TotalBooks : 0,
                                 lan.ThumbnailUrl
                             };

                return Ok(result);
            }
            else
            {
                var result = from lan in _context.ElMLanguages
                             join hyb in (
                                 from bs in _context.ElTBooks
                                 join ls in _context.ElMLanguages on bs.Language equals ls.Id
                                 where bs.IsDeleted == false && bs.VisibilityOfBook == "Public"
                                 group bs by bs.Language into g
                                 select new
                                 {
                                     Lang = g.Key,
                                     TotalBooks = g.Count()
                                 }
                             ) on lan.Id equals hyb.Lang into temp
                             from hyb in temp.DefaultIfEmpty()
                             where lan.IsDeleted == false
                             select new
                             {
                                 lan.Title,
                                 LanguageId = lan.Id,
                                 TotalBooks = hyb.TotalBooks != null ? hyb.TotalBooks : 0,
                                 lan.ThumbnailUrl
                             };

                return Ok(result);
            }
        }

        [HttpGet]
        [Route("GetCountByCategory")]
        public IActionResult GetbyCategory(int languageId, bool? IsGeneralView = false)
        {
            if (IsGeneralView == false)
            {
                var result = from lan in _context.ElMCategories
                             join hyb in (
                                 from bs in _context.ElTBooks
                                 join ls in _context.ElMCategories on bs.Category equals ls.Id
                                 where bs.Language == languageId && bs.IsDeleted == false
                                 group bs by bs.Category into g
                                 select new
                                 {
                                     Cat = g.Key,
                                     TotalBooks = g.Count()
                                 }
                             ) on lan.Id equals hyb.Cat into temp
                             from hyb in temp.DefaultIfEmpty()
                             where lan.IsDeleted != true
                             select new
                             {
                                 lan.Title,
                                 lan.ArabicTitle,
                                 lan.Id,
                                 TotalBooks = hyb.TotalBooks != null ? hyb.TotalBooks : 0,
                                 lan.ThumbnailUrl
                             };

                return Ok(result);
            }
            else
            {
                var result = from lan in _context.ElMCategories
                             join hyb in (
                                 from bs in _context.ElTBooks
                                 join ls in _context.ElMCategories on bs.Category equals ls.Id
                                 where bs.Language == languageId && bs.IsDeleted == false && bs.VisibilityOfBook == "Public"
                                 group bs by bs.Category into g
                                 select new
                                 {
                                     Cat = g.Key,
                                     TotalBooks = g.Count()
                                 }
                             ) on lan.Id equals hyb.Cat into temp
                             from hyb in temp.DefaultIfEmpty()
                             where lan.IsDeleted != true
                             select new
                             {
                                 lan.Title,
                                 lan.ArabicTitle,
                                 lan.Id,
                                 TotalBooks = hyb.TotalBooks != null ? hyb.TotalBooks : 0,
                                 lan.ThumbnailUrl
                             };

                return Ok(result);
            }


        }

        [HttpGet]
        [Route("GetTotalViews")]
        public IActionResult GetTotalViews()
        {
            var totalViews = _context.ElTRecentViews.Count();
            return StatusCode(200, new
            {
                TotalViews = totalViews
            });

        }



        [HttpGet]
        [Route("Search")]
        public IActionResult Search()
        {
            var client = new RestClient("https://almasdar-search-dev-svc.search.windows.net/indexes/test-index/docs?api-version=2021-04-30-Preview&search=*");
            var request = new RestRequest("", Method.Get);
            request.Timeout = Timeout.InfiniteTimeSpan;
            request.AddHeader("api-key", "XdheSxyD2efBeoOgeeVTrsjtkCOzkyqrIu65uCxPWxAzSeDJikJb");
            RestResponse response = client.Execute(request);
            return StatusCode(200, new
            {
                Results = response.Content
            });

        }



    }



}
