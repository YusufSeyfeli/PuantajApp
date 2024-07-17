using Core.DataAccess;
using Entities.Concrete;
using Entities.Dtos.UserDtos;

namespace DataAccess.Repositories.UserRepository
{
    public interface IUserDal : IEntityRepository<User>
    {
        Task<List<JobUnit>> GetUserJobUnit(Guid guidUserId);
        Task<List<OperationClaim>> GetUserOperatinonClaims(Guid GuidUserId);
        Task<List<Competency>> GetCompetency(Guid GuidUserId);

    }
}
