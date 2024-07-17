using Core.CorssCuttingConcerns.Caching;
using Core.CorssCuttingConcerns.Caching.Microsoft;
using Core.Utilities.Business.Services;
using Core.Utilities.Business.Services.Abstracts;
using Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics;

namespace Core.DependencyResolvers
{
    public class CoreModule : ICoreModule
    {
        public void Load(IServiceCollection services)
        {
            services.AddMemoryCache();
            services.AddSingleton<ICacheManager, MemoryCacheManager>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<Stopwatch>();
            services.AddSingleton<ITallyCountControlService, TallyCountControlService>();
            services.AddSingleton<ITallyCountService, TallyCountService>();
            services.AddSingleton<ITallySyllabusOverlapService, TallySyllabusOverlapService>();
            services.AddSingleton<ITallyToMonthService, TallyToMonthService>();
            services.AddSingleton<ITallyToWeekService, TallyToWeekService>();
            services.AddSingleton<ITallyWeekendService, TallyWeekendService>();
            services.AddSingleton<ITallyWorkTimeService, TallyWorkTimeService>();
            services.AddSingleton<ITallyWorkTimeToHolidayService, TallyWorkTimeToHolidayService>();
            services.AddSingleton<IWeekTallyToWeekService, WeekTallyToWeekService>();
            services.AddSingleton<IWeekTallyToMonthService, WeekTallyToMonthService>();

        }
    }
}
