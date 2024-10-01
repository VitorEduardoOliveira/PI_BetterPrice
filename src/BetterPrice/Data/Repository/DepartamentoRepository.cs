using BetterPrice.Entities;
using Microsoft.EntityFrameworkCore;

namespace BetterPrice.Data.Repository;

public class DepartamentoRepository
{
    private readonly DbSet<Departamento> _departamentos;

    public DepartamentoRepository(ApplicationDbContext context)
    {
        _departamentos = context.Departamentos;
    }

    public Task<List<Departamento>> ListarDepartamentos() => _departamentos.ToListAsync();
}