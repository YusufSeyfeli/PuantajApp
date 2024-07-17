using Core.DataAccess.EntityFramework;
using DataAccess.Context.EntityFramework;
using DataAccess.Repositories.StudentRepository;
using Entities.Concrete;
using Entities.Dtos.StudentDtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.StudentRepository
{
    public class EfStudentDal : EfEntityRepositoryBase<Student, SimpleContextDb>, IStudentDal
    {
                public async Task<List<JobDepartment>> GetStudentJobDepartment(Guid JobUnitGuidId)
            {
            using (var context = new SimpleContextDb())
            {
                var result = from jobUnit in context.JobUnits.Where(p => p.JobUnitGuidId == JobUnitGuidId)
                             join jobDepartment in context.JobDepartments on jobUnit.JobDepartmentGuidId equals jobDepartment.JobDepartmentGuidId
                             select new JobDepartment
                             {
                                 JobDepartmentGuidId = jobDepartment.JobDepartmentGuidId,
                                 Name = jobDepartment.Name
                             };
                return await result.OrderBy(p => p.Name).ToListAsync();
            }
        }
    }
}
