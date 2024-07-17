using Entities.Concrete;
using FluentValidation;

namespace Business.Repositories.UserOperationClaimRepository.Validation
{
    public class UserOperationClaimValidator : AbstractValidator<UserOperationClaim>
    {
        public UserOperationClaimValidator()
        {
            RuleFor(p => p.UserGuidId).Must(IsIdValid).WithMessage("Yetki ataması için kullanıcı seçimi yapmalısınız");
            RuleFor(p => p.OperationClaimGuidId).Must(IsIdValid).WithMessage("Yetki ataması için yetki seçimi yapmalısınız");
        }
        // Bu kısımı Guid.Empty metodu ile değiştirdik sayılar ile guid'in içindeki değer karşılaştırılamıyor.
        //private bool IsIdValid(Guid id)
        //{
        //    if (id > 0 && id != null)
        //    {
        //        return true;
        //    }
        //    return false;
        //}
        private bool IsIdValid(Guid id)
        {
            return id != Guid.Empty;
        }

    }
}
