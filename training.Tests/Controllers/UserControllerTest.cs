namespace Boilerplate.Tests.Controllers
{
    using Boilerplate.Controllers;
    using Boilerplate.Entities;
    using Boilerplate.Repositories;
    using Boilerplate.Repositories.Contrat;
    using Boilerplate.Tests.Helpers;
    using Boilerplate.ViewModel;
    using Moq;
    using Xunit;

    public class UserControllerTest
    {
        private readonly DatabaseContext _context;
        public UserControllerTest()
        {
            _context = GetContext.ReturnContext();
        }

        [Fact]
        public async void UserController_GetAll_Login_ReturnsTrue()
        {
            // Arrange 
            User userToAdd = new UserHelper().CreateUser();
            Mock<IUserRepository> _userRepository = new Mock<IUserRepository>();
            _userRepository.Setup(x => x.Add(userToAdd)).ReturnsAsync(userToAdd);

            // Act
            LoginViewModel loginPass = new LoginViewModel { Email = userToAdd.Email, Password = userToAdd.Password };
            var result = await new UserController(_userRepository.Object).Login(loginPass);

            // Assert
            Assert.NotNull(result);
        }
    }
}
