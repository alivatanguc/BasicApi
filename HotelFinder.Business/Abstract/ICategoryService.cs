using HotelFinder.Business.Models;
using OtelFinder.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelFinder.Business.Abstract
{
    public interface ICategoryService
    {
        Category CreateCategory(CategoryModel category);
        List<Category> GetAllCategories();
        Category GetCategoryById(int id);
        Category UpdateCategory(CategoryUpdateModel category);
        void DeleteCategory(int id);
    }
}

