  using BetterPrice.Data.Repository;
using BetterPrice.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BetterPrice.Pages.Components;

public class ProdutoListViewComponent : ViewComponent
{
    private readonly ItemRepository _itemRepository;
    private readonly CarrinhoRepository _carrinhoRepository;

    public ProdutoListViewComponent(ItemRepository itemRepository, CarrinhoRepository carrinhoRepository)
    {
        _itemRepository = itemRepository;
        _carrinhoRepository = carrinhoRepository;
    }

    public async Task<IViewComponentResult> InvokeAsync(TipoListaProduto tipoListaProduto, FiltroProduto filtroProduto)
    {
        var listItens = await _itemRepository.CarregarItems(filtroProduto);

        return View(new ProdutoListVM
        {
            TipoLista = tipoListaProduto,
            Itens = listItens
        });
    }

    public
}

public enum TipoListaProduto
{
    Cards,
    Lista
}