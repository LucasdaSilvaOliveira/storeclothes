using storeclothes.Models;

namespace storeclothes.Sessao
{
    public interface iSessao
    {
        void CriarSessao(UsuarioModel usuario);
        void RemoverSessao();
        UsuarioModel BuscarSessao();
    }
}
