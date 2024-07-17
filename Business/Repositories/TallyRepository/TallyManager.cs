using AutoMapper;
using Business.Aspects.Secured;
using Business.Repositories.TallyRepository.Constants;
using Core.Utilities.Business;
using Core.Utilities.Business.Services;
using Core.Utilities.Business.Services.Abstracts;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Repositories.HolidayRepository;
using DataAccess.Repositories.SettingsRepository;
using DataAccess.Repositories.SyllabusRepository;
using DataAccess.Repositories.TallyRepository;
using Entities.Concrete;
using Entities.Dtos.HolidayDtos;
using Entities.Dtos.SyllabusDtos;
using Entities.Dtos.TallyDtos;
using Entities.Dtos.UserDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repositories.TallyRepository
{
    public class TallyManager: ITallyService
    {
        private readonly ISettingsDal _settingsDal;
        private readonly ITallyDal _tallyDal;
        private readonly IMapper _mapper;
        private readonly ISyllabusDal _syllabusDal;
        private readonly IHolidayDal _holidayDal;
        private readonly ITallyCountControlService _tallyCountControlService;
        private readonly ITallyWeekendService _tallyWeekendService;
        private readonly ITallyWorkTimeService _tallyWorkTimeService;
        private readonly ITallyWorkTimeToHolidayService _tallyWorkTimeToHolidayService;
        private readonly ITallyToMonthService _tallyToMonthService;
        private readonly ITallyToWeekService _tallyToWeekService;
        private readonly ITallyCountService _tallyCountService;
        private readonly ITallySyllabusOverlapService _tallySyllabusOverlapService;
         
        public TallyManager(ITallyDal tally, IMapper mapper, ITallyCountControlService tallyCountControlService,
                            ITallyWeekendService tallyWeekendService, ITallyWorkTimeService tallyWorkTimeService,
                            ITallyWorkTimeToHolidayService tallyWorkTimeToHolidayService,
                            ITallyToMonthService tallyToMonthService, ITallyCountService tallyCountService,
                            ITallyToWeekService tallyToWeekService,ISettingsDal settingsDal,ISyllabusDal syllabusDal,
                            ITallySyllabusOverlapService tallySyllabusOverlapService,IHolidayDal holidayDal
            )
        {
            _tallyDal = tally;
            _mapper = mapper;
            _tallyCountControlService = tallyCountControlService;
            _tallyWeekendService = tallyWeekendService;
            _tallyWorkTimeService = tallyWorkTimeService;
            _tallyWorkTimeToHolidayService = tallyWorkTimeToHolidayService;
            _tallyToMonthService = tallyToMonthService;
            _tallyCountService = tallyCountService;
            _tallyToWeekService = tallyToWeekService;
            _settingsDal = settingsDal; 
            _syllabusDal = syllabusDal;
            _tallySyllabusOverlapService = tallySyllabusOverlapService;
            _holidayDal = holidayDal;
        }


        [SecuredAspect("Tally.Add,Admin")]
        public async Task<IResult> Add(TallyRebuildDto tallyDto)
        {

            var monthHour = _settingsDal.GetMonthHour();
            var weekHour = _settingsDal.GetWeekHour();

            TimeZoneInfo utc3TimeZone = TimeZoneInfo.FindSystemTimeZoneById("Turkey Standard Time");

            tallyDto.FirstDate = TimeZoneInfo.ConvertTimeFromUtc(tallyDto.FirstDate, utc3TimeZone);
            tallyDto.FinishDate = TimeZoneInfo.ConvertTimeFromUtc(tallyDto.FinishDate, utc3TimeZone);
            tallyDto.JobDate = TimeZoneInfo.ConvertTimeFromUtc(tallyDto.JobDate, utc3TimeZone);

            List<Syllabus> syllabusList = await _syllabusDal.GetAll();
            List<Tally> tallyList = await _tallyDal.GetAll();
            List<Holiday> holidayList = await _holidayDal.GetAll();


            List<SyllabusGetListDto> mappedList = syllabusList.Select(syllabus => new SyllabusGetListDto
            {
                FirstTime = syllabus.FirstTime,
                FinishTime = syllabus.FinishTime,
                DayTime = syllabus.DayTime,
                StudentGuidId = syllabus.StudentGuidId,
                SyllabusGuidId = syllabus.SyllabusGuidId
            }).ToList();


            List<TallyCalculatorDto> tallyCalculatorList = tallyList.Select(tally => new TallyCalculatorDto
            {
                FirstDate = tally.FirstDate,
                FinishDate = tally.FinishDate,
                TallyCountHour = tally.CountHour,
                StudentGuidId = tally.StudentGuidId
            }).ToList();

            List<HolidayDto> holidayDtoList = holidayList.Select(holiday => new HolidayDto
            {
                HolidayFirstDate = holiday.HolidayFirstDate,
                HolidayFinishDate = holiday.HolidayFinishDate,
                HolidayName = holiday.HolidayName
            }).ToList();


            int nowCountHour = await _tallyCountService.TallyCountHour(tallyDto.FirstDate, tallyDto.FinishDate);
            IResult result = BusinessRules.Run(await _tallyCountControlService.IsTallyCountHourCalculator(nowCountHour),
            await _tallyWeekendService.IsWeekend(tallyDto.FirstDate, tallyDto.FinishDate),
            await _tallyWorkTimeService.IsWorkTime(tallyDto.FirstDate, tallyDto.FinishDate),
            await _tallyToMonthService.IsMonthTimeExist(tallyDto.FirstDate, tallyDto.FinishDate, tallyDto.StudentGuidId, nowCountHour, monthHour ,tallyCalculatorList),
            await _tallyToWeekService.IsWeekTimeExist(tallyDto.FirstDate, tallyDto.FinishDate, tallyDto.StudentGuidId, nowCountHour, weekHour ,tallyCalculatorList),
            await _tallySyllabusOverlapService.IsSyllabusOverlap(tallyDto.FirstDate, tallyDto.FinishDate, mappedList),
            await _tallyWorkTimeToHolidayService.IsWorkTimeHoliday(tallyDto.FirstDate, tallyDto.FinishDate, holidayDtoList));
            if (result != null)
            {
                return result;
            }

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TallyDto, Tally>()
                   .AfterMap((src, dest) => dest.CountHour = nowCountHour);
            });
            var mapperHashandSalt = config.CreateMapper();


            var mapper = _mapper.Map<Tally>(tallyDto);
            try
            {
                await _tallyDal.Add(mapper);
                return new SuccessResult(TallyMessages.Added);
            }
            catch (Exception ex)
            {
                return new Result(false, ex.Message);
            }
        }



        [SecuredAspect("Tally.Delete,Admin")]
        public async Task<IResult> Delete(Guid TallyGuidid)
        {
            if (TallyGuidid == Guid.Empty)
            {
                return new ErrorDataResult<Tally>("Id boş gönderilemez!!");
            }
            try
            {
                await _tallyDal.Delete(TallyGuidid);
                return new SuccessResult(TallyMessages.Deleted);
            }
            catch (Exception ex)
            {
                return new Result(false, ex.Message);
            }
        }


        [SecuredAspect("Tally.Get,Admin")]
        public async Task<IDataResult<Tally>> GetById(Guid TallyGuidId)
        {
            if (TallyGuidId == Guid.Empty)
            {
                return new ErrorDataResult<Tally>("Id boş gönderilemez!!");
            }

            var result = await _tallyDal.Get(p => p.TallyGuidId == TallyGuidId);
            return new SuccessDataResult<Tally>(result);
        }


        [SecuredAspect("Tally.Get,Admin")]
        public async Task<Tally> GetByIdForTallyService(Guid TallyGuidId)
        {
            var result = await _tallyDal.Get(p => p.TallyGuidId == TallyGuidId);
            return result;
        }

        [SecuredAspect("Tally.Get,Admin")]
        public async Task<IDataResult<List<TallyGetListDto>>> GetList()
        {
            List<Tally> listTally = await _tallyDal.GetAll();

            var myListTally = _mapper.Map<List<TallyGetListDto>>(listTally);
            return new SuccessDataResult<List<TallyGetListDto>>(myListTally);

        }


        [SecuredAspect("Tally.Update,Admin")]
        public async Task<IResult> Update(TallyUpdateDto tallyUpdateDto)
        {
            if (tallyUpdateDto.TallyGuidId == Guid.Empty)
            {
                return new ErrorDataResult<TallyUpdateDto>("Id boş gönderilemez!!");
            }

            var mapper = _mapper.Map<Tally>(tallyUpdateDto);
            //IResult result = BusinessRules.Run(await IsNameExistForUpdate(mapper));
            //if (result != null)
            //{
            //    return result;
            //}
            try
            {
                await _tallyDal.Update(mapper);
                return new SuccessResult(TallyMessages.Updated);
            }
            catch (Exception ex)
            {
                return new Result(false, ex.Message);
            }
        }







        //private async Task<IResult> IsNameExistForAdd(string name)
        //{
        //    var result = await _tallyDal.Get(p => p.Name == name);
        //    if (result != null)
        //    {
        //        return new ErrorResult(TallyMessages.NameIsNotAvaible);
        //    }
        //    return new SuccessResult();
        ////}
        //private async Task<IResult> IsNameExistForUpdate(Tally tally)
        //{
        //    var currentTally = await _tallyDal.Get(p => p.TallyGuidId == tally.TallyGuidId);
        //    if (currentTally.Name != tally.Name)
        //    {
        //        var result = await _tallyDal.Get(p => p.Name == tally.Name);
        //        if (result != null)
        //        {
        //            return new ErrorResult(TallyMessages.NameIsNotAvaible);
        //        }
        //    }
        //    return new SuccessResult();
        //}


    }
}
