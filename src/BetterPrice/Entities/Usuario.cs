namespace BetterPrice.Entities;

public class Usuario
{
    public int Id { get; set; }
    public required string Nome { get; set; }
    public string CPF { get; set; }
    public DateTime DataNascimento { get; set; }
    public required string Email { get; set; }
    public string? Senha { get; set; }
    public required TipoAutenticacao TipoAutenticacao { get; set; }

    public int CarrinhoId { get; set; }
    public Carrinho Carrinho { get; set; }
}

public enum TipoAutenticacao
{
    App,
    Google
}