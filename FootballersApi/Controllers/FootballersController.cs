using AutoMapper;
using FootballersApi.Data;
using FootballersApi.Dtos;
using FootballersApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FootballersApi.Controllers
{
    [Route("api/Teams/{teamId}/[controller]")]
    [ApiController]
    public class FootballersController : ControllerBase
    {
        private readonly IAppRepository _appRepository;
        private readonly IMapper _mapper;
        public FootballersController(IAppRepository appRepository, IMapper mapper)
        {
            _appRepository = appRepository;
            _mapper = mapper;
        }

        [HttpPost("createFootballer")]
        public IActionResult CreateFootballer([FromBody] FootballerForCreationDto footballerForCreationDto,int teamId)
        {
            if (footballerForCreationDto==null || teamId==null)
            {
                return BadRequest("You have not entered footballer datas or entered url by wrong");
            }

            var footballer = _mapper.Map<Footballer>(footballerForCreationDto);
            footballer.TeamId = teamId;
            footballer.Team = _appRepository.ReadAllTeams().FirstOrDefault(t => t.Id == teamId);

            _appRepository.Create<Footballer>(footballer);
            _appRepository.SaveAll();
            



            return StatusCode(201,_mapper.Map<FootballerForListDto>(footballer));

            //Bir tane Dto yazılacak çünkü footballer içinde team nesnesi geliyor biz bunu istemiyoruz.
            //Automapper kurulumu gerçekleşecek ve Dto'da Team nesnesi olmayacak.
            //Biz sonra DTO'yu Footballer nesnesine match edip veritabanına team id ile çektiğimiz takımı eşleyip ekleyeceğiz.
            //Verilen Team Id'ye(route'dan gelen) göre oyuncuya takım atanılacak.

        }

        [HttpGet]
        public IActionResult ReadAllFootballersByTeam(int teamId)
        {
            //Route'dan gelen team Id ile takımdan gelen futbolcular filtrelenecek ve tüm veriler okunacak. Direkt default route ile çağırılacak.
            var footballers = _appRepository.ReadAllFootballers().Where(f => f.TeamId == teamId).ToList();
            var TempFootballers= new List<FootballerForListDto>();
            
            foreach (var footballer in footballers)
            {
                var tempDto=_mapper.Map<FootballerForListDto>(footballer);
                TempFootballers.Add(tempDto);
            }

            return Ok(TempFootballers);
        }



        
    }
}
