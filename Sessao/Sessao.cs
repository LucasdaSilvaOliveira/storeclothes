using Newtonsoft.Json;
using storeclothes.Models;

namespace storeclothes.Sessao
{
    public class Sessao : iSessao
    {
        private readonly IHttpContextAccessor _httpContext;
        public Sessao(IHttpContextAccessor httpContext)
        {
            _httpContext = httpContext;
        }
        public UsuarioModel BuscarSessao()
        {
            string usuarioString = _httpContext.HttpContext.Session.GetString("sessaoUsuarioLogado");

            if (string.IsNullOrEmpty(usuarioString)) return null;

            return JsonConvert.DeserializeObject<UsuarioModel>(usuarioString);
        }

        public void CriarSessao(UsuarioModel usuario)
        {
            string valor = JsonConvert.SerializeObject(usuario);
            _httpContext.HttpContext.Session.SetString("sessaoUsuarioLogado", valor);
        }

        public void RemoverSessao()
        {
            _httpContext.HttpContext.Session.Remove("sessaoUsuarioLogado");
        }
    }
}
