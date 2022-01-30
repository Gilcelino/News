using Data.Context;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repository
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity:BaseEntity
    {
        protected readonly MySQLContext _mySQLContext;

        public BaseRepository(MySQLContext mySQLContext)
        {
            _mySQLContext = mySQLContext;
        }

        public void Insert(TEntity obj)
        {
            _mySQLContext.Set<TEntity>().Add(obj);
            _mySQLContext.SaveChanges();
        }

        public void Update(TEntity obj)
        {
            _mySQLContext.Entry(obj).State = EntityState.Modified;
            _mySQLContext.SaveChanges();
        }

        public void Delete(int id)
        {
            _mySQLContext.Set<TEntity>().Remove(GetById(id));
            _mySQLContext.SaveChanges();
        }

        public IEnumerable<TEntity> GetAll()=> _mySQLContext.Set<TEntity>().ToList();

        public TEntity GetById(int id) => _mySQLContext.Set<TEntity>().Find(id);
        
    }
}