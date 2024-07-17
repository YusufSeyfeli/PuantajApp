using AutoMapper;
using Business.Aspects.Secured;
using Business.Repositories.CompetencyRepository.Constants;
using Business.Repositories.OperationCompetencyRepository.Constants;
using Business.Repositories.UserJobUnitRepository.Constants;
using Core.Utilities.Business;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Repositories.CompetencyRepository;
using DataAccess.Repositories.UserJobUnitRepository;
using Entities.Concrete;
using Entities.Dtos.CompetencyDtos;
using Entities.Dtos.OperationClaimDtos;
using Entities.Dtos.OperationCompetencyDtos;
using Entities.Dtos.UserDtos;
using Entities.Dtos.UserJobUnitDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repositories.UserJobUnitRepository
{
    public class UserJobUnitManager : IUserJobUnitService
    {
        private readonly IUserJobUnitDal _userJobUnitDal;
        private readonly IMapper _mapper;
        public UserJobUnitManager(IUserJobUnitDal userJobUnitDal,IMapper mapper)
        {
            _userJobUnitDal = userJobUnitDal;
            _mapper = mapper;
        }


        [SecuredAspect("UserJobUnit.Add,Admin")]
        public async Task<IResult> Add(UserJobUnitDto userJobUnitDto)
        {

            //Bu kısımı sor
            //IResult result = BusinessRules.Run(await IsNameExistForAdd(userJobUnitDto.UserJobUnitGuidId));
            //if (result != null)
            //{
            //    return result;
            //}
            var mapper = _mapper.Map<UserJobUnit>(userJobUnitDto);
            try
            {
                await _userJobUnitDal.Add(mapper);
                return new SuccessResult(UserJobUnitMessages.Added);
            }
            catch (Exception ex)
            {
                return new Result(false, ex.Message);
            }
        }


        [SecuredAspect("UserJobUnit.Delete,Admin")]
        public async Task<IResult> Delete(Guid UserJobUnitGuidId)
        {
            if (UserJobUnitGuidId == Guid.Empty)
            {
                return new ErrorDataResult<UserJobUnit>("Id boş gönderilemez!!");
            }

            try
            {
                await _userJobUnitDal.Delete(UserJobUnitGuidId);
                return new SuccessResult(UserJobUnitMessages.Deleted);
            }
            catch (Exception ex)
            {
                return new Result(false, ex.Message);
            }
        }


        [SecuredAspect("UserJobUnit.Get,Admin")]
        public async Task<IDataResult<UserJobUnit>> GetById(Guid UserJobUnitGuidId)
        {
            if (UserJobUnitGuidId == Guid.Empty)
            {
                return new ErrorDataResult<UserJobUnit>("Id boş gönderilemez!!");
            }

            var result = await _userJobUnitDal.Get(p => p.UserJobUnitGuidId == UserJobUnitGuidId);
            return new SuccessDataResult<UserJobUnit>(result);
        }


        [SecuredAspect("UserJobUnit.Get,Admin")]
        public async Task<UserJobUnit> GetByIdForCompetencyService(Guid UserJobUnitGuidId)
        {
            var result = await _userJobUnitDal.Get(p => p.UserJobUnitGuidId == UserJobUnitGuidId);
            return result;

        }


        [SecuredAspect("UserJobUnit.Get,Admin")]
        public async Task<IDataResult<List<UserJobUnitGetListDto>>> GetList()
        {
            List<UserJobUnit> listUserJobUnit = await _userJobUnitDal.GetAll();

            var myListUserJobUnit = _mapper.Map<List<UserJobUnitGetListDto>>(listUserJobUnit);
            return new SuccessDataResult<List<UserJobUnitGetListDto>>(myListUserJobUnit);
        }


        [SecuredAspect("UserJobUnit.Get,Admin")]
        public async Task<IResult> Update(UserJobUnitUpdateDto userJobUnitUpdateDto)
        {
            if (userJobUnitUpdateDto.UserGuidId == Guid.Empty)
            {
                return new ErrorDataResult<UserJobUnitUpdateDto>("Id boş gönderilemez!!");
            }

            var mapper = _mapper.Map<UserJobUnit>(userJobUnitUpdateDto);

            //IResult result = BusinessRules.Run(await IsNameExistForUpdate(userJobUnit));
            //if (result != null)
            //{
            //    return result;
            //}
            try
            {
                await _userJobUnitDal.Update(mapper);
                return new SuccessResult(UserJobUnitMessages.Updated);
            }
            catch (Exception ex)
            {
                return new Result(false, ex.Message);
            }
        }

        //private async Task<IResult> IsNameExistForAdd(Guid UserJobUnitGuidId)
        //{
        //    var result = await _userJobUnitDal.Get(p => p.UserGuidId == UserJobUnitGuidId);
        //    if (result != null)
        //    {
        //        return new ErrorResult(UserJobUnitMessages.NameIsNotAvaible);
        //    }
        //    return new SuccessResult();
        //}
        //private async Task<IResult> IsNameExistForUpdate(UserJobUnit userJobUnit)
        //{
        //    var currentUserJobUnit = await _userJobUnitDal.Get(p => p.UserJobUnitGuidId == userJobUnit.UserJobUnitGuidId);
        //    if (currentUserJobUnit.UserGuidId != userJobUnit.UserGuidId)
        //    {
        //        var result = await _userJobUnitDal.Get(p => p.UserGuidId == userJobUnit.UserGuidId);
        //        if (result != null)
        //        {
        //            return new ErrorResult(UserJobUnitMessages.NameIsNotAvaible);
        //        }
        //    }
        //    return new SuccessResult();
        //}

        //[SecuredAspect("UserJobUnit.Update,Admin")]
        //public async Task<IResult> BulkUpdateForUserJobUnit(List<UserJobUnitUpdateDto> userJobUnits)
        //{
        //    var mapper = _mapper.Map<List<UserJobUnitUpdateDto>, List<UserJobUnit>>(userJobUnits);
        //    try
        //    {
        //        await _userJobUnitDal.BulkUpdateForUserJobUnit(mapper);
        //        return new SuccessResult(UserJobUnitMessages.Updated);
        //    }
        //    catch (Exception ex)
        //    {
        //        return new Result(false, ex.Message);
        //    }
        //    throw new NotImplementedException();
        //}

        //[SecuredAspect("UserJobUnit.Add,Admin")]
        //public async Task<IResult> BulkAddForUserJobUnit(List<UserJobUnitDto> userJobUnits)
        //{
        //    var mapper = _mapper.Map<List<UserJobUnit>>(userJobUnits);
        //    try
        //    {
        //        await _userJobUnitDal.BulkAddForUserJobUnit(mapper);
        //        return new SuccessResult(UserJobUnitMessages.Added);
        //    }
        //    catch (Exception ex)
        //    {
        //        return new Result(false, ex.Message);
        //    }
        //    throw new NotImplementedException();
        //}

        //[SecuredAspect("UserJobUnit.Add,Admin")]
        //public async Task<IResult> BulkDeleteForUserJobUnit(List<UserJobUnitUpdateDto> userJobUnits)
        //{
        //    var mapper = _mapper.Map<List<UserJobUnit>>(userJobUnits);
        //    try
        //    {
        //        await _userJobUnitDal.BulkDeleteForUserJobUnit(mapper);
        //        return new SuccessResult(UserJobUnitMessages.Deleted);
        //    }
        //    catch (Exception ex)
        //    {
        //        return new Result(false, ex.Message);
        //    }
        //    throw new NotImplementedException();
        //}

        [SecuredAspect("UserJobUnit.Add,Admin")]
        public async Task<IResult> BulkAddForUserJobUnit(List<UserJobUnitDto> userJobUnitDtos)
        {            
            try
            {
                List<UserJobUnit> userJobUnits = await _userJobUnitDal.GetAll(p => p.UserGuidId == userJobUnitDtos[0].UserGuidId);
                await _userJobUnitDal.BulkDelete(userJobUnits);
                var mapper = _mapper.Map<List<UserJobUnit>>(userJobUnitDtos);
                await _userJobUnitDal.BulkAdd(mapper);
                return new SuccessResult(UserJobUnitMessages.Added);
            }
            catch (Exception ex)
            {
                return new Result(false, ex.Message);
            }
            throw new NotImplementedException();
        }

        [SecuredAspect("UserJobUnit.Delete,Admin")]
        public async Task<IResult> BulkDeleteForUserJobUnit(Guid UserGuidId)
        {
            try
            {
                List<UserJobUnit> userJobUnits = await _userJobUnitDal.GetAll(p => p.UserGuidId == UserGuidId);
                await _userJobUnitDal.BulkDelete(userJobUnits);
                return new SuccessResult(UserJobUnitMessages.Deleted);
            }
            catch (Exception ex)
            {
                return new Result(false, ex.Message);
            }
            throw new NotImplementedException();
        }

        [SecuredAspect("UserJobUnit.Add,Admin")]
        public async Task<IResult> BulkUpdateForUserJobUnit(List<UserJobUnitUpdateDto> userJobUnitUpdateDtos)
        {
            try
            {
                var mapper = _mapper.Map<List<UserJobUnit>>(userJobUnitUpdateDtos);
                await _userJobUnitDal.BulkUpdate(mapper);
                return new SuccessResult(UserJobUnitMessages.Added);
            }
            catch (Exception ex)
            {
                return new Result(false, ex.Message);
            }
            throw new NotImplementedException();
        }

    }
}

