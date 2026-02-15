using Microsoft.AspNetCore.Mvc;

namespace AuthService.Controllers
{
    public class SignUpDto
    {
        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }

    public class SignInDto
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }

    public class UserModel
    {
        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }

    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly List<UserModel> UserDatabase = new List<UserModel>();

        public AuthController()
        {
            UserDatabase.Add(new UserModel {
                UserName = "Sanyi",
                Email = "sanyi23@gmail.com",
                Password = "asd123"
            });
        }

        [HttpPost("sign-up")]
        public async Task<IActionResult> SignUp([FromBody] SignUpDto body)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(400, "Hiba! Rossz formátumú adat!");
            }

            UserDatabase.Add(new UserModel()
            {
                UserName = body.UserName,
                Email = body.Email,
                Password = body.Password,
            });

            return StatusCode(200, "Ok");
        }

        [HttpPost("sign-in")]
        public async Task<IActionResult> SignIn([FromBody] SignInDto body)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(400, "Whoops! Wrong body format!");
            }

            var foundUser = UserDatabase.SingleOrDefault(u => u.Email == body.Email);
            if (foundUser == null)
                return StatusCode(400, "Whoops! Invalid credentials!");

            if (foundUser.Password != body.Password)
                return StatusCode(400, "Whoops! Invalid credentials!");

            return StatusCode(200, foundUser);
        }
    }
}
