using Core.Utilities.Result.Abstract;
using Entities.Concrete;
using Entities.Dtos.JobDepartmentDtos;
using Entities.Dtos.JobUnitDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repositories.JobUnitRepository
{
    public interface IJobUnitService
    {
        Task<IResult> Add(JobUnitDto jobUnitDto);
        Task<IResult> Update(JobUnitUpdateDto jobUnitUpdateDto);
        Task<IResult> Delete(Guid JobUnitGuidid);   
        Task<IDataResult<List<JobUnitGetListDto>>> GetList();
        Task<IDataResult<JobUnit>> GetById(Guid JobUnitGuidId);
        Task<JobUnit> GetByIdForJobUnitService(Guid JobUnitGuidId);

    }
}
