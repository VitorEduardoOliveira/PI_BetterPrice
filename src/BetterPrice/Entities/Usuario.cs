namespace BetterPrice.Entities;

public class Usuario
{
    public int Id { get; set; }
    public required string Nome { get; set; }
    public string CPF { get; set; }
    public required DateTime DataNascimento { get; set; }
    public required string Email { get; set; }
    public string? Senha { get; set; }
    public required TipoAutenticacao TipoAutenticacao { get; set; }
}

public enum TipoAutenticacao
{
    App,
    Google
}