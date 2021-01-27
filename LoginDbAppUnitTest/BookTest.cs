using LoginDbApp.Businnes.Abstract;
using LoginDbApp.Businnes.Concrete;
using LoginDbApp.DataAccess.Abstract;
using LoginDbApp.DataAccess.Concrete;
using LoginDbApp.Entities;
using LoginDbApp.Entities.Concrete;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace LoginApplication.UnitTest
{
    public class BookTest
    {
        [Fact]
        public void AddBookItem_Success()
        {
            BookRepository bookRepository = new BookRepository();
            Book book = bookRepository.GetBookById(9);
            Assert.Equal(9, book.ID);
        }

        [Fact]
        public void AddLike_Success()
        {
            BookRepository bookRepository = new BookRepository();
            Like like = new Like{ IDUser=1, IDBook=1};
            bookRepository.AddLike(like);
            Assert.Equal(1, like.IDBook);
        }

        [Fact]
        public void AddRead_Success()
        {
            BookRepository bookRepository = new BookRepository();
            Read read = new Read { IDBook = 1, IDUser = 1, Name="test" };
            bookRepository.AddRead(read);
            Assert.Equal(1, read.IDBook);
        }



    }
}
