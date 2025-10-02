namespace projeto_final_backend.Application.Dtos
{
    public record RegisterDto(string Usuario, string Email, string Password);
    public record LoginDto(string Email, string Password);
    public record AuthResponse(string Token);
}
