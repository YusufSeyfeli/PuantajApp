using Core.DataAccess;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.UserJobUnitRepository
{
    public interface IUserJobUnitDal: IEntityRepository<UserJobUnit>
    {
        //Task BulkDeleteForOperationClaims(Guid UserJobUnitGuidId);
        //Task BulkUpdateForUserJobUnit(List<UserJobUnit> userJobUnits);
        //Task BulkAddForOperationClaim(List<UserJobUnit> userJobUnits);

    }
}
