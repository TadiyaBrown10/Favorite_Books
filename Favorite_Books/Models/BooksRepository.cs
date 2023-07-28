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

        public Books AssignGenre()
        { 

            var genreType = GetGenres();
            var books = new Books();
            books.GenreType = genreType;
            return books;
        }

        public void DeleteBook(Books books)
        {
            _conn.Execute("DELETE FROM BOOKS WHERE ID = @id;", new { id = books.ID });
            _conn.Execute("DELETE FROM GENRES WHERE GenresID = @id;", new { id = books.ID });
        }

        public IEnumerable<Books> GetALLBooks()
        {
            return _conn.Query<Books>("SELECT * FROM Books;");
        }

        public Books GetBooks(int ID)
        {
            return _conn.QuerySingle<Books>("SELECT * FROM BOOKS WHERE ID = @id", new { id = ID });
        }

        public IEnumerable<Genres> GetGenres()
        {
            return _conn.Query<Genres>("SELECT * FROM Genres");
        }

        public void InsertBook(Books bookToInsert)
        {
            _conn.Execute("INSERT INTO Books ( GenresID, TITLE, DESCRIPTION, AUTHOR, PAGES) VALUES (@genresid, @title, @description, @author, @pages);",
                new { genresid = bookToInsert.GenresID, title = bookToInsert.Title, description = bookToInsert.Description, author = bookToInsert.Author, pages = bookToInsert.Pages });
        }

        public void UpdateBooks(Books books)
        {
            _conn.Execute("UPDATE Books SET  GenresID = @genresID, Title = @title, Description = @description, Author = @author, Pages = @pages WHERE ID = @id;",
               new { id = books.ID, genresId= books.GenresID, title = books.Title, description = books.Description, author = books.Author, pages = books.Pages });
        }
    }
}

