using Business.Repositories.TallyRepository;
using Entities.Dtos.TallyDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TallyController : ControllerBase
    {
        private readonly ITallyService _tallyService;
        public TallyController(ITallyService tallyService)
        {
            _tallyService = tallyService;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetList()
        {
            var result = await _tallyService.GetList();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }


        [HttpGet("[action]")]
        public async Task<IActionResult> GetById(Guid tallyGuidId)
        {
            var result = await _tallyService.GetById(tallyGuidId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> Update(TallyUpdateDto tallyUpdateDto)
        {
            var result = await _tallyService.Update(tallyUpdateDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpDelete("[action]")]
        public async Task<IActionResult> Delete(Guid tallyGuidId)
        {
            var result = await _tallyService.Delete(tallyGuidId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Add(TallyRebuildDto tallyDto)
        {
            var result = await _tallyService.Add(tallyDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
    }
}
