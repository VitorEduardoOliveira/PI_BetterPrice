namespace BetterPrice.Entities;

public class ItemPreco
{
    public int Id { get; set; }
    public int ProdutoId { get; set; }
    public Produto Produto { get; set; }
    public int MercadoId { get; set; }
    public Mercado Mercado { get; set; }
    
    public decimal Valor { get; set; }
    public decimal Oferta { get; set; }
    public bool Destaque { get; set; }

    //public List<Carrinho>? CarrinhosIncluso { get; set; }
}