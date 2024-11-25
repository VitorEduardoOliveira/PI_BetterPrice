using BetterPrice.Entities;
using Microsoft.EntityFrameworkCore;

namespace BetterPrice.Data.Repository;

public class CarrinhoRepository
{
    private readonly ApplicationDbContext _context;
    private readonly DbSet<Carrinho> _carrinhos;

    public CarrinhoRepository(ApplicationDbContext context)
    {
        _context = context;
        _carrinhos = context.Carrinhos;
    }

    public Task AdicionarNoCarrinho(int carrinhoId, int itemId, int userId)
    {
        var carrinhoItem = new Carrinho()
        {
            Id = carrinhoId,
            Items = new List<ItemPreco>()
            {
                new() { Id = itemId, }
            },
            UsuarioId = userId
        };

        _context.Entry(carrinhoItem).State = EntityState.Added;

        foreach (var item in carrinhoItem.Items)
        {
            _context.Entry(item).State = EntityState.Added;
        }

        return _context.SaveChangesAsync();
    }

    public Task RemoverDoCarrinho(int carrinhoId, int itemId, int userId)
    {
        var carrinhoItem = new Carrinho()
        {
            Id = carrinhoId,
            Items = new List<ItemPreco>()
            {
                new() { Id = itemId, }
            },
            UsuarioId = userId
        };

        _context.Entry(carrinhoItem).State = EntityState.Deleted;

        foreach (var item in carrinhoItem.Items)
        {
            _context.Entry(item).State = EntityState.Deleted;
        }

        return _context.SaveChangesAsync();
    }

    public Task<List<ItemPreco>> CarregarCarrinho(int carrinhoId) => _carrinhos
            .Include(c => c.Items).ThenInclude(i => i.Mercado)
            .Where(c => c.Id == carrinhoId)
            .SelectMany(s => s.Items)
            .ToListAsync();
}