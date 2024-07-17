using AutoMapper;
using Business.Aspects.Secured;
using Business.Repositories.CompetencyRepository.Constants;
using Business.Repositories.SettingsRepository.Constants;
using Business.Repositories.SettingsRepository.Validation;
using Core.Aspects.Caching;
using Core.Aspects.Performance;
using Core.Aspects.Validation;
using Core.Utilities.Business;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Repositories.SettingsRepository;
using Entities.Concrete;
using Entities.Dtos.CompetencyDtos;
using Entities.Dtos.SettingsDtos;
using Entities.Dtos.UserDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repositories.SettingsRepository
{
    public class SettingsManager : ISettingsService
    {
        private readonly ISettingsDal _settingsDal;
        private readonly IMapper _mapper;

        public SettingsManager(ISettingsDal settingsDal, IMapper mapper)
        {
            _settingsDal = settingsDal;
            _mapper = mapper;
        }


        [SecuredAspect("Settings.Add,Admin")]
        public async Task<IResult> Add(SettingsDto settingsDto)
        {
            //IResult result = BusinessRules.Run(await IsNameExistForAdd(settingsDto.));
            //if (result != null)
            //{
            //    return result;
            //}
            var mapper = _mapper.Map<Settings>(settingsDto);
            try
            {
                await _settingsDal.Add(mapper);
                return new SuccessResult(SettingsMessages.Added);
            }
            catch (Exception ex)
            {
                return new Result(false, ex.Message);
            }
        }



        [SecuredAspect("Settings.Update,Admin")]
        public async Task<IResult> Update(SettingsUpdateDto settingsUpdateDto)
        {
            if (settingsUpdateDto.SettingsGuidId == Guid.Empty)
            {
                return new ErrorDataResult<Settings>("Id boş gönderilemez!!");
            }
            var mapper = _mapper.Map<Settings>(settingsUpdateDto);
            //IResult result = BusinessRules.Run(await IsNameExistForUpdate(mapper));
            //if (result != null)
            //{
            //    return result;
            //}
            try
            {
                await _settingsDal.Update(mapper);
                return new SuccessResult(SettingsMessages.Updated);
            }
            catch (Exception ex)
            {
                return new Result(false, ex.Message);
            }
        }

        [SecuredAspect("Settings.Delete,Admin")]
        public async Task<IResult> Delete(Guid id)
        {
            await _settingsDal.Delete(id);
            return new SuccessResult(SettingsMessages.Deleted);
        }

        [SecuredAspect("Settings.Get,Admin")]
        public async Task<IDataResult<List<SettingsGetListDto>>> GetList()
        {
            List<Settings> listUser = await _settingsDal.GetAll();

            var myListUser = _mapper.Map<List<SettingsGetListDto>>(listUser);
            return new SuccessDataResult<List<SettingsGetListDto>>(myListUser);

        }


        [SecuredAspect("Settings.Get,Admin")]
        public async Task<IDataResult<Settings>> GetById(Guid SettingsGuidId)
        {
            if (SettingsGuidId == Guid.Empty)
            {
                return new ErrorDataResult<Settings>("Id boş gönderilemez!!");
            }


            var result = await _settingsDal.Get(p => p.SettingsGuidId == SettingsGuidId);
            return new SuccessDataResult<Settings>(result);
        }


        [SecuredAspect("Swttings.Get,Admin")]
        public async Task<Settings> GetByIdForSettingsService(Guid SettingsGuidId)
        {
            var result = await _settingsDal.Get(p => p.SettingsGuidId == SettingsGuidId);
            return result;
        }

        //private async Task<IResult> IsNameExistForAdd(DateTime weekHour)
        //{
        //    var result = await _settingsDal.Get(p => p.WeekHour == weekHour);
        //    if (result != null)
        //    {
        //        return new ErrorResult(SettingsMessages.NameIsNotAvaible);
        //    }
        //    return new SuccessResult();
        //}

        //private async Task<IResult> IsNameExistForUpdate(Settings settings)
        //{
        //    var currentSettings = await _settingsDal.Get(p => p.SettingsGuidId == settings.SettingsGuidId);
        //    if (currentSettings.WeekHour != settings.WeekHour)
        //    {
        //        var result = await _settingsDal.Get(p => p.WeekHour == settings.WeekHour);
        //        if (result != null)
        //        {
        //            return new ErrorResult(SettingsMessages.NameIsNotAvaible);
        //        }
        //    }
        //    return new SuccessResult();
        //}
    }
}
