using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Business.Services.Abstracts
{
    public interface ITallyCountService
    {
        public Task<int> TallyCountHour(DateTime firsDate, DateTime finishDate);
    }
}
