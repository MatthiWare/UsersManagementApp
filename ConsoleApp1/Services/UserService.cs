using UsersManagementApp.Data;
using UsersManagementApp.Models;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Threading;

namespace UsersManagementApp.Services
{
    public interface IUserService
    {
        Task<UserModel> RegisterUserAsync(string userName, string password);
        Task<UserModel> GetUserAsync(int id);
        Task<bool> IsUsernameUnique(string userName, CancellationToken cancellationToken);
        Task<List<UserModel>> GetAllUsersAsync();
    }

    public class UserService : IUserService
    {
        private readonly UserDbContext context;

        public UserService(UserDbContext context)
        {
            this.context = context;
        }

        public async Task<UserModel> GetUserAsync(int id)
        {
            return await context.Users.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<List<UserModel>> GetAllUsersAsync()
        {
            return await context.Users.ToListAsync();
        }

        public async Task<UserModel> RegisterUserAsync(string userName, string password)
        {
            var user = new UserModel
            {
                Username = userName.ToLowerInvariant(),
                Password = password
            };

            context.Users.Add(user);

            await context.SaveChangesAsync();

            return user;
        }

        public async Task<bool> IsUsernameUnique(string userName, CancellationToken cancellationToken)
        {
            var userNameLower = userName.ToLowerInvariant();
            var userNameFound = await context.Users.AnyAsync(u => u.Username == userNameLower, cancellationToken);

            return !userNameFound;
        }
    }
}
