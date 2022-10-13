
using Domain.Entities;
using Domain.Interfaces;
using FluentValidation;

namespace Service.Services
{
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : BaseEntity
    {
        private readonly IBaseRepository<TEntity> _baseRepository;

        public BaseService(IBaseRepository<TEntity> baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public async Task<TEntity> Insert<TValidator>(TEntity obj) where TValidator : AbstractValidator<TEntity>
        {
            Validate(obj, Activator.CreateInstance<TValidator>());
            await _baseRepository.Insert(obj);
            return obj;
        }

        public async Task<TEntity> Update<TValidator>(TEntity obj) where TValidator : AbstractValidator<TEntity>
        {
            Validate(obj, Activator.CreateInstance<TValidator>());
            await _baseRepository.Update(obj);
            return obj;
        }

        public Task Delete(int id) => _baseRepository.Delete(id);

        public Task<IEnumerable<TEntity>> GetAll() => _baseRepository.GetAll();

        public Task< TEntity> GetById(int id) => _baseRepository.GetById(id);

        private void Validate(TEntity obj, AbstractValidator<TEntity> Validator)
        {   
            if (obj is null)
            {
                throw new Exception("Registros não detectados!");
            }

            Validator.ValidateAndThrow(obj);
        }

    }
}