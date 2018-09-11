using System;
using System.Collections.Generic;
using System.Text;

namespace LifeRecoder.Application.Dto
{
    public class OrderListDto
    {
        public int PageCount { get; set; }
        public List<OrderDto> OrderDtos { get; set; }
    }
}
