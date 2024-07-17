using Core.Utilities.Result.Abstract;
using Entities.Concrete;
using Entities.Dtos.UserJobUnitDtos;
using Entities.Dtos.UserOperationClaimDtos;

namespace Business.Repositories.UserOperationClaimRepository
{
    public interface IUserOperationClaimService
    {
        Task<IResult> Add(UserOperationClaimDto userOperationClaimDto);
        Task<IResult> Update(UserOperationClaimUpdateDto userOperationClaimUpdateDto);
        Task<IResult> Delete(Guid UserOperationClaimGuidId);
        Task<IDataResult<List<UserOperationClaimGetListDto>>> GetList();
        Task<IDataResult<UserOperationClaim>> GetById(Guid OperationClaimGuidId);
        Task<IResult> BulkUpdateForUserOperationClaim(List<UserOperationClaimUpdateDto> userOperationClaimUpdateDtos);
        Task<IResult> BulkAddForUserOperationClaim(List<UserOperationClaimDto> userOperationClaimDtos);
        Task<IResult> BulkDeleteForUserOperationClaim(Guid UserGuidId);
    }
}
