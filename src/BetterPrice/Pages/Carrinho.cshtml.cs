using BetterPrice.Data.Repository;
using BetterPrice.Entities;
using BetterPrice.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BetterPrice.Pages;

[Authorize]
public class CarrinhoModel : PageModel
{
    private readonly CarrinhoRepository _carrinhoRepository;

    public IEnumerable<ItemCarrinhoVM>? ProdutosPorMercados { get; set; }

    public CarrinhoModel(CarrinhoRepository carrinhoRepository)
    {
        _carrinhoRepository = carrinhoRepository;
    }
    public async Task OnGetAsync()
    {
        var userId = Request.Cookies["UserID"];

        if (userId == null)
        {

        }

        var items = await _carrinhoRepository.CarregarCarrinho(int.Parse(userId));
        ProdutosPorMercados = items.GroupBy(m => m.Mercado, m => m, (m, items) => new ItemCarrinhoVM
        {
            Mercado = m,
            Items = items
        });
    }
}