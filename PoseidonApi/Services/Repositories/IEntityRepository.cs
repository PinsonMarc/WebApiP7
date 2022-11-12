using Dot.Net.PoseidonApi.Entities;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System;

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