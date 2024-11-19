using BetterPrice.Data.Repository;
using BetterPrice.Entities;
using BetterPrice.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BetterPrice.Pages.Components;

[ViewComponent(Name = "AddItemCarrinho")]
public class AddItemCarrinho : ViewComponent
{
    private readonly CarrinhoRepository _carrinhoRepository;

    public AddItemCarrinho(CarrinhoRepository carrinhoRepository)
    {
        _carrinhoRepository = carrinhoRepository;
    }
    public async Task<IViewComponentResult> InvokeAsync(int itemId)
    {
        var carrinhoId = Request.Cookies["CarrinhoID"];

        try
        {
            await _carrinhoRepository.AdicionarNoCarrinho(int.Parse(carrinhoId!), itemId);

            return View("./Mensagens/MessageView.cshtml", new Mensagem
            {
                Descricao = "Item adicionado no carrinho!",
                TipoMensagem = TipoMensagem.Sucesso
            });
        }
        catch
        {
            return View("./Mensagens/MessageView.cshtml", new Mensagem
            {
                Descricao = "Falha ao adicionar item no carrinho!",
                TipoMensagem = TipoMensagem.Erro
            });
        }
    }
}