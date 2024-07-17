using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repositories.LoggingRepository.Validation
{
    public class LoggingValidation:AbstractValidator<Logging>
    {
        public LoggingValidation() 
        {
        RuleFor(p => p.LogInfo).NotEmpty().WithMessage("Logging infosu boş olamaz");

        }

    }
}
