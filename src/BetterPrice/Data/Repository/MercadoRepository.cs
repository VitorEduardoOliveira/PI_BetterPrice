using BetterPrice.Entities;
using Microsoft.EntityFrameworkCore;

namespace BetterPrice.Data.Repository;

public class MercadoRepository
{
    private DbSet<Mercado> _mercados;

    public MercadoRepository(ApplicationDbContext context)
    {
        _mercados = context.Mercados;
    }

    public Task<List<Mercado>> CarregarDestaques() => _mercados.Where(m => m.Destaque).ToListAsync();

    public Task<List<Mercado>> ListarMercados() => _mercados.ToListAsync();

}