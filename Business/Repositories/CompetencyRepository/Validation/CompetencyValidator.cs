using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repositories.CompetencyRepository.Validation
{
    public class CompetencyValidator : AbstractValidator<Competency>
    {
        public CompetencyValidator()
        {
            RuleFor(p => p.Name).NotEmpty().WithMessage("Yetki adı boş olamaz");
        }
    }
}
