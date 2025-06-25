using BackendDotNet.Dto;
using BackendDotNet.Models;
using BackendDotNet.Repository;
using Microsoft.EntityFrameworkCore;

namespace BackendDotNet.Service
{
    public class UsersService : IUsersService
    {
        private readonly IUsersRepository repo;

        public UsersService(IUsersRepository repo)
        {
            this.repo = repo;
        }
        public async Task<bool> Delete(int id)
        {
          var existingUser=await this.GetUserById(id);
            if (existingUser != null)
            {
               return  await repo.DeleteUser(existingUser);
            }
            return false;
        }

        public async Task<IList<User>> GetAllUsers()
       => await repo.GetAllUsers();

        public async Task<User> GetUserById(int id)
        {
           return await repo.GetUserById(id);
        }

        public async Task<User> Login(LoginDto obj)
        {
            var user =await repo.GetUserByEmail(obj.Email);
            if (user != null) { 
               bool res= BCrypt.Net.BCrypt.Verify(obj.Password, user.Password);
                if (res) {
                    user.Password = " ";
                   return user;

                }
                return null;

            }
            return null;
        }

        public async Task<bool> Register(RegisterDto obj)
        {
            var exist = await repo.GetUserByEmail(obj.Email);
            if (exist != null)
            {
                return false;
            }
           User user= this.ConvertDto(obj);
            // //convert dto into user and convert password into hash
            return await repo.AddUser(user);
        }


        public async Task<bool> Update(int id, RegisterDto newObj)
        {
            var existing = await repo.GetUserById(id);

            if (existing == null)
            {
                return false;
            }

            existing.Name = newObj.UserName;
            existing.Email = newObj.Email;
            existing.Password = BCrypt.Net.BCrypt.HashPassword(newObj.Password);
            existing.Address = newObj.Address;
            existing.Gender = newObj.Gender;
            existing.Birthdate = newObj.Birthdate;

            return await repo.UpdateUser(existing);
        }


        private User ConvertDto(RegisterDto obj)
        {
            var pass = BCrypt.Net.BCrypt.HashPassword(obj.Password);
            User u = new User
            {
                Name = obj.UserName,
                Email = obj.Email,
                Password = pass,
                Address = obj.Address,
                Birthdate = obj.Birthdate,
                Gender = obj.Gender,

            };
            return u;
        }

        public async Task<bool> ResetPassword(ResetDto resetDto)
        {
            var exist = await repo.GetUserByEmail(resetDto.Email);
            if (exist == null)
            {
                return false;
            }
            exist.Password = BCrypt.Net.BCrypt.HashPassword(resetDto.Password);
            return await repo.UpdateUser(exist);
        }

        public async Task<User?> GetUserByIdAsync(int id)
        {
            return await repo.Finduser(id);
        }


        public async Task<User> Getuser(int id)
        {
            return await repo.GetUserById(id);
        }
    }
    
}
