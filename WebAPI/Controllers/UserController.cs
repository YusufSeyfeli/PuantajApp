using Business.Repositories.UserRepository;
using Entities.Concrete;
using Entities.Dtos.AuthDtos;
using Entities.Dtos.JobUnitDtos;
using Entities.Dtos.UserDtos;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetList()
        {
            var result = await _userService.GetList();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }


        [HttpGet("[action]")]
        public async Task<IActionResult> GetById(Guid UserGuidId)
        {
            var result = await _userService.GetById(UserGuidId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> Update(UserUpdateDto userUpdateDto)
        {
            var result = await _userService.Update(userUpdateDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpDelete("[action]")]
        public async Task<IActionResult> Delete(Guid UserGuidId)
        {
            var result = await _userService.Delete(UserGuidId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("[action]/{email}")]
        public async Task<IActionResult> SendConfirmUserMail( string email)
        {
            var result = await _userService.SendConfirmUserMail(email);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("[action]/{email}")]
        public async Task<IActionResult> SendForgotPasswordMail(string email)
        {
            var result = await _userService.SendForgotPasswordMail(email);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("[action]/{confirmValue}")]
        public async Task<IActionResult> ConfirmUser(string confirmValue)
        {
            var result = await _userService.ConfirmUser(confirmValue);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        //[HttpPost("[action]")]
        //public async Task<IActionResult> CreateANewPassword(CreateANewPasswordDto createANewPasswordDto)
        //{
        //    var result = await _userService.CreateANewPassword(createANewPasswordDto);
        //    if (result.Success)
        //    {
        //        return Ok(result);
        //    }
        //    return BadRequest(result.Message);
        //}

        [HttpPost("[action]")]
        public async Task<IActionResult> ChangePassword(UserChangePasswordDto userChangePasswordDto)
        {
            var result = await _userService.ChangePassword(userChangePasswordDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        //[HttpGet("[action]")]
        //public async Task<IActionResult> GetUserJobUnit(Guid UserGuidId)
        //{
        //    var result = await _userService.GetUserJobUnit(UserGuidId);
        //    if (result != null)
        //    {
        //        return Ok(result);
        //    }
        //    return BadRequest(result);

        //}

        //[HttpPost("[action]")]
        //public async Task<IActionResult> BulkDeleteForUserJobUnit(List<JobUnitDto> jobUnits)
        //{
            
        //    var result = await _userService.BulkDeleteForUserJobUnit();
        //    if (result.Success)
        //    {
        //        return Ok(result);
        //    }
        //    return BadRequest(result.Message);
        //}


    }
}
