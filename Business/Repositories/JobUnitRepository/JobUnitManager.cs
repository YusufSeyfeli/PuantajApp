using AutoMapper;
using Business.Aspects.Secured;
using Business.Repositories.CompetencyRepository.Constants;
using Business.Repositories.JobUnitRepository.Constants;
using Business.Repositories.OperationClaimRepository.Validation;
using Core.Aspects.Caching;
using Core.Aspects.Validation;
using Core.Utilities.Business;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Repositories.JobDepartmentRepository;
using DataAccess.Repositories.JobUnitRepository;
using Entities.Concrete;
using Entities.Dtos.CompetencyDtos;
using Entities.Dtos.JobUnitDtos;
using Entities.Dtos.UserDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repositories.JobUnitRepository
{
    public class JobUnitManager :IJobUnitService
    {
        private readonly IJobUnitDal _jobUnitDal;
        private readonly IMapper _mapper;
        private readonly IJobDepartmentDal _jobDepartmentDal;
        public JobUnitManager(IJobUnitDal jobUnit,IMapper mapper, IJobDepartmentDal jobDepartmentDal )
        {
            _jobUnitDal = jobUnit;
            _mapper = mapper;
            _jobDepartmentDal = jobDepartmentDal;
        }


        [SecuredAspect("JobUnit.Add,Admin")]
        public async Task<IResult> Add(JobUnitDto jobUnitDto)
        {
            IResult result = BusinessRules.Run(await IsNameExistForAdd(jobUnitDto.JobUnitName));
            IResult result1 = BusinessRules.Run(await IsDepartmentAvailableForAdd(jobUnitDto.JobDepartmentGuidId.ToString()));
            if (result != null)
            {
                return result;
            }
            if (result1 != null)
            {
                return result1;
            }
            var mapper = _mapper.Map<JobUnit>(jobUnitDto);
            try
            {
                await _jobUnitDal.Add(mapper);
                return new SuccessResult(JobUnitMessages.Added);
            }
            catch (Exception ex)
            {
                return new Result(false, ex.Message);
            }
        }

        private async Task<IResult> IsDepartmentAvailableForAdd(string id)
        {
            var result = await _jobDepartmentDal.Get(p => p.JobDepartmentGuidId.ToString() == id);
            if (result == null)
            {
                return new ErrorResult(JobUnitMessages.JobDepartmentIdIsNotAvaible);
            }
            return new SuccessResult();
        }

        [SecuredAspect("JobUnit.Delete,Admin")]
        public async Task<IResult> Delete(Guid JobUnitGuidId)
        {
            if (JobUnitGuidId == Guid.Empty)
            {
                return new ErrorDataResult<JobUnit>("Id boş gönderilemez!!");
            }
            try
            {
                await _jobUnitDal.Delete(JobUnitGuidId);
                return new SuccessResult(JobUnitMessages.Deleted);
            }
            catch (Exception ex)
            {
                return new Result(false, ex.Message);
            }
        }


        [SecuredAspect("JobUnit.Get,Admin")]
        public async Task<IDataResult<JobUnit>> GetById(Guid JobUnitGuidId)
        {
            if (JobUnitGuidId == Guid.Empty)
            {
                return new ErrorDataResult<JobUnit>("Id boş gönderilemez!!");
            }
            var result = await _jobUnitDal.Get(p => p.JobUnitGuidId == JobUnitGuidId);
            return new SuccessDataResult<JobUnit>(result);
        }


        [SecuredAspect("JobUnit.Get,Admin")]
        public async Task<JobUnit> GetByIdForJobUnitService(Guid JobUnitGuidId)
        {
            var result = await _jobUnitDal.Get(p => p.JobUnitGuidId == JobUnitGuidId);
            return result;
        }

        [SecuredAspect("JobUnit.Get,Admin")]
        public async Task<IDataResult<List<JobUnitGetListDto>>> GetList()
        {
            List<JobUnit> listUser = await _jobUnitDal.GetAll();

            var myListUser = _mapper.Map<List<JobUnitGetListDto>>(listUser);
            return new SuccessDataResult<List<JobUnitGetListDto>>(myListUser);

        }

        [SecuredAspect("JobUnit.Update,Admin")]
        public async Task<IResult> Update(JobUnitUpdateDto jobUnitUpdateDto)
        {
            if (jobUnitUpdateDto.JobUnitGuidId == Guid.Empty)
            {
                return new ErrorDataResult<JobUnit>("Id boş gönderilemez!!");
            }
            var mapper = _mapper.Map<JobUnit>(jobUnitUpdateDto);
            IResult result = BusinessRules.Run(await IsNameExistForUpdate(mapper));
            if (result != null)
            {
                return result;
            }
            try
            {
                await _jobUnitDal.Update(mapper);
                return new SuccessResult(JobUnitMessages.Added);
            }
            catch (Exception ex)
            {
                return new Result(false, ex.Message);
            }
        }
        private async Task<IResult> IsNameExistForAdd(string name)
        {
            var result = await _jobUnitDal.Get(p => p.JobUnitName == name);
            if (result != null)
            {
                return new ErrorResult(JobUnitMessages.NameIsNotAvaible);
            }
            return new SuccessResult();
        }
        private async Task<IResult> IsNameExistForUpdate(JobUnit jobUnit)
        {
            var currentJobUnit = await _jobUnitDal.Get(p => p.JobUnitGuidId == jobUnit.JobUnitGuidId);
            if (currentJobUnit.JobUnitName != jobUnit.JobUnitName)
            {
                var result = await _jobUnitDal.Get(p => p.JobUnitName == jobUnit.JobUnitName);
                if (result != null)
                {
                    return new ErrorResult(JobUnitMessages.NameIsNotAvaible);
                }
            }
            return new SuccessResult();
        }
    }
}
