using Microsoft.AspNetCore.Mvc;

using service;
using Entity;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase

    {
        IProductService poductService;

        public ProductsController(IProductService poductService)
        {
            this.poductService = poductService;
        }



        // GET: api/<ProductsController>
        [HttpGet]
        public async Task<ActionResult<List<Product>>>Get()
        {
            return  await poductService.GetAllProduct();
        }

     

    
    }
}
