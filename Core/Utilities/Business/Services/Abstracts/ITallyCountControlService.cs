using Core.Utilities.Result.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Business.Services.Abstracts
{
    public interface ITallyCountControlService
    {
        public Task<IResult> IsTallyCountHourCalculator(int countHourNow);
    }
}
