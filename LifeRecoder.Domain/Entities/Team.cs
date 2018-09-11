using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LifeRecoder.Domain.Entities
{
    public class Team : Entity
    {
        [Required]
        [MaxLength(20, ErrorMessage = "团队名字太长")]
        public string TeamName { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "金额不能小于零")]
        public decimal TotalMoney { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
