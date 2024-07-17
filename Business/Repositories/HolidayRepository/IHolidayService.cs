using Core.Utilities.Result.Abstract;
using Entities.Concrete;
using Entities.Dtos.HolidayDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repositories.HolidayRepository
{
    public interface IHolidayService
    {
        Task<IResult> Add(HolidayDto holidayDto);
        Task<IResult> Update(HolidayUpdateDto holidayUpdateDto);
        Task<IResult> Delete(Guid id);
        Task<IDataResult<List<HolidayGetListDto>>> GetList();
        Task<IDataResult<Holiday>> GetById(Guid HolidayGuidId);
        Task<Holiday> GetByIdForHolidayService(Guid HolidayGuidId);
    }
}
