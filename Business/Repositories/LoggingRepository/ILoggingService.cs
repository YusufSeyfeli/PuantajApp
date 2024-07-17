using Core.Utilities.Result.Abstract;
using Entities.Concrete;
using Entities.Dtos.LoggingDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repositories.LoggingRepository
{
    public interface ILoggingService
    {
        Task<IResult> Add(LoggingDto loggingDto);
        Task<IResult> Update(LoggingUpdateDto loggingupdateDto);
        Task<IResult> Delete(Guid id);
        Task<IDataResult<List<LoggingGetListDto>>> GetList();
        Task<IDataResult<Logging>> GetById(Guid LoggingGuidId);
        Task<Logging> GetByIdForLoggingService(Guid LoggingGuidId);

    }
}
