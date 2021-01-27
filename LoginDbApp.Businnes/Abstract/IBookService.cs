using LoginDbApp.Entities;
using LoginDbApp.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoginDbApp.Businnes.Abstract
{
    public interface IBookService
    {
        BookResult CreateBook(Book book);

        List<Book> GetAllBooks();

        Book GetBookById(int id);

        Book UpdateBook(Book book);

        void DeleteBook(int id);

        LikeResult AddLike(Like like);

        ReadResult AddRead(Read read);
    }
}
