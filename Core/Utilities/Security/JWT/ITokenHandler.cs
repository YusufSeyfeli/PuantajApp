


using Entities.Concrete;

namespace Core.Utilities.Security.JWT
{
    public interface ITokenHandler
    {
        //Token CreateToken(User user, List<OperationClaim> operationClaims);
        Token CreateToken(User user, List<Competency> competencies);
    }
}
