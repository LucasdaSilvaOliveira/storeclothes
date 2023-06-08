using storeclothes.Contexto;
using storeclothes.Models;

namespace storeclothes.Repositorio
{
	public class UsuarioRepositorio : iUsuarioRepositorio
	{
        private readonly BancoContext _bancoContext;

        public UsuarioRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

		public UsuarioModel Adicionar(UsuarioModel usuario)
		{
			_bancoContext.usuarios.Add(usuario);
			_bancoContext.SaveChanges();
			return usuario;
		}

        public UsuarioModel BuscarPorLogin(UsuarioModel usuario)
        {
            UsuarioModel usuarioDB = _bancoContext.usuarios.FirstOrDefault(x => x.Login == usuario.Login);
            return usuarioDB;
        }
    }
}
