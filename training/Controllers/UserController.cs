namespace Boilerplate.Controllers
{
    using Microsoft.AspNetCore.Authentication;
    using Microsoft.AspNetCore.Authentication.Cookies;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using Boilerplate.Repositories.Contrat;
    using Boilerplate.Entities;
    using Boilerplate.ViewModel;

    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        // Warning : Send data with header Content-Type: application/json
        [HttpPost]
        public async Task<ActionResult> Login([FromBody] LoginViewModel model)
        {
            bool isAuthenticated = false;
            User userIsAuthenticated = await _userRepository.GetUserByLogin(model.Email, model.Password);

            if (userIsAuthenticated != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, userIsAuthenticated.LastName),
                    new Claim(ClaimTypes.Role, userIsAuthenticated.Role),
                    new Claim(ClaimTypes.Email, userIsAuthenticated.Email),
                };

                var userIdentity = new ClaimsIdentity(claims);

                ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
                await HttpContext.SignInAsync(principal);
                isAuthenticated = true;
            }

            return Ok(isAuthenticated);
        }

        private bool LoginUser(object email, string password)
        {
            throw new NotImplementedException();
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return Ok();
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<List<User>>> GetAll()
        {
            List<User> users = await _userRepository.GetAll();

            if (users == null)
            {
                return NotFound();
            }

            return Ok(users);
        }

        [HttpPost("~/api/user/register")]
        public async Task<ActionResult<User>> Register([FromBody] RegisterViewModel user)
        {
            User userToRegister = new User
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Password = user.Password,
                Role = "Admin"
            };

            await _userRepository.Add(userToRegister);

            return Ok(userToRegister);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
