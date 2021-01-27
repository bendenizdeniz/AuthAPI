using LoginDbApp.Businnes.Abstract;
using LoginDbApp.DataAccess;
using LoginDbApp.Entities;
using LoginDbApp.Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoginDbApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService bookService;

        public BookController(IBookService bookService)
        {
            this.bookService = bookService;
        }

        [HttpPost]
        [Route("[Action]")]
        public BookResult CreateBook([FromBody] Book book)
        {
            return bookService.CreateBook(book);
        }

        [HttpGet]
        [Route("[Action]")]
        public List<Book> GetAllBooks()
        {
            return bookService.GetAllBooks();
        }

        [HttpGet("{id}")]
        public Book Get(int id)
        {
            return bookService.GetBookById(id);
        }

        [HttpPut]
        public Book Put([FromBody] Book book)
        {
            return bookService.UpdateBook(book);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            bookService.DeleteBook(id);
        }

        [HttpPost]
        [Route("[Action]")]
        public LikeResult LikeBook([FromBody] Like like)
        {
            return bookService.AddLike(like);
        }

        [HttpPost]
        [Route("[Action]")]
        public ReadResult ReadBook([FromBody] Read read)
        {
            return bookService.AddRead(read);
        }


        [HttpGet("GetWhoLiked/{idBook}")]
        public IActionResult GetWhoLiked(int idBook)
        {
            var bookDbContext = new LoginAppDbContext();
            var query = from user in bookDbContext.Users
                        join like in bookDbContext.Likes on user.id equals like.IDUser
                        where like.IDBook == idBook
                        select new
                        {
                            Name = user.Name
                        };
            return Ok(query);

        }


        [HttpGet("GetWhoRead/{idBook}")]
        public IActionResult GetWhoRead(int idBook)
        {
            var bookDbContext = new LoginAppDbContext();
            var query = from user in bookDbContext.Users
                        join read in bookDbContext.Reads on user.id equals read.IDUser
                        where read.IDBook == idBook
                        select new
                        {
                            Name = user.Name
                        };
            return Ok(query);

        }

        [HttpGet("GetILiked/{idUser}")]
        public IActionResult GetILiked(int idUser)
        {
            var bookDbContext = new LoginAppDbContext();
            var query = from book in bookDbContext.Books
                        join like in bookDbContext.Likes on book.ID equals like.IDBook
                        where like.IDUser == idUser
                        select new
                        {
                            ID = book.ID,
                            Reader = book.Reader,
                            BookName = book.BookName,
                            AuthorName = book.AuthorName,
                            Comment = book.Comment,
                            Likes = book.Likes,
                            IDUser = book.IDUser,
                            PostedTime = book.PostedTime
                        };
            return Ok(query);

        }

        [HttpGet("GetIRead/{idUser}")]
        public IActionResult GetIRead(int idUser)
        {
            var bookDbContext = new LoginAppDbContext();
            var query = from book in bookDbContext.Books
                        join read in bookDbContext.Reads on book.ID equals read.IDBook
                        where read.IDUser == idUser
                        select new
                        {
                            ID = book.ID,
                            Reader = book.Reader,
                            BookName = book.BookName,
                            AuthorName = book.AuthorName,
                            Comment = book.Comment,
                            Likes = book.Likes,
                            IDUser = book.IDUser,
                            PostedTime = book.PostedTime
                        };
            return Ok(query);

        }

        [HttpGet("GetWhoPostedGender/{idBook}")]
        public IActionResult GetWhoPostedGender(int idBook)
        {
            var bookDbContext = new LoginAppDbContext();
            var query = from book in bookDbContext.Books
                        join user in bookDbContext.Users on book.IDUser equals user.id
                        where book.ID == idBook
                        select new
                        {
                            Gender = user.Gender
                        };
            return Ok(query);

        }




    }
}
