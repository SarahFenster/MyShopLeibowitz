using Entity;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;
using System.Text.Json;


namespace Repository
{
    public class UserRepository : IUserRepository
    {

        ApiDbToCodeContext _apiDbToCodeContext;
        public UserRepository(ApiDbToCodeContext ApiDbToCodeContext)
        {
            _apiDbToCodeContext = ApiDbToCodeContext;

        }



        public async Task<User> GetUserById(int id)
        {
            return await _apiDbToCodeContext.Users.FindAsync(id);

        }

        public async Task<User> AddUser(User user)
        {
            await _apiDbToCodeContext.Users.AddAsync(user);
            await _apiDbToCodeContext.SaveChangesAsync();

            return user;

        }
        public async Task UpdateUser(int id, User userToUpdate)
        {
            userToUpdate.UserId = id;
            _apiDbToCodeContext.Users.Update(userToUpdate);
            await _apiDbToCodeContext.SaveChangesAsync();
         

        }

        public async Task<User> LogIn(string userName, string password)
        {
            return await _apiDbToCodeContext.Users.FirstOrDefaultAsync((user) => user.UserName == userName && user.Password == password);


        }


    }
}

       
    

