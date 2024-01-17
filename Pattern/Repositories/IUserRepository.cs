using Pattern.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pattern.Repositories
{
    public interface IUserRepository
    {
        Task<User> CreateUserAsync(User user);

        Task<User> GetUserByIdAsync(int userId);

        Task<List<User>> GetAllUsersAsync();

        Task<User> UpdateUserAsync(User user);

        Task<bool> DeleteUserAsync(int userId);
    }
}
