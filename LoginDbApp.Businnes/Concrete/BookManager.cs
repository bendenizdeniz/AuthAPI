using LoginDbApp.Businnes.Abstract;
using LoginDbApp.DataAccess.Abstract;
using LoginDbApp.Entities;
using LoginDbApp.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoginDbApp.Businnes.Concrete
{
    public class BookManager : IBookService
    {
        IBookRepository bookRepository;
        IUserRepository userRepository;
       
        public BookManager(
            IBookRepository bookRepository,
            IUserRepository userRepository)
        {
            this.bookRepository = bookRepository;
            this.userRepository = userRepository;
        }

        public BookResult CreateBook(Book book)
        {
            var isLoggedIn = userRepository.GetUserById(book.IDUser);
            if (isLoggedIn != null)
            {
                book.Reader = isLoggedIn.Name;
                book.PostedTime = DateTime.Now;
                bookRepository.CreateBook(book);
                return new BookResult { IsSuccess = true, Message = "Book Posted.", IDUser = isLoggedIn.id };
            }
            return new BookResult { IsSuccess = false, Message = "Book Was Not Posted." };
        }

        public void DeleteBook(int id)
        {
            bookRepository.DeleteBook(id);
        }

        public List<Book> GetAllBooks()
        {
            return bookRepository.GetAllBooks();
        }

        public Book GetBookById(int id)
        {
            if (id > 0)
                return bookRepository.GetBookById(id);
            throw new Exception("ID can not be less than 0.");
        }

        public Book UpdateBook(Book book)
        {
            return bookRepository.UpdateBook(book);
        }

        public LikeResult AddLike(Like like)
        {
            if (like.IDBook != null && like.IDUser != null)
            {
                var isLoggedIn = userRepository.GetUserById(like.IDUser);
                var isBook = bookRepository.GetBookById(like.IDBook);


                if (isLoggedIn != null && isBook != null)
                {
                    return bookRepository.AddLike(like);
                }

                return new LikeResult { IsSuccess = false, Message = isLoggedIn == null ? "must login" : "create a book" };
            }

            return new LikeResult { IsSuccess = false, Message = "must have IDUser and IDBook" };
        }

        public ReadResult AddRead(Read read)
        {
            if (read.IDBook != null && read.IDUser != null)
            {
                var isLoggedIn = userRepository.GetUserById(read.IDUser);
                var isPosted = bookRepository.GetBookById(read.IDBook);

                if (isLoggedIn != null && isPosted != null)
                {
                    return bookRepository.AddRead(read);
                }
                return new ReadResult { IsSuccess = false, Message = isLoggedIn == null ? "must login" : "create a book" };
            }
            return new ReadResult { IsSuccess = false, Message = "must have IDUser and IDBook" };
        }


    }
}
