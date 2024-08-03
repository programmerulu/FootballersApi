using FootballersApi.Data;
using FootballersApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FootballersApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamsController : ControllerBase
    {
        private readonly IAppRepository _appRepository;
        public TeamsController(IAppRepository appRepository)
        {
            _appRepository = appRepository;
        }
        [HttpPost("create")]
        public IActionResult CreateTeam([FromBody] Team team)
        {
            if (team==null)
            {
                BadRequest("You have not entered team datas");
            }

            _appRepository.Create(team);
            _appRepository.SaveAll();
            return Ok(team);

        }

        [HttpPut]
        public IActionResult EditTeam() 
        {
            return Ok();

        }

        [HttpDelete("delete/{Id}")]
        public IActionResult DeleteTeam(int Id)
        {
            if (Id==null)
            {
                return BadRequest("Id has not been sent");
            }

            _appRepository.Delete<Team>(Id);
            _appRepository.SaveAll();

            return StatusCode(204, $"Data was deleted with {Id}");
        }

        [HttpGet("readAll")]
        public IActionResult ReadAllTeam()
        {
            var allTeams=_appRepository.ReadAllTeams();
            return Ok(allTeams);
        }
    }
}
