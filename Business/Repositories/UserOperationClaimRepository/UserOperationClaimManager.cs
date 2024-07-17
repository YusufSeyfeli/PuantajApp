using AutoMapper;
using Business.Aspects.Secured;
using Business.Repositories.CompetencyRepository.Constants;
using Business.Repositories.OperationClaimRepository;
using Business.Repositories.UserJobUnitRepository.Constants;
using Business.Repositories.UserOperationClaimRepository.Constans;
using Business.Repositories.UserOperationClaimRepository.Validation;
using Business.Repositories.UserRepository;
using Core.Aspects.Validation;
using Core.Utilities.Business;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Repositories.UserOperationClaimRepository;
using Entities.Concrete;
using Entities.Dtos.CompetencyDtos;
using Entities.Dtos.UserDtos;
using Entities.Dtos.UserJobUnitDtos;
using Entities.Dtos.UserOperationClaimDtos;

namespace Business.Repositories.UserOperationClaimRepository
{
    public class UserOperationClaimManager : IUserOperationClaimService
    {
        private readonly IUserOperationClaimDal _userOperationClaimDal;
        private readonly IOperationClaimService _operationClaimService;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserOperationClaimManager(IUserOperationClaimDal userOperationClaimDal, IOperationClaimService operationClaimService, IUserService userService,IMapper mapper)
        {
            _userOperationClaimDal = userOperationClaimDal;
            _operationClaimService = operationClaimService;
            _userService = userService;
            _mapper = mapper;
        }

        [SecuredAspect("UserOperationClaim.Delete,Admin")]
        public async Task<IResult> Delete(Guid UserOperationClaimGuidId)
        {
            if (UserOperationClaimGuidId == Guid.Empty)
            {
                return new ErrorDataResult<UserOperationClaim>("Id boş gönderilemez!!");
            }

            await _userOperationClaimDal.Delete(UserOperationClaimGuidId);
            return new SuccessResult(UserOperationClaimMessages.Deleted);
        }

        [SecuredAspect("UserOperationClaim.Get,Admin")]
        public async Task<IDataResult<UserOperationClaim>> GetById(Guid UserOperationClaimGuidId)
        {
            if (UserOperationClaimGuidId == Guid.Empty)
            {
                return new ErrorDataResult<UserOperationClaim>("Id boş gönderilemez!!");
            }
            return new SuccessDataResult<UserOperationClaim>(await _userOperationClaimDal.Get(p => p.UserOperationClaimGuidId == UserOperationClaimGuidId));
        }

        [SecuredAspect("UserOperationClaim.Get,Admin")]
        public async Task<IDataResult<List<UserOperationClaimGetListDto>>> GetList()
        {
            List<UserOperationClaim> listUserOperationClaim = await _userOperationClaimDal.GetAll();

            var myListUserOperationClaim = _mapper.Map<List<UserOperationClaimGetListDto>>(listUserOperationClaim);
            return new SuccessDataResult<List<UserOperationClaimGetListDto>>(myListUserOperationClaim);

        }


        [SecuredAspect("UserOperationClaim.Update,Admin")]
        [ValidationAspect(typeof(UserOperationClaimValidator))]
        public async Task<IResult> Update(UserOperationClaimUpdateDto userOperationClaimUpdateDto)
        {//Bu kısımı sor
            if (userOperationClaimUpdateDto.UserGuidId == Guid.Empty)
            {
                return new ErrorDataResult<UserOperationClaimUpdateDto>("Id boş gönderilemez!!");
            }
            var mapper = _mapper.Map<UserOperationClaim>(userOperationClaimUpdateDto);
            IResult result = BusinessRules.Run(
                await IsUserExist(mapper.OperationClaimGuidId),
                await IsOperationClaimExist(mapper.UserOperationClaimGuidId),
                await IsOperationSetExistForUpdate(mapper)
                );
            if (result != null)
            {
                return result;
            }
            try
            {
                await _userOperationClaimDal.Update(mapper);
                return new SuccessResult(UserOperationClaimMessages.Updated);
            }
            catch (Exception ex)
            {
                return new Result(false, ex.Message);
            }
        }


        [SecuredAspect("UserOperationClaim.Add,Admin")]
        [ValidationAspect(typeof(UserOperationClaimValidator))]
        public async Task<IResult> Add(UserOperationClaimDto userOperationClaimDto)
        {

            IResult result = BusinessRules.Run(
                await IsUserExist(userOperationClaimDto.UserGuidId),
                await IsOperationClaimExist(userOperationClaimDto.OperationClaimGuidId),
                await IsOperationSetExistForAdd(userOperationClaimDto)
                );

            if (result != null)
            {
                return result;
            }
            var mapper = _mapper.Map<UserOperationClaim>(userOperationClaimDto);

            try
            {
                await _userOperationClaimDal.Add(mapper);
                return new SuccessResult(UserOperationClaimMessages.Added);
            }
            catch (Exception ex)
            {
                return new Result(false, ex.Message);
            }

        }

        public async Task<IResult> IsUserExist(Guid userId)
        {
            var result = await _userService.GetByIdForAuth(userId);
            if (result == null)
            {
                return new ErrorResult(UserOperationClaimMessages.UserNotExist);
            }
            return new SuccessResult();
        }

        public async Task<IResult> IsOperationClaimExist(Guid operationClaimId)
        {
            var result = await _operationClaimService.GetByIdForUserService(operationClaimId);
            if (result == null)
            {
                return new ErrorResult(UserOperationClaimMessages.OperationClaimNotExist);
            }
            return new SuccessResult();
        }

        public async Task<IResult> IsOperationSetExistForAdd(UserOperationClaimDto userOperationClaimDto)
        {
            var mapper = _mapper.Map<UserOperationClaim>(userOperationClaimDto);

            var result = await _userOperationClaimDal.Get(p => p.UserGuidId == mapper.UserGuidId && p.UserOperationClaimGuidId == mapper.UserOperationClaimGuidId);
            if (result != null)
            {
                return new ErrorResult(UserOperationClaimMessages.OperationClaimSetExist);
            }
            return new SuccessResult();
        }

        private async Task<IResult> IsOperationSetExistForUpdate(UserOperationClaim userOperationClaim)
        {
            var currentUserOperationClaim = await _userOperationClaimDal.Get(p => p.UserOperationClaimGuidId == userOperationClaim.UserOperationClaimGuidId);
            if (currentUserOperationClaim.UserGuidId != userOperationClaim.UserGuidId || currentUserOperationClaim.UserGuidId != userOperationClaim.UserGuidId)
            {
                var result = await _userOperationClaimDal.Get(p => p.UserGuidId == userOperationClaim.UserGuidId && p.UserOperationClaimGuidId == userOperationClaim.UserOperationClaimGuidId);
                if (result != null)
                {
                    return new ErrorResult(UserOperationClaimMessages.OperationClaimSetExist);
                }
            }
            return new SuccessResult();
        }


        [SecuredAspect("UserOperationClaim.Add,Admin")]
        public async Task<IResult> BulkAddForUserOperationClaim(List<UserOperationClaimDto> userOperationClaimDtos)
        {
            try
            {
                List<UserOperationClaim> userOperationClaims = await _userOperationClaimDal.GetAll(p => p.UserGuidId == userOperationClaimDtos[0].UserGuidId);
                await _userOperationClaimDal.BulkDelete(userOperationClaims);
                var mapper = _mapper.Map<List<UserOperationClaim>>(userOperationClaimDtos);
                await _userOperationClaimDal.BulkAdd(mapper);
                return new SuccessResult(UserOperationClaimMessages.Added);
            }
            catch (Exception ex)
            {
                return new Result(false, ex.Message);
            }
            throw new NotImplementedException();
        }

        [SecuredAspect("UserOperationClaim.Delete,Admin")]
        public async Task<IResult> BulkDeleteForUserOperationClaim(Guid UserGuidId)
        {
            try
            {
                List<UserOperationClaim> userOperationClaims = await _userOperationClaimDal.GetAll(p => p.UserGuidId == UserGuidId);
                await _userOperationClaimDal.BulkDelete(userOperationClaims);
                return new SuccessResult(UserOperationClaimMessages.Deleted);
            }
            catch (Exception ex)
            {
                return new Result(false, ex.Message);
            }
            throw new NotImplementedException();
        }

        [SecuredAspect("UserOperationClaim.Add,Admin")]
        public async Task<IResult> BulkUpdateForUserOperationClaim(List<UserOperationClaimUpdateDto> userOperationClaimUpdateDtos)
        {
            try
            {
                var mapper = _mapper.Map<List<UserOperationClaim>>(userOperationClaimUpdateDtos);
                await _userOperationClaimDal.BulkUpdate(mapper);
                return new SuccessResult(UserOperationClaimMessages.Added);
            }
            catch (Exception ex)
            {
                return new Result(false, ex.Message);
            }
            throw new NotImplementedException();
        }


    }
}
