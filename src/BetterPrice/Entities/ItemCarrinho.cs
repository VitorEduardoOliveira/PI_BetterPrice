namespace BetterPrice.Entities;

public class ItemCarrinho
{
    public int Id { get; set; }
    public int CarrinhoId { get; set; }
    public Carrinho Carrinho { get; set; }
    public int ItemId { get; set; }
    public ItemPreco Item { get; set; }
}