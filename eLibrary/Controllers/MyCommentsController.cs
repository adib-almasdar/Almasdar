using CommonLib.Data;
using eLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;



namespace eLibrary.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MyCommentsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public MyCommentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var recentViews = _context.ElTBookMarkComments.ToList();
            return Ok(recentViews);
        }


        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var recentViews = _context.ElTBookMarkComments.Where(a => a.Id == id).FirstOrDefault();
            return Ok(recentViews);
        }




        [HttpGet]
        [Route("GetDetailsByCommentBy")]
        public IActionResult GetCommentsByCommentBy(string commentBy, string bookTitle = "all", string comment = "all", int count = -1, bool? IsGeneralView = false)
        {
            if (IsGeneralView == false)
            {
                var query = from c in _context.ElTBookMarkComments
                            join r in _context.ElTBookMarkComments on c.ReferMessageId equals r.Id into cr
                            from r in cr.DefaultIfEmpty()
                            join b in _context.ElTBooks on c.BookId equals b.BookId
                            where c.CommentBy == commentBy && b.IsDeleted == false && c.IsDeleted == false && (c.ReferMessageId == null || c.ReferMessage.IsDeleted != true)
                            select new
                            {
                                Id = c.Id,
                                ReferMessageId = c.ReferMessageId,
                                BookId = c.BookId,
                                BookTitleArabic = b.BookTitleArabic,
                                BookTitleEnglish = b.BookTitleEnglish,
                                Author = b.Author,
                                Year = b.Year,
                                ThumbnailUrl = b.ThumbnailUrl,
                                Description = b.Description,
                                BookUrl = b.BookUrl,
                                VolumeNumber = b.VolumeNumber,
                                Message = c.Message,
                                PageNumber = c.PageNumber,
                                Highlight = c.Highlight,
                                CommentDate = c.CommentDate,
                                CommentBy = c.CommentBy,
                                IsPrivate = c.IsPrivate,
                                IsDeleted = c.IsDeleted,
                                ReferMessage = r
                            };

                if (bookTitle.ToLower() != "all")
                {
                    query = query.Where(q => q.BookTitleEnglish.ToLower().Contains(bookTitle.ToLower()) || q.BookTitleArabic.ToLower().Contains(bookTitle.ToLower()));
                }

                if (comment.ToLower() != "all")
                {
                    query = query.Where(q => q.Message.ToLower().Contains(comment.ToLower()));
                }

                var results = query.GroupBy(q => q.BookId).Select(g => new
                {
                    BookId = g.Key,
                    BookTitleEnglish = g.First().BookTitleEnglish,
                    BookTitleArabic = g.First().BookTitleArabic,
                    Author = g.First().Author,
                    Year = g.First().Year,
                    ThumbnailUrl = g.First().ThumbnailUrl,
                    Description = g.First().Description,
                    BookUrl = g.First().BookUrl,
                    VolumeNumber = g.First().VolumeNumber,
                    Comments = g.Select(q => new
                    {
                        Id = q.Id,
                        ReferMessageId = q.ReferMessageId,
                        Message = q.Message,
                        PageNumber = q.PageNumber,
                        Highlight = q.Highlight,
                        CommentDate = q.CommentDate,
                        CommentBy = q.CommentBy,
                        IsPrivate = q.IsPrivate,
                        IsDeleted = q.IsDeleted,
                        ReferMessage = q.ReferMessage
                    }).ToList()
                }).ToList();

                int totalCount = results.Count();

                if (count == -1)
                {
                    count = totalCount;
                }

                results = results.Take(count).ToList();

                if (results == null)
                {
                    return NotFound();
                }

                return Ok(new { TotalCount = totalCount, Data = results });
            }
            else
            {
                var query = from c in _context.ElTBookMarkComments
                            join r in _context.ElTBookMarkComments on c.ReferMessageId equals r.Id into cr
                            from r in cr.DefaultIfEmpty()
                            join b in _context.ElTBooks on c.BookId equals b.BookId
                            where c.CommentBy == commentBy && b.IsDeleted == false && b.VisibilityOfBook == "Public" && c.IsDeleted == false && (c.ReferMessageId == null || c.ReferMessage.IsDeleted != true)
                            select new
                            {
                                Id = c.Id,
                                ReferMessageId = c.ReferMessageId,
                                BookId = c.BookId,
                                BookTitleArabic = b.BookTitleArabic,
                                BookTitleEnglish = b.BookTitleEnglish,
                                Author = b.Author,
                                Year = b.Year,
                                ThumbnailUrl = b.ThumbnailUrl,
                                Description = b.Description,
                                BookUrl = b.BookUrl,
                                VolumeNumber = b.VolumeNumber,
                                Message = c.Message,
                                PageNumber = c.PageNumber,
                                Highlight = c.Highlight,
                                CommentDate = c.CommentDate,
                                CommentBy = c.CommentBy,
                                IsPrivate = c.IsPrivate,
                                IsDeleted = c.IsDeleted,
                                ReferMessage = r
                            };

                if (bookTitle.ToLower() != "all")
                {
                    query = query.Where(q => q.BookTitleEnglish.ToLower().Contains(bookTitle.ToLower()) || q.BookTitleArabic.ToLower().Contains(bookTitle.ToLower()));
                }

                if (comment.ToLower() != "all")
                {
                    query = query.Where(q => q.Message.ToLower().Contains(comment.ToLower()));
                }

                var results = query.GroupBy(q => q.BookId).Select(g => new
                {
                    BookId = g.Key,
                    BookTitleEnglish = g.First().BookTitleEnglish,
                    BookTitleArabic = g.First().BookTitleArabic,
                    Author = g.First().Author,
                    Year = g.First().Year,
                    ThumbnailUrl = g.First().ThumbnailUrl,
                    Description = g.First().Description,
                    BookUrl = g.First().BookUrl,
                    VolumeNumber = g.First().VolumeNumber,
                    Comments = g.Select(q => new
                    {
                        Id = q.Id,
                        ReferMessageId = q.ReferMessageId,
                        Message = q.Message,
                        PageNumber = q.PageNumber,
                        Highlight = q.Highlight,
                        CommentDate = q.CommentDate,
                        CommentBy = q.CommentBy,
                        IsPrivate = q.IsPrivate,
                        IsDeleted = q.IsDeleted,
                        ReferMessage = q.ReferMessage
                    }).ToList()
                }).ToList();

                int totalCount = results.Count();

                if (count == -1)
                {
                    count = totalCount;
                }

                results = results.Take(count).ToList();

                if (results == null)
                {
                    return NotFound();
                }

                return Ok(new { TotalCount = totalCount, Data = results });
            }
        }



        [HttpGet]
        [Route("GetPublicCommentsbyBookId")]
        public IActionResult GetPublicCommetsbyCommentBy(int bookId)
        {
            var BookId = _context.ElTBookMarkComments
                       .Where(x => x.BookId == bookId && x.IsPrivate == false)
                       .ToList();

            return Ok(BookId);
        }



        [HttpPost]

        public IActionResult Create([FromBody] MyCommentsModel myComments)
        {
            var myComment = new ElTBookMarkComment();
            if (!(myComment.ReferMessageId > 0))
            {
                myComment.ReferMessageId = null;
            }

            myComment.ReferMessageId = myComments.ReferMessageId;
            myComment.BookId = myComments.BookId;
            myComment.Message = myComments.Message;
            myComment.PageNumber = myComments.PageNumber;
            myComment.Highlight = myComments.Highlight;
            myComment.CommentDate = myComments.CommentDate;
            myComment.CommentBy = myComments.CommentBy;
            myComment.IsPrivate = myComments.IsPrivate;
            myComment.IsDeleted = myComments.IsDeleted;
            _context.Add(myComment);
            _context.SaveChanges();

            return Ok(myComment);
        }



        //[HttpGet]
        //[Route("{commentBy}")]
        //public IActionResult GetCommentDetails(string commentBy, string bookTitle = "all", string comment = "all", int count = -1)
        //{
        //    try
        //    {
        //        var query = (from myComment in _context.ElTBookMarkComments
        //                     join book in _context.ElTBooks on myComment.BookId equals book.BookId
        //                     where myComment.CommentBy == commentBy
        //                     select new
        //                     {
        //                         BookId = book.BookId,
        //                         BookTitleArabic = book.BookTitleArabic,
        //                         BookTitleEnglish = book.BookTitleEnglish,
        //                         Author = book.Author,
        //                         Year = book.Year,
        //                         ThumbnailUrl = book.ThumbnailUrl,
        //                         Description = book.Description,
        //                         BookUrl = book.BookUrl,
        //                         VolumeNumber = book.VolumeNumber,
        //                         ReferMessageId = myComment.ReferMessageId,
        //                         Message = myComment.Message,
        //                         PageNumber = myComment.PageNumber,
        //                         Highlight = myComment.Highlight,
        //                         CommentDate = myComment.CommentDate,
        //                         CommentBy = myComment.CommentBy,
        //                         IsPrivate = myComment.IsPrivate
        //                     });

        //        if (bookTitle.ToLower() != "all")
        //        {
        //            query = query.Where(q => q.BookTitleEnglish.ToLower().Contains(bookTitle.ToLower()) || q.BookTitleArabic.ToLower().Contains(bookTitle.ToLower()));
        //        }

        //        if (comment.ToLower() != "all")
        //        {
        //            query = query.Where(q => q.Message.ToLower().Contains(comment.ToLower()));
        //        }

        //        int totalCount = query.Count();

        //        if (count == -1)
        //        {
        //            count = totalCount;
        //        }

        //        var results = query.Take(count).ToList();

        //        if (results == null)
        //        {
        //            return NotFound();
        //        }

        //        return Ok(new { TotalCount = totalCount, Data = results });
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, ex.Message);
        //    }
        //}


        [HttpGet]
        [Route("book/{BookId:int}")]
        public IActionResult GetCommentByBookId(int BookId, int pageNumber)
        {
            var result = (from myComment in _context.ElTBookMarkComments
                          join book in _context.ElTBooks on myComment.BookId equals book.BookId
                          where myComment.BookId == BookId && myComment.PageNumber == pageNumber && book.IsDeleted == false && myComment.IsDeleted == false && (myComment.ReferMessageId == null || myComment.ReferMessage.IsDeleted != true)
                          select new
                          {
                              Id = myComment.Id,
                              BookId = book.BookId,
                              BookTitleArabic = book.BookTitleArabic,
                              BookTitleEnglish = book.BookTitleEnglish,
                              Author = book.Author,
                              Year = book.Year,
                              ThumbnailUrl = book.ThumbnailUrl,
                              Description = book.Description,
                              BookUrl = book.BookUrl,
                              VolumeNumber = book.VolumeNumber,
                              ReferMessageId = myComment.ReferMessageId,
                              Message = myComment.Message,
                              PageNumber = myComment.PageNumber,
                              Highlight = myComment.Highlight,
                              CommentDate = myComment.CommentDate,
                              CommentBy = myComment.CommentBy,
                              IsPrivate = myComment.IsPrivate,
                              IsDeleted = myComment.IsDeleted
                          }).ToList();

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPut]
        [Route("UpdateByMesageId")]

        public IActionResult UpdateMessage(int messageId, [FromBody] MyCommentsModel myComments)
        {
            var myComment = _context.ElTBookMarkComments.FirstOrDefault(c => c.Id == messageId);

            if (myComment == null)
            {
                return NotFound();
            }

            myComment.Message = myComments.Message;
            myComment.CommentDate = myComments.CommentDate;
            myComment.IsPrivate = myComments.IsPrivate;
            _context.SaveChanges();

            return Ok(myComment);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {

            var eiTComments = new ElTBookMarkComment();
            eiTComments = (from x in _context.ElTBookMarkComments
                           where x.Id == id
                           select x).First();
            eiTComments.IsDeleted = true;
            _context.SaveChanges();
            return Ok();

        }

    }
}
