using BlazeChat.Server.Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlazeChat.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly ChatContext chatContext;
        private readonly TokenService tokenService;

        public AccountController(ChatContext chatContext, TokenService tokenService)
        {
            this.chatContext = chatContext;
            this.tokenService = tokenService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser(RegisterDTO dto, CancellationToken cancellationToken)
        {
            var usernameExists = await chatContext.Users.AsNoTracking().AnyAsync(
                u => u.Username == dto.Username, cancellationToken);
            if (usernameExists)
            {
                return BadRequest($"{nameof(dto.Username)} уже существует");
            }
            var user = new User
            {
                Username = dto.Username,
                AddedOn = DateTime.Now,
                Name = dto.Name,
                Password = dto.Password,
            };
            await chatContext.Users.AddAsync(user, cancellationToken);
            await chatContext.SaveChangesAsync(cancellationToken);



            return Ok(GenerateToken(user));
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDTO dto, CancellationToken cancellationToken)
        {
            var user = await chatContext.Users.FirstOrDefaultAsync(
                u => u.Username == dto.Username && u.Password == dto.Password,
                cancellationToken);
            if (user is null)
            {
                return BadRequest("Неправильные данные!");
            }
            return Ok(GenerateToken(user));
        }

        private AuthResponseDTO GenerateToken(User user)
        {
            var token = tokenService.GenerateJWT(user);
            return new AuthResponseDTO(user.Name, token);
        }
    }
}
