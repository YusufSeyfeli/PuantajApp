using Business.Repositories.OperationCompetencyRepository;
using Business.Repositories.UserOperationClaimRepository;
using Entities.Concrete;
using Entities.Dtos.OperationCompetencyDtos;
using Entities.Dtos.UserOperationClaimDtos;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserOperationClaimsController : ControllerBase
    {
        private readonly IUserOperationClaimService _userOperationClaimService;

        public UserOperationClaimsController(IUserOperationClaimService userOperationClaimService)
        {
            _userOperationClaimService = userOperationClaimService;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Add(UserOperationClaimDto userOperationClaimDto)
        {
            var result = await _userOperationClaimService.Add(userOperationClaimDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> Update(UserOperationClaimUpdateDto userOperationClaimUpdateDto)
        {
            var result = await _userOperationClaimService.Update(userOperationClaimUpdateDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpDelete("[action]")]
        public async Task<IActionResult> Delete(Guid UserOperationClaimGuidId)
        {
            var result = await _userOperationClaimService.Delete(UserOperationClaimGuidId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetList()
        {
            var result = await _userOperationClaimService.GetList();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetById(Guid UserOperationClaimGuidId)
        {
            var result = await _userOperationClaimService.GetById(UserOperationClaimGuidId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> BulkAddForUserOperationClaim(List<UserOperationClaimDto> userOperationClaimDtos)
        {
            var result = await _userOperationClaimService.BulkAddForUserOperationClaim(userOperationClaimDtos);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpDelete("[action]")]
        public async Task<IActionResult> BulkDeleteForUserOperationClaim(Guid UserGuidId)
        {
            var result = await _userOperationClaimService.BulkDeleteForUserOperationClaim(UserGuidId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message); 
        }

        //[HttpPut("[action]")]
        //public async Task<IActionResult> BulkUpdateForUserOperationClaim(List<UserOperationCompetencyUpdateDto> userOperationCompetencyUpdateDto)
        //{
        //    var result = await _userOperationClaimService.BulkUpdateForUserOperationClaim(userOperationCompetencyUpdateDto);
        //    if (result.Success)
        //    {
        //        return Ok(result);
        //    }
        //    return BadRequest(result.Message);
        //}
    }
}
