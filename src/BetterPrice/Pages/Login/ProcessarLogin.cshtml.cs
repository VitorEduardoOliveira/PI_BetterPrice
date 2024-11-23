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

        public ProcessarLoginModel(UsuarioRepository userRepository)
        {
            _userRepository = userRepository;
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
