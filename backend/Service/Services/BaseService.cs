using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public TEntity Insert<TValidator>(TEntity obj) where TValidator : AbstractValidator<TEntity>
        {
            Validate(obj, Activator.CreateInstance<TValidator>());
            _baseRepository.Insert(obj);
            return obj;
        }

        public TEntity Update<TValidator>(TEntity obj) where TValidator : AbstractValidator<TEntity>
        {
            Validate(obj, Activator.CreateInstance<TValidator>());
            _baseRepository.Update(obj);
            return obj;
        }

        public void Delete(int id) => _baseRepository.Delete(id);

        public IEnumerable<TEntity> GetAll() => _baseRepository.GetAll();

        public TEntity GetById(int id) => _baseRepository.GetById(id);

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