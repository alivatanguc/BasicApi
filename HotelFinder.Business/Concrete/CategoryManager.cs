
using HotelFinder.Business.Abstract;
using HotelFinder.Business.Models;
using HotelFinder.DataAccess.Abstract;
using HotelFinder.DataAccess.Concrete;

using OtelFinder.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelFinder.Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryManager()
        {
            _categoryRepository = new CategoryRepository();
        }


        Category ICategoryService.CreateCategory(CategoryModel categoryModel)
        {
            Category category = new Category()
            {
                // City = hotelModel.City
                Name = categoryModel.Name
            };
            return _categoryRepository.CreateCategory(category);
        }

        void ICategoryService.DeleteCategory(int id)
        {
            //_hotelRepository.DeleteHotel(id);
            var entity = _categoryRepository.GetCategoryById(id);
            if(entity != null)
            {
                _categoryRepository.DeleteCategory(id);
            }
            else
            {
                return;
            }
        }

        List<Category> ICategoryService.GetAllCategories()
        {
            return _categoryRepository.GetAllCategories();
        }

        Category ICategoryService.GetCategoryById(int id)
        {
            if(id > 0)
            {
                return _categoryRepository.GetCategoryById(id);
            }

            //return _hotelRepository.GetHotelById(id);
            throw new Exception("ID CAN NOT BE LESS THAN ONE!!!");
        }

       public Category UpdateCategory(CategoryUpdateModel categoryUpdateModel)
        {
            var entity = _categoryRepository.GetCategoryById(categoryUpdateModel.Id);
            if(entity != null)
            {
                Category category = new Category()
                {
                    Id = categoryUpdateModel.Id,
                    // City = hotelUpdateModel.City,
                    Name = categoryUpdateModel.Name
                };
                return _categoryRepository.UpdateCategory(category);
            }
            else
            {
                return null;
            }
        }
    }
}

        

       
        

