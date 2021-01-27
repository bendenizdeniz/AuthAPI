using LoginDbApp.Entities;
using LoginDbApp.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoginDbApp.DataAccess.Abstract
{
    public interface IBookRepository
    {
        List<Book> GetAllBooks();

        Book GetBookById(int id);

        Book CreateBook(Book book);

        Book UpdateBook(Book book);

        void DeleteBook(int id);

        public LikeResult AddLike(Like like);

        ReadResult AddRead(Read read);
    }
}
