using Business.Repositories.CompetencyRepository;
using Business.Repositories.JobDepartmentRepository;
using Entities.Concrete;
using Entities.Dtos.CompetencyDtos;
using Entities.Dtos.JobDepartmentDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobDepartmentController : ControllerBase
    {
        private readonly IJobDepartmentService _jobDepartmentService;
        public JobDepartmentController(IJobDepartmentService jobDepartmentService)
        {
            _jobDepartmentService = jobDepartmentService;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetList()
        {
            var result = await _jobDepartmentService.GetList();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetById(Guid JobDepartmentGuidId)
        {
            var result = await _jobDepartmentService.GetById(JobDepartmentGuidId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> Update(JobDepartmentUpdateDto jobDepartmentUpdateDto)
        {
            var result = await _jobDepartmentService.Update(jobDepartmentUpdateDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpDelete("[action]")]
        public async Task<IActionResult> Delete(Guid JobDepartmentGuidId)
        {
            var result = await _jobDepartmentService.Delete(JobDepartmentGuidId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
        
        [HttpPost("[action]")]
        public async Task<IActionResult> Add(JobDepartmentDto jobDepartmentDto)
        {
            var result = await _jobDepartmentService.Add(jobDepartmentDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

    }

}
