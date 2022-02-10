using Data.Context;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace Infra.Data.Repository
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity:BaseEntity
    {
        protected readonly MySQLContext _mySQLContext;

        public BaseRepository(MySQLContext mySQLContext)
        {
            _mySQLContext = mySQLContext;
        }

        public virtual async Task<TEntity> Insert(TEntity obj)
        {
            _mySQLContext.Set<TEntity>().Add(obj);
            await _mySQLContext.SaveChangesAsync();
            
            return obj;
        }

        public virtual async Task<TEntity> Update(TEntity obj)
        {
            _mySQLContext.Entry(obj).State = EntityState.Modified;
            await _mySQLContext.SaveChangesAsync();
            return obj;
        }

        public virtual async Task Delete(int id)
        {
            var obj = await GetById(id);

            if (obj != null )
            {
                _mySQLContext.Set<TEntity>().Remove(obj);
               await _mySQLContext.SaveChangesAsync();
            }            
        }

        public virtual async Task<IEnumerable<TEntity>> GetAll()=> 
                                                        await _mySQLContext.Set<TEntity>()
                                                        .AsNoTracking()
                                                        .ToListAsync();

        public virtual async Task<TEntity> GetById(int id) => 
                                                        await _mySQLContext.Set<TEntity>()
                                                        .AsNoTracking()
                                                        .Where(x => x.Id == id).FirstAsync();
    }
}