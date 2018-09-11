using System;
using System.ComponentModel.DataAnnotations;

namespace LifeRecoder.Domain
{
    /// <summary>
    /// 泛型实体基类
    /// </summary>
    /// <typeparam name="TPrimaryKey">主键类型</typeparam>
    public abstract class Entity<TPrimaryKey>
    {
        public virtual TPrimaryKey Id { get; set; }
    }

    /// <summary>
    /// 带时间和添加人的泛型实体基类
    /// </summary>
    /// <typeparam name="TPrimaryKey">主键类型</typeparam>
    public abstract class EntityWithDate<TPrimaryKey> : Entity<TPrimaryKey>
    {
        public EntityWithDate()
        {
            AddDate = DateTime.Now;
        }

        public DateTime AddDate { get; set; }
        [StringLength(50)]
        public string AddUser { get; set; }
    }

    /// <summary>
    /// 定义默认主键类型为Guid的实体基类
    /// </summary>
    public abstract class Entity : Entity<Guid>
    {

    }
}
