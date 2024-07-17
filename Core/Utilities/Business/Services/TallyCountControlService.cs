using Core.Utilities.Business.Services.Abstracts;
using Core.Utilities.Business.Services.Validation;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Business.Services
{
    public class TallyCountControlService : ITallyCountControlService
    {
        public async Task<IResult> IsTallyCountHourCalculator(int countHourNow)
        {
            if (countHourNow <= 0) // seçilen saatlerin eksi olmamasını kontrol ediyor
            {
                return new ErrorResult(ServiceMessages.TallyCountHourNegative);
            }
            return new SuccessResult();

        }
    }
}
