using Core.Utilities.Result.Abstract;
using Entities.Dtos.HolidayDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Business.Services.Abstracts
{
    public interface ITallyWorkTimeToHolidayService
    {
        public Task<IResult> IsWorkTimeHoliday(DateTime firstDateTally, DateTime finishDateTally, List<HolidayDto> holidayDtoList);

    }
}
