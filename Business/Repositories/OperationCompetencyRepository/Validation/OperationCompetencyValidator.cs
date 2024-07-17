using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repositories.OperationCompetencyRepository.Validation
{
    public class OperationCompetencyValidator : AbstractValidator<OperationCompetency>
    {
        public OperationCompetencyValidator()
        {
            RuleFor(p => p.OperationCompetencyGuidId).NotEmpty().WithMessage("Id numarası boş olamaz");
        }
    }
}
