using BetterPrice.Entities;
using Microsoft.EntityFrameworkCore;

namespace BetterPrice.Data.Repository;

public class CarrinhoRepository
{
    private readonly ApplicationDbContext _context;
    private readonly DbSet<Carrinho> _carrinhos;
    private readonly DbSet<ItemCarrinho> _itemsCarrinho;

    public CarrinhoRepository(ApplicationDbContext context)
    {
        _context = context;
        _carrinhos = context.Carrinhos;
        _itemsCarrinho = context.ItemCarrinhos;
    }

    public Task AdicionarNoCarrinho(int carrinhoId, int itemId, int userId)
    {
        var carrinhoItem = new ItemCarrinho()
        {
            CarrinhoId = carrinhoId,
            Item = new ItemPreco() { Id = itemId }
        };

        _context.Entry(carrinhoItem).State = EntityState.Added;

        return _context.SaveChangesAsync();
    }

    public async Task RemoverDoCarrinho(int carrinhoId, int itemId, int userId)
    {
        var item = await _itemsCarrinho.FirstAsync(i => i.CarrinhoId == carrinhoId && i.Item.Id == itemId);
        _itemsCarrinho.Remove(item);

        await _context.SaveChangesAsync();
    }

    public Task<List<ItemPreco>> CarregarCarrinho(int carrinhoId) => _itemsCarrinho
            .Include(c => c.Item)
            .ThenInclude(i => i.Mercado)
            .Include(c => c.Item.Produto)
            .Where(c => c.CarrinhoId == carrinhoId)
            .Select(c => c.Item)
            .ToListAsync();
}