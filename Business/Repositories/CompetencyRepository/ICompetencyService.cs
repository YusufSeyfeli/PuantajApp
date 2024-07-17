using Core.Utilities.Result.Abstract;
using Entities.Concrete;
using Entities.Dtos.CompetencyDtos;

namespace Business.Repositories.CompetencyRepository
{
    public interface ICompetencyService 
    {
        Task<IResult> Add(CompetencyDto competencyDto);
        Task<IResult> Update(CompetencyUpdateDto competencyUpdateDto);
        Task<IResult> Delete(Guid competencyGuidId);
        Task<IDataResult<List<CompetencyGetListDto>>> GetList();
        Task<IDataResult<Competency>> GetById(Guid CompetencyGuidId);
        Task<IDataResult<List<OperationClaim>>> GetCompetencyOperatinonClaims(Guid CompetencyGuidId);
        Task<IDataResult<List<Competency>>> GetCompetenciesbyOperationClaimId(Guid OperationClaimGuidId);
    }
}
