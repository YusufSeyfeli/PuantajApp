using Core.Utilities.Business;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Repositories.CompetencyRepository;
using Entities.Concrete;

using Entities.Dtos.CompetencyDtos;
using AutoMapper;
using Business.Aspects.Secured;
using DataAccess.Repositories.WeekTallyRepository;
using Business.Repositories.WeekTallyRepository;
using Entities.Dtos.WeekTallyDtos;
using Business.Repositories.WeekTallyRepository.Constants;
using DataAccess.Repositories.SettingsRepository;
using DataAccess.Repositories.SyllabusRepository;
using DataAccess.Repositories.HolidayRepository;
using Entities.Dtos.SettingsDtos;
using Entities.Dtos.SyllabusDtos;
using Entities.Dtos.HolidayDtos;
using Entities.Dtos.TallyDtos;
using Core.Utilities.Business.Services.Abstracts;
using Core.Utilities.Business.Services;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Business.Repositories.CompetencyRepository
{
    public class WeekTallyManager : IWeekTallyService
    {
        private readonly IWeekTallyDal _weekTallyDal;
        private readonly IMapper _mapper;
        private readonly ISettingsDal _settingsDal;
        private readonly ISyllabusDal _syllabusDal;
        private readonly IHolidayDal _holidayDal;
        private readonly IWeekTallyCountService _weekTallyCountService;
        private readonly ITallyCountControlService _tallyCountControlService;
        private readonly ITallyWeekendService _tallyWeekendService;
        private readonly ITallyWorkTimeService _tallyWorkTimeService;
        private readonly ITallyWorkTimeToHolidayService _tallyWorkTimeToHolidayService;
        private readonly IWeekTallyToMonthService _weekTallyToMonthService;
        private readonly IWeekTallyToWeekService _weekTallyToWeekService;
        private readonly ITallyCountService _tallyCountService;
        private readonly ITallySyllabusOverlapService _tallySyllabusOverlapService;
        public WeekTallyManager(IWeekTallyDal weekTallyDal, IMapper mapper,
            ISettingsDal settingsDal, ISyllabusDal syllabusDal,
            IHolidayDal holidayDal, ITallyCountControlService tallyCountControlService
            ,ITallyWeekendService tallyWeekendService, ITallyWorkTimeService tallyWorkTimeService
            ,ITallyWorkTimeToHolidayService tallyWorkTimeToHolidayService
            ,IWeekTallyToMonthService weekTallyToMonthService
            , ITallyCountService tallyCountService
            ,IWeekTallyToWeekService weekTallyToWeekService
            ,ITallySyllabusOverlapService tallySyllabusOverlapService
            )
        {
            _weekTallyDal = weekTallyDal;
            _mapper = mapper;
            _settingsDal = settingsDal;
            _syllabusDal = syllabusDal;
            _holidayDal = holidayDal;
            _tallyCountControlService = tallyCountControlService;
            _tallyWeekendService = tallyWeekendService;
            _tallyWorkTimeService = tallyWorkTimeService;
            _tallyWorkTimeToHolidayService = tallyWorkTimeToHolidayService;
            _weekTallyToMonthService = weekTallyToMonthService;
            _tallyCountService = tallyCountService;
            _weekTallyToWeekService = weekTallyToWeekService;
            _tallySyllabusOverlapService = tallySyllabusOverlapService;

        }

        [SecuredAspect("WeekTally.Add,Admin")]
        public async Task<IResult> Add(WeekTallyRebuildDto weekTallyRebuildDto)
        {
            var monthHour = _settingsDal.GetMonthHour();
            var weekHour = _settingsDal.GetWeekHour();
            TimeZoneInfo utc3TimeZone = TimeZoneInfo.FindSystemTimeZoneById("Turkey Standard Time");

            weekTallyRebuildDto.FirstDate = TimeZoneInfo.ConvertTimeFromUtc(weekTallyRebuildDto.FirstDate, utc3TimeZone);
            weekTallyRebuildDto.FinishDate = TimeZoneInfo.ConvertTimeFromUtc(weekTallyRebuildDto.FinishDate, utc3TimeZone);

            List<Syllabus> syllabusList = await _syllabusDal.GetAll();
            List<WeekTally> weekTallyList = await _weekTallyDal.GetAll();
            List<Holiday> holidayList = await _holidayDal.GetAll();

            List<SyllabusGetListDto> mappedList = syllabusList.Select(syllabus => new SyllabusGetListDto
            {
                FirstTime = syllabus.FirstTime,
                FinishTime = syllabus.FinishTime,
                DayTime = syllabus.DayTime,
                StudentGuidId = syllabus.StudentGuidId,
                SyllabusGuidId = syllabus.SyllabusGuidId
            }).ToList();


            List<WeekTallyCalculatorDto> weekTallyCalculatorList = weekTallyList.Select(weekTally => new WeekTallyCalculatorDto
            {
                FirstDate = weekTally.FirstDate,
                FinishDate = weekTally.FinishDate,
                CountHour = weekTally.CountHour,
                StudentGuidId = weekTally.StudentGuidId
            }).ToList();

            List<HolidayDto> holidayDtoList = holidayList.Select(holiday => new HolidayDto
            {
                HolidayFirstDate = holiday.HolidayFirstDate,
                HolidayFinishDate = holiday.HolidayFinishDate,
                HolidayName = holiday.HolidayName
            }).ToList();
            int nowCountHour = await _tallyCountService.TallyCountHour(weekTallyRebuildDto.FirstDate, weekTallyRebuildDto.FinishDate);
            IResult result = BusinessRules.Run(await _tallyCountControlService.IsTallyCountHourCalculator(nowCountHour),
            await _tallyWeekendService.IsWeekend(weekTallyRebuildDto.FirstDate, weekTallyRebuildDto.FinishDate),
            await _tallyWorkTimeService.IsWorkTime(weekTallyRebuildDto.FirstDate, weekTallyRebuildDto.FinishDate),
            await _weekTallyToMonthService.IsMonthTimeExist(weekTallyRebuildDto.FirstDate, weekTallyRebuildDto.FinishDate, weekTallyRebuildDto.StudentGuidId, nowCountHour, monthHour, weekTallyCalculatorList),
            await _weekTallyToWeekService.IsWeekTimeExist(weekTallyRebuildDto.FirstDate, weekTallyRebuildDto.FinishDate, weekTallyRebuildDto.StudentGuidId, nowCountHour, weekHour, weekTallyCalculatorList),
            await _tallySyllabusOverlapService.IsSyllabusOverlap(weekTallyRebuildDto.FirstDate, weekTallyRebuildDto.FinishDate, mappedList),
            await _tallyWorkTimeToHolidayService.IsWorkTimeHoliday(weekTallyRebuildDto.FirstDate, weekTallyRebuildDto.FinishDate, holidayDtoList));
            if (result != null)
            {
                return result;
            }

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<WeekTallyDto, WeekTally>()
                   .AfterMap((src, dest) => dest.CountHour = nowCountHour);
            });
            var mapperHashandSalt = config.CreateMapper();
            var mapper = _mapper.Map<WeekTally>(weekTallyRebuildDto);
            try
            {
                await _weekTallyDal.Add(mapper);
                return new SuccessResult(WeekTallyMessages.Added);
            }
            catch (Exception ex)
            {
                return new Result(false, ex.Message);
            }
        }


        [SecuredAspect("WeekTally.Delete,Admin")]
        public async Task<IResult> Delete(Guid WeekTallyGuidid)
        {
            if (WeekTallyGuidid == Guid.Empty)
            {
                return new ErrorDataResult<WeekTally>("Id boş gönderilemez!!");
            }
            try
            {
                await _weekTallyDal.Delete(WeekTallyGuidid);
                return new SuccessResult(WeekTallyMessages.Deleted);
            }
            catch (Exception ex)
            {
                return new Result(false, ex.Message);
            }
        }


        [SecuredAspect("WeekTally.Get,Admin")]
        public async Task<IDataResult<WeekTally>> GetById(Guid StudentGuidId)
        {
            if (StudentGuidId == Guid.Empty)
            {
                return new ErrorDataResult<WeekTally>("Id boş gönderilemez!!");
            }
            var result = await _weekTallyDal.Get(p => p.StudentGuidId == StudentGuidId);
            return new SuccessDataResult<WeekTally>(result);
        }

        [SecuredAspect("WeekTally.Get,Admin")]
        public async Task<WeekTally> GetByIdForTallyService(Guid WeekTallyGuidId)
        {
            var result = await _weekTallyDal.Get(p => p.WeekTallyGuidId == WeekTallyGuidId);
            return result;
        }

        [SecuredAspect("WeekTally.Get,Admin")]
        public async Task<IDataResult<List<WeekTallyGetListDto>>> GetList()
        {
            List<WeekTally> listWeekTally = await _weekTallyDal.GetAll();

            var myListWeekTally = _mapper.Map<List<WeekTallyGetListDto>>(listWeekTally);
            return new SuccessDataResult<List<WeekTallyGetListDto>>(myListWeekTally);

        }

        [SecuredAspect("WeekTally.Update,Admin")]
        public async Task<IResult> Update(WeekTallyUpdateDto weekTallyUpdateDto)
        {
            if (weekTallyUpdateDto.WeekTallyGuidId == Guid.Empty)
            {
                return new ErrorDataResult<WeekTally>("Id boş gönderilemez!!");
            }
            var mapper = _mapper.Map<WeekTally>(weekTallyUpdateDto);
            //IResult result = BusinessRules.Run(await IsNameExistForUpdate(mapper));
            //if (result != null)
            //{
            //    return result;
            //}

            try
            {
                await _weekTallyDal.Update(mapper);
                return new SuccessResult(WeekTallyMessages.Added);
            }
            catch (Exception ex)
            {
                return new Result(false, ex.Message);
            }
        }

        //private async Task<IResult> IsNameExistForAdd(string name)
        //{
        //    var result = await _weekTallyDal.Get(p => p.Name == name);
        //    if (result != null)
        //    {
        //        return new ErrorResult(WeekTallyMessages.NameIsNotAvaible);
        //    }
        //    return new SuccessResult();
        //}
        //private async Task<IResult> IsNameExistForUpdate(Competency competency)
        //{
        //    var currentCompetency = await _weekTallyDal.Get(p => p. == competency.Name);
        //    if (currentCompetency.Name != competency.Name)
        //    {
        //        var result = await _weekTallyDal.Get(p => p.Name == competency.Name);
        //        if (result != null)
        //        {
        //            return new ErrorResult(CompetencyMessages.NameIsNotAvaible);
        //        }
        //    }
        //    return new SuccessResult();
        //}


        //[SecuredAspect("Competency.Get,Admin")]
        //public async Task<IDataResult<List<OperationClaim>>> GetCompetencyOperatinonClaims(Guid CompetencyGuidId)
        //{
        //    if (CompetencyGuidId == Guid.Empty)
        //    {
        //        return new ErrorDataResult<List<OperationClaim>>("Id boş gönderilemez!!");
        //    }
        //    try
        //    {
        //        var operationClaims = await _weekTallyDal.GetCompetencyOperatinonClaims(CompetencyGuidId);
        //        return new SuccessDataResult<List<OperationClaim>>(operationClaims);
        //    }
        //    catch (Exception ex)
        //    {
        //        return new ErrorDataResult<List<OperationClaim>>(ex.Message);
        //    }
        //}

        //[SecuredAspect("Competency.Get,Admin")]
        //public async Task<IDataResult<List<Competency>>> GetCompetenciesbyOperationClaimId(Guid OperationClaimGuidId)
        //{
        //    if (OperationClaimGuidId == Guid.Empty)
        //    {
        //        return new ErrorDataResult<List<Competency>>("Id boş gönderilemez!!");
        //    }
        //    try
        //    {
        //        var competencies = await _competencyDal.GetCompetenciesbyOperationClaimId(OperationClaimGuidId);
        //        return new SuccessDataResult<List<Competency>>(competencies);
        //    }
        //    catch (Exception ex)
        //    {
        //        return new ErrorDataResult<List<Competency>>(ex.Message);
        //    }
        //}

        //public async Task<Result> BulkAddForOperationClaim(Guid OperationClaimGuidId)
        //{
        //    try
        //    {

        //        var competencies = await _competencyDal.GetCompetenciesbyOperationClaimId(OperationClaimGuidId);
        //        return new SuccessResult(CompetencyMessages.BulkUpdatead);
        //    }
        //    catch (Exception ex)
        //    {
        //        return new ErrorDataResult<List<Competency>>(ex.Message);
        //    }
        //}

    }
}
