using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete
{
    public class UserOperationClaim
    {
        [Key]
        public Guid UserOperationClaimGuidId { get; set; }
        public Guid UserGuidId { get; set; }
        public Guid OperationClaimGuidId { get; set; }
        public User User { get; set; }
        public OperationClaim OperationClaim { get; set; }
    }
}
