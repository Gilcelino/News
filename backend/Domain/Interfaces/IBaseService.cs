using Domain.Entities;
using FluentValidation;

namespace Domain.Interfaces
{
    public interface IBaseService<TEntity> where TEntity: BaseEntity
    {
        Task<TEntity >Insert<TValidator>(TEntity obj) where TValidator: AbstractValidator<TEntity>;
        Task<TEntity> Update<TValidator>(TEntity obj) where TValidator: AbstractValidator<TEntity>; 
        Task Delete(int id);
        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity> GetById (int id);
    }
}