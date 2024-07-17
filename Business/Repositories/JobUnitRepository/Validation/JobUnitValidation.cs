using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repositories.JobUnitRepository.Validation
{
    public class JobUnitValidation:AbstractValidator<JobUnit>

    {
        public JobUnitValidation() 
        {
        RuleFor(p => p.JobUnitName).NotEmpty().WithMessage("İş bölümü adı boş olamaz");
        }

    }
}
