using Business.Repositories.HolidayRepository.Constants;
using Business.Repositories.HolidayRepository;
using Core.Utilities.Business;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Repositories.HolidayRepository;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Repositories.OperationCompetencyRepository;
using Business.Repositories.OperationCompetencyRepository.Constants;
using Business.Repositories.CompetencyRepository.Constants;
using Entities.Dtos.CompetencyDtos;
using Entities.Dtos.OperationCompetencyDtos;
using AutoMapper;
using Business.Aspects.Secured;
using Entities.Dtos.UserDtos;

namespace Business.Repositories.OperationCompetencyRepository
{
    public class OperationCompetencyManager : IOperationCompetencyService
    {
        private readonly IOperationCompetencyDal _operationCompetencyDal;
        private readonly IMapper _mapper;
        public OperationCompetencyManager(IOperationCompetencyDal operationCompetencyDal,IMapper mapper)
        {
            _operationCompetencyDal = operationCompetencyDal;
            _mapper = mapper;
        }


        [SecuredAspect("OperationCompetency.Add,Admin")]
        public async Task<IResult> Add(OperationCompetencyDto operationCompetencyDto)
        {
            var mapper = _mapper.Map<OperationCompetency>(operationCompetencyDto);
            try
            {
                await _operationCompetencyDal.Add(mapper);
                return new SuccessResult(OperationCompetencyMessages.Added);
            }
            catch (Exception ex)
            {
                return new Result(false, ex.Message);
            }
        }


        [SecuredAspect("OperationCompetency.Delete,Admin")]
        public async Task<IResult> Delete(Guid operationCompetencyGuidId)
        {
            if (operationCompetencyGuidId == Guid.Empty)
            {
                return new ErrorDataResult<OperationCompetency>("Id boş gönderilemez!!");
            }
            try
            {
                await _operationCompetencyDal.Delete(operationCompetencyGuidId);
                return new SuccessResult(OperationCompetencyMessages.Deleted);
            }
            catch (Exception ex)
            {
                return new Result(false, ex.Message);
            }
        }


        [SecuredAspect("OperationCompetency.Get,Admin")]
        public async Task<IDataResult<OperationCompetency>> GetById(Guid operationCompetencyGuidId)
        {
            if (operationCompetencyGuidId == Guid.Empty)
            {
                return new ErrorDataResult<OperationCompetency>("Id boş gönderilemez!!");
            }
            var result = await _operationCompetencyDal.Get(p => p.OperationCompetencyGuidId == operationCompetencyGuidId);
            return new SuccessDataResult<OperationCompetency>(result);
        }


        [SecuredAspect("OperationCompetency.Get,Admin")]
        public async Task<OperationCompetency> GetByIdForOperationCompetencyService(Guid operationCompetencyGuidId)
        {
            var result = await _operationCompetencyDal.Get(p => p.OperationCompetencyGuidId == operationCompetencyGuidId);
            return result;
        }


        [SecuredAspect("OperationCompetency.Get,Admin")]
        public async Task<IDataResult<List<OperationCompetencyGetListDto>>> GetList()
        {
            List<OperationCompetency> listOperationCompetency = await _operationCompetencyDal.GetAll();

            var myListOperationCompetency = _mapper.Map<List<OperationCompetencyGetListDto>>(listOperationCompetency);
            return new SuccessDataResult<List<OperationCompetencyGetListDto>>(myListOperationCompetency);

        }


        [SecuredAspect("OperationCompetency.Update,Admin")]
        public async Task<IResult> Update(OperationCompetencyUpdateDto operationCompetencyUpdateDto)
        {
            if (operationCompetencyUpdateDto.OperationCompetencyGuidId == Guid.Empty
                || operationCompetencyUpdateDto.OperationCompetencyGuidId == Guid.Empty
                || operationCompetencyUpdateDto.OperationClaimGuidId == Guid.Empty)
            {
                return new ErrorDataResult<OperationCompetency>("Id boş gönderilemez!!");
            }
            var mapper = _mapper.Map<OperationCompetency>(operationCompetencyUpdateDto);

            try
            {
                await _operationCompetencyDal.Update(mapper);
                return new SuccessResult(OperationCompetencyMessages.Updated);
            }
            catch (Exception ex)
            {
                return new Result(false, ex.Message);
            }
        }

        //[SecuredAspect("OperationCompetency.Update,Admin")]
        //public async Task<IResult> BulkUpdateForOperationClaim(OperationCompetencyUpdateDto operationCompetencies)
        //{
        //    var mapper = _mapper.Map<List<OperationCompetencyUpdateDto>,List<OperationCompetency>>(operationCompetencies);
        //    try
        //    {
        //        await _operationCompetencyDal.BulkUpdateForOperationClaim(mapper);
        //        return new SuccessResult(OperationCompetencyMessages.Updated);
        //    }
        //    catch (Exception ex)
        //    {
        //        return new Result(false, ex.Message);
        //    }
        //    throw new NotImplementedException();
        //}

        [SecuredAspect("OperationCompetency.Add,Admin")]
        public async Task<IResult> BulkAddForOperationCompetency(List<OperationCompetencyDto> operationCompetencies)
        {

            try
            {
                var mapper = _mapper.Map<List<OperationCompetency>>(operationCompetencies);
                await _operationCompetencyDal.BulkAdd(mapper);
                return new SuccessResult(OperationCompetencyMessages.Added);
            }
            catch (Exception ex)
            {
                return new Result(false, ex.Message);
            }
            throw new NotImplementedException();
        }

        //[SecuredAspect("OperationCompetency.Add,Admin")]
        //public async Task<IResult> BulkDeleteForOperationClaim(OperationCompetencyUpdateDto operationCompetencies)
        //{
        //    var mapper = _mapper.Map<List<OperationCompetency>>(operationCompetencies);
        //    try
        //    {
        //        await _operationCompetencyDal.BulkDeleteForOperationClaim(mapper);
        //        return new SuccessResult(OperationCompetencyMessages.Deleted);
        //    }
        //    catch (Exception ex)
        //    {
        //        return new Result(false, ex.Message);
        //    }
        //    throw new NotImplementedException();
        //}
        
        [SecuredAspect("OperationCompetency.Delete,Admin")]
        public async Task<IResult> BulkDeleteForOperationCompetency(Guid guidId)
        {
            if (guidId == Guid.Empty)
            {
                return new ErrorDataResult<OperationCompetency>("Id boş gönderilemez!!");
            }
            try
            {
                List<OperationCompetency> operationCompetencies = await _operationCompetencyDal.GetAll(p => p.OperationClaimGuidId == guidId);
                var mapper = _mapper.Map<List<OperationCompetency>>(operationCompetencies);
                await _operationCompetencyDal.BulkDelete(mapper);
                return new SuccessResult(OperationCompetencyMessages.Deleted);
            }
            catch (Exception ex)
            {
                return new Result(false, ex.Message);
            }
            throw new NotImplementedException();
        }

        [SecuredAspect("OperationCompetency.Update,Admin")]
        public async Task<IResult> BulkUpdateForOperationCompetency(List<OperationCompetencyUpdateDto> operationCompetencyUpdate)
        {

            try
            {
                var mapper = _mapper.Map<List<OperationCompetency>>(operationCompetencyUpdate);
                await _operationCompetencyDal.BulkUpdate(mapper);
                return new SuccessResult(OperationCompetencyMessages.Added);
            }
            catch (Exception ex)
            {
                return new Result(false, ex.Message);
            }
            throw new NotImplementedException();
        }


        //Bu kısımı sor
        //private async Task<IResult> IsIdExistForAdd(Guid OperationCompetencyGuidId)
        //{
        //    var result = await _operationCompetencyDal.Get(p => p.OperationCompetencyGuidId == OperationCompetencyGuidId);
        //    if (result != null)
        //    {
        //        return new ErrorResult(OperationCompetencyMessages.NameIsNotAvaible);
        //    }
        //    return new SuccessResult();
        //}
        // Bu kısımı sor
        //private async Task<IResult> IsNameExistForUpdate(OperationCompetency operationCompetency)
        //{
        //    var currentOperationCompetency = await _operationCompetencyDal.Get(p => p.OperationCompetencyGuidId == operationCompetency.OperationCompetencyGuidId);
        //    if (currentOperationCompetency.OperationCompetencyGuidId != operationCompetency.OperationCompetencyGuidId)
        //    {
        //        var result = await _operationCompetencyDal.Get(p => p.OperationCompetencyGuidId == operationCompetency.OperationCompetencyGuidId);
        //        if (result != null)
        //        {
        //            return new ErrorResult(OperationCompetencyMessages.NameIsNotAvaible);
        //        }
        //    }
        //    return new SuccessResult();
        //}

    }
}
