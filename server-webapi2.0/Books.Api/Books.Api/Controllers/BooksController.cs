using Books.Api.Repository;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Books.Api.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*", exposedHeaders: "X-My-Header")]
    [RoutePrefix("api/Books")]
    public class BooksController : ApiController
    {
        BooksRepository booksRepository = new BooksRepository();

        [Route("AddBooks")]
        [HttpPost()]
        public int AddBooks(BooksDTO booksDTO)
        {
            int result = 0;
            
            if (Validaton(booksDTO))
            {
                result = booksRepository.AddBooks(booksDTO);
            }
            return result;
        }

        [Route("GetBooks")]
        [HttpGet()]
        public List<BooksDTO> GetBooks()
        {
            List<BooksDTO> result = new List<BooksDTO>();
            result = booksRepository.GetBooks();
            return result;
        }

        [Route("GetBook/{id}")]
        [HttpGet()]
        public BooksDTO GetBook(string id)
        {
            BooksDTO result = new BooksDTO();
            result = booksRepository.GetBook(id);
            return result;
        }

        [Route("UpdateBooks")]
        [HttpPost()]
        public int UpdateBooks(BooksDTO booksDTO)
        {
            int result = 0;
            if (Validaton(booksDTO))
            {
                result = booksRepository.UpdateBooks(booksDTO);
            }
            return result;
        }

        [Route("DeleteBooks/{id}")]
        [HttpPost()]
        public int DeleteBooks(int id)
        {
            int result = 0;
            result = booksRepository.DeleteBooks(id);
            return result;
        }

        public bool Validaton(BooksDTO booksDTO)
        {
            bool isValid = true;
            if (string.IsNullOrEmpty(booksDTO.book))
            {
                isValid = false;
            }
            else if (string.IsNullOrEmpty(booksDTO.book))
            {
                isValid = false;
            }
            return isValid;
        }
    }
}