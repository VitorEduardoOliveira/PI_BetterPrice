using BetterPrice.Data.Repository;
using BetterPrice.Services;

namespace BetterPrice;

public static class BetterPriceServices
{
    public static IServiceCollection AddDomainServices(this IServiceCollection services)
    {
        return services.AddTransient<CarrinhoService>();
    }

    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        return services
            .AddTransient<CarrinhoRepository>()
            .AddTransient<CategoriaRepository>()
            .AddTransient<DepartamentoRepository>()
            .AddTransient<ItemRepository>()
            .AddTransient<MercadoRepository>();
    }
}
