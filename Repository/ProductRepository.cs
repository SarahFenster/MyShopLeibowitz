using Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ProductRepository : IProductRepository
    {

        ApiDbToCodeContext _apiDbToCodeContext;
        public ProductRepository(ApiDbToCodeContext ApiDbToCodeContext)
        {
            _apiDbToCodeContext = ApiDbToCodeContext;

        }





        public async Task<List<Product>> GetAllProduct()
        {
            return await _apiDbToCodeContext.Products.ToListAsync();


        }


    }
}

