using Business.Repositories.OperationClaimRepository;
using Business.Repositories.OperationCompetencyRepository;
using Entities.Concrete;
using Entities.Dtos.OperationClaimDtos;
using Entities.Dtos.OperationCompetencyDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperationCompetencyController : ControllerBase
    {
        private readonly IOperationCompetencyService _operationCompetencyService;

        public OperationCompetencyController(IOperationCompetencyService operationCompetencyService)
        {
            _operationCompetencyService = operationCompetencyService;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Add(OperationCompetencyDto operationCompetencyDto)
        {
            var result = await _operationCompetencyService.Add(operationCompetencyDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> Update(OperationCompetencyUpdateDto operationCompetencyUpdateDto)
        {
            var result = await _operationCompetencyService.Update(operationCompetencyUpdateDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpDelete("[action]")]
        public async Task<IActionResult> Delete(Guid operationCompetencyGuidId)
        {
            var result = await _operationCompetencyService.Delete(operationCompetencyGuidId);
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
            var result = await _operationCompetencyService.GetList();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetById(Guid operationCompetencyGuidId)
        {
            var result = await _operationCompetencyService.GetById(operationCompetencyGuidId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        //[HttpPut("[action]")]
        //public async Task<IActionResult> BulkUpdateForOperationClaim(List<OperationClaimUpdateDto> operationClaims)
        //{
        //    var result = await _operationCompetencyService.BulkUpdateForOperationClaim(operationClaims);
        //    if (result.Success)
        //    {
        //        return Ok(result);
        //    }
        //    return BadRequest(result.Message);
        //}

        [HttpPost("[action]")]
        public async Task<IActionResult> BulkAddForOperationClaim(List<OperationCompetencyDto> operationCompetencyDto)
        {
            var result = await _operationCompetencyService.BulkAddForOperationCompetency(operationCompetencyDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpDelete("[action]")]
        public async Task<IActionResult> BulkDeleteForOperationClaim(Guid OperationClaimGuidId)
        {
            var result = await _operationCompetencyService.BulkDeleteForOperationCompetency(OperationClaimGuidId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        //[HttpPut("[action]")]
        //public async Task<IActionResult> BulkUpdateForOperationClaim(List<OperationCompetencyUpdateDto> operationCompetencyUpdateDto)
        //{
        //    var result = await _operationCompetencyService.BulkUpdateForOperationClaim(operationCompetencyUpdateDto);
        //    if (result.Success)
        //    {
        //        return Ok(result);
        //    }
        //    return BadRequest(result.Message);
        //}
    }
}
