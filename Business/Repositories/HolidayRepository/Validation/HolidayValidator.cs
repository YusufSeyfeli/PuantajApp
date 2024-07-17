using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repositories.HolidayRepository.Validation
{
    public class HolidayValidator : AbstractValidator<Holiday>
    {
        public HolidayValidator() 
        {
            RuleFor(p => p.HolidayName).NotEmpty().WithMessage("Yetki adı boş olamaz");
        }


    }
}
