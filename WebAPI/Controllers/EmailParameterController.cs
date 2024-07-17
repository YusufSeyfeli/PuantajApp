using Business.Repositories.EmailParameterRepository;
using Entities.Concrete;
using Entities.Dtos.EmailParameter;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailParameterController : ControllerBase
    {
        private readonly IEmailParameterService _emailParameterService;

        public EmailParameterController(IEmailParameterService emailParameterService)
        {
            _emailParameterService = emailParameterService;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Add(EmailParameterDto emailParameterDto)
        {
            var result = await _emailParameterService.Add(emailParameterDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> Update(EmailParameterUpdateDto emailParameterUpdateDto)
        {
            var result = await _emailParameterService.Update(emailParameterUpdateDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpDelete("[action]")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _emailParameterService.Delete(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetList()
        {
            var result = await _emailParameterService.GetList();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _emailParameterService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
    }
}
