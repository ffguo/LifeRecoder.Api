using LifeRecoder.Domain;
using LifeRecoder.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace LifeRecoder.EntityFrameworkCore
{
    /// <summary>
    ///     EntityFramework仓储操作基类
    /// </summary>
    /// <typeparam name="TEntity">动态实体类型</typeparam>
    /// <typeparam name="TKey">实体主键类型</typeparam>
    public abstract class EFRepositoryBase<TEntity, TKey> : IRepository<TEntity, TKey>
        where TEntity : Entity<TKey>
    { 

        //定义数据访问上下文对象
        protected readonly LifeDbContext _dbContext;

        /// <summary>
        /// 通过构造函数注入得到数据上下文对象实例
        /// </summary>
        /// <param name="dbContext"></param>
        public EFRepositoryBase(LifeDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<TEntity> Entities => _dbContext.Set<TEntity>();

        public void Delete(TEntity entity, bool autoSave = true)
        {
            _dbContext.Set<TEntity>().Remove(entity);
            if (autoSave)
                Save();
        }

        public void Delete(TKey id, bool autoSave = true)
        {
            _dbContext.Set<TEntity>().Remove(Get(id));
            if (autoSave)
                Save();
        }

        public void Delete(Expression<Func<TEntity, bool>> where, bool autoSave = true)
        {
            _dbContext.Set<TEntity>().Where(where).ToList().ForEach(it => _dbContext.Set<TEntity>().Remove(it));
            if (autoSave)
                Save();
        }

        public TEntity Get(TKey id)
        {
            return _dbContext.Set<TEntity>().FirstOrDefault(CreateEqualityExpressionForId(id));
        }

        public TEntity Insert(TEntity entity, bool autoSave = true)
        {
            _dbContext.Set<TEntity>().Add(entity);
            if (autoSave)
                Save();
            return entity;
        }

        public TEntity InsertOrUpdate(TEntity entity, bool autoSave = true)
        {
            if (Get(entity.Id) == null)
                return Insert(entity, autoSave);
            return Update(entity, autoSave);
        }

        public IQueryable<TEntity> LoadPageList(int startPage, int pageSize, out int rowCount, Expression<Func<TEntity, bool>> where, Expression<Func<TEntity, object>> order)
        {
            var result = from p in _dbContext.Set<TEntity>()
                         select p;
            if (where != null)
                result = result.Where(where);
            if (order != null)
                result = result.OrderBy(order);
            else
                result = result.OrderBy(m => m.Id);
            rowCount = result.Count();
            return result.Skip((startPage - 1) * pageSize).Take(pageSize);
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public TEntity Update(TEntity entity, bool autoSave = true)
        {
            var obj = Get(entity.Id);
            EntityToEntity(entity, obj);
            if (autoSave)
                Save();
            return entity;
        }

        private void EntityToEntity(TEntity pTargetObjSrc, TEntity pTargetObjDest)
        {
            foreach (var mItem in typeof(TEntity).GetProperties())
            {
                mItem.SetValue(pTargetObjDest, mItem.GetValue(pTargetObjSrc, new object[] { }), null);
            }
        }

        private Expression<Func<TEntity, bool>> CreateEqualityExpressionForId(TKey id)
        {
            var lambdaParam = Expression.Parameter(typeof(TEntity));
            var lambdaBody = Expression.Equal(
                Expression.PropertyOrField(lambdaParam, "Id"),
                Expression.Constant(id, typeof(TKey))
                );

            return Expression.Lambda<Func<TEntity, bool>>(lambdaBody, lambdaParam);
        }
    }

    public abstract class EFRepositoryBase<TEntity> : EFRepositoryBase<TEntity, Guid>
        where TEntity : Entity
    {
        public EFRepositoryBase(LifeDbContext dbContext) : base(dbContext)
        {
        }
    }
}
