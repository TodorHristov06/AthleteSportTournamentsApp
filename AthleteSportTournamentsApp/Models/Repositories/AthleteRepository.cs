using AthleteSportTournamentsApp.Data;
using Microsoft.EntityFrameworkCore;

namespace AthleteSportTournamentsApp.Models.Repositories
{
    public class AthleteRepository : IRepository<Athlete>
    {
        private readonly AppDbContext _context;

        public AthleteRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Athlete> GetAll()
        {
            return _context.Athletes.ToList();
        }

        public Athlete GetById(int id)
        {
            return _context.Athletes.Find(id);
        }

        public void Add(Athlete entity)
        {
            _context.Athletes.Add(entity);
        }

        public void Update(Athlete entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(Athlete entity)
        {
            _context.Athletes.Remove(entity);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
