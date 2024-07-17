using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete
{
    public class OperationClaim 
    {
        [Key]
        public Guid OperationClaimGuidId { get; set; }
        public string OperationClaimName { get; set; }
        public List<UserOperationClaim> UserOperationClaims { get; set; }
        public List<OperationCompetency> OperationCompetencies { get; set; }

    }
}
