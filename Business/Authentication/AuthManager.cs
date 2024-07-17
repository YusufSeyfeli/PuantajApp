using Business.Abstract;
using Business.Aspects.Secured;
using Business.Aspects.Secured.Messages;
using Business.Authentication.Constants;
using Business.Repositories.UserRepository;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Validation;
using Core.Utilities.Business;
using Core.Utilities.Hashing;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using Core.Utilities.Security.JWT;
using Entities.Concrete;
using Entities.Dtos.AuthDtos;

namespace Business.Authentication
{
    public class AuthManager : IAuthService
    {
        private readonly IUserService _userService;
        private readonly ITokenHandler _tokenHandler;

        public AuthManager(IUserService userService, ITokenHandler tokenHandler)
        {
            _userService = userService;
            _tokenHandler = tokenHandler;
        }

        public async Task<IDataResult<Token>> Login(LoginAuthDto loginDto)
        {
            var user = await _userService.GetByEmail(loginDto.Email);
            

            if (user == null)
                return new ErrorDataResult<Token>(AuthMessages.IsEmailNotFound);
            var admin = await _userService.GetCompetency(user.UserGuidId);

            //if (!user.IsConfirm)
            //    return new ErrorDataResult<Token>("Kullanıcı maili onaylanmamış!");

            var result = HashingHelper.VerifyPasswordHash(loginDto.Password, user.PasswordHash, user.PasswordSalt);
            List<Competency> competencies = await _userService.GetCompetency(user.UserGuidId);

            if (result)
            {
                Token token = new();
                token = _tokenHandler.CreateToken(user, competencies);
                token.UserGuidId = user.UserGuidId;
                
                foreach (var adminClaim in admin)
                {
                    if (admin != null && admin.Any(adminClaim => adminClaim.Name == "Admin"))
                    {
                        token.MyClaim = true;
                    }
                    else
                    {
                        token.MyClaim = false;
                    }


                }
                return new SuccessDataResult<Token>(token);
            }
 
            //return new ErrorDataResult<Token>(AuthMessages.IsEmailorPasswordIncorrect);
            throw new Exception(AuthMessages.IsEmailorPasswordIncorrect);
        }

        [ValidationAspect(typeof(AuthValidator))]
        public async Task<IResult> Register(RegisterAuthDto registerDto)
        {
            IResult result = BusinessRules.Run(
                await CheckIfEmailExists(registerDto.Email),
                //CheckIfImageExtesionsAllow(registerDto.ImageByte.FileName),
                CheckIfImageSizeIsLessThanOneMb(registerDto.ImageByteString.Length)
                );

            if (result != null)
            {
                return result;
            }

            await _userService.Add(registerDto);
            return new SuccessResult("Kullanıcı kaydı başarıyla tamamlandı");
        }

        private async Task<IResult> CheckIfEmailExists(string email)
        {
            var list = await _userService.GetByEmail(email);
            if (list != null)
            {
                //return new ErrorResult(AuthMessages.IsEmailAlreadyUse);
                throw new Exception(AuthMessages.IsEmailAlreadyUse);

            }
            return new SuccessResult();
        }

        private IResult CheckIfImageSizeIsLessThanOneMb(long imgSize)
        {
            decimal imgMbSize = Convert.ToDecimal(imgSize * 0.000001);
            if (imgMbSize > 1)
            {
                //return new ErrorResult(AuthMessages.IsImageOneByte);
                throw new Exception(AuthMessages.IsImageOneByte);

            }
            return new SuccessResult();
        }

        private IResult CheckIfImageExtesionsAllow(string fileName)
        {
            var ext = fileName.Substring(fileName.LastIndexOf('.'));
            var extension = ext.ToLower();
            List<string> AllowFileExtensions = new List<string> { ".jpg", ".jpeg", ".gif", ".png" };
            if (!AllowFileExtensions.Contains(extension))
            {
                //return new ErrorResult(AuthMessages.IsImageJpeg);
                throw new Exception(AuthMessages.IsImageJpeg);

            }
            return new SuccessResult();
        }
    }
}
