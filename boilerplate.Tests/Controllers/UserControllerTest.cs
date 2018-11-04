namespace Boilerplate.Tests.Controllers
{
    using Boilerplate.Controllers;
    using Boilerplate.Entities;
    using Boilerplate.Repositories;
    using Boilerplate.Repositories.Contrat;
    using Boilerplate.Tests.Helpers;
    using Boilerplate.ViewModel;
    using Microsoft.AspNetCore.Mvc;
    using Moq;
    using System.Threading.Tasks;
    using Xunit;

    public class UserControllerTest
    {
        private readonly DatabaseContext _context;
        public UserControllerTest()
        {
            _context = GetContext.ReturnContext();
        }

        //[Fact]
        //public async Task UserController_Login_ReturnsNotFound()
        //{
        //    // Arrange 
        //    User userToAdd = new UserHelper().CreateUser();
        //    Mock<IUserRepository> _userRepository = new Mock<IUserRepository>();

        //    // Act
        //    LoginViewModel loginPass = new LoginViewModel { Email = userToAdd.Email, Password = userToAdd.Password };
        //    var _controller = new UserController(_userRepository.Object);
        //    var result = await _controller.Login(loginPass);

        //    // Assert
        //    Assert.IsType<NotFoundResult>(result);
        //}

        //[Fact]
        //public async void UserController_Login_ReturnsOk()
        //{
        //    // Arrange 
        //    User userToAdd = new UserHelper().CreateUser();
        //    Mock<IUserRepository> _userRepository = new Mock<IUserRepository>();
        //    _userRepository.Setup(x => x.GetUserByLogin(userToAdd.Email, userToAdd.Password)).ReturnsAsync(userToAdd);

        //    // Act
        //    LoginViewModel loginPass = new LoginViewModel { Email = userToAdd.Email, Password = userToAdd.Password };
        //    var _controller = new UserController(_userRepository.Object);
        //    var result = await _controller.Login(loginPass);

        //    // Assert
        //    //Assert.IsType<OkObjectResult>(result.ExecuteResult);
        //}
    }
}
