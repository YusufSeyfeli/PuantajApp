using Core.Utilities.Result.Abstract;
using Entities.Dtos.TallyDtos;
using Entities.Dtos.WeekTallyDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Business.Services.Abstracts
{
    public interface IWeekTallyToMonthService
    {
        public Task<IResult> IsMonthTimeExist(DateTime firstDate, DateTime finishDate, Guid StudentGuidId, int nowCounthour, int monthHour, List<WeekTallyCalculatorDto> weekTallyCalculatorDtos);

    }
}
