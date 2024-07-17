using Core.DataAccess;
using Entities.Concrete;
using Entities.Dtos.OperationCompetencyDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.OperationCompetencyRepository
{
    public interface IOperationCompetencyDal :IEntityRepository<OperationCompetency>
    {
        //Task BulkDeleteForOperationClaim(List<OperationCompetency> operationCompetencies);
        ////Task BulkUpdateForOperationClaim(List<OperationCompetency> operationCompetencies);
        //Task BulkAddForOperationClaim(List<OperationCompetency> operationCompetencies);

    }
}
