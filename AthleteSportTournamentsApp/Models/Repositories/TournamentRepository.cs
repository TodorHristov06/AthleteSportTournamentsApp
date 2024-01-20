using AthleteSportTournamentsApp.Data;
using Microsoft.EntityFrameworkCore;

namespace AthleteSportTournamentsApp.Models.Repositories
{
    public class TournamentRepository : IRepository<Tournament>
    {
        private readonly AppDbContext _context;

        public TournamentRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Tournament> GetAll()
        {
            return _context.Tournaments.ToList();
        }

        public Tournament GetById(int id)
        {
            return _context.Tournaments.Find(id);
        }

        public void Add(Tournament entity)
        {
            _context.Tournaments.Add(entity);
        }

        public void Update(Tournament entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(Tournament entity)
        {
            _context.Tournaments.Remove(entity);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
