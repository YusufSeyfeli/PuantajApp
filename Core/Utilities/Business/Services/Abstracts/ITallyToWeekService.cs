using Core.Utilities.Result.Abstract;
using Entities.Dtos.TallyDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Business.Services.Abstracts
{
    public interface ITallyToWeekService
    {
        public Task<IResult> IsWeekTimeExist(DateTime firstDateTally, DateTime finishDateTally, Guid StudentGuidId, int nowCounthour, int weekHour ,List<TallyCalculatorDto> tallyCalculatorDtos);

    }
}
