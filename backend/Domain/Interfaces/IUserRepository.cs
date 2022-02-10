using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User> GetByEmail(string email);
        Task<IEnumerable<User>> SearchByEmail(string email);
        Task<IEnumerable<User>> SearchByNome(string name);
    }
}