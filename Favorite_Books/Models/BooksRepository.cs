using System;
using System.Data;
using Dapper;

namespace Favorite_Books.Models
{
	public class BooksRepository : IBooksRepository
	{
        private readonly IDbConnection _conn;

		public BooksRepository(IDbConnection conn)
		{
            _conn = conn;
		}

        public IEnumerable<Books> GetALLBooks()
        {
            return _conn.Query<Books>("SELECT * FROM Books;");
        }

        public Books GetBooks(int ID)
        {
            return _conn.QuerySingle<Books>("SELECT * FROM BOOKS WHERE ID = @id", new { id = ID });
        }
    }
}

