using LifeRecoder.Application.Dto;
using LifeRecoder.Application.IServices;
using LifeRecoder.Domain.Entities;
using LifeRecoder.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;

namespace LifeRecoder.Application.Services
{
    public class OrderServices : IOrderServices
    {
        private readonly IOrderRepository _repository;

        public OrderServices(IOrderRepository repository)
        {
            _repository = repository;
          
        }

        public OrderListDto LoadPageList(int startPage, int pageSize)
        {
            int rowCount = 0;
            var rows = Mapper.Map<List<OrderDto>>(_repository.LoadPageList(startPage, pageSize, out rowCount, null, o => o.AddDate));
            return new OrderListDto
            {
                PageCount = rowCount,
                OrderDtos = rows
            };
        }

        public OrderDto GetOrder(int id)
        {
            return Mapper.Map<OrderDto>(_repository.Get(id));
        }

        public OrderDto AddOrder(OrderDto orderDto, Guid userId)
        {
            if (orderDto == null)
                return null;
            var order = Mapper.Map<Order>(orderDto);
            order.UserId = userId;
            return Mapper.Map<OrderDto>(_repository.Insert(order, true));
        }
    }
}
