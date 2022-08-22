using HotelFinder.Business.Models;
using OtelFinder.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelFinder.Business.Abstract
{
    public interface ICategoryService
    {
        Category Create(CategoryModel category);
        List<Category> GetAll();
        Category GetById(int id);
        Category Update(CategoryUpdateModel category);
        void Delete(int id);
    }
}

