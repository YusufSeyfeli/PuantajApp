using Core.DataAccess.EntityFramework;
using DataAccess.Context.EntityFramework;
using Entities.Concrete;
using Entities.Dtos.CompetencyDtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.CompetencyRepository
{
    public class EfCompetencyDal : EfEntityRepositoryBase<Competency, SimpleContextDb>,ICompetencyDal
    {
        public async Task<List<Competency>> GetCompetenciesbyOperationClaimId(Guid OperationClaimGuidId)
        {
            using (var context = new SimpleContextDb())
            {
                var result = from operationCompetency in context.OperationCompetencies.Where(p => p.OperationClaimGuidId == OperationClaimGuidId)
                             join Competency in context.Competencies on operationCompetency.CompetencyGuidId equals Competency.CompetencyGuidId
                             select new Competency
                             {
                                 CompetencyGuidId = Competency.CompetencyGuidId,
                                 Name = Competency.Name
                             };
                return await result.OrderBy(p => p.Name).ToListAsync();
            }
        }

        public async Task<List<OperationClaim>> GetCompetencyOperatinonClaims(Guid CompetencyGuidId)
        {
            using (var context = new SimpleContextDb())
            {
                var result = from operationCompetency in context.OperationCompetencies.Where(p => p.CompetencyGuidId == CompetencyGuidId)
                             join operationClaim in context.OperationClaims on operationCompetency.OperationClaimGuidId equals operationClaim.OperationClaimGuidId
                             select new OperationClaim
                             {
                                 OperationClaimGuidId = operationClaim.OperationClaimGuidId,
                                 OperationClaimName = operationClaim.OperationClaimName
                             };
                return await result.OrderBy(p => p.OperationClaimName).ToListAsync();
            }
        }
    }
}
