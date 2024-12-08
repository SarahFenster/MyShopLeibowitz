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

        public OrdersController(IOrderService orderService)
        {
            this.orderService = orderService;
        }


        // GET api/<OrdersController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> Get(int id)
        {

            Order foundOrder = await orderService.GetOrderById(id);
            if (foundOrder == null)
                return NoContent();
            else

                return Ok(foundOrder);

        }

        // POST api/<OrdersController>
      
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Order order)
        {
            Order newOrder = await orderService.AddOrder(order);
            return newOrder != null ? Ok(newOrder) : Unauthorized();
        }

    }
}
