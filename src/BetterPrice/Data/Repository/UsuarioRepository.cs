using BetterPrice.Entities;
using Microsoft.EntityFrameworkCore;

namespace BetterPrice.Data.Repository
{
    public class UsuarioRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly DbSet<Usuario> _usuarios;

        public UsuarioRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _usuarios = dbContext.Usuarios;
        }

        public Task<bool> ExisteUsuario(string email)
        {
            return _usuarios.AnyAsync(u => u.Email == email);
        }

        public Task<Usuario?> CarregarUsuarioPorEmail(string email)
        {
            return _usuarios.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task CadastrarUsuario(Usuario usuario)
        {
            await _usuarios.AddAsync(usuario);
            await _dbContext.SaveChangesAsync();
        }

        public ValueTask<Usuario?> CarregarUsuario(int id)
        {
            return _usuarios.FindAsync(id);
        }
    }
}
