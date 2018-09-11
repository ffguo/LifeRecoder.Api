using LifeRecoder.Domain.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LifeRecoder.Application.Dto
{
    /// <summary>
    /// 菜单数据类
    /// </summary>
    public class OrderDto
    {
        /// <summary>
        /// 购买者
        /// </summary>
        [Required]
        [MaxLength(20, ErrorMessage = "购买者名字太长")]
        public string Buyer { get; set; }

        /// <summary>
        /// 菜名列表（以英文逗号分隔）
        /// </summary>
        [Required]
        [Split(",")]
        public string ItemsName { get; set; }

        /// <summary>
        /// 价格
        /// </summary>
        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "金额不能小于零")]
        public decimal Price { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remarks { get; set; }

        /// <summary>
        /// 购买时间
        /// </summary>
        public DateTime BuyDate { get; set; }

        /// <summary>
        /// 添加记录人的昵称
        /// </summary>
        public string AddUser { get; set; }
    }
}
