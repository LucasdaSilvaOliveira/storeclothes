using storeclothes.Models;

namespace storeclothes.Repositorio
{
	public interface iUsuarioRepositorio
	{
		UsuarioModel Adicionar(UsuarioModel usuario);
		UsuarioModel BuscarPorLogin(UsuarioModel usuario);
	}
}
