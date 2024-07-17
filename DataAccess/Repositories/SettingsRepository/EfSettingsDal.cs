using Core.DataAccess.EntityFramework;
using DataAccess.Context.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.SettingsRepository
{
    public class EfSettingsDal : EfEntityRepositoryBase<Settings,SimpleContextDb>,ISettingsDal
    {
        public int GetMonthHour()
        {
            using (var context = new SimpleContextDb())
            {
                var monthHour = context.Settings.FirstOrDefault()?.MontHour;
                return monthHour ?? 0; 
            }

        }public int GetWeekHour()
        {
            using (var context = new SimpleContextDb())
            {
                var weekHour = context.Settings.FirstOrDefault()?.WeekHour;
                return weekHour ?? 0; 
            }
        }

    }
}
