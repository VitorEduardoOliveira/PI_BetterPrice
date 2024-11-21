using BetterPrice.Entities;

namespace BetterPrice.ViewModels;

public class ItemCarrinhoVM
{
    public required Mercado Mercado { get; set; }
    public required IEnumerable<ItemPreco> Items { get; set; }


    public decimal TotalPorMercado()
    {
        return Items.Sum(i => i.Valor);
    }
}