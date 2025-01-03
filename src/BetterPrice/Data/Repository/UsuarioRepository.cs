﻿using BetterPrice.Entities;
using Microsoft.EntityFrameworkCore;

namespace BetterPrice.Data.Repository
{
    public class UsuarioRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly DbSet<Usuario> _usuarios;
        private readonly DbSet<Carrinho> _carrinho;

        public UsuarioRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _usuarios = dbContext.Usuarios;
            _carrinho = dbContext.Carrinhos;
        }

        public Task<bool> ExisteUsuario(string email)
        {
            return _usuarios.AnyAsync(u => u.Email == email);
        }

        public Task<Usuario?> CarregarUsuarioPorEmail(string email)
        {
            return _usuarios
                .Include(c => c.Carrinho)
                .FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task CadastrarUsuario(Usuario usuario)
        {
            await _usuarios.AddAsync(usuario);
            var carrinho = new Carrinho() { UsuarioId = usuario.Id, Usuario = usuario };
            await _carrinho.AddAsync(carrinho);
            await _dbContext.SaveChangesAsync();

            usuario.CarrinhoId = carrinho.Id;
        }

        public ValueTask<Usuario?> CarregarUsuario(int id)
        {
            return _usuarios.FindAsync(id);
        } 
    }
}
