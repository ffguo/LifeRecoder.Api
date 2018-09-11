using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LifeRecoder.Application.Dto
{
    public class UserDto
    {
        public Guid Id { get; set; }

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
    }
}
