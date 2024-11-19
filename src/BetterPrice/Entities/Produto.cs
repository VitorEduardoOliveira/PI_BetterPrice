namespace BetterPrice.Entities;

public class Produto
{
    public required int Id { get; set; }
    public required string Nome { get; set; }
    public required string Descricao { get; set; }
    public required string EAN { get; set; }
    public required string UrlImagem { get; set; }
    public required int DepartamentoId { get; set; }
    public Departamento Departamento { get; set; }
    public required int CategoriaId { get; set; }
    public Categoria Categoria { get; set; }
}