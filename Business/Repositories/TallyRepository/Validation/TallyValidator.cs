using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repositories.TallyRepository.Validation
{
    public class TallyValidator:AbstractValidator<Tally>
    {
        public TallyValidator()
        {
            //RuleFor(p => p.Name).NotEmpty().WithMessage("Puantaj adı boş olamaz");
        }
    }
}
