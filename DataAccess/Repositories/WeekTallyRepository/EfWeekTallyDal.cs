using Core.DataAccess.EntityFramework;
using DataAccess.Context.EntityFramework;
using DataAccess.Repositories.TallyRepository;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.WeekTallyRepository
{
    public class EfWeekTallyDal : EfEntityRepositoryBase<WeekTally, SimpleContextDb>, IWeekTallyDal
    {

    }
}
