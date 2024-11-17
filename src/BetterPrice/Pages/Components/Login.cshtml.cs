using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BetterPrice.Pages
{
    [ViewComponent]
    public class Login : ViewComponent
    {
        public IViewComponentResult Invoke(string loginView)
        {
            return View(loginView);
        }
    }
}
