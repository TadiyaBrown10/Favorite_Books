﻿using System;
namespace Favorite_Books.Models
{
	public interface IBooksRepository
	{

		public IEnumerable<Books> GetALLBooks();
	}
}
