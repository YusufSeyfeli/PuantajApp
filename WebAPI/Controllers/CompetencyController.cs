using Business.Repositories.CompetencyRepository;
using Business.Repositories.OperationClaimRepository;
using Business.Repositories.UserRepository;
using Entities.Concrete;
using Entities.Dtos;
using Entities.Dtos.CompetencyDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompetencyController : ControllerBase
    {
        private readonly ICompetencyService _competencyService;
        public CompetencyController (ICompetencyService competencyService)
        {
            _competencyService = competencyService;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetList()
        {
            var result = await _competencyService.GetList();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }


        [HttpGet("[action]")]
        public async Task<IActionResult> GetById(Guid competencyGuidId)
        {
            var result = await _competencyService.GetById(competencyGuidId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        //[HttpPut("[action]")]
        //public async Task<IActionResult> Update(CompetencyUpdateDto competencyUpdateDto)
        //{
        //    var result = await _competencyService.Update(competencyUpdateDto);
        //    if (result.Success)
        //    {
        //        return Ok(result);
        //    }
        //    return BadRequest(result.Message);
        //}

        //[HttpDelete("[action]")]
        //public async Task<IActionResult> Delete(Guid competencyGuidId)
        //{
        //    var result = await _competencyService.Delete(competencyGuidId);
        //    if (result.Success)
        //    {
        //        return Ok(result);
        //    }
        //    return BadRequest(result.Message);
        //}

        //[HttpPost("[action]")]
        //public async Task<IActionResult> Add(CompetencyDto competencyDto)
        //{
        //    var result = await _competencyService.Add(competencyDto);
        //    if (result.Success)
        //    {
        //        return Ok(result);
        //    }
        //    return BadRequest(result.Message);
        //}

        [HttpGet("[action]")]
        public async Task<IActionResult> GetCompetenciesbyOperationClaimId(Guid operationClaimGuidId)
        {
            var result = await _competencyService.GetCompetenciesbyOperationClaimId(operationClaimGuidId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
    }
}
