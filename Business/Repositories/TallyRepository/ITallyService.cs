using Core.Utilities.Result.Abstract;
using Entities.Concrete;
using Entities.Dtos.TallyDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repositories.TallyRepository
{
    public interface ITallyService
    {
        Task<IResult> Add(TallyRebuildDto TallyDto);
        Task<IResult> Update(TallyUpdateDto tallyUpdateDto);
        Task<IResult> Delete(Guid id);
        Task<IDataResult<List<TallyGetListDto>>> GetList();
        Task<IDataResult<Tally>> GetById(Guid TallyGuidId);

    }
}
