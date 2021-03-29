using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator : AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(p => p.ColorId).NotEmpty();
            RuleFor(p => p.DailyPrice).NotEmpty();
            RuleFor(p => p.Description).MinimumLength(5);
            RuleFor(p => p.BrandId).NotEmpty();
            RuleFor(p => p.ModelYear).NotEmpty();
            //RuleFor(p => p.Description).Must(StartWithA);
        }

        private bool StartWithA(string arg)
        {
            return arg.StartsWith("1");
        }
    }
}
