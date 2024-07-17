using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete
{
    public class User
    {
        [Key]
        public Guid UserGuidId { get; set; }
        public string NameSurname { get; set; }
        public string Email { get; set; }
        public string ImageUrl { get; set; }
        public byte[] ImageByte { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string ConfirmValue { get; set; }
        public bool IsConfirm { get; set; }
        public string ForgotPasswordValue { get; set; } 
        public DateTime? ForgotPasswordRequestDate { get; set; }
        public bool IsForgotPasswordComplete { get; set; }
        //public Guid JobUnitGuidId { get; set; }
        public List<UserOperationClaim> UserOperationClaims { get; set; }
        public List<UserJobUnit> UserJobUnits { get; set; } // yeni eklenen
    }
}
