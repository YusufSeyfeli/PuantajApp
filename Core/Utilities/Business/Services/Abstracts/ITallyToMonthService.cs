using Core.Utilities.Result.Abstract;
using Entities.Dtos.TallyDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Business.Services.Abstracts
{
    public interface ITallyToMonthService
    {
        public Task<IResult> IsMonthTimeExist(DateTime firstDateTally, DateTime finishDateTally, Guid StudentGuidId, int nowCounthour, int monthHour, List<TallyCalculatorDto> tallyCalculatorDtos);

    }
}
