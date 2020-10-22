using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DTO;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using Dapper;

namespace books.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class booksController : ControllerBase
    {
        private readonly IConfiguration _config;

        public booksController(IConfiguration config)
        {
            _config = config;
        }

        [Route("AddBooks")]
        [HttpPost()]
        public  int AddBooks(BooksDTO booksDTO)
        {
            string query = "USP_CRUD_BOOKS @id, @book, @author, @type";
            using (var conn = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
            {
                conn.Open();
                int result = conn.Execute(query, new { id = booksDTO.id, book = booksDTO.book, author = booksDTO.author, type = "insert" });
                return result;
            }
        }

        [Route("GetBooks")]
        [HttpGet()]
        public List<BooksDTO> GetBooks()
        {
            string query = "USP_CRUD_BOOKS @id, @book, @author, @type";
            using (var conn = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
            {
                conn.Open();
                List<BooksDTO> result = conn.Query<BooksDTO>(query, new { id =0, book = string.Empty , author = string.Empty, type = "view" }).ToList();
                return result;
            }
        }

        [Route("GetBook/{id}")]
        [HttpGet()]
        public BooksDTO GetBook(string id)
        {
            string query = "USP_CRUD_BOOKS @id, @book, @author, @type";
            using (var conn = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
            {
                conn.Open();
                BooksDTO result = conn.Query<BooksDTO>(query, new { id = id, book = string.Empty, author = string.Empty, type = "single" }).ToList().SingleOrDefault();
                return result;
            }
        }

        [Route("UpdateBooks")]
        [HttpPost()]
        public int UpdateBooks(BooksDTO booksDTO)
        {
            string query = "USP_CRUD_BOOKS @id, @book, @author, @type";
            using (var conn = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
            {
                conn.Open();
                int result = conn.Execute(query, new { id = booksDTO.id, book = booksDTO.book, author = booksDTO.author, type = "update" });
                return result;
            }
        }

        [Route("DeleteBooks/{id}")]
        [HttpPost()]
        public int DeleteBooks(int id)
        {
            string query = "USP_CRUD_BOOKS @id, @book, @author, @type";
            using (var conn = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
            {
                conn.Open();
                int result = conn.Execute(query, new { id = id, book = string.Empty, author = string.Empty, type = "delete" });
                return result;
            }
        }
    }
}