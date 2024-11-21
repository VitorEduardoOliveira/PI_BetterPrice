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

        public void OnPostPesquisa()
        {
            if (string.IsNullOrEmpty(Filtro.Nome))
                return;

            RedirectToPage("Produtos");
        }

        public IActionResult OnPostLogout()
        {
            HttpContext.Session.Clear();
            return RedirectToPage("/Index");
        }

    }
}
