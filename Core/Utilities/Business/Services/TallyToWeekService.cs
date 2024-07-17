using Core.Utilities.Business.Services.Abstracts;
using Core.Utilities.Business.Services.Validation;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using Entities.Concrete;
using Entities.Dtos.TallyDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Business.Services
{
    public class TallyToWeekService : ITallyToWeekService
    {
        public async Task<IResult> IsWeekTimeExist(DateTime firstDate, DateTime finishDate, Guid StudentGuidId, int nowCounthour,int weekHour,List<TallyCalculatorDto> tallyCalculatorDtos)
        {
            int totalHoursForSpecificWeek = 0;
            //çalışılan saatler aynı haftada mı kontrol ediyor ve haftalık sınırı geçip geçmediği kontrol ediliyor
            if (firstDate.DayOfWeek == finishDate.DayOfWeek)
            {
                foreach (var whatHour in tallyCalculatorDtos)
                {
                    if (whatHour.FirstDate.DayOfWeek == firstDate.DayOfWeek)
                    {
                        totalHoursForSpecificWeek += whatHour.TallyCountHour;
                    }
                }
            }
            else
            {
                //throw new Exception(ServiceMessages.IsSameWeek);

                return new ErrorResult(ServiceMessages.IsSameWeek);

            }
            if (totalHoursForSpecificWeek + nowCounthour > weekHour)
            {
                //throw new Exception(ServiceMessages.WeekHourExceed);

                return new ErrorResult(ServiceMessages.WeekHourExceed);

            }
            else
            {
                return new SuccessResult();
            }
         

        }
    }
}
