using BetterPrice.Data.Repository;
using BetterPrice.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BetterPrice.Pages
{
    public class PerfilModel : PageModel
    {
        private readonly UsuarioRepository _userRepository;

        public Usuario Usuario { get; set; }

        public PerfilModel(UsuarioRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task OnGetAsync()
        {
            var userId = HttpContext.Session.GetString("UsuarioId");

            Usuario = await _userRepository.CarregarUsuario(int.Parse(userId));
        }
    }
}
