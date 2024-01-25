using AthleteSportTournamentsApp.Data;

namespace AthleteSportTournamentsApp.Repositories
{
    public interface ICrudRepository<T>
    {
        public Task<T> GetByIdAsync(int id);
        public Task<List<T>> GetAllAsync();
        public Task AddAsync(T entity);
        public Task UpdateAsync(T entity);
        public Task DeleteAsync(int id);
    }
}