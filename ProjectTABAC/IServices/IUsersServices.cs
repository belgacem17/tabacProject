using Microsoft.EntityFrameworkCore;
using ProjectTABAC.Data;
using ProjectTABAC.Models;
using ProjectTABAC.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTABAC.IServices
{
    public class IUsersServices : UsersServices
    {
        private readonly TabacDbContext connexion;

        public IUsersServices(TabacDbContext context)
        {
            connexion = context;
        }
        public async Task<User> CreateUser(User User)
        {
            connexion.Users.Add(User);
            await connexion.SaveChangesAsync();
            return User;
        }  

        public async Task DeleteUser(User User)
        { 
            connexion.Users.Remove(User); 
            await connexion.SaveChangesAsync(); 
        }

        public async Task<User> GetUserById(int id)
        {
            return await connexion.Users 
           .FirstOrDefaultAsync(u => u.UserId == id);
        }

        public async Task<IEnumerable<User>> GetUsersList()
        {
            return await connexion.Users.ToListAsync();
        }

        public async Task UpdateUser(User User)
        {
            connexion.Users.Update(User);
            await connexion.SaveChangesAsync();
        }

        public Task<User> ConnectUser(string email, string password)
        {
            return connexion.Users.Where(u => u.Email == email && u.Password == password).FirstOrDefaultAsync();
        }
    }
}
