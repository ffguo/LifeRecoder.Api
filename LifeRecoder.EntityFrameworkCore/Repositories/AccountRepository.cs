using LifeRecoder.Domain.Entities;
using LifeRecoder.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace LifeRecoder.EntityFrameworkCore.Repositories
{
    public class AccountRepository : EFRepositoryBase<User>, IAccountRepository
    {
        public AccountRepository(LifeDbContext dbContext) : base(dbContext)
        {
        }
    }
}
