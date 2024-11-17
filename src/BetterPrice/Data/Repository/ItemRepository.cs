using BetterPrice.Entities;
using BetterPrice.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace BetterPrice.Data.Repository;

public class ItemRepository
{
    private readonly DbSet<ItemPreco> _itemPrecos;
    public ItemRepository(ApplicationDbContext context)
    {
        _itemPrecos = context.ItemPrecos;
    }

    public Task<List<ItemPreco>> CarregarFavoritos() => throw new NotImplementedException();
    public Task<List<ItemPreco>> CarregarItems(FiltroProduto filtro)
    {
        var query = QueryBase();

        if (!string.IsNullOrEmpty(filtro.Nome))
            query = query.Where(i => i.Produto.Nome.Contains(filtro.Nome));

        if (!string.IsNullOrEmpty(filtro.Ean))
            query = query.Where(i => i.Produto.EAN == filtro.Ean);

        if (filtro.Categorias is not null)
            query = query.Where(i => filtro.Categorias.Contains(i.Produto.CategoriaId));

        if (filtro.Departamentos is not null)
            query = query.Where(i => filtro.Departamentos.Contains(i.Produto.DepartamentoId));

        if (filtro.OrdernarMenorMaior)
            query = query.OrderBy(i => i.Valor);

        if (filtro.OrdenarMaiorMenor)
            query = query.OrderByDescending(i => i.Valor);

        if (filtro.ApenasDestaques)
            query = query.Where(i => i.Destaque);

        return query.ToListAsync();
    }

    private IQueryable<ItemPreco> QueryBase() => _itemPrecos
        .Include(i => i.Produto)
        .Include(i => i.Mercado);


}