namespace projeto_final_backend.Application.Dtos
{
    public record RegisterDto(string Nome, string Email, string Senha, string Telefone);
    public record LoginDto(string Email, string Senha);
    public record AuthResponse(string Token);
}
