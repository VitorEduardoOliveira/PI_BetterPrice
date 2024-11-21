using BetterPrice.Data.Repository;
using BetterPrice.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.CodeAnalysis.Scripting;
using Microsoft.EntityFrameworkCore;

namespace BetterPrice.Pages.Login
{
    public class ProcessarCadastroModel : PageModel
    {
        private readonly UsuarioRepository _userRepository;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public ProcessarCadastroModel(UsuarioRepository userRepository, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userRepository = userRepository;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<IActionResult> OnPostAsync(string name, string email, DateTime dataNascimento, string password)
        {
            // checa se o email existe
            if (await _userRepository.ExisteUsuario(email))
            {
                ModelState.AddModelError(string.Empty, "Email já cadastrado.");
                return Page();
            }

            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);

            // Create the Usuario object
            var usuario = new Usuario
            {
                Nome = name,
                DataNascimento = dataNascimento,
                Email = email,
                Senha = hashedPassword,
                TipoAutenticacao = TipoAutenticacao.App
            };

            await _userRepository.CadastrarUsuario(usuario);

            HttpContext.Session.SetString("UserId", usuario.Id.ToString());

            return RedirectToPage("/Index");

        }
    }
}
