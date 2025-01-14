﻿using AutoMapper;
using DTO;
using Entity;
using Microsoft.AspNetCore.Mvc;
using service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {

        IOrderService orderService;
        IMapper _mapper;
        public OrdersController(IOrderService orderService, IMapper mapper)
        {
            this.orderService = orderService;
            _mapper = mapper;
        }


        // GET api/<OrdersController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> Get(int id)
        {

            Order foundOrder = await orderService.GetOrderById(id);
           
            if (foundOrder == null)
                return NoContent();
            else

                return Ok( _mapper.Map<Order, OrderDTO>(foundOrder));

        



        }

        // POST api/<OrdersController>

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] AddOrderDTO order)
        {
            Order newOrder = await orderService.AddOrder(_mapper.Map<AddOrderDTO, Order>(order));
            return newOrder != null ? Ok( _mapper.Map<Order, OrderDTO>(newOrder)) : Unauthorized();
        }

    }
}
