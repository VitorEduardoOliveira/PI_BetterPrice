using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BetterPrice.Entities;

public class Carrinho
{
    public int Id { get; set; }
    public int UsuarioId { get; set; }
    public List<ItemPreco> Items { get; set; }
}