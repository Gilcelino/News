using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IBaseRepository<TEntity> where TEntity: BaseEntity 
    {
        Task<TEntity> Insert(TEntity obj);
        Task<TEntity> Update(TEntity obj);
        Task Delete(int id);
        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity>  GetById(int id);
    }
}