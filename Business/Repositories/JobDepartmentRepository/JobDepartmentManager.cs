using AutoMapper;
using Business.Aspects.Secured;
using Business.Repositories.CompetencyRepository.Constants;
using Business.Repositories.JobDepartmentRepository.Constants;
using Core.Utilities.Business;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Repositories.JobDepartmentRepository;
using Entities.Concrete;
using Entities.Dtos.CompetencyDtos;
using Entities.Dtos.JobDepartmentDtos;
using Entities.Dtos.UserDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repositories.JobDepartmentRepository
{
    public class JobDepartmentManager : IJobDepartmentService
    {
        private readonly IJobDepartmentDal _jobDepartmentDal;
        private readonly IMapper _mapper;
        public JobDepartmentManager(IJobDepartmentDal jobDepartment,IMapper mapper)
        {
            _jobDepartmentDal = jobDepartment;
            _mapper = mapper;
        }


        [SecuredAspect("JobDepartment.Add,Admin")]
        public async Task<IResult> Add(JobDepartmentDto jobDepartmentDto)
        {
            IResult result = BusinessRules.Run(await IsNameExistForAdd(jobDepartmentDto.Name));

            if (result != null)
            {
                return result;
            }
            var mapper = _mapper.Map<JobDepartment>(jobDepartmentDto);
            try
            {
                await _jobDepartmentDal.Add(mapper);
                return new SuccessResult(JobDepartmentMessages.Added);
            }
            catch (Exception ex)
            {
                return new Result(false, ex.Message);
            }
        }

        [SecuredAspect("JobDepartment.Delete,Admin")]
        public async Task<IResult> Delete(Guid JobDepartmentGuidid)
        {
            if (JobDepartmentGuidid == Guid.Empty)
            {
                return new ErrorDataResult<JobDepartment>("Id boş gönderilemez!!");
            }
            try
            {
                await _jobDepartmentDal.Delete(JobDepartmentGuidid);
                return new SuccessResult(JobDepartmentMessages.Deleted);
            }
            catch (Exception ex)
            {
                return new Result(false, ex.Message);
            }
        }


        [SecuredAspect("JobDepartment.Get,Admin")]
        public async Task<IDataResult<JobDepartment>> GetById(Guid JobDepartmentGuidId)
        {
            if (JobDepartmentGuidId == Guid.Empty)
            {
                return new ErrorDataResult<JobDepartment>("Id boş gönderilemez!!");
            }
            var result = await _jobDepartmentDal.Get(p => p.JobDepartmentGuidId == JobDepartmentGuidId);
            return new SuccessDataResult<JobDepartment>(result);
        }


        [SecuredAspect("JobDepartment.Get,Admin")]
        public async Task<JobDepartment> GetByIdForJobDepartmentService(Guid JobDepartmentGuidId)
        {
            var result = await _jobDepartmentDal.Get(p => p.JobDepartmentGuidId == JobDepartmentGuidId);
            return result;
        }
        
        [SecuredAspect("JobDepartment.Get,Admin")]
        public async Task<IDataResult<List<JobDepartmentGetListDto>>> GetList()
        {
            List<JobDepartment> listJobDepartment = await _jobDepartmentDal.GetAll();

            var myListJobDepartment = _mapper.Map<List<JobDepartmentGetListDto>>(listJobDepartment);
            return new SuccessDataResult<List<JobDepartmentGetListDto>>(myListJobDepartment);

        }


        [SecuredAspect("JobDepartment.Update,Admin")]
        public async Task<IResult> Update(JobDepartmentUpdateDto jobDepartmentUpdateDto)
        {
            if (jobDepartmentUpdateDto.JobDepartmentGuidId == Guid.Empty)
            {
                return new ErrorDataResult<JobDepartment>("Id boş gönderilemez!!");
            }
            var mapper = _mapper.Map<JobDepartment>(jobDepartmentUpdateDto);
            IResult result = BusinessRules.Run(await IsNameExistForUpdate(mapper));
            if (result != null)
            {
                return result;
            }
            try
            {
                await _jobDepartmentDal.Update(mapper);
                return new SuccessResult(JobDepartmentMessages.Updated);
            }
            catch (Exception ex)
            {
                return new Result(false, ex.Message);
            }
        }
       
        
        private async Task<IResult> IsNameExistForAdd(string name)
        {
            var result = await _jobDepartmentDal.Get(p => p.Name == name);
            if (result != null)
            {
                return new ErrorResult(JobDepartmentMessages.NameIsNotAvaible);
            }
            return new SuccessResult();
        }
        private async Task<IResult> IsNameExistForUpdate(JobDepartment jobDepartment)
        {
            var currentJobDepartment = await _jobDepartmentDal.Get(p => p.JobDepartmentGuidId == jobDepartment.JobDepartmentGuidId);
            if (currentJobDepartment.Name != jobDepartment.Name)
            {
                var result = await _jobDepartmentDal.Get(p => p.Name == jobDepartment.Name);
                if (result != null)
                {
                    return new ErrorResult(JobDepartmentMessages.NameIsNotAvaible);
                }
            }
            return new SuccessResult();
        }


    }
}
