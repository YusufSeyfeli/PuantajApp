using AutoMapper;
using Business.Aspects.Secured;
using Business.Repositories.CompetencyRepository.Constants;
using Business.Repositories.LoggingRepository.Constants;
using Business.Repositories.OperationClaimRepository.Validation;
using Business.Repositories.SettingsRepository.Validation;
using Core.Aspects.Caching;
using Core.Aspects.Performance;
using Core.Aspects.Validation;
using Core.Utilities.Business;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Repositories.LoggingRepository;
using Entities.Concrete;
using Entities.Dtos.CompetencyDtos;
using Entities.Dtos.LoggingDtos;
using Entities.Dtos.UserDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repositories.LoggingRepository
{
    public class LoggingManager:ILoggingService
    {
        private readonly ILoggingDal _loggingDal;
        private readonly IMapper _mapper;

        public LoggingManager(ILoggingDal logging, IMapper mapper)
        {
            _loggingDal = logging;
            _mapper = mapper;
        }

        [SecuredAspect("Logging.Add,Admin")]
        public async Task<IResult> Add(LoggingDto loggingDto)
        {
            IResult result = BusinessRules.Run(await IsNameExistForAdd(loggingDto.LogInfo));
            if (result != null)
            {
                return result;
            }
            var mapper = _mapper.Map<Logging>(loggingDto);
            try
            {
                await _loggingDal.Add(mapper);
                return new SuccessResult(LoggingMessages.Added);
            }
            catch (Exception ex)
            {
                return new Result(false, ex.Message);
            }
        }

        [SecuredAspect("Logging.Delete,Admin")]
        public async Task<IResult> Delete(Guid loggingGuidId)
        {
            if (loggingGuidId == Guid.Empty)
            {
                return new ErrorDataResult<Logging>("Id boş gönderilemez!!");
            }
            try
            {
                await _loggingDal.Delete(loggingGuidId);
                return new SuccessResult(LoggingMessages.Deleted);
            }
            catch (Exception ex)
            {
                return new Result(false, ex.Message);
            }
        }

        [SecuredAspect("Logging.Get,Admin")]
        public async Task<IDataResult<Logging>> GetById(Guid LoggingGuidId)
        {
            if (LoggingGuidId == Guid.Empty)
            {
                return new ErrorDataResult<Logging>("Id boş gönderilemez!!");
            }
            var result = await _loggingDal.Get(p => p.LoggingGuidId == LoggingGuidId);
            return new SuccessDataResult<Logging>(result);
        }


        [SecuredAspect("Logging.Get,Admin")]
        public async Task<Logging> GetByIdForLoggingService(Guid LoggingGuidId)
        {
            var result = await _loggingDal.Get(p => p.LoggingGuidId == LoggingGuidId);
            return result;
        }

        [SecuredAspect("Logging.Get,Admin")]
        public async Task<IDataResult<List<LoggingGetListDto>>> GetList()
        {
            List<Logging> listLogging = await _loggingDal.GetAll();

            var myListLogging = _mapper.Map<List<LoggingGetListDto>>(listLogging);
            return new SuccessDataResult<List<LoggingGetListDto>>(myListLogging);

        }


        [SecuredAspect("Logging.Update,Admin")]
        public async Task<IResult> Update(LoggingUpdateDto loggingUpdateDto)
        {
            if (loggingUpdateDto.LoggingGuidId == Guid.Empty)
            {
                return new ErrorDataResult<Logging>("Id boş gönderilemez!!");
            }
            var mapper = _mapper.Map<Logging>(loggingUpdateDto);
            IResult result = BusinessRules.Run(await IsNameExistForUpdate(mapper));
            if (result != null)
            {
                return result;
            }
            try
            {
                await _loggingDal.Update(mapper);
                return new SuccessResult(LoggingMessages.Updated);
            }
            catch (Exception ex)
            {
                return new Result(false, ex.Message);
            }
        }
        
        
        private async Task<IResult> IsNameExistForAdd(string logInfo)
        {
            var result = await _loggingDal.Get(p => p.LogInfo == logInfo);
            if (result != null)
            {
                return new ErrorResult(LoggingMessages.LogInfoIsNotAvaible);
            }
            return new SuccessResult();
        }
        private async Task<IResult> IsNameExistForUpdate(Logging logging)
        {
            var currentLogging = await _loggingDal.Get(p => p.LoggingGuidId == logging.LoggingGuidId);
            if (currentLogging.LogInfo != logging.LogInfo)
            {
                var result = await _loggingDal.Get(p => p.LogInfo == logging.LogInfo);
                if (result != null)
                {
                    return new ErrorResult(LoggingMessages.LogInfoIsNotAvaible);
                }
            }
            return new SuccessResult();
        }
    }
}
