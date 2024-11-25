namespace BetterPrice.Services
{
    public class AuthenticationHelper
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AuthenticationHelper(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public bool UsuarioEstaLogado()
        {
            var userId = _httpContextAccessor.HttpContext?.Session.GetString("UserId");
            return !string.IsNullOrEmpty(userId);
        }
    }
}
