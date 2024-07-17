using Core.Utilities.Result.Abstract;
using Entities.Concrete;
using Entities.Dtos.WeekTallyDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repositories.WeekTallyRepository
{
    public interface IWeekTallyService
    {
        Task<IResult> Add(WeekTallyRebuildDto WeekTallyRebuildDto);
        Task<IResult> Update(WeekTallyUpdateDto tallyUpdateDto);
        Task<IResult> Delete(Guid id);
        Task<IDataResult<List<WeekTallyGetListDto>>> GetList();
        Task<IDataResult<WeekTally>> GetById(Guid WeekTallyGuidId);
        
    }
}
