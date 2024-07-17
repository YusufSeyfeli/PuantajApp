using Business.Repositories.CompetencyRepository.Constants;
using Business.Repositories.CompetencyRepository;
using Core.Utilities.Business;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Repositories.CompetencyRepository;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Dtos.CompetencyDtos;
using AutoMapper;
using Business.Aspects.Secured;
using Entities.Dtos.UserDtos;

namespace Business.Repositories.CompetencyRepository
{
    public class CompetencyManager : ICompetencyService
    {
        private readonly ICompetencyDal _competencyDal;
        private readonly IMapper _mapper; 
        public CompetencyManager(ICompetencyDal competencyDal, IMapper mapper) 
        {
            _competencyDal = competencyDal;
            _mapper = mapper;
        }

        public async Task<IResult> Add(CompetencyDto competencyDto)
        {
            IResult result = BusinessRules.Run(await IsNameExistForAdd(competencyDto.Name));
            if (result != null)
            {
                return result;
            }
            var mapper = _mapper.Map<Competency>(competencyDto);
            try
            {
                await _competencyDal.Add(mapper);
                return new SuccessResult(CompetencyMessages.Added);
            }
            catch (Exception ex)
            {
                return new Result(false, ex.Message);
            }
        }


        [SecuredAspect("Competency.Delete,Admin")]
        public async Task<IResult> Delete(Guid CompetencyGuidId)
        {
            if (CompetencyGuidId == Guid.Empty)
            {
                return new ErrorDataResult<Competency>("Id boş gönderilemez!!");
            }
            try
            {
                await _competencyDal.Delete(CompetencyGuidId);
                return new SuccessResult(CompetencyMessages.Deleted);
            }
            catch (Exception ex)
            {
                return new Result(false, ex.Message);
            }
        }


        [SecuredAspect("Competency.Get,Admin")]
        public async Task<IDataResult<Competency>> GetById(Guid CompetencyGuidId)
        {
            if (CompetencyGuidId == Guid.Empty )
            {
                return new ErrorDataResult<Competency>("Id boş gönderilemez!!");
            }
            var result = await _competencyDal.Get(p => p.CompetencyGuidId == CompetencyGuidId);
            return new SuccessDataResult<Competency>(result);
        }


        [SecuredAspect("Competency.Get,Admin")]
        public async Task<IDataResult<List<CompetencyGetListDto>>> GetList()
        {
            List<Competency> listCompetency = await _competencyDal.GetAll();

            var myListCompetency = _mapper.Map<List<CompetencyGetListDto>>(listCompetency);
            return new SuccessDataResult<List<CompetencyGetListDto>>(myListCompetency);

        }

        [SecuredAspect("Competency.Update,Admin")]
        public async Task<IResult> Update(CompetencyUpdateDto competencyUpdateDto)
        {
            if (competencyUpdateDto.CompetencyGuidId == Guid.Empty)
            {
                return new ErrorDataResult<Competency>("Id boş gönderilemez!!");
            }
            var mapper = _mapper.Map<Competency>(competencyUpdateDto);
            IResult result = BusinessRules.Run(await IsNameExistForUpdate(mapper));
            if (result != null)
            {
                return result;
            }

            
            try
            {
                await _competencyDal.Update(mapper);
                return new SuccessResult(CompetencyMessages.Added);
            }
            catch (Exception ex)
            {
                return new Result(false, ex.Message);
            }
        }

        private async Task<IResult> IsNameExistForAdd(string name)
        {
            var result = await _competencyDal.Get(p => p.Name == name);
            if (result != null)
            {
                return new ErrorResult(CompetencyMessages.NameIsNotAvaible);
            }
            return new SuccessResult();
        }
        private async Task<IResult> IsNameExistForUpdate(Competency competency)
        {
            var currentCompetency = await _competencyDal.Get(p => p.Name == competency.Name);
            if (currentCompetency.Name != competency.Name)
            {
                var result = await _competencyDal.Get(p => p.Name == competency.Name);
                if (result != null)
                {
                    return new ErrorResult(CompetencyMessages.NameIsNotAvaible);
                }
            }
            return new SuccessResult();
        }


        [SecuredAspect("Competency.Get,Admin")]
        public async Task<IDataResult<List<OperationClaim>>> GetCompetencyOperatinonClaims(Guid CompetencyGuidId)
        {
            if (CompetencyGuidId == Guid.Empty)
            {
                return new ErrorDataResult<List<OperationClaim>>("Id boş gönderilemez!!");
            }
            try
            {
                var operationClaims = await _competencyDal.GetCompetencyOperatinonClaims(CompetencyGuidId);
                return new SuccessDataResult<List<OperationClaim>>(operationClaims);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<List<OperationClaim>>(ex.Message);
            }
        }

        //[SecuredAspect("Competency.Get,Admin")]
        public async Task<IDataResult<List<Competency>>> GetCompetenciesbyOperationClaimId(Guid OperationClaimGuidId)
        {
            if (OperationClaimGuidId == Guid.Empty)
            {
                return new ErrorDataResult<List<Competency>>("Id boş gönderilemez!!");
            }
            try
            {
                var competencies = await _competencyDal.GetCompetenciesbyOperationClaimId(OperationClaimGuidId);
                return new SuccessDataResult<List<Competency>>(competencies);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<List<Competency>>(ex.Message);
            }
        }

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
