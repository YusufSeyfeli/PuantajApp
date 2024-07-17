using Core.Utilities.Result.Abstract;
using Entities.Concrete;
using Entities.Dtos.OperationClaimDtos;

namespace Business.Repositories.OperationClaimRepository
{
    public interface IOperationClaimService
    {
        Task<IResult> Add(OperationClaimDto operationClaimDto);
        Task<IResult> Update(OperationClaimUpdateDto operationClaimUpdateDto);
        Task<IResult> Delete(Guid OperationClaimGuidId);
        Task<IDataResult<List<OperationClaimGetListDto>>> GetListWithCompetency();
        Task<IDataResult<List<OperationClaimGetUserDto>>> GetList();
        Task<IDataResult<OperationClaim>> GetById(Guid OperationClaimGuidId);
        Task<OperationClaim> GetByIdForUserService(Guid OperationClaimGuidId);
    }
}
