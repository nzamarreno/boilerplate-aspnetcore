using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Boilerplate.Entities;
using Boilerplate.Repositories.Contrat;

namespace Boilerplate.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DatabaseContext _context; 
        public UserRepository(DatabaseContext DatabaseContext)
        {
            _context = DatabaseContext;
        }

        public async Task<User> GetUserByLogin(string email, string password)
        {
            var userRegister = await _context.Users.FirstOrDefaultAsync(x => email == x.Email && x.Password == password);

            return userRegister;
        }

        public async Task<User> Add(User user)
        {
            _context.Add(user);
            await _context.SaveChangesAsync();

            return user;
        }

        public async Task<List<User>> GetAll()
        {
            return await _context.Users.ToListAsync();
        }
    }
}
