namespace Boilerplate.Controllers
{
    using Microsoft.AspNetCore.Authentication;
    using Microsoft.AspNetCore.Authentication.Cookies;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
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
        //private readonly UserManager<User> _userManager;

        public UserController(IUserRepository userRepository)
        {
            // UserManager<User> userManager ==> inject
            _userRepository = userRepository;
            //_userManager = userManager;
        }

        // Warning : Send data with header Content-Type: application/json
        [HttpPost]
        public async Task<ActionResult> Login([FromBody] LoginViewModel model)
        {
            User userIsAuthenticated = await _userRepository.GetUserByLogin(model.Email, model.Password);

            if (userIsAuthenticated == null)
            {
                return NotFound();
            }


            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name, userIsAuthenticated.LastName));
            claims.Add(new Claim(ClaimTypes.Role, userIsAuthenticated.Role));
            claims.Add(new Claim(ClaimTypes.Email, userIsAuthenticated.Email));

            var userIdentity = new ClaimsIdentity(claims);

            ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
            await HttpContext.SignInAsync(principal);

            return Ok();
        }

        [HttpPost("~/api/user/logout")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return Ok();
        }

        //private Task<User> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<List<User>>> GetAll()
        {
            //User usr = await GetCurrentUserAsync();

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
