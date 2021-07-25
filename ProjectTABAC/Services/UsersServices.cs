using ProjectTABAC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTABAC.Services
{
public  interface UsersServices
    {
        Task<User> ConnectUser(string email, string password);
        Task<IEnumerable<User>> GetUsersList();
        Task<User> GetUserById(int id);
        Task<User> CreateUser(User User);
        Task UpdateUser(User User);
        Task DeleteUser(User User);
    }
}
