using BetterPrice.Entities;
using BetterPrice.Pages.Components;

namespace BetterPrice.ViewModels;

public class ProdutoListVM
{
    public List<ItemPreco> Itens { get; set; }
    public TipoListaProduto TipoLista { get; set; }
}