using HotelFinder.DataAccess;
using System;

namespace PostgreCache
{
    class Program
    {
       public static void Main(string[] args)
        {
           
                InsertSampleData();
            }

            private static void InsertSampleData()
            {
                using(var context = new HotelDbContext())
                {
                    context.Book.Add(new Book { Title = "Witcher", Author = "Andrzej Sapkowski" });
                    context.Book.Add(new Book { Title = "A Game of Thrones", Author = "George R.R. Martin" });
                    context.Book.Add(new Book { Title = "Inclusion", Author = "Andrzej W. Sawicki" });
                    context.SaveChanges();
                }
            }
        
    }
}
