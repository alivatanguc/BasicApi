
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
        public CategoryManager(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }


        Category ICategoryService.Create(CategoryModel categoryModel)
        {
            Category category = new Category()
            {
                // City = hotelModel.City
                Name = categoryModel.Name
            };
            return _categoryRepository.Create(category);
        }

        void ICategoryService.Delete(int id)
        {
            //_hotelRepository.DeleteHotel(id);
            var entity = _categoryRepository.GetById(id);
            if(entity != null)
            {
                _categoryRepository.Delete(id);
            }
            else
            {
                return;
            }
        }

        List<Category> ICategoryService.GetAll()
        {
            return _categoryRepository.GetAll();
        }

        Category ICategoryService.GetById(int id)
        {
            if(id > 0)
            {
                return _categoryRepository.GetById(id);
            }

            //return _hotelRepository.GetHotelById(id);
            throw new Exception("ID CAN NOT BE LESS THAN ONE!!!");
        }

       public Category Update(CategoryUpdateModel categoryUpdateModel)
        {
            var entity = _categoryRepository.GetById(categoryUpdateModel.Id);
            if(entity != null)
            {
                Category category = new Category()
                {
                    Id = categoryUpdateModel.Id,
                    // City = hotelUpdateModel.City,
                    Name = categoryUpdateModel.Name
                };
                return _categoryRepository.Update(category);
            }
            else
            {
                return null;
            }
        }
    }
}

        

       
        

