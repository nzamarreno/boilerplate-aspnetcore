namespace Boilerplate.Repositories.Contrat
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Boilerplate.Entities;

    public interface IUserRepository
    {
        Task<User> GetUserByLogin(string email, string password);
        Task<List<User>> GetAll();
        Task<User> Add(User user);
    }
}
