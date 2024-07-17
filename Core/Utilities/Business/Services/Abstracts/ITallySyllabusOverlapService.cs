using Core.Utilities.Result.Abstract;
using Entities.Dtos.SyllabusDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Business.Services.Abstracts
{
    public interface ITallySyllabusOverlapService
    {
        public Task<IResult> IsSyllabusOverlap(DateTime firstDateTally, DateTime finishDateTally, List<SyllabusGetListDto> syllabusGetListDtos);

    }
}
