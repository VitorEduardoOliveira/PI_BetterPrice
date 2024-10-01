using BetterPrice.Entities;
using Microsoft.EntityFrameworkCore;

namespace BetterPrice.Data.Repository;

public class CategoriaRepository
{
    private readonly DbSet<Categoria> _categorias;

    public CategoriaRepository(ApplicationDbContext context)
    {
        _categorias = context.Categorias;
    }

    public Task<List<Categoria>> ListarCategorias() => _categorias.ToListAsync();
}