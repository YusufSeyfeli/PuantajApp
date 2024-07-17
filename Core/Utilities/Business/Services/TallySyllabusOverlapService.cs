using Core.Utilities.Business.Services.Abstracts;
using Core.Utilities.Business.Services.Validation;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using Entities.Dtos.SyllabusDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Business.Services
{
    public class TallySyllabusOverlapService : ITallySyllabusOverlapService
    {
        public async Task<IResult> IsSyllabusOverlap(DateTime firstDateTally, DateTime finishDateTally, List<SyllabusGetListDto> syllabusGetListDtos)
        {
            bool hasOverlap = false;
            foreach (var syllabus in syllabusGetListDtos)
            {
                if (syllabus.FirstTime.DayOfWeek == finishDateTally.DayOfWeek)
                {
                    if (syllabus.FirstTime < finishDateTally && syllabus.FinishTime > firstDateTally)
                    {
                        hasOverlap = false;
                    }
                }
            }

            if (hasOverlap)
            {
                throw new Exception(ServiceMessages.IsSyllabusOverlap);
            }
            else
            {
                return new SuccessResult();
            }
        }
    }
}
