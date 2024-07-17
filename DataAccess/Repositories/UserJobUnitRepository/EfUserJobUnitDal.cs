using Core.DataAccess.EntityFramework;
using DataAccess.Context.EntityFramework;
using DataAccess.Repositories.OperationClaimRepository;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.UserJobUnitRepository
{
    public class EfUserJobUnitDal: EfEntityRepositoryBase<UserJobUnit, SimpleContextDb>, IUserJobUnitDal 
    {
        //public async Task BulkAddForUserJobUnit(Guid UserJobUnitGuidId)
        //{
        //    using (var context = new SimpleContextDb())
        //    {
        //        var jobUnits = new List<JobUnit>();
        //        {
        //            context.AddRange(jobUnits);
        //            await context.SaveChangesAsync();
        //        }
        //    }
        //}

        //public async Task BulkAddForUserJobUnit(List<UserJobUnit> userJobUnits)
        //{
        //    using (var context = new SimpleContextDb())
        //    {
        //        var jobUnits = new List<JobUnit>();
        //        {
        //            context.AddRange(jobUnits);
        //            await context.SaveChangesAsync();
        //        }
        //    }
        //}

        //public async Task BulkDeleteForUserJobUnit(List<UserJobUnit> userJobUnits)
        //{
        //    using (var context = new SimpleContextDb())
        //    {
        //        List<Guid> userJobUnitsIds = userJobUnits.Select(c => c.UserJobUnitGuidId).ToList();

        //        context.RemoveRange(userJobUnitsIds);
        //        await context.SaveChangesAsync();
        //    }
        //}

        //public async Task BulkUpdateForUserJobUnit(List<UserJobUnit> userJobUnits)
        //{
        //    using (var context = new SimpleContextDb())
        //    {
        //        context.UpdateRange(userJobUnits);
        //        await context.SaveChangesAsync();
        //    }
        //}
        //public async Task BulkAddForOperationClaim(Guid OperationClaimGuidId)
        //{
        //    using (var context = new SimpleContextDb())
        //    {
        //        var jobUnits = new List<JobUnit>();
        //        {
        //            context.AddRange(jobUnits);
        //            await context.SaveChangesAsync();
        //        }
        //    }
        //}

        //public async Task BulkDeleteForOperationClaim(List<OperationCompetency> operationCompetencies)
        //{
        //    using (var context = new SimpleContextDb())
        //    {
        //        //List<OperationCompetencyDto> competencyIds = operationCompetencies.Select(c => c.OperationClaimGuidId = );

        //        context.RemoveRange(operationCompetencies);
        //        await context.SaveChangesAsync();
        //    }
        //}
    }
}
