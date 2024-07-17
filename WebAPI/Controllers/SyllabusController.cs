using Business.Repositories.CompetencyRepository;
using Business.Repositories.SyllabusRepository;
using Entities.Dtos.CompetencyDtos;
using Entities.Dtos.SyllabusDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SyllabusController : ControllerBase
    {
        private readonly ISyllabusService _syllabusService;
        public SyllabusController(ISyllabusService syllabusService)
        {
            _syllabusService = syllabusService;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetList()
        {
            var result = await _syllabusService.GetList();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }



        [HttpGet("[action]")]
        public async Task<IActionResult> GetById(Guid syllabusGuidId)
        {
            var result = await _syllabusService.GetById(syllabusGuidId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> Refresh(Guid StudentGuidId)
        {
            var result = await _syllabusService.Refresh(StudentGuidId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> Update(SyllabusUpdateDto syllabusUpdateDto)
        {
            var result = await _syllabusService.Update(syllabusUpdateDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpDelete("[action]")]
        public async Task<IActionResult> Delete(Guid syllabusGuidId)
        {
            var result = await _syllabusService.Delete(syllabusGuidId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Add(SyllabusDto syllabusDto)
        {
            var result = await _syllabusService.Add(syllabusDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
    }
}
