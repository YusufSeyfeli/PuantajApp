using Business.Repositories.CompetencyRepository;
using Business.Repositories.OperationCompetencyRepository;
using Business.Repositories.UserJobUnitRepository;
using Entities.Concrete;
using Entities.Dtos.CompetencyDtos;
using Entities.Dtos.OperationCompetencyDtos;
using Entities.Dtos.UserJobUnitDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserJobUnitController : ControllerBase
    {
        private readonly IUserJobUnitService _userJobUnitService;
        public UserJobUnitController(IUserJobUnitService userJobUnitService)
        {
            _userJobUnitService = userJobUnitService;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetList()
        {
            var result = await _userJobUnitService.GetList();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }


        [HttpGet("[action]")]
        public async Task<IActionResult> GetById(Guid UserJobUnitGuidId)
        {
            var result = await _userJobUnitService.GetById(UserJobUnitGuidId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> Update(UserJobUnitUpdateDto userJobUnitUpdateDto)
        {
            var result = await _userJobUnitService.Update(userJobUnitUpdateDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpDelete("[action]")]
        public async Task<IActionResult> Delete(Guid UserJobUnitGuidId)
        {
            var result = await _userJobUnitService.Delete(UserJobUnitGuidId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Add(UserJobUnitDto userJobUnitDto)
        {
            var result = await _userJobUnitService.Add(userJobUnitDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> BulkAddForUserJobUnit(List<UserJobUnitDto> userJobUnitDto)
        {
            var result = await _userJobUnitService.BulkAddForUserJobUnit(userJobUnitDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpDelete("[action]")]
        public async Task<IActionResult> BulkDeleteForUserJobUnit(Guid UserGuidId)
        {
            var result = await _userJobUnitService.BulkDeleteForUserJobUnit(UserGuidId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        //[HttpPut("[action]")]
        //public async Task<IActionResult> BulkUpdateForUserJobUnit(List<UserJobUnitUpdateDto> userJobUnitUpdateDto)
        //{
        //    var result = await _userJobUnitService.BulkUpdateForUserJobUnit(userJobUnitUpdateDto);
        //    if (result.Success)
        //    {
        //        return Ok(result);
        //    }
        //    return BadRequest(result.Message);
        //}
    }
}

