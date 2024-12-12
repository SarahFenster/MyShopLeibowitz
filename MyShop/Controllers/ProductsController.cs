using Microsoft.AspNetCore.Mvc;

using service;
using Entity;
using AutoMapper;
using DTO;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase

    {
        IProductService poductService;

        IMapper _mapper;
        public ProductsController(IProductService poductService , IMapper mapper)
        {
            this.poductService = poductService;
            _mapper = mapper;
        }



        // GET: api/<ProductsController>
        [HttpGet]
        public async Task<ActionResult<List<ProductDTO>>>Get()
        {
            List<Product> products = await poductService.GetAllProduct();
            return _mapper.Map<List<Product>, List<ProductDTO>>(products); ;
           
        }

     

    
    }
}
