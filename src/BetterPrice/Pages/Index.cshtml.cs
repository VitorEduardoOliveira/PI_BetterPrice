using BetterPrice.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BetterPrice.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public FiltroProduto Filtro { get; set; }

        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public IActionResult OnPostPesquisa()
        {
            if (string.IsNullOrEmpty(Filtro.Nome))
                return RedirectToPage("/Index");

            return RedirectToPage("Produtos", Filtro);
        }

        public IActionResult OnPostLogout()
        {
            HttpContext.Session.Clear();
            return RedirectToPage("/Index");
        }

    }
}
