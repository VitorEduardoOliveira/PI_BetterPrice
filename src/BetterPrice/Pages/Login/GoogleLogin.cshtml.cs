using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;
using BetterPrice.Data.Repository;
using BetterPrice.Entities;

namespace BetterPrice.Pages.Login
{
    public class GoogleLoginModel : PageModel
    {
        private readonly UsuarioRepository _userRepository;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public GoogleLoginModel(UsuarioRepository userRepository, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userRepository = userRepository;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            if (User.Identity.IsAuthenticated)
            {
                var email = User.FindFirst(ClaimTypes.Email)?.Value;
                var name = User.FindFirst(ClaimTypes.Name)?.Value;

                if (string.IsNullOrEmpty(email))
                {
                    return RedirectToPage("/Error");
                }

                var usuario = await _userRepository.CarregarUsuarioPorEmail(email);

                if (usuario is null)
                {
                    usuario = new Usuario
                    {
                        Nome = name ?? "Usuário não identificado",
                        Email = email,
                        TipoAutenticacao = TipoAutenticacao.Google
                    };

                    await _userRepository.CadastrarUsuario(usuario);
                }

                HttpContext.Session.SetString("UserId", usuario.Id.ToString());

                return RedirectToPage("/Index");
            }

            
            return RedirectToPage("/Index");
        }

    }
}
