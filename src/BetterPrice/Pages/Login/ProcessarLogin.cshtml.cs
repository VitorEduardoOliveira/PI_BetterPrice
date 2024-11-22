using BetterPrice.Data.Repository;
using BetterPrice.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BetterPrice.Pages.Login
{
    public class ProcessarLoginModel : PageModel
    {
        private readonly UsuarioRepository _userRepository;
        private readonly SignInManager<IdentityUser> _signInManager;

        public ProcessarLoginModel(UsuarioRepository userRepository, SignInManager<IdentityUser> signInManager)
        {
            _userRepository = userRepository;
            _signInManager = signInManager;
        }

        public async Task<IActionResult> OnPostAsync(string email, string senha)
        {
            // Procura email
            var usuario = await _userRepository.CarregarUsuarioPorEmail(email);

            if (usuario == null)
            {
                ModelState.AddModelError(string.Empty, "Nenhum usuário cadastro com esse email");
                return Page();
            }

            // Verificando senha
            if (usuario.TipoAutenticacao == TipoAutenticacao.App && BCrypt.Net.BCrypt.Verify(senha, usuario.Senha))
            {
                HttpContext.Session.SetString("UserId", usuario.Id.ToString());
                return RedirectToPage("/Index");
            }

            ModelState.AddModelError(string.Empty, "Senha incorreta");
            return Page();
        }
    }
}
