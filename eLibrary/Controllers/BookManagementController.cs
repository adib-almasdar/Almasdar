using CommonLib.Data;
using eLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;



namespace eLibrary.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookManageentController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public BookManageentController(ApplicationDbContext context)
        {
            _context = context;
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

            using (var context = new ApplicationDbContext())
            {
                context.ElTRecentViews.Add(recentView);
                context.SaveChanges();
            }
            return Ok(recentView);
        }




        [HttpPut]
        public IActionResult UpdateByBookId([FromQuery] int bookId, [FromQuery] string userEmail, MyRecenetViewModel recentViews)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingRecentViews = _context.ElTRecentViews.Where(rv => rv.BookId == bookId && rv.UserEmail == userEmail).ToList();

            if (existingRecentViews.Count == 0)
            {
                return NotFound();
            }

            foreach (var existingRecentView in existingRecentViews)
            {
                existingRecentView.PageNumber = recentViews.PageNumber;
                existingRecentView.ViewDate = DateTime.UtcNow;
            }

            _context.SaveChanges();

            return Ok(existingRecentViews);
        }



    }
}