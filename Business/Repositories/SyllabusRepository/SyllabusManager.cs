using AutoMapper;
using Business.Aspects.Secured;
using Business.Repositories.JobUnitRepository.Constants;
using Business.Repositories.LoggingRepository.Constants;
using Business.Repositories.SyllabusRepository.Constants;
using Core.Utilities.Business;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Repositories.LoggingRepository;
using DataAccess.Repositories.SyllabusRepository;
using Entities.Concrete;
using Entities.Dtos.JobUnitDtos;
using Entities.Dtos.SyllabusDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repositories.SyllabusRepository
{
    public class SyllabusManager : ISyllabusService
    {
        private readonly ISyllabusDal _syllabusDal;
        private readonly IMapper _mapper;
        public SyllabusManager(ISyllabusDal syllabus,IMapper mapper)
        {
            _syllabusDal = syllabus;
            _mapper = mapper;
        }

        [SecuredAspect("Syllabus.Add,Admin")]
        public async Task<IResult> Add(SyllabusDto syllabusDto)
        {
            IResult result = BusinessRules.Run(await IsStudentAvailableForAdd(syllabusDto.StudentGuidId.ToString()));
            if (result != null)
            {
                return result;
            }
            var mapper = _mapper.Map<Syllabus>(syllabusDto);
            try
            {
                await _syllabusDal.Add(mapper);
                return new SuccessResult(JobUnitMessages.Added);
            }
            catch (Exception ex)
            {
                return new Result(false, ex.Message);
            }
        }


        public async Task<IResult> Delete(Guid SyllabusGuidId)
        {
            if (SyllabusGuidId == Guid.Empty)
            {
                return new ErrorDataResult<Syllabus>("Id boş gönderilemez!!");
            }
            await _syllabusDal.Delete(SyllabusGuidId);
            return new SuccessResult(SyllabusMessages.Deleted);
        }


        public async Task<IDataResult<Syllabus>> GetById(Guid SyllabusGuidId)
        {
            if (SyllabusGuidId == Guid.Empty)
            {
                return new ErrorDataResult<Syllabus>("Id boş gönderilemez!!");
            }
            var result = await _syllabusDal.Get(p => p.SyllabusGuidId == SyllabusGuidId);
            return new SuccessDataResult<Syllabus>(result);
        }
        public async Task<IDataResult<List<SyllabusGetListDto>>> GetList()
        {
            List<Syllabus> listSyllabus = await _syllabusDal.GetAll();
            var myListSyllabus = _mapper.Map<List<SyllabusGetListDto>>(listSyllabus);
            return new SuccessDataResult<List<SyllabusGetListDto>>(myListSyllabus);
        }

        public async Task<IResult> Refresh(Guid StudentGuidId)
        {
            return new SuccessResult("Başarıyla Güncellendi.");
        }

        public async Task<IResult> Update(SyllabusUpdateDto syllabusUpdateDto)
        {
            if (syllabusUpdateDto.SyllabusGuidId == Guid.Empty)
            {
                return new ErrorDataResult<Syllabus>("Id boş gönderilemez!!");
            }
            var mapper = _mapper.Map<Syllabus>(syllabusUpdateDto);
            try
            {
                await _syllabusDal.Update(mapper);
                return new SuccessResult(SyllabusMessages.Updated);
            }
            catch (Exception ex)
            {
                return new Result(false, ex.Message);
            }
        }
        private async Task<IResult> IsStudentAvailableForAdd(string id)
        {
            var result = await _syllabusDal.Get(p => p.StudentGuidId.ToString() == id);
            if (result != null)
            {
                return new ErrorResult(SyllabusMessages.IsStudenExist);
            }
            return new SuccessResult();
        }
    }
}
