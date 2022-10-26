using Dot.Net.PoseidonApi.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PoseidonApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoseidonApi.Repositories
{
    public class EntityRepository<T> : IEntityRepository<T> where T : APIEntity
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<T> _entities;


        public EntityRepository(ApplicationDbContext dbContext)
        {
            _context = dbContext;
            _entities = dbContext.Set<T>();
        }


        public async Task<T[]> FindAllAsync()
        {
            return await _entities.ToArrayAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _entities.SingleOrDefaultAsync(s => s.Id == id);
        }

        public async Task AddAsync(T entity)
        {
            _entities.Add(entity);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(T entity)
        {
            _entities.Remove(entity);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(T entity)
        {
            _entities.Update(entity);   
            await _context.SaveChangesAsync();
        }

    }
}
