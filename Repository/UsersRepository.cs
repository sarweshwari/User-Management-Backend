using BackendDotNet.Models;
using Microsoft.EntityFrameworkCore;

namespace BackendDotNet.Repository
{
    public class UsersRepository : IUsersRepository
    {
        private readonly TechrelContext db;

        public UsersRepository(TechrelContext db)
        {
            this.db = db;
        }

        public async Task<bool> AddUser(User user)
        {
            await db.Users.AddAsync(user);
            return await  Save();
        }

        public async Task<bool> DeleteUser(User user)
        {
            db.Users.Remove(user);
           return await Save();
        }

        public async Task<User?> Finduser(int id) => await db.Users.FindAsync(id);

        public async Task<IList<User>> GetAllUsers()
        {
           return  await db.Users.ToListAsync();
        }

        public async Task<User> GetUserByEmail(string email)
       => await db.Users.FirstOrDefaultAsync(x => x.Email == email);

        public async Task<User> GetUserById(int id)
       => await db.Users.FindAsync(id); 

        public async Task<bool> Save()
       => await db.SaveChangesAsync() > 0;

        public async Task<bool> UpdateUser(User user)
        {
            db.Users.Update(user);
            return await Save();
        }
    }
}
