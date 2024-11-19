namespace BetterPrice.ViewModels;


public class Mensagem
{
    public string Descricao { get; set; }
    public TipoMensagem TipoMensagem { get; set; }
}
public enum TipoMensagem
{
    Sucesso,
    Erro
}