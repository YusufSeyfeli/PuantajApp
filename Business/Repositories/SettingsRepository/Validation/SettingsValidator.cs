using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repositories.SettingsRepository.Validation
{
    public class SettingsValidator: AbstractValidator<Settings>
    {
        public SettingsValidator() 
        {
            RuleFor(p => p.WeekHour).NotEmpty().WithMessage("Haftadaki çalışma saati boş olamaz");

        }
    }
}
