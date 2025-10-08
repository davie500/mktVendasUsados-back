using Microsoft.AspNetCore.Mvc;
using projeto_final_backend.Application.Dtos;
using projeto_final_backend.Application.Services;

namespace tech_store_api.API.Controllers
{
    [ApiController]
    [Route("auth")]
    public class AuthController(UsuarioService auth) : ControllerBase
    {
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto dto)
        {
            await auth.RegisterAsync(dto.Nome, dto.Email, dto.Senha, dto.Telefone);
            return Created("", new { dto.Email });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            var token = await auth.LoginAsync(dto.Email, dto.Senha);
            return Ok(new AuthResponse(token));
        }
    }
}