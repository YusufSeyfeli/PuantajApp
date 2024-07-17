using Core.Utilities.Result.Abstract;
using Entities.Concrete;
using Entities.Dtos.AuthDtos;
using Entities.Dtos.JobUnitDtos;
using Entities.Dtos.UserDtos;
using Entities.Dtos.UserJobUnitDtos;

namespace Business.Repositories.UserRepository
{
    public interface IUserService
    {
        Task Add(RegisterAuthDto authDto);
        Task<IResult> Update(UserUpdateDto userUpdateDto);
        Task<IResult> ConfirmUser(string confirmValue);
        Task<IResult> SendConfirmUserMail(string email);
        Task<IResult> SendForgotPasswordMail(string email);
        Task<IResult> ChangePassword(UserChangePasswordDto userChangePasswordDto);
        Task<IResult> CreateANewPassword(CreateANewPasswordDto createANewPasswordDto);
        Task<IResult> Delete(Guid id);
        Task<IDataResult<List<UserGetListDto>>> GetList();
        Task<User> GetByEmail(string email);
        Task<List<OperationClaim>> GetUserOperationClaims(Guid GuidUserId);
        Task<List<Competency>> GetCompetency(Guid GuidUserId);
        //List<JobUnit> GetUserJobUnit(Guid GuidUserId);
        Task<IDataResult<UserGetUserDto>> GetById(Guid GuidUserId);
        Task<User> GetByIdForAuth(Guid GuidUserId);
        //Task<IResult> BulkDeleteForUserJobUnit(List<UserJobUnitUpdateDto> userJobUnits);
        //Task BulkDeleteForUserJobUnit(List<JobUnitUpdateDto> jobUnits);
    }
}
