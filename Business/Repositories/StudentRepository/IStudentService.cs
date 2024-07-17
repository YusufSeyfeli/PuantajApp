using Core.Utilities.Result.Abstract;
using Entities.Concrete;
using Entities.Dtos.StudentDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repositories.StudentRepository
{
    public interface IStudentService
    {
        Task<IResult> Add(StudentDto studentDto);
        Task<IResult> Update(StudentUpdateDto studentUpdateDto);
        Task<IResult> Delete(Guid StudentGuidId);
        Task<IDataResult<List<StudentGetListDto>>> GetList();
        Task<IDataResult<StudentGetStudentDto>> GetById(Guid StudentGuidId);
        Task<Student> GetByIdForStudentService(Guid StudentGuidId);

    }
}
