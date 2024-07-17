using AutoMapper;
using Entities.Concrete;
using Entities.Dtos.CompetencyDtos;
using Entities.Dtos.EmailParameter;
using Entities.Dtos.EmailParameterDtos;
using Entities.Dtos.HolidayDtos;
using Entities.Dtos.JobDepartmentDtos;
using Entities.Dtos.JobUnitDtos;
using Entities.Dtos.LoggingDtos;
using Entities.Dtos.OperationClaimDtos;
using Entities.Dtos.OperationCompetencyDtos;
using Entities.Dtos.SettingsDtos;
using Entities.Dtos.StudentDtos;
using Entities.Dtos.SyllabusDtos;
using Entities.Dtos.TallyDtos;
using Entities.Dtos.WeekTallyDtos;
using Entities.Dtos.UserDtos;
using Entities.Dtos.UserJobUnitDtos;
using Entities.Dtos.UserOperationClaimDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Mapper.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();

            CreateMap<User, UserUpdateDto>();
            CreateMap<UserUpdateDto, User>();

            CreateMap<User,UserGetListDto>().ReverseMap();
          

            CreateMap<UserOperationClaim, UserOperationClaimDto>();
            CreateMap<UserOperationClaimDto, UserOperationClaim>();
            CreateMap<UserOperationClaim, UserOperationClaimUpdateDto>();
            CreateMap<UserOperationClaimUpdateDto, UserOperationClaim>();


            CreateMap<OperationClaimGetUserDto, OperationClaim>().ReverseMap();
            
            CreateMap<UserOperationClaim, UserOperationClaimGetListDto>().ReverseMap();


            CreateMap<OperationClaim, OperationClaimDto>();
            CreateMap<OperationClaimDto, OperationClaim>();
            CreateMap<OperationClaim, OperationClaimUpdateDto>();
            CreateMap<OperationClaimUpdateDto, OperationClaim>();

            CreateMap<OperationClaim, OperationClaimGetListDto>().ReverseMap();


            CreateMap<OperationCompetency, OperationCompetencyDto>();
            CreateMap<OperationCompetencyDto, OperationCompetency>();
            CreateMap<OperationCompetency, OperationCompetencyUpdateDto>();
            CreateMap<OperationCompetencyUpdateDto, OperationCompetency>();
            CreateMap<List<OperationCompetency>, OperationCompetency>().ReverseMap();

            CreateMap<OperationCompetency, OperationCompetencyGetListDto>().ReverseMap();


            CreateMap<Competency, CompetencyDto>();
            CreateMap<CompetencyDto, Competency>();
            CreateMap<Competency, CompetencyUpdateDto>();
            CreateMap<CompetencyUpdateDto, Competency>();


            CreateMap<Competency, CompetencyGetListDto>().ReverseMap();


            CreateMap<UserJobUnit, UserJobUnitDto>();
            CreateMap<UserJobUnitDto, UserJobUnit>();
            CreateMap<UserJobUnit, UserJobUnitUpdateDto>();
            CreateMap<UserJobUnitUpdateDto, UserJobUnit>();

            CreateMap<UserJobUnit, UserJobUnitGetListDto>().ReverseMap();

            CreateMap<JobUnit, JobUnitDto>();
            CreateMap<JobUnitDto, JobUnit>();
            CreateMap<JobUnit, JobUnitUpdateDto>();
            CreateMap<JobUnitUpdateDto, JobUnit>();

            CreateMap<JobUnit, JobUnitGetListDto>().ReverseMap();


            CreateMap<JobDepartment, JobDepartmentDto>();
            CreateMap<JobDepartmentDto, JobDepartment>();
            CreateMap<JobDepartment, JobDepartmentUpdateDto>();
            CreateMap<JobDepartmentUpdateDto, JobDepartment>();

            CreateMap<JobDepartment, JobDepartmentGetListDto>().ReverseMap();


            CreateMap<Student, StudentDto>();
            CreateMap<StudentDto, Student>();

            CreateMap<Student, StudentUpdateDto>();
            CreateMap<StudentUpdateDto, Student>();

            CreateMap<Student, StudentGetListDto>().ReverseMap();


            CreateMap<Tally, TallyDto>();
            CreateMap<TallyDto, Tally>();
            CreateMap<Tally, TallyUpdateDto>();
            CreateMap<TallyUpdateDto, Tally>();

            CreateMap<Tally, TallyGetListDto>().ReverseMap();
            CreateMap<Tally, TallyCalculatorDto>().ReverseMap();
            CreateMap<Tally, TallyRebuildDto>().ReverseMap();

            CreateMap<WeekTally, WeekTallyDto>();
            CreateMap<WeekTallyDto, WeekTally>();
            CreateMap<WeekTally, WeekTallyUpdateDto>();
            CreateMap<WeekTallyUpdateDto, WeekTally>();

            CreateMap<WeekTally, WeekTallyGetListDto>().ReverseMap();
            CreateMap<WeekTally, WeekTallyCalculatorDto>().ReverseMap();
            CreateMap<WeekTally, WeekTallyRebuildDto>().ReverseMap();

            CreateMap<Syllabus, SyllabusDto>();
            CreateMap<SyllabusDto, Syllabus>();
            CreateMap<Syllabus, SyllabusUpdateDto>();
            CreateMap<SyllabusUpdateDto, Syllabus>();

            CreateMap<Syllabus, SyllabusGetListDto>().ReverseMap();



            CreateMap<Holiday, HolidayDto>();
            CreateMap<HolidayDto, Holiday>();
            CreateMap<Holiday, HolidayUpdateDto>();
            CreateMap<HolidayUpdateDto, Holiday>();

            CreateMap<Holiday, HolidayGetListDto>().ReverseMap();

            CreateMap<Logging, LoggingDto>();
            CreateMap<LoggingDto, Logging>();
            CreateMap<Logging, LoggingUpdateDto>();
            CreateMap<LoggingUpdateDto, Logging>();

            CreateMap<Logging, LoggingGetListDto>().ReverseMap();

            CreateMap<Settings, SettingsDto>();
            CreateMap<SettingsDto, Settings>();
            CreateMap<Settings, SettingsUpdateDto>();
            CreateMap<SettingsUpdateDto, Settings>();

            CreateMap<Settings, SettingsGetListDto>().ReverseMap();


            CreateMap<EmailParameter, EmailParameterDto>();
            CreateMap<EmailParameterDto, EmailParameter>();
            CreateMap<EmailParameter, EmailParameterUpdateDto>();
            CreateMap<EmailParameterUpdateDto, EmailParameter>();

            CreateMap<EmailParameter, EmailParameterGetListDto>().ReverseMap();


        }
    }
}
