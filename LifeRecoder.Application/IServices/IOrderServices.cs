using LifeRecoder.Application.Dto;
using LifeRecoder.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace LifeRecoder.Application.IServices
{
    public interface IOrderServices
    {
        OrderListDto LoadPageList(int startPage, int pageSize);
        OrderDto GetOrder(int id);
        OrderDto AddOrder(OrderDto order, Guid userId);
    }
}
