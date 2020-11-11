using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace Interfaces
{
    public interface IBooks
    {
        int AddBooks(BooksDTO booksDTO);
        List<BooksDTO> GetBooks();
        BooksDTO GetBook(string id);
        int UpdateBooks(BooksDTO booksDTO);
        int DeleteBooks(int id);
    }
}
