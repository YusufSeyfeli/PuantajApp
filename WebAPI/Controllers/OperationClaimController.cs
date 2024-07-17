using Business.Repositories.CompetencyRepository;
using Business.Repositories.OperationClaimRepository;
using Entities.Concrete;
using Entities.Dtos.CompetencyDtos;
using Entities.Dtos.OperationClaimDtos;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperationClaimController : ControllerBase
    {
        private readonly IOperationClaimService _operationClaimService;

        public OperationClaimController(IOperationClaimService operationClaimService)
        {
            _operationClaimService = operationClaimService;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Add(OperationClaimDto operationClaimDto)
        {
            var result = await _operationClaimService.Add(operationClaimDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> Update(OperationClaimUpdateDto operationClaimDto)
        {
            var result = await _operationClaimService.Update(operationClaimDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpDelete("[action]")]
        public async Task<IActionResult> Delete(Guid operationClaimGuidId)
        {
            var result = await _operationClaimService.Delete(operationClaimGuidId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("[action]")]
        //[Authorize(Roles = "GetList")]
        public async Task<IActionResult> GetListWithCompetency()
        {
            var result = await _operationClaimService.GetListWithCompetency();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("[action]")]
        //[Authorize(Roles = "GetList")]
        public async Task<IActionResult> GetList()
        {
            var result = await _operationClaimService.GetList();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetById(Guid operationClaimGuidId)
        {
            var result = await _operationClaimService.GetById(operationClaimGuidId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
    }
}
