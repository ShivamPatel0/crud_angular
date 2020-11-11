using BAL;
using DTO;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Books.Api.Repository
{
    public class BooksRepository : IBooks
    {
        BooksBO booksBO = new BooksBO();
        public int AddBooks(BooksDTO booksDTO)
        {
            return booksBO.AddBooks(booksDTO);
        }

        public int DeleteBooks(int id)
        {
            return booksBO.DeleteBooks(id);
        }

        public BooksDTO GetBook(string id)
        {
            return booksBO.GetBook(id);
        }

        public List<BooksDTO> GetBooks()
        {
            return booksBO.GetBooks();
        }

        public int UpdateBooks(BooksDTO booksDTO)
        {
            return booksBO.UpdateBooks(booksDTO);
        }
    }
}