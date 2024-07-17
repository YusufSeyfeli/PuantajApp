using Business.Repositories.WeekTallyRepository;
using Entities.Dtos.WeekTallyDtos;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeekTallyController : Controller
    {
        private readonly IWeekTallyService _weekTallyService;
        public WeekTallyController(IWeekTallyService weekTallyService)
        {
            _weekTallyService = weekTallyService;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetList()
        {
            var result = await _weekTallyService.GetList();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }


        [HttpGet("[action]")]
        public async Task<IActionResult> GetById(Guid weekTallyGuidId)
        {
            var result = await _weekTallyService.GetById(weekTallyGuidId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> Update(WeekTallyUpdateDto weekTallyUpdateDto)
        {
            var result = await _weekTallyService.Update(weekTallyUpdateDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpDelete("[action]")]
        public async Task<IActionResult> Delete(Guid weekTallyGuidId)
        {
            var result = await _weekTallyService.Delete(weekTallyGuidId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Add(WeekTallyRebuildDto weekTallyDto)
        {
            var result = await _weekTallyService.Add(weekTallyDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
    }
}
