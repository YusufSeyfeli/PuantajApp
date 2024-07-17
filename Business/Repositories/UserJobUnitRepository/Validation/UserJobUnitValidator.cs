using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repositories.UserJobUnitRepository.Validation
{
    public class UserJobUnitValidator : AbstractValidator<UserJobUnit>
    {
        public UserJobUnitValidator()
        {
            RuleFor(p => p.UserJobUnitGuidId).NotEmpty().WithMessage("Kimlik numarası boş olamaz");
        }
    }
}
