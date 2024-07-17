using Core.DataAccess;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.SettingsRepository
{
    public interface ISettingsDal : IEntityRepository<Settings>
    {
        public int GetMonthHour();
        public int GetWeekHour();

    }
}
