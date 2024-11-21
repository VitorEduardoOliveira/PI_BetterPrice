using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BetterPrice.Pages.Components
{
    [ViewComponent]
    public class LoginViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(string loginView)
        {
            return View(loginView);
        }
    }
}
