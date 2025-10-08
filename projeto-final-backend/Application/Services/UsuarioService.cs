using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using projeto_final_backend.Domain.Entities;
using projeto_final_backend.Domain.Interfaces;

namespace projeto_final_backend.Application.Services
{
    public class UsuarioService
    {
        private readonly IUsuarioRepository _repo;
        private readonly IConfiguration _cfg;

        public UsuarioService(IUsuarioRepository repo, IConfiguration cfg)
        {
            _repo = repo;
            _cfg = cfg;
        }

        public IEnumerable<Usuario> ObterUsuarios()
        {
            return _repo.ListarTodos();
        }

        public Usuario? ObterUsuarioPorId(int id)
        {
            return _repo.ObterPorId(id);
        }

        public Usuario CriarUsuario(Usuario usuario)
        {
            _repo.Add(usuario);
            return usuario;
        }

        public Usuario AtualizarUsuario(Usuario usuario)
        {
            _repo.Atualizar(usuario);
            _repo.Salvar();
            return usuario;
        }

        public void RemoverUsuario(int id)
        {
            _repo.Remover(id);
            _repo.Salvar();
        }

        public async Task RegisterAsync(string usuario, string email, string senha,  string telefone)
        {
            email = email.Trim().ToLowerInvariant();

            var usuarioExistente = _repo.ObterPorEmail(email);
            if (usuarioExistente != null)
                throw new InvalidOperationException("Email já registrado.");

            var senhaHash = BCrypt.Net.BCrypt.HashPassword(senha);

            var novoUsuario = new Usuario
            {
                Nome = usuario,
                Email = email,
                Senha_Hash = senhaHash,
                Telefone = telefone
            };

            _repo.Add(novoUsuario);
            _repo.Salvar();
        }

        public async Task<string> LoginAsync(string email, string senha)
        {
            email = email.Trim().ToLowerInvariant();

            var usuario = _repo.ObterPorEmail(email);
            if (usuario == null || !BCrypt.Net.BCrypt.Verify(senha, usuario.Senha_Hash))
                throw new UnauthorizedAccessException("Credenciais inválidas.");

            return GerarToken(usuario.Email);
        }

        private string GerarToken(string email)
        {
            var jwt = _cfg.GetSection("Jwt");
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt["Key"]!));

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: jwt["Issuer"],
                audience: jwt["Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(int.TryParse(jwt["ExpirationMinutes"], out var m) ? m : 60),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
