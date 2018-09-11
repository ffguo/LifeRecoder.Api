using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LifeRecoder.Domain.Entities
{
    public class User : Entity
    {
        [Required]
        [MaxLength(10, ErrorMessage = "用户名太长")]
        public string UserName { get; set; }

        [Required]
        [MaxLength(32, ErrorMessage = "密码加密长度太长")]
        public string PassWord { get; set; }

        [Required]
        [MaxLength(20, ErrorMessage = "昵称太长")]
        public string NickName { get; set; }

        public Guid TeamId { get; set; }

        public virtual Team Team { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
