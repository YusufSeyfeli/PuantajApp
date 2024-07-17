using Core.DataAccess.EntityFramework;
using DataAccess.Context.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.JobDepartmentRepository
{
    public class EfJobDepartmentDal: EfEntityRepositoryBase<JobDepartment,SimpleContextDb>,IJobDepartmentDal
    {
        public async Task BulkAddForJobDepartment(Guid JobDepartmentGuidId)
        {
            using (var context = new SimpleContextDb())
            {
                var jobDepartments = new List<JobDepartment>();
                {
                    context.AddRange(jobDepartments);
                    await context.SaveChangesAsync();
                }
            }
        }

        public async Task BulkDeleteForOperationClaim(List<JobDepartment> jobDepartments)
        {
            using (var context = new SimpleContextDb())
            {
                List<Guid> competencyIds = jobDepartments.Select(c => c.JobDepartmentGuidId).ToList();

                context.RemoveRange(competencyIds);
                await context.SaveChangesAsync();
            }
        }

        public async Task BulkUpdateForOperationClaim(List<OperationCompetency> operationCompetencies)
        {
            using (var context = new SimpleContextDb())
            {
                context.UpdateRange(operationCompetencies);
                await context.SaveChangesAsync();
            }
        }
    }
}
