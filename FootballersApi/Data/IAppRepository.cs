using FootballersApi.Models;

namespace FootballersApi.Data
{
    public interface IAppRepository
    {
        //CRUD

        void Create<T>(T entity);
        List<Footballer> ReadAllFootballers();
        List<Team> ReadAllTeams();
        void Update<T>(T entity,int Id) where T : class;
        void Delete<T>(int Id) where T : class;

        List<Footballer> GetAllFootballersByTeam();

        bool SaveAll();

        //GetAllFootballeryByTeam


    }
}
