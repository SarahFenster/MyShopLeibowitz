using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class OrderDTO(DateTime? OrderDate, int? OrderSum, string UserUserName);

    public class AddOrderDTO(DateTime? OrderDate, int? OrderSum, int UserId);

}
