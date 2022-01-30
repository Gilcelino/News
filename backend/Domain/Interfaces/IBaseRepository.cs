using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IBaseRepository<TEntity> where TEntity: BaseEntity 
    {
        void Insert(TEntity obj);
        void Update(TEntity obj);
        void Delete(int id);
        IEnumerable<TEntity> GetAll();
        TEntity  GetById(int id);
    }
}