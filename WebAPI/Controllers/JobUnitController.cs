using Business.Repositories.CompetencyRepository;
using Business.Repositories.JobDepartmentRepository;
using Business.Repositories.JobUnitRepository;
using Entities.Concrete;
using Entities.Dtos.CompetencyDtos;
using Entities.Dtos.JobDepartmentDtos;
using Entities.Dtos.JobUnitDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobUnitController : ControllerBase
    {
        private readonly IJobUnitService _jobUnitService;
        public JobUnitController(IJobUnitService jobUnitService)
        {
            _jobUnitService = jobUnitService;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetList()
        {
            var result = await _jobUnitService.GetList();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }


        [HttpGet("[action]")]
        public async Task<IActionResult> GetById(Guid JobUnitGuidId)
        {
            var result = await _jobUnitService.GetById(JobUnitGuidId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> Update(JobUnitUpdateDto jobUnitUpdateDto)
        {
            var result = await _jobUnitService.Update(jobUnitUpdateDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpDelete("[action]")]
        public async Task<IActionResult> Delete(Guid JobUnitGuidId)
        {
            var result = await _jobUnitService.Delete(JobUnitGuidId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Add(JobUnitDto jobUnitDto)
        {
            var result = await _jobUnitService.Add(jobUnitDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
    }
}
