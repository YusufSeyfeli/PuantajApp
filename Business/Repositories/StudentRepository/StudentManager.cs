using AutoMapper;
using Business.Abstract;
using Business.Aspects.Secured;
using Business.Repositories.CompetencyRepository.Constants;
using Business.Repositories.StudentRepository.Constants;
using Core.Utilities.Business;
using Core.Utilities.Hashing;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Repositories.StudentRepository;
using Entities.Concrete;
using Entities.Dtos.AuthDtos;
using Entities.Dtos.CompetencyDtos;
using Entities.Dtos.StudentDtos;
using Entities.Dtos.UserDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repositories.StudentRepository
{
    public class StudentManager : IStudentService
    {
        private readonly IStudentDal _studentDal;
        private readonly IMapper _mapper;
        private readonly IFileService _fileService;

        public StudentManager(IStudentDal student, IFileService fileService, IMapper mapper)
        {
            _studentDal = student;
            _fileService = fileService;
            _mapper = mapper;
        }

        //[SecuredAspect("Student.Add,Admin")]
        public async Task<IResult> Add(StudentDto studentDto)
        {
            //string fileName = _fileService.FileSaveToServer(studentDto.ImageByte, "./Content/Img/");
            //byte[] fileByteArray = _fileService.FileConvertByteArrayToDatabase(studentDto.ImageByteString);
            //var fileByteArray = studentDto.ImageByteString;
            //byte[] byteArray = Encoding.UTF8.GetBytes(fileByteArray);
            byte[] fileByteArray = Convert.FromBase64String(studentDto.ImageByteString);

            IResult result = BusinessRules.Run(
                await IsNameExistForAdd(studentDto.NameSurname)
                //CheckIfImageExtesionsAllow(studentDto.ImageByte.FileName),
                //CheckIfImageSizeIsLessThanOneMb(studentDto.ImageByteString.Length)
                );
            if (result != null)
            {
                return result;
            }
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<StudentDto, Student>()
                   //.AfterMap((src, dest) => dest.ImageUrl = fileName)
                   //.AfterMap((src, dest) => dest.StudentNo = studentDto.StudentNo)
                   .AfterMap((src, dest) => dest.ImageByte = fileByteArray);
                  
            });
            var mapper = config.CreateMapper();

            var student = mapper.Map<Student>(studentDto);
            try
            {
                await _studentDal.Add(student);
                return new SuccessResult(StudentMessages.Added);
            }
            catch (Exception ex)
            {
                return new Result(false, ex.Message);
            }
        }
        
        [SecuredAspect("Student.Delete,Admin")]
        public async Task<IResult> Delete(Guid studentGuidId)
        {
            if (studentGuidId == Guid.Empty)
            {
                return new ErrorDataResult<Student>("Id boş gönderilemez!!");
            }
            try
            {
                await _studentDal.Delete(studentGuidId);
                return new SuccessResult(StudentMessages.Deleted);

            }
            catch (Exception ex)
            {
                return new Result(false, ex.Message);

            }
        }


        [SecuredAspect("Student.Get,Admin")]
        public async Task<IDataResult<StudentGetStudentDto>> GetById(Guid StudentGuidId)
        {
            if (StudentGuidId == Guid.Empty)
            {
                return new ErrorDataResult<StudentGetStudentDto>("Id boş gönderilemez!!");
            }
            Student studentList = await _studentDal.Get(p => p.StudentGuidId == StudentGuidId);
            var fileByteArray = Convert.ToBase64String(studentList.ImageByte);
            
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Student, StudentGetStudentDto>()
                   .AfterMap((src, dest) => dest.ImageByteString = fileByteArray);
            });
            var getByteArray = config.CreateMapper();
            var myListUser = getByteArray.Map<StudentGetStudentDto>(studentList);

            return new SuccessDataResult<StudentGetStudentDto>(myListUser);
        }


        [SecuredAspect("Student.Gets,Admin")]
        public async Task<Student> GetByIdForStudentService(Guid StudentGuidId)
        {
            var result = await _studentDal.Get(p => p.StudentGuidId == StudentGuidId);
            return result;
        }

        [SecuredAspect("Student.Get,Admin")]
        public async Task<IDataResult<List<StudentGetListDto>>> GetList()
        {
            List<StudentGetListDto> studentGetListDtoList = new List<StudentGetListDto>();
            List<Student> listStudent = await _studentDal.GetAll();
            foreach (var student in listStudent)
            {
                var fileByteArray = Convert.ToBase64String(student.ImageByte);
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<Student, StudentGetListDto>()
                       .AfterMap((src, dest) => dest.ImageByteString = fileByteArray);
                });
                var getByteArray = config.CreateMapper();
                studentGetListDtoList.Add(getByteArray.Map<StudentGetListDto>(student));
            }

            return new SuccessDataResult<List<StudentGetListDto>>(studentGetListDtoList);

        }


        [SecuredAspect("Student.Update,Admin")]
        public async Task<IResult> Update(StudentUpdateDto studentUpdateDto)
        {
            if (studentUpdateDto.StudentGuidId == Guid.Empty)
            {
                return new ErrorDataResult<Competency>("Id boş gönderilemez!!");
            }

            byte[] fileByteArray = Convert.FromBase64String(studentUpdateDto.ImageByteString);

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<StudentUpdateDto, Student>()
                   //.AfterMap((src, dest) => dest.ImageUrl = fileName)
                   //.AfterMap((src, dest) => dest.StudentNo = studentDto.StudentNo)
                   .AfterMap((src, dest) => dest.ImageByte = fileByteArray);

            });
            var mapper = config.CreateMapper();

            var student = mapper.Map<Student>(studentUpdateDto);
            IResult result = BusinessRules.Run(await IsNameExistForUpdate(student));
            if (result != null)
            {
                return result;
            }
            try
            {
                await _studentDal.Update(student);
                return new SuccessResult(StudentMessages.Updated);
            }
            catch (Exception ex)
            {
                return new Result(false, ex.Message);
            }
        }
        private async Task<IResult> IsNameExistForAdd(string nameSurname)
        {
            var result = await _studentDal.Get(p => p.NameSurname == nameSurname);
            if (result != null)
            {
                return new ErrorResult(StudentMessages.NameIsNotAvaible);
            }
            return new SuccessResult();
        }
        private async Task<IResult> IsNameExistForUpdate(Student student)
        {
            var currentStudent = await _studentDal.Get(p => p.StudentGuidId == student.StudentGuidId);
            if (currentStudent.NameSurname != student.NameSurname)
            {
                var result = await _studentDal.Get(p => p.NameSurname == student.NameSurname);
                if (result != null)
                {
                    return new ErrorResult(StudentMessages.NameIsNotAvaible);
                }
            }
            return new SuccessResult();
        }

        //private IResult CheckIfImageSizeIsLessThanOneMb(long imgSize)
        //{
        //    decimal imgMbSize = Convert.ToDecimal(imgSize * 0.000001);
        //    if (imgMbSize > 1)
        //    {
        //        return new ErrorResult("Yüklediğiniz resmi boyutu en fazla 1mb olmalıdır");
        //    }
        //    return new SuccessResult();
        //}

        //private IResult CheckIfImageExtesionsAllow(string fileName)
        //{
        //    var ext = fileName.Substring(fileName.LastIndexOf('.'));
        //    var extension = ext.ToLower();
        //    List<string> AllowFileExtensions = new List<string> { ".jpg", ".jpeg", ".gif", ".png" };
        //    if (!AllowFileExtensions.Contains(extension))
        //    {
        //        return new ErrorResult("Eklediğiniz resim .jpg, .jpeg, .gif, .png türlerinden biri olmalıdır!");
        //    }
        //    return new SuccessResult();
        //}


    }
}
