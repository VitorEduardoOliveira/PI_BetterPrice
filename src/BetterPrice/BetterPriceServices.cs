using BetterPrice.Data.Repository;

namespace BetterPrice;

public static class BetterPriceServices
{
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
