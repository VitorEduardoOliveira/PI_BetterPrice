using BetterPrice.Data.Repository;
using BetterPrice.Entities;
using BetterPrice.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BetterPrice.Pages;

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
        var carrinhoId = HttpContext.Session.GetString("CarrinhoId");

        if (carrinhoId == null)
        {
            RedirectToPage("Index");
        }

        var items = await _carrinhoRepository.CarregarCarrinho(int.Parse(carrinhoId));
        ProdutosPorMercados = items.GroupBy(m => m.Mercado, m => m, (m, items) => new ItemCarrinhoVM
        {
            Mercado = m,
            Items = items
        });
    }

    public async Task<IActionResult> OnPostAddCarrinho(int itemId)
    {
        var carrinhoId = HttpContext.Session.GetString("CarrinhoId");
        var userId = HttpContext.Session.GetString("UserId");

        try
        {
            await _carrinhoRepository.AdicionarNoCarrinho(int.Parse(carrinhoId!), itemId, int.Parse(userId));

            return Partial("Components/Mensagens/MessageView", new Mensagem
            {
                Descricao = "Item adicionado no carrinho!",
                TipoMensagem = TipoMensagem.Sucesso
            });
        }
        catch
        {
            return Partial("Components/Mensagens/MessageView", new Mensagem
            {
                Descricao = "Falha ao adicionar item no carrinho!",
                TipoMensagem = TipoMensagem.Erro
            });
        }
    }

    public async Task<IActionResult> OnPostRemoverCarrinho(int itemId)
    {
        var carrinhoId = HttpContext.Session.GetString("CarrinhoId");
        var userId = HttpContext.Session.GetString("UserId");

        try
        {
            await _carrinhoRepository.RemoverDoCarrinho(int.Parse(carrinhoId!), itemId, int.Parse(userId));

            return Partial("Components/Mensagens/MessageView", new Mensagem
            {
                Descricao = "Item removido do carrinho!",
                TipoMensagem = TipoMensagem.Sucesso
            });
        }
        catch
        {
            return Partial("Components/Mensagens/MessageView", new Mensagem
            {
                Descricao = "Falha ao remover item do carrinho!",
                TipoMensagem = TipoMensagem.Erro
            });
        }
    }
}