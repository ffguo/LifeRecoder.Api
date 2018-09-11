using LifeRecoder.Domain;
using LifeRecoder.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace LifeRecoder.Application
{
    public class ServicesBase<TEntity, TPrimaryKey>
        where TEntity : Entity<TPrimaryKey>
    {
        protected IRepository<TEntity, TPrimaryKey> _repository;

        public ServicesBase(IRepository<TEntity, TPrimaryKey> repository)
        {
            _repository = repository;
        }
    }
}
