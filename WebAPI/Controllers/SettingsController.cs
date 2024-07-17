using Business.Repositories.CompetencyRepository;
using Business.Repositories.SettingsRepository;
using Entities.Concrete;
using Entities.Dtos.CompetencyDtos;
using Entities.Dtos.SettingsDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SettingsController : ControllerBase
    {
        private readonly ISettingsService _settingsService;
        public SettingsController(ISettingsService settingsService)
        {
            _settingsService = settingsService;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetList()
        {
            var result = await _settingsService.GetList();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }


        [HttpGet("[action]")]
        public async Task<IActionResult> GetById(Guid SettingsGuidId)
        {
            var result = await _settingsService.GetById(SettingsGuidId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> Update(SettingsUpdateDto settingsUpdateDto)
        {
            var result = await _settingsService.Update(settingsUpdateDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        //[HttpDelete("[action]")]
        //public async Task<IActionResult> Delete(Guid SettingsGuidId)
        //{
        //    var result = await _settingsService.Delete(SettingsGuidId);
        //    if (result.Success)
        //    {
        //        return Ok(result);
        //    }
        //    return BadRequest(result.Message);
        //}
        //[HttpPost("[action]")]
        //public async Task<IActionResult> Add(SettingsDto settingsDto)
        //{
        //    var result = await _settingsService.Add(settingsDto);
        //    if (result.Success)
        //    {
        //        return Ok(result);
        //    }
        //    return BadRequest(result.Message);
        //}
    }
}
