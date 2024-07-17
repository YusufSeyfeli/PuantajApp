using Core.DataAccess;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.JobUnitRepository
{
    public interface IJobUnitDal:IEntityRepository<JobUnit>
    {
        //Jobdepartmentları çeken jobunitleri listeleyen bir api ucu lazım
    }
}
