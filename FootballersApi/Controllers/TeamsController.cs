using AutoMapper;
using FootballersApi.Data;
using FootballersApi.Dtos;
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
        private readonly IMapper _mapper;
        public TeamsController(IAppRepository appRepository, IMapper mapper)
        {
            _appRepository = appRepository;
            _mapper = mapper;
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
            var tempTeams = new List<TeamForListDto>();
            var allTeams=_appRepository.ReadAllTeams();
            foreach (var team in allTeams)
            {
                tempTeams.Add(_mapper.Map<TeamForListDto>(team));
            }
            return Ok(tempTeams);
        }
    }
}
