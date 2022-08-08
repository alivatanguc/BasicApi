using HotelFinder.DataAccess.Abstract;
using Microsoft.EntityFrameworkCore;
using OtelFinder.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HotelFinder.DataAccess.Concrete
{
    public class CategoryRepository : ICategoryRepository
    {
      

        public Category CreateCategory(Category category)
        {
            using(var hoteldbContext = new HotelDbContext())
            {


                hoteldbContext.Categories.Add(category);
                    
                hoteldbContext.SaveChanges();
                return category;
            }
        }
        public Category GetCategoryById(int id)
        {
            using(var hoteldbContext = new HotelDbContext())
            {
                return hoteldbContext.Categories.Include(k => k.Hotels).FirstOrDefault(k => k.Id == id);
                 return hoteldbContext.Categories.Find(id);
                //return (from k in hoteldbContext.Categories where k.Id > 2 select k).ToList();
            }
        }

        public void DeleteCategory(int id)
        {
            using(var hoteldbContext = new HotelDbContext())
            {
                var deletedCategory = GetCategoryById(id);
                hoteldbContext.Categories.Remove(deletedCategory);
                hoteldbContext.SaveChanges();
            }
        }

       

        List<Category> ICategoryRepository.GetAllCategories()
        {
            using(var hoteldbContext = new HotelDbContext())
            {
                return hoteldbContext.Categories.Include(k => k.Hotels).ToList();
                return hoteldbContext.Categories.ToList();
            }
        }

       

        Category ICategoryRepository.UpdateCategory(Category category)
        {
            using(var hoteldbContext = new HotelDbContext())
            {
                hoteldbContext.Categories.Update(category);
                hoteldbContext.SaveChanges();
                return category;
            }
        }
    }
}