using LifeRecoder.Domain.Entities;
using LifeRecoder.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace LifeRecoder.EntityFrameworkCore.Repositories
{
    public class OrderRepository : EFRepositoryBase<Order, int>, IOrderRepository
    {
        public OrderRepository(LifeDbContext dbContext) : base(dbContext)
        {
        }
    }
}
