namespace BetterPrice.ViewModels;

public class FiltroProduto
{
    public bool ApenasDestaques { get; set; }
    public string? Nome { get; set; }
    public string? Ean { get; set; }
    public bool OrdernarMenorMaior { get; set; }
    public bool OrdenarMaiorMenor { get; set; }
    public int[]? Categorias { get; set; }
    public int[]? Departamentos { get; set; }
    public bool AgruparPorProdutos { get; set; }
}