using BetterPrice.Entities;

namespace BetterPrice.ViewModels;

public class ItemCarrinhoVM
{
    public Mercado Mercado { get; set; }
    public IEnumerable<ItemPreco> Items { get; set; }


    public decimal TotalPorMercado()
    {
        return Items.Sum(i => i.Valor);
    }
}