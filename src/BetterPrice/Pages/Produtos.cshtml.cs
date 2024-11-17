using BetterPrice.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BetterPrice.Pages;

public class ProdutosModel : PageModel
{
    [BindProperty(SupportsGet = true)]
    public FiltroProduto Filtro { get; set; }
    
    public void OnGet()
    {

    }
}