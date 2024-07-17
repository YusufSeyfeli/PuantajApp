using Core.Utilities.Result.Abstract;
using Entities.Concrete;
using Entities.Dtos.OperationCompetencyDtos;
using Entities.Dtos.UserJobUnitDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repositories.UserJobUnitRepository
{
    public interface IUserJobUnitService
    {
        Task<IResult> Add(UserJobUnitDto userJobUnitDto);
        Task<IResult> Update(UserJobUnitUpdateDto userJobUnitUpdateDto);
        Task<IResult> Delete(Guid UserJobUnitGuidId);
        Task<IDataResult<List<UserJobUnitGetListDto>>> GetList();
        Task<IDataResult<UserJobUnit>> GetById(Guid UserJobUnitGuidId);
        Task<UserJobUnit> GetByIdForCompetencyService(Guid UserJobUnitGuidId);
        Task<IResult> BulkUpdateForUserJobUnit(List<UserJobUnitUpdateDto> userJobUnitUpdateDtos);
        Task<IResult> BulkAddForUserJobUnit(List<UserJobUnitDto> userJobUnitDtos);
        Task<IResult> BulkDeleteForUserJobUnit(Guid UserGuidId);
    }
}
