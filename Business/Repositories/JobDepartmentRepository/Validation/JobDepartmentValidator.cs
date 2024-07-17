using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repositories.JobDepartmentRepository.Validation
{
    public class JobDepartmentValidator:AbstractValidator<JobDepartment>
    {
        public JobDepartmentValidator()
        {
            RuleFor(p => p.Name).NotEmpty().WithMessage("İş bölümü adı boş olamaz");
        }
    }
}
