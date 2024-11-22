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

        public ProcessarCadastroModel(UsuarioRepository userRepository)
        {
            _userRepository = userRepository;
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
