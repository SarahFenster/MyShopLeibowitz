using Entity;

namespace Repository
{
    public interface IUserRepository
    {
        Task<User> AddUser(User user);
        Task<User> GetUserById(int id);
        Task<User> LogIn(string userName, string password);
        Task UpdateUser(int id, User userToUpdate);
    }
}