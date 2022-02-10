using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Context;
using Domain.Entities;
using Domain.Interfaces;
using Infra.Data.Repository;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        protected readonly MySQLContext _mySQLContext;
        public UserRepository(MySQLContext mySQLContext) : base(mySQLContext)
        {
            _mySQLContext = mySQLContext;
        }

        public async Task<User> GetByEmail(string email) => await _mySQLContext.Users
                                                                                .AsNoTracking()
                                                                                .Where(u => u.Email.ToLower() == email.ToLower())
                                                                                .FirstAsync();
        
        public async Task<IEnumerable<User>> SearchByEmail(string email) => await _mySQLContext.Users
                                                                                                .AsNoTracking()
                                                                                                .Where(u => u.Email.ToLower().Contains(email.ToLower()))
                                                                                                .ToListAsync();

        public async Task<IEnumerable<User>> SearchByNome(string name) => await _mySQLContext.Users
                                                                                                .AsNoTracking()
                                                                                                .Where(u => u.Name.ToLower().Contains(name.ToLower()))
                                                                                                .ToListAsync();
        
    }
}