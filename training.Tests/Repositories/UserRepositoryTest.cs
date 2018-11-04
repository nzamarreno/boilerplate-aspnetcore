namespace training.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using training.Entities;
    using training.Repositories;
    using training.Tests.Helpers;
    using Xunit;
    public class UserRepositoryTest
    {
        private readonly TrainingContext _context;
        private readonly UserRepository _repository;

        public UserRepositoryTest()
        {
            _context = GetContext.ReturnContext();
            _repository = new UserRepository(_context);
        }

        [Fact]
        public async void UserRepository_GetUserByNameAndPassword_ReturnsUserIfExist()
        {
            // Arrange
            User user = new User { FirstName = "Nicolas", LastName = "Bonjour", Email = "hello@moto.com", Password = "hello" };
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            // Act
            var result = await _repository.GetUserByLogin(user.Email, user.Password);

            //Assert
            Assert.Equal(user.FirstName, result.FirstName);
        }

        [Fact]
        public async void UserRepository_AddNewUser_ReturnsId()
        {
            // Arrange
            User user = new User { FirstName = "Nicolas", LastName = "Bonjour", Password = "hello" };
            User SecondUser = new User { FirstName = "Nicolas", LastName = "Hello", Password = "bonjour" };
            // Act
            var userId = await _repository.Add(user);
            var userSecondId = await _repository.Add(SecondUser);

            //Assert
            Assert.IsType<long>(user.Id);
        }
    }
}
