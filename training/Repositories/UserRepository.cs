using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using training.Entities;
using training.Repositories.Contrat;

namespace training.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly TrainingContext _context; 
        public UserRepository(TrainingContext trainingContext)
        {
            _context = trainingContext;
        }

        public async Task<User> GetUserByLogin(string email, string password)
        {
            var userRegister = await _context.Users.FirstOrDefaultAsync(x => email == x.Email && x.Password == password);

            return userRegister;
        }

        public async Task<int> Add(User user)
        {
            _context.Add(user);
            return await _context.SaveChangesAsync();
        }

        public async Task<List<User>> GetAll()
        {
            return await _context.Users.ToListAsync();
        }
    }
}
