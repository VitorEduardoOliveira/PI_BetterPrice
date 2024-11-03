namespace BetterPrice.Entities;

public class Produto
{
    public required int Id { get; set; }
    public required string Nome { get; set; }
    public required string EAN { get; set; }
    public required string Image { get; set; }
    public required int DepartamentoId { get; set; }
    public required Departamento Departamento { get; set; }
    public required int CategoriaId { get; set; }
    public required Categoria Categoria { get; set; }
}