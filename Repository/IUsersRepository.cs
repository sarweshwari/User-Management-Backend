using BackendDotNet.Models;

namespace BackendDotNet.Repository
{
    public interface IUsersRepository
    {
        public Task<bool> AddUser(User user);
        public Task<bool> UpdateUser(User user);
        public Task<bool> DeleteUser(User user);
        public Task<User> GetUserById(int id);
        public Task<User> GetUserByEmail(string email);
        public Task<IList<User>> GetAllUsers();
        public Task<bool> Save();
        Task<User?> Finduser(int id);
    }
}
