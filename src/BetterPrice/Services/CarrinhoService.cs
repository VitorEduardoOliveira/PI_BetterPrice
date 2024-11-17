using BetterPrice.Data.Repository;

namespace BetterPrice.Services;

public class CarrinhoService
{
    private readonly CarrinhoRepository _carrinhoRepository;

    public CarrinhoService(CarrinhoRepository carrinhoRepository)
    {
        _carrinhoRepository = carrinhoRepository;
    }

    public Task AdicionarItem(int carrinhoId, int itemId)
    {
        return _carrinhoRepository.AdicionarNoCarrinho(carrinhoId, itemId);
    }
}