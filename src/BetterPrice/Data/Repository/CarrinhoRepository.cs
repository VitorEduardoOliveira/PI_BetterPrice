﻿using BetterPrice.Entities;
using Microsoft.EntityFrameworkCore;

namespace BetterPrice.Data.Repository;

public class CarrinhoRepository
{
    private readonly DbSet<Carrinho> _carrinhos;

    public CarrinhoRepository(ApplicationDbContext context)
    {
        _carrinhos = context.Carrinhos;
    }

    public Task AdicionarNoCarrinho(int carrinhoId, int produtoId)
    {
        throw new NotImplementedException();
    }
    public Task<List<ItemPreco>> CarregarCarrinho(int usuarioId) => _carrinhos
            .Include(c => c.Items).ThenInclude(i => i.Mercado)
            .Where(c => c.UsuarioId == usuarioId)
            .SelectMany(s => s.Items)
            .ToListAsync();
}