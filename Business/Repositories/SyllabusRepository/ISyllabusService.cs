using Core.Utilities.Result.Abstract;
using Entities.Concrete;
using Entities.Dtos.SyllabusDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repositories.SyllabusRepository
{
    public interface ISyllabusService
    {
        Task<IResult> Add(SyllabusDto syllabusDto);
        Task<IResult> Update(SyllabusUpdateDto syllabusUpdateDto);
        Task<IResult> Delete(Guid syllabusGuidId);
        Task<IDataResult<List<SyllabusGetListDto>>> GetList();
        Task<IDataResult<Syllabus>> GetById(Guid syllabusGuidId);
        Task<IResult> Refresh(Guid StudentGuidId);

    }
}
