using BetterPrice.Entities;
using Microsoft.EntityFrameworkCore;

namespace BetterPrice.Data.Repository;

public class ItemRepository
{
    private readonly DbSet<ItemPreco> _itemPrecos;
    public ItemRepository(ApplicationDbContext context)
    {
        _itemPrecos = context.ItemPrecos;
    }

    public Task<List<ItemPreco>> CarregarDestaques() => QueryBase().Where(p => p.Destaque).ToListAsync();
    public Task<List<ItemPreco>> CarregarFavoritos() => throw new NotImplementedException();
    public Task<List<ItemPreco>> CarregarItems(string? nome = null,
                                               string? ean = null,
                                               bool ordenarMenorMaior = false,
                                               bool ordenarMaiorMenor = false,
                                               int[]? categorias = null,
                                               int[]? departamentos = null)
    {
        var query = QueryBase();

        if (!string.IsNullOrEmpty(nome))
            query = query.Where(i => i.Produto.Nome.Contains(nome));

        if (!string.IsNullOrEmpty(ean))
            query = query.Where(i => i.Produto.EAN == ean);

        if (categorias is not null)
            query = query.Where(i => categorias.Contains(i.Produto.CategoriaId));

        if (departamentos is not null)
            query = query.Where(i => departamentos.Contains(i.Produto.DepartamentoId));

        if (ordenarMenorMaior)
            query = query.OrderBy(i => i.Valor);

        if (ordenarMaiorMenor)
            query = query.OrderByDescending(i => i.Valor);

        return query.ToListAsync();
    }

    private IQueryable<ItemPreco> QueryBase() => _itemPrecos
        .Include(i => i.Produto)
        .Include(i => i.Mercado);


}