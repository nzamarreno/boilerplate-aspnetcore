namespace training.Repositories.Contrat
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using training.Entities;
    using training.ViewModel;

    public interface IUserRepository
    {
        Task<User> GetUserByLogin(string email, string password);
        Task<List<User>> GetAll();
        Task<int> Add(User user);
    }
}
