using AutoMapper;
using Business.Aspects.Secured;
using Business.Repositories.CompetencyRepository.Constants;
using Business.Repositories.OperationClaimRepository.Constants;
using Business.Repositories.OperationClaimRepository.Validation;
using Core.Aspects.Caching;
using Core.Aspects.Performance;
using Core.Aspects.Validation;
using Core.Utilities.Business;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Repositories.OperationClaimRepository;
using DataAccess.Repositories.CompetencyRepository;
using Entities.Concrete;
using Entities.Dtos.CompetencyDtos;
using Entities.Dtos.JobUnitDtos;
using Entities.Dtos.OperationClaimDtos;
using Entities.Dtos.UserDtos;

namespace Business.Repositories.OperationClaimRepository
{
    public class OperationClaimManager : IOperationClaimService
    {
        private readonly IOperationClaimDal _operationClaimDal;
        private readonly IMapper _mapper;
        private readonly ICompetencyDal _competencyDal;
        public OperationClaimManager(IOperationClaimDal operationClaimDal,IMapper mapper, ICompetencyDal competencyDal)
        {
            _operationClaimDal = operationClaimDal;
            _mapper = mapper;
            _competencyDal = competencyDal;
        }

        [SecuredAspect("OperationClaim.Add,Admin")]
        [ValidationAspect(typeof(OperationClaimValidator))]
        public async Task<IResult> Add(OperationClaimDto operationClaimDto)
        {
            IResult result = BusinessRules.Run(await IsNameExistForAdd(operationClaimDto.OperationClaimName));
            if (result != null)
            {
                return result;
            }
            var mapper = _mapper.Map<OperationClaim>(operationClaimDto);
            try
            {
                await _operationClaimDal.Add(mapper);
                return new SuccessResult(OperationClaimMessages.Added);
            }
            catch (Exception ex)
            {
                return new Result(false, ex.Message);
            }
        }

        [SecuredAspect("OperationClaim.Update,Admin")]
        [ValidationAspect(typeof(OperationClaimValidator))] 
        public async Task<IResult> Update(OperationClaimUpdateDto operationClaimUpdateDto)
        {
            if (operationClaimUpdateDto.OperationClaimGuidId == Guid.Empty)
            {
                return new ErrorDataResult<OperationClaim>("Id boş gönderilemez!!");
            }
            var mapper = _mapper.Map<OperationClaim>(operationClaimUpdateDto);
            IResult result = BusinessRules.Run(await IsNameExistForUpdate(mapper));
            if (result != null)
            {
                return result;
            }
            try
            {
                await _operationClaimDal.Update(mapper);
                return new SuccessResult(OperationClaimMessages.Added);
            }
            catch (Exception ex)
            {
                return new Result(false, ex.Message);
            }
        }

        [SecuredAspect("OperationClaim.Delete,Admin")]
        public async Task<IResult> Delete(Guid OperationClaimGuidId)
        {
            if (OperationClaimGuidId == Guid.Empty)
            {
                return new ErrorDataResult<OperationClaim>("Id boş gönderilemez!!");
            }
            await _operationClaimDal.Delete(OperationClaimGuidId);
            return new SuccessResult(OperationClaimMessages.Deleted);
        }

        [SecuredAspect("OperationClaim.Get,Admin")]
        //[CacheAspect()]
        //[PerformanceAspect()]
        public async Task<IDataResult<List<OperationClaimGetListDto>>> GetListWithCompetency()
        {
            List<OperationClaimGetListDto> operationClaimGetListDtos = new List<OperationClaimGetListDto>();
            List<OperationClaim> listOperationClaim = await _operationClaimDal.GetAll();

            foreach (var operationClaim in listOperationClaim)
            {
                List<Competency> listCompetencies = await _competencyDal.GetCompetenciesbyOperationClaimId(operationClaim.OperationClaimGuidId);
                var config2 = _mapper.Map<List<Competency>,List<CompetencyGetListDto>>(listCompetencies);
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<OperationClaim, OperationClaimGetListDto>()
                       .AfterMap((src, dest) => dest.GetCompetencyGetListDtos = config2);
                });
                var myMap = config.CreateMapper();
                operationClaimGetListDtos.Add(myMap.Map<OperationClaimGetListDto>(operationClaim));
            }
            return new SuccessDataResult<List<OperationClaimGetListDto>>(operationClaimGetListDtos);

        }
        [SecuredAspect("OperationClaim.Get,Admin")]
        //[CacheAspect()]
        //[PerformanceAspect()]
        public async Task<IDataResult<List<OperationClaimGetUserDto>>> GetList()
        {
            List<OperationClaim> listOperationClaim = await _operationClaimDal.GetAll();

            var mapper = _mapper.Map<List<OperationClaim>, List<OperationClaimGetUserDto>>(listOperationClaim);
            return new SuccessDataResult<List<OperationClaimGetUserDto>>(mapper);

        }

        [SecuredAspect("OperationClaim.Get,Admin")]
        public async Task<IDataResult<OperationClaim>> GetById(Guid OperationClaimGuidId)
        {
            if (OperationClaimGuidId == Guid.Empty)
            {
                return new ErrorDataResult<OperationClaim>("Id boş gönderilemez!!");
            }
            var result = await _operationClaimDal.Get(p => p.OperationClaimGuidId == OperationClaimGuidId);
            return new SuccessDataResult<OperationClaim>(result);
        }

        [SecuredAspect("OperationClaim.Get,Admin")]
        public async Task<OperationClaim> GetByIdForUserService(Guid OperationClaimGuidId)
        {
            var result = await _operationClaimDal.Get(p => p.OperationClaimGuidId == OperationClaimGuidId);
            return result;
        }

        private async Task<IResult> IsNameExistForAdd(string name)
        {
            var result = await _operationClaimDal.Get(p => p.OperationClaimName == name);
            if (result != null)
            {
                return new ErrorResult(OperationClaimMessages.NameIsNotAvaible);
            }
            return new SuccessResult();
        }

        private async Task<IResult> IsNameExistForUpdate(OperationClaim operationClaim)
        {
            var currentOperationClaim = await _operationClaimDal.Get(p => p.OperationClaimGuidId == operationClaim.OperationClaimGuidId);
            if (currentOperationClaim.OperationClaimName != operationClaim.OperationClaimName)
            {
                var result = await _operationClaimDal.Get(p => p.OperationClaimName == operationClaim.OperationClaimName);
                if (result != null)
                {
                    return new ErrorResult(OperationClaimMessages.NameIsNotAvaible);
                }
            }
            return new SuccessResult();
        }
    }
}
