using Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO

{
    public class GetUserDTO(string UserName, string? FirstName, string? LastName, ICollection<Order> Orders);
    public class RegisterUserDTO(string UserName, string? FirstName, string? LastName, string Password);


}
