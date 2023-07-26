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

        public void UpdateBooks(Books books)
        {
            _conn.Execute("UPDATE Books SET  GenresID = @GenresID, Title = @Title, Description = @Desrciption, Author = @Author, Pages = @Pages" +
                " WHERE ID = @ID",
               new { id = books.ID, genresId= books.GenresID, title = books.Title, description = books.Description, author = books.Author, pages = books.Pages });
        }
    }
}

