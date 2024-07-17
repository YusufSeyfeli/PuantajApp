using Core.Utilities.Result.Abstract;
using Entities.Concrete;
using Entities.Dtos.JobDepartmentDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repositories.JobDepartmentRepository
{
    public interface IJobDepartmentService
    {
        Task<IResult> Add(JobDepartmentDto jobDepartmentDto);
        Task<IResult> Update(JobDepartmentUpdateDto jobDepartmentUpdateDto);
        Task<IResult> Delete(Guid id);
        Task<IDataResult<List<JobDepartmentGetListDto>>> GetList();
        Task<IDataResult<JobDepartment>> GetById(Guid JobDepartmentGuidId);
        Task<JobDepartment> GetByIdForJobDepartmentService(Guid JobDepartmentGuidId);
    }
}
