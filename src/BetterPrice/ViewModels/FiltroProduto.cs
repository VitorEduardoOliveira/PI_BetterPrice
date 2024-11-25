namespace BetterPrice.ViewModels;

public class FiltroProduto
{
    public bool ApenasDestaques { get; set; }
    public string? Nome { get; set; }
    public string? Ean { get; set; }
    public bool OrdernarMenorMaior { get; set; }
    public bool OrdenarMaiorMenor { get; set; }
    public bool Ate50 { get; set; }
    public bool De50a200 { get; set; }
    public bool Acima200 { get; set; }
    public int[]? Categorias { get; set; }
    public int[]? Departamentos { get; set; }
    public bool AgruparPorProdutos { get; set; }
}