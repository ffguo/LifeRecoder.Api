using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LifeRecoder.Application.Dto
{
    /// <summary>
    /// 登录用户信息
    /// </summary>
    public class LoginUserDto
    {
        /// <summary>
        /// 用户名
        /// </summary>
        [Required]
        [MaxLength(10, ErrorMessage = "用户名太长")]
        public string UserName { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        [Required]
        [MaxLength(32, ErrorMessage = "密码加密长度太长")]
        public string PassWord { get; set; }
    }
}
