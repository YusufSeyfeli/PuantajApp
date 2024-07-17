using Core.Utilities.Result.Abstract;
using Entities.Concrete;
using Entities.Dtos.OperationCompetencyDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repositories.OperationCompetencyRepository
{
    public interface IOperationCompetencyService
    {
        Task<IResult> Add(OperationCompetencyDto operationCompetencyDto);
        Task<IResult> Update(OperationCompetencyUpdateDto operationCompetencyUpdateDto);
        Task<IResult> Delete(Guid operationCompetencyGuidId);
        Task<IDataResult<List<OperationCompetencyGetListDto>>> GetList();
        Task<IDataResult<OperationCompetency>> GetById(Guid operationCompetencyGuidId);
        Task<OperationCompetency> GetByIdForOperationCompetencyService(Guid OperationCompetencyGuidId);
        Task<IResult> BulkUpdateForOperationCompetency(List<OperationCompetencyUpdateDto> operationCompetencyUpdate);
        Task<IResult> BulkAddForOperationCompetency(List<OperationCompetencyDto> operationCompetencyDtos);
        Task<IResult> BulkDeleteForOperationCompetency(Guid guidId);
    }
}
