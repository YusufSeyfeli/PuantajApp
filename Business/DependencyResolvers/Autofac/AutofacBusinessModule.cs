using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Authentication;
using Business.Repositories.CompetencyRepository;
using Business.Repositories.EmailParameterRepository;
using Business.Repositories.HolidayRepository;
using Business.Repositories.JobDepartmentRepository;
using Business.Repositories.JobUnitRepository;
using Business.Repositories.LoggingRepository;
using Business.Repositories.OperationClaimRepository;
using Business.Repositories.OperationCompetencyRepository;
using Business.Repositories.SettingsRepository;
using Business.Repositories.StudentRepository;
using Business.Repositories.SyllabusRepository;
using Business.Repositories.TallyRepository;
using Business.Repositories.UserJobUnitRepository;
using Business.Repositories.UserOperationClaimRepository;
using Business.Repositories.UserRepository;
using Business.Repositories.WeekTallyRepository;
using Core.Utilities.Interceptors;
using Core.Utilities.Security.JWT;
using DataAccess.Repositories.CompetencyRepository;
using DataAccess.Repositories.EmailParameterRepository;
using DataAccess.Repositories.HolidayRepository;
using DataAccess.Repositories.JobDepartmentRepository;
using DataAccess.Repositories.JobUnitRepository;
using DataAccess.Repositories.LoggingRepository;
using DataAccess.Repositories.OperationClaimRepository;
using DataAccess.Repositories.OperationCompetencyRepository;
using DataAccess.Repositories.SettingsRepository;
using DataAccess.Repositories.StudentRepository;
using DataAccess.Repositories.SyllabusRepository;
using DataAccess.Repositories.TallyRepository;
using DataAccess.Repositories.UserJobUnitRepository;
using DataAccess.Repositories.UserOperationClaimRepository;
using DataAccess.Repositories.UserRepository;
using DataAccess.Repositories.WeekTallyRepository;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<OperationClaimManager>().As<IOperationClaimService>();
            builder.RegisterType<EfOperationClaimDal>().As<IOperationClaimDal>();

            builder.RegisterType<UserManager>().As<IUserService>();
            builder.RegisterType<EfUserDal>().As<IUserDal>();

            builder.RegisterType<UserOperationClaimManager>().As<IUserOperationClaimService>();
            builder.RegisterType<EfUserOperationClaimDal>().As<IUserOperationClaimDal>();

            builder.RegisterType<EmailParameterManager>().As<IEmailParameterService>();
            builder.RegisterType<EfEmailParameterDal>().As<IEmailParameterDal>();

            builder.RegisterType<AuthManager>().As<IAuthService>();
            builder.RegisterType<TokenHandler>().As<ITokenHandler>();

            builder.RegisterType<CompetencyManager>().As<ICompetencyService>();
            builder.RegisterType<EfCompetencyDal>().As<ICompetencyDal>();

            builder.RegisterType<HolidayManager>().As<IHolidayService>();
            builder.RegisterType<EfHolidayDal>().As<IHolidayDal>();
           
            builder.RegisterType<JobDepartmentManager>().As<IJobDepartmentService>();
            builder.RegisterType<EfJobDepartmentDal>().As<IJobDepartmentDal>();

            builder.RegisterType<JobUnitManager>().As<IJobUnitService>();
            builder.RegisterType<EfJobUnitDal>().As<IJobUnitDal>();

            builder.RegisterType<LoggingManager>().As<ILoggingService>();
            builder.RegisterType<EfLoggingDal>().As<ILoggingDal>();

            builder.RegisterType<SettingsManager>().As<ISettingsService>();
            builder.RegisterType<EfSettingsDal>().As<ISettingsDal>();

            builder.RegisterType<StudentManager>().As<IStudentService>();
            builder.RegisterType<EfStudentDal>().As<IStudentDal>();

            builder.RegisterType<UserJobUnitManager>().As<IUserJobUnitService>();
            builder.RegisterType<EfUserJobUnitDal>().As<IUserJobUnitDal>();

            builder.RegisterType<OperationCompetencyManager>().As<IOperationCompetencyService>();
            builder.RegisterType<EfOperationCompetencyDal>().As<IOperationCompetencyDal>();

            builder.RegisterType<TallyManager>().As<ITallyService>();
            builder.RegisterType<EfTallyDal>().As<ITallyDal>();

            builder.RegisterType<WeekTallyManager>().As<IWeekTallyService>();
            builder.RegisterType<EfWeekTallyDal>().As<IWeekTallyDal>();

            builder.RegisterType<SyllabusManager>().As<ISyllabusService>();
            builder.RegisterType<EfSyllabusDal>().As<ISyllabusDal>();


            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces().EnableInterfaceInterceptors(new Castle.DynamicProxy.ProxyGenerationOptions()
            {
                Selector = new AspectInterceptorSelector()
            }).SingleInstance();
        }
    }
}
