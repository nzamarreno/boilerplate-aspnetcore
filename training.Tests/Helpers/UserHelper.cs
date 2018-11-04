using Boilerplate.Entities;
using Boilerplate.Repositories;

namespace Boilerplate.Tests.Helpers
{
    public class UserHelper
    {
        private readonly DatabaseContext _context;
        public UserHelper()
        {
            _context = GetContext.ReturnContext();
        }

        public User CreateUser(User user = null, string role = "Admin")
        {
            var userToCreate = user;
            if (userToCreate == null)
            {
                userToCreate = new User
                {
                    FirstName = "John",
                    LastName = "Doe",
                    Email = "joh.doe@gmail.com",
                    Password = "password",
                    Role = role ?? "Admin"
                };
            }

            _context.Add(userToCreate);
            _context.SaveChanges();

            return userToCreate;
        }
    }
}
