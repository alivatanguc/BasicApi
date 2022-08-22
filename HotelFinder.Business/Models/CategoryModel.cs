using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelFinder.Business.Models
{
    public class CategoryModel 
    {

        public int Id { get; set; }
        public string Name { get; set; }



    }
    //public class CategoryModelValidator : AbstractValidator<CategoryModel>
    //{
    //    public CategoryModelValidator()
    //    {

    //        RuleFor(x => x.Name).Length(0, 20);

    //    }
    //}
}
