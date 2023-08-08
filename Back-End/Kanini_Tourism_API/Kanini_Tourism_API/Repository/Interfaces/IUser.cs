using Kanini_Tourism_API.Models;
using Kanini_Tourism_API.Models.DTO;

namespace Kanini_Tourism_API.Repository.Interfaces
{
    public interface IUser
    {
        Task<User> AddUser(User user);
        Task<IEnumerable<User>> GetAllUsers();

        Task<User> GetUserByEmail(string email);
        Task<User> GetUserById(int id);
        Task<User> UpdateUser(int userId, User updatedUser);
        Task DeleteUser(int id);
        /* Task<UserStatusDTO> UpdateUserstatus(int userId, UserStatusDTO updatedUser);*/

    }
}
