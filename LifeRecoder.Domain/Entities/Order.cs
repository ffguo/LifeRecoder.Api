using LifeRecoder.Domain.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LifeRecoder.Domain.Entities
{
    public class Order : EntityWithDate<int>
    {
        [Required]
        [MaxLength(20, ErrorMessage = "购买者名字太长")]
        public string Buyer { get; set; }

        [Required]
        [Split(",")]
        public string ItemsName { get; set; }

        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "金额不能小于零")]
        public decimal Price { get; set; }

        public string Remarks { get; set; }

        public DateTime BuyDate { get; set; }

        public Guid UserId { get; set; }


        public virtual User User { get; set; }
    }
}
