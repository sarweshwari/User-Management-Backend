using BackendDotNet.Dto;
using BackendDotNet.Models;
using System.Collections.Generic;

namespace BackendDotNet.Service
{
    public interface IUsersService
    {
        public Task<bool> Register(RegisterDto obj);
        public Task<User> Login(LoginDto obj);
        public Task<bool> Update(int id , RegisterDto newObj);
        public Task<bool> Delete(int id);
        public Task<User> GetUserById(int id);
        public Task<IList<User>> GetAllUsers();
        Task<bool> ResetPassword(ResetDto resetDto);
        public Task<User> Getuser(int id);
    }
}
