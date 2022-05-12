using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HigherOrLowerGame.Api.Infra.repositories.interfaces;
using Microsoft.EntityFrameworkCore;

namespace HigherOrLowerGame.Api.Infra.repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        private readonly AppDbContext _dbContext;

        public BaseRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual async Task<TEntity> GetById(Guid id)
        {
            return await _dbContext.Set<TEntity>().FindAsync(id);
        }

        public virtual async Task<IEnumerable<TEntity>> GetAll()
        {
            return await _dbContext.Set<TEntity>().ToListAsync();
        }
        

        public virtual async Task<TEntity> AddAsync(TEntity entity)
        {
            try
            {
                _dbContext.ChangeTracker.Clear();
                await _dbContext.Set<TEntity>().AddAsync(entity);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw;
            }


            return entity;
        }
        

        public virtual async Task<bool> DeleteAsync(TEntity entity) 
        {
            try
            {
                _dbContext.Set<TEntity>().Remove(entity);
                var result = await _dbContext.SaveChangesAsync();
                return result > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public virtual async Task<bool> UpdateAsync(TEntity entity)
        {
            try
            {
                _dbContext.Update(entity);
                var result = await _dbContext.SaveChangesAsync();
                return result > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }
   
        
    }
}