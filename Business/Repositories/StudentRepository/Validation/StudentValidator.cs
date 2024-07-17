using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repositories.StudentRepository.Validation
{
    public class StudentValidator : AbstractValidator<Student>
    {
        public StudentValidator()
        {
            RuleFor(p => p.NameSurname).NotEmpty().WithMessage("Öğrenci ismi ve soyismi boş olamaz");

        }
    }
}
