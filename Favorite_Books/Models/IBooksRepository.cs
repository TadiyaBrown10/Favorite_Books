using System;
namespace Favorite_Books.Models
{
	public interface IBooksRepository
	{

		public IEnumerable<Books> GetALLBooks();
		public Books GetBooks(int ID);
		public void UpdateBooks(Books books);

		public void InsertBook(Books bookToInsert);
		public IEnumerable<Genres> GetGenres();
		public Books AssignGenre();
		public void DeleteBook(Books books);
     
    }
}

