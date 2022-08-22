using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelFinder.Business.Models
{
    public class CategoryModelValidator : AbstractValidator<CategoryModel>
    {
        public CategoryModelValidator()
        {

            RuleFor(x => x.Name).Length(0, 20);

        }
    }
}
