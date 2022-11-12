using Dot.Net.PoseidonApi.Entities;
using System.Threading.Tasks;

namespace PoseidonApi.Repositories
{
    public interface IEntityRepository<T> where T : APIEntity
    {
        Task AddAsync(T entity);
        Task DeleteAsync(T entity);
        Task UpdateAsync(T entity);
        Task<T[]> FindAllAsync();
        Task<T> GetByIdAsync(int id);
    }
}