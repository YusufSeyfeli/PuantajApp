using Core.DataAccess;
using Entities.Concrete;
using Entities.Dtos.CompetencyDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.CompetencyRepository
{
    public interface ICompetencyDal:IEntityRepository<Competency>
    {
        Task<List<OperationClaim>> GetCompetencyOperatinonClaims(Guid CompetencyGuidId);
        Task<List<Competency>> GetCompetenciesbyOperationClaimId(Guid OperationClaimGuidId);


    }
}
