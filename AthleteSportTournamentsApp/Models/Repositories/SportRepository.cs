using AthleteSportTournamentsApp.Data;
using Microsoft.EntityFrameworkCore;

namespace AthleteSportTournamentsApp.Models.Repositories
{
    public class SportRepository : IRepository<Sport>
    {
        private readonly AppDbContext _context;

        public SportRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Sport> GetAll()
        {
            return _context.Sports.ToList();
        }

        public Sport GetById(int id)
        {
            return _context.Sports.Find(id);
        }

        public void Add(Sport entity)
        {
            _context.Sports.Add(entity);
        }

        public void Update(Sport entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(Sport entity)
        {
            _context.Sports.Remove(entity);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
