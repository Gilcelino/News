using Domain.Entities;
using FluentValidation;

namespace Domain.Interfaces
{
    public interface IBaseService<TEntity> where TEntity: BaseEntity
    {
        TEntity Insert<TValidator>(TEntity obj) where TValidator: AbstractValidator<TEntity>;
        TEntity Update<TValidator>(TEntity obj) where TValidator: AbstractValidator<TEntity>; 
        void Delete(int id);
        IEnumerable<TEntity> GetAll();
        TEntity GetById (int id);
    }
}