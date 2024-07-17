using Business.Repositories.CompetencyRepository;
using Business.Repositories.HolidayRepository;
using Entities.Concrete;
using Entities.Dtos.CompetencyDtos;
using Entities.Dtos.HolidayDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HolidayController : ControllerBase
    {
        private readonly IHolidayService _holidayService;
        public HolidayController(IHolidayService holidayService)
        {
            _holidayService = holidayService;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetList()
        {
            var result = await _holidayService.GetList();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }


        [HttpGet("[action]")]
        public async Task<IActionResult> GetById(Guid HolidayGuidId)
        {
            var result = await _holidayService.GetById(HolidayGuidId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> Update(HolidayUpdateDto holidayUpdateDto)
        {
            var result = await _holidayService.Update(holidayUpdateDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpDelete("[action]")]
        public async Task<IActionResult> Delete(Guid HolidayGuidId)
        {
            var result = await _holidayService.Delete(HolidayGuidId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Add(HolidayDto holidayDto)
        {
            var result = await _holidayService.Add(holidayDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
    }
}
