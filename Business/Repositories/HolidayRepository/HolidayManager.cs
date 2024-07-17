using AutoMapper;
using Business.Aspects.Secured;
using Business.Repositories.CompetencyRepository.Constants;
using Business.Repositories.HolidayRepository.Constants;
using Core.Utilities.Business;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Repositories.HolidayRepository;
using Entities.Concrete;
using Entities.Dtos.CompetencyDtos;
using Entities.Dtos.HolidayDtos;
using Entities.Dtos.TallyDtos;
using Entities.Dtos.UserDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repositories.HolidayRepository
{
    public class HolidayManager : IHolidayService
    {
        private readonly IHolidayDal _holidayDal;
        private readonly IMapper _mapper;
        public HolidayManager(IHolidayDal holidayDal,IMapper mapper)
        {
            _holidayDal = holidayDal;
            _mapper = mapper;
        }

        [SecuredAspect("Holiday.Add,Admin")]
        public async Task<IResult> Add(HolidayDto holidayDto)
        {

            TimeZoneInfo utc3TimeZone = TimeZoneInfo.FindSystemTimeZoneById("Turkey Standard Time");

            holidayDto.HolidayFirstDate = TimeZoneInfo.ConvertTimeFromUtc(holidayDto.HolidayFirstDate, utc3TimeZone);
            holidayDto.HolidayFinishDate = TimeZoneInfo.ConvertTimeFromUtc(holidayDto.HolidayFinishDate, utc3TimeZone);

            IResult result = BusinessRules.Run(await IsNameExistForAdd(holidayDto.HolidayName));
            if (result != null)
            {
                return result;
            }
            var mapper = _mapper.Map<Holiday>(holidayDto);
            try
            {
                await _holidayDal.Add(mapper);
                return new SuccessResult(HolidayMessages.Added);
            }
            catch (Exception ex)
            {
                return new Result(false, ex.Message);
            }


        }


        [SecuredAspect("Holiday.Delete,Admin")]
        public async Task<IResult> Delete(Guid HolidayGuidId)
        {
            if (HolidayGuidId == Guid.Empty)
            {
                return new ErrorDataResult<Holiday>("Id boş gönderilemez!!");
            }
            try
            {
                await _holidayDal.Delete(HolidayGuidId);
                return new SuccessResult(HolidayMessages.Deleted);
            }
            catch (Exception ex)
            {
                return new Result(false, ex.Message);
            }
        }


        [SecuredAspect("Holiday.Add,Admin")]
        public async Task<IDataResult<Holiday>> GetById(Guid HolidayGuidId)
        {

            if (HolidayGuidId == Guid.Empty)
            {
                return new ErrorDataResult<Holiday>("Id boş gönderilemez!!");
            }
            var result = await _holidayDal.Get(p => p.HolidayGuidId == HolidayGuidId);
            return new SuccessDataResult<Holiday>(result);
        }

        [SecuredAspect("Holiday.Get,Admin")]
        public async Task<Holiday> GetByIdForHolidayService(Guid HolidayGuidId)
        {
            var result = await _holidayDal.Get(p => p.HolidayGuidId == HolidayGuidId);
            return result;
        }

        [SecuredAspect("Holiday.Add,Admin")]
        public async Task<IDataResult<List<HolidayGetListDto>>> GetList()
        {
            List<Holiday> listHoliday = await _holidayDal.GetAll();

            var myListHoliday = _mapper.Map<List<HolidayGetListDto>>(listHoliday);
            return new SuccessDataResult<List<HolidayGetListDto>>(myListHoliday);

        }


        [SecuredAspect("Holiday.Update,Admin")]
        public async Task<IResult> Update(HolidayUpdateDto holidayUpdateDto)
        {
            if (holidayUpdateDto.HolidayGuidId == Guid.Empty)
            {
                return new ErrorDataResult<HolidayUpdateDto>("Id boş gönderilemez!!");
            }
            var mapper = _mapper.Map<Holiday>(holidayUpdateDto);
            IResult result = BusinessRules.Run(await IsNameExistForUpdate(mapper));
            if (result != null)
            {
                return result;
            }
            try
            {
                await _holidayDal.Update(mapper);
                return new SuccessResult(HolidayMessages.Updated);
            }
            catch (Exception ex)
            {
                return new Result(false, ex.Message);
            }
        }
        private async Task<IResult> IsNameExistForAdd(string name)
        {
            var result = await _holidayDal.Get(p => p.HolidayName == name);
            if (result != null)
            {
                return new ErrorResult(HolidayMessages.NameIsNotAvaible);
            }
            return new SuccessResult();
        }
        private async Task<IResult> IsNameExistForUpdate(Holiday holiday)
        {
            var currentHoliday = await _holidayDal.Get(p => p.HolidayGuidId == holiday.HolidayGuidId);
            if (currentHoliday.HolidayName != holiday.HolidayName)
            {
                var result = await _holidayDal.Get(p => p.HolidayName == holiday.HolidayName);
                if (result != null)
                {
                    return new ErrorResult(HolidayMessages.NameIsNotAvaible);
                }
            }
            return new SuccessResult();
        }
    }
}
