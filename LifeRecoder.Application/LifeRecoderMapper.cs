using AutoMapper;
using LifeRecoder.Application.Dto;
using LifeRecoder.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace LifeRecoder.Application
{
    public class LifeRecoderMapper
    {
        public static void Initialize()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Order, OrderDto>();
                cfg.CreateMap<OrderDto, Order>();
                cfg.CreateMap<User, UserDto>();
                cfg.CreateMap<UserDto, User>();
            });
        }
    }
}
