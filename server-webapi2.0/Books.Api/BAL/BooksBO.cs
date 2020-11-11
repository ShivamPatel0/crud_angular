using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data.SqlClient;
using DTO;

namespace BAL
{
    public class BooksBO
    {
        static readonly string DbConnection = HelperClasses.GlobalConnection.DBConnection;

        public int AddBooks(BooksDTO booksDTO)
        {
            string query = "USP_CRUD_BOOKS @id, @book, @author, @type";
            try
            {
                var conn = new SqlConnection(DbConnection);
                int result = conn.Execute(query, new { id = booksDTO.id, book = booksDTO.book, author = booksDTO.author, type = "insert" });
                return result;
            }
            catch(Exception ex)
            {
                throw ex;
            }            
        }


        public List<BooksDTO> GetBooks()
        {
            string query = "USP_CRUD_BOOKS @id, @book, @author, @type";
            try
            {
                var conn = new SqlConnection(DbConnection);
                conn.Open();
                List<BooksDTO> result = conn.Query<BooksDTO>(query, new { id = 0, book = string.Empty, author = string.Empty, type = "view" }).ToList();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }            
        }


        public BooksDTO GetBook(string id)
        {

            string query = "USP_CRUD_BOOKS @id, @book, @author, @type";
            try
            {
                var conn = new SqlConnection(DbConnection);
                conn.Open();
                BooksDTO result = conn.Query<BooksDTO>(query, new { id = id, book = string.Empty, author = string.Empty, type = "single" }).ToList().SingleOrDefault();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }            
        }


        public int UpdateBooks(BooksDTO booksDTO)
        {
            string query = "USP_CRUD_BOOKS @id, @book, @author, @type";
            try
            {
                var conn = new SqlConnection(DbConnection);
                conn.Open();
                int result = conn.Execute(query, new { id = booksDTO.id, book = booksDTO.book, author = booksDTO.author, type = "update" });
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }    
        }


        public int DeleteBooks(int id)
        {
            string query = "USP_CRUD_BOOKS @id, @book, @author, @type";
            try
            {
                var conn = new SqlConnection(DbConnection);
                conn.Open();
                int result = conn.Execute(query, new { id = id, book = string.Empty, author = string.Empty, type = "delete" });
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }           
        }
    }
}
