using LoginDbApp.DataAccess.Abstract;
using LoginDbApp.Entities;
using LoginDbApp.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LoginDbApp.DataAccess.Concrete
{
    public class BookRepository : IBookRepository
    {
        public LikeResult AddLike(Like like)
        {

            using (var bookDbContext = new LoginAppDbContext())
            {
                var isLiked = bookDbContext.Likes.Where(X => X.IDBook == like.IDBook && X.IDUser == like.IDUser).ToList();

                if (isLiked.Count == 0)
                {
                    bookDbContext.Likes.Add(like);
                    bookDbContext.SaveChanges();
                    return new LikeResult { IsSuccess = true, Message = "You liked" };
                }


                bookDbContext.Likes.Remove(isLiked[0]);
                bookDbContext.SaveChanges();
                return new LikeResult { IsSuccess = false, Message = "You disliked" };

            }

        }

        public Book CreateBook(Book book)
        {
            using (var bookDbContext = new LoginAppDbContext())
            {
                bookDbContext.Books.Add(book);
                bookDbContext.SaveChanges();
                return book;
            }
        }

        public void DeleteBook(int id)
        {
            using (var bookDbContext = new LoginAppDbContext())
            {
                var deletedBook = GetBookById(id);
                bookDbContext.Books.Remove(deletedBook);
                bookDbContext.SaveChanges();
            }
        }

        public List<Book> GetAllBooks()
        {
            using (var bookDbContext = new LoginAppDbContext())
            {
                return bookDbContext.Books.ToList();
            }
        }

        public Book GetBookById(int id)
        {
            using (var bookDbContext = new LoginAppDbContext())
            {
                return bookDbContext.Books.Find(id);
            }
        }

        public Book UpdateBook(Book book)
        {
            using (var bookDbContext = new LoginAppDbContext())
            {
                bookDbContext.Books.Update(book);
                bookDbContext.SaveChanges();
                return book;
            }
        }

        public ReadResult AddRead(Read read)
        {

            using var bookDbContext = new LoginAppDbContext();
            var isRead = bookDbContext.Reads.Where(X => X.IDBook == read.IDBook && X.IDUser == read.IDUser).ToList();

            if (isRead.Count == 0)
            {

                bookDbContext.Reads.Add(read);
                bookDbContext.SaveChanges();
                return new ReadResult { IsSuccess = true, Message = "read" };
            }

            bookDbContext.Reads.Remove(isRead[0]);
            bookDbContext.SaveChanges();
            return new ReadResult { IsSuccess = false, Message = "unread" };

        }

    }
}
