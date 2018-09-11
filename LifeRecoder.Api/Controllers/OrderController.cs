using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LifeRecoder.Api.AuthHelper;
using LifeRecoder.Application.Dto;
using LifeRecoder.Application.IServices;
using LifeRecoder.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LifeRecoder.Api.Controllers
{
    /// <summary>
    /// 订菜订单API
    /// </summary>
    [Route("api/[Controller]")]
    [Authorize(Policy = "Client")]
    public class OrderController : Controller
    {
        private IOrderServices _orderServices;

        public OrderController(IOrderServices orderServices)
        {
            _orderServices = orderServices;
        }

        /// <summary>
        /// 获取分页订单数据
        /// </summary>
        /// <param name="startPage">从第几条开始</param>
        /// <param name="pageSize">一页的数量</param>
        /// <returns>返回分页订单列表</returns>
        [HttpGet]
        public IActionResult GetAllOrders(int startPage, int pageSize)
        {
            if (startPage <= 0 || pageSize <= 0)
                return BadRequest("参数不能小于零");
            return Ok(_orderServices.LoadPageList(startPage, pageSize));
        }

        /// <summary>
        /// 获取单个订单
        /// </summary>
        /// <param name="id">订单编号</param>
        /// <returns>返回单个订单</returns>
        [HttpGet("{id}")]
        public IActionResult GetOrder(int id)
        {
            if (id <= 0)
                return BadRequest("参数不能小于零");
            var order = _orderServices.GetOrder(id);
            if (order == null)
                return NotFound();
            return Ok(order);
        }

        /// <summary>
        /// 添加一个订单
        /// </summary>
        /// <param name="orderDto"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Add([FromBody] OrderDto orderDto)
        {
            if (orderDto == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newOrder = _orderServices.AddOrder(orderDto, JwtHelper.GetPayload(Request).Uid);
            if (newOrder == null)
            {
                return StatusCode(500, "保存订单的时候出错");
            }

            return Ok(newOrder);
        }
    }
}