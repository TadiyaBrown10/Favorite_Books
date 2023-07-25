using System;
namespace Favorite_Books.Models
{
	public class Books
	{
        public Books()
		{
		}

	    public int ID { get; set; }
		public string GenresID { get; set; }
		public string Title { get; set; }
		public string Description {get; set;}
		public string Author { get; set; }
		public int Pages { get; set; }
	}
}

