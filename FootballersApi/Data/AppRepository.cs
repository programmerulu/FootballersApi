using FootballersApi.Models;
using Microsoft.EntityFrameworkCore;

namespace FootballersApi.Data
{
    public class AppRepository : IAppRepository
    {
        private readonly DataContext _context;
        public AppRepository(DataContext context)
        {
            _context = context;
        }

        public void Create<T>(T entity)
        {
            _context.Add(entity);
            _context.SaveChanges();
        }

        public void Delete<T>(int Id) where T:class
        {
            var dbEntity = _context.Set<T>().Find(Id);
            _context.Remove(dbEntity);
            _context.SaveChanges();
        }

        public List<Footballer> GetAllFootballersByTeam()
        {
            throw new NotImplementedException();
        }

        public List<Footballer> ReadAllFootballers()
        {
            return _context.Footballers.Include(f => f.Team).ToList();
        }

        public List<Team> ReadAllTeams()
        {
            return _context.Teams.Include(f=>f.Footballers).ToList();

        }

        public bool SaveAll()
        {
            return _context.SaveChanges() > 0;
        }

        public void Update<T>(T entity, int Id) where T : class
        {
            var dbEntity = _context.Set<T>().Find(Id);
            if (dbEntity != null)
            {
                _context.Entry(dbEntity).CurrentValues.SetValues(entity);
                _context.SaveChanges();
            }
        }
    }
}
