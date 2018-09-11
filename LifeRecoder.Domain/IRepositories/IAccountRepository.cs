using LifeRecoder.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace LifeRecoder.Domain.IRepositories
{
    public interface IAccountRepository : IRepository<User, Guid>
    {
    }
}
