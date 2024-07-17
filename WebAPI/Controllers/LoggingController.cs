using Business.Repositories.CompetencyRepository;
using Business.Repositories.JobUnitRepository;
using Business.Repositories.LoggingRepository;
using Entities.Concrete;
using Entities.Dtos.CompetencyDtos;
using Entities.Dtos.LoggingDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoggingController : ControllerBase
    {
        private readonly ILoggingService _loggingService;
        public LoggingController(ILoggingService logging)
        {
            _loggingService = logging;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetList()
        {
            var result = await _loggingService.GetList();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }


        [HttpGet("[action]")]
        public async Task<IActionResult> GetById(Guid LoggingGuidId)
        {
            var result = await _loggingService.GetById(LoggingGuidId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> Update(LoggingUpdateDto loggingUpdateDto)
        {
            var result = await _loggingService.Update(loggingUpdateDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpDelete("[action]")]
        public async Task<IActionResult> Delete(Guid loggingGuidId)
        {
            var result = await _loggingService.Delete(loggingGuidId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }


        [HttpPost("[action]")]
        public async Task<IActionResult> Add(LoggingDto loggingDto)
        {
            var result = await _loggingService.Add(loggingDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
    }
}
