using AthleteSportTournamentsApp.Data;
using Microsoft.EntityFrameworkCore;

namespace AthleteSportTournamentsApp.Models.Repositories
{
    public class AthleteSportTournamentsRepository : IRepository<AthleteSportTournaments>
    {
        private readonly AppDbContext _context;

        public AthleteSportTournamentsRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<AthleteSportTournaments> GetAll()
        {
            return _context.AthleteSportTournaments.ToList();
        }

        public AthleteSportTournaments GetById(int id)
        {
            return _context.AthleteSportTournaments.Find(id);
        }

        public void Add(AthleteSportTournaments entity)
        {
            _context.AthleteSportTournaments.Add(entity);
        }

        public void Update(AthleteSportTournaments entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(AthleteSportTournaments entity)
        {
            _context.AthleteSportTournaments.Remove(entity);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
