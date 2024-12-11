using AutoMapper;
using DTO;
using Entity;

namespace MyShop
 
{
    public class _Mapper : Profile
    {
        protected _Mapper()
        {
            CreateMap<User, UserDTO>();
        }
    }
}
