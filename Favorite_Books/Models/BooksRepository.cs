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
            _conn.Execute("DELETE FROM GENRES ID = @id;", new { id = books.ID });
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
            _conn.Execute("INSERT INTO Books ( GENREID, TITLE, DESCRIPTION, AUTHOR, PAGES) VALUES (@genreid, @title, @description, @author, @pages);",
                new { genres = bookToInsert.GenresID, title = bookToInsert.Title, description = bookToInsert.Description, author = bookToInsert.Author, pages = bookToInsert.Pages });
        }

        public void UpdateBooks(Books books)
        {
            _conn.Execute("UPDATE Books SET  GenresID = @GenresID, Title = @Title, Description = @Desrciption, Author = @Author, Pages = @Pages" +
                " WHERE ID = @ID",
               new { id = books.ID, genresId= books.GenresID, title = books.Title, description = books.Description, author = books.Author, pages = books.Pages });
        }
    }
}

