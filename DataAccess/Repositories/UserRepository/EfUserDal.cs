using Core.DataAccess.EntityFramework;
using DataAccess.Context.EntityFramework;
using Entities.Concrete;
using Entities.Dtos.UserDtos;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories.UserRepository
{
    public class EfUserDal : EfEntityRepositoryBase<User, SimpleContextDb>, IUserDal
    {
        public async Task<List<OperationClaim>> GetUserOperatinonClaims(Guid UserGuidId)
        {
            using (var context = new SimpleContextDb())
            {
                var result = from userOperationClaim in context.UserOperationClaims.Where(p => p.UserGuidId == UserGuidId)
                             join operationClaim in context.OperationClaims on userOperationClaim.OperationClaimGuidId equals operationClaim.OperationClaimGuidId
                             select new OperationClaim
                             {
                                 OperationClaimGuidId = operationClaim.OperationClaimGuidId,
                                 OperationClaimName = operationClaim.OperationClaimName
                             };
                return await result.OrderBy(p => p.OperationClaimName).ToListAsync();
            }
        }
        public async Task<List<JobUnit>> GetUserJobUnit(Guid UserGuidId)
        {
            using (var context = new SimpleContextDb())
            {
                var result = from userJobUnit in context.UserJobUnits.Where(p => p.UserGuidId == UserGuidId)
                             join jobUnit in context.JobUnits on userJobUnit.JobUnitGuidId equals jobUnit.JobUnitGuidId
                             select new JobUnit
                             {
                                 JobUnitGuidId = jobUnit.JobUnitGuidId,
                                 JobDepartmentGuidId = jobUnit.JobDepartmentGuidId,
                                 JobUnitName = jobUnit.JobUnitName
                             };
                return await result.OrderBy(p => p.JobUnitName).ToListAsync();
            }
        }

        public async Task<List<Competency>> GetCompetency(Guid GuidUserId)
        {
            using (var context = new SimpleContextDb())
            {
                var result = from userOperationClaim in context.UserOperationClaims.Where(p => p.UserGuidId == GuidUserId)
                             join operationClaim in context.OperationClaims on userOperationClaim.OperationClaimGuidId equals operationClaim.OperationClaimGuidId
                             join operationCompetency in context.OperationCompetencies on operationClaim.OperationClaimGuidId equals operationCompetency.OperationClaimGuidId
                             join competency in context.Competencies on operationCompetency.CompetencyGuidId equals competency.CompetencyGuidId
                             select new Competency
                             {
                                 CompetencyGuidId = competency.CompetencyGuidId,
                                 Name = competency.Name
                             };
                return await result.OrderBy(p => p.Name).ToListAsync();
            }
        }

    }
}
