using Core.DataAccess.EntityFramework;
using DataAccess.Context.EntityFramework;
using Entities.Concrete;
using Entities.Dtos.OperationCompetencyDtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.OperationCompetencyRepository
{
    public class EfOperationCompetencyDal : EfEntityRepositoryBase<OperationCompetency, SimpleContextDb>, IOperationCompetencyDal
    {
        //public async Task BulkAddForOperationClaim(Guid OperationClaimGuidId)
        //{
        //    using (var context = new SimpleContextDb())
        //    {
        //        var competencies = new List<Competency>();
        //        {
        //            context.AddRange(competencies);
        //            await context.SaveChangesAsync();
        //        }
        //    }
        //}
   
        //public async Task BulkDeleteForOperationClaim(List<OperationCompetency> operationCompetencies)
        //{
        //    using (var context = new SimpleContextDb())
        //    {
        //        

        //        context.RemoveRange(operationCompetencies);
        //        await context.SaveChangesAsync();
        //    }
        //}

        //public async Task BulkUpdateForOperationClaim(List<OperationCompetency> operationCompetencies)
        //{
        //    using (var context = new SimpleContextDb())
        //    {
        //        context.UpdateRange(operationCompetencies);
        //        await context.SaveChangesAsync();
        //    }
        //}
    }
}
