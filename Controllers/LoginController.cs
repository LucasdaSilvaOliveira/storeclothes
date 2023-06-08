using Microsoft.AspNetCore.Mvc;
using storeclothes.Filters;
using storeclothes.Models;
using storeclothes.Repositorio;
using storeclothes.Sessao;

namespace storeclothes.Controllers
{
	public class LoginController : Controller
	{
		private readonly iUsuarioRepositorio _usuarioRepositorio;
		private readonly iSessao _sessao;
        public LoginController(iUsuarioRepositorio usuarioRepositorio, iSessao sessao)
        {
			_usuarioRepositorio = usuarioRepositorio;
			_sessao = sessao;
		}
        public IActionResult Index()
		{
			if (_sessao.BuscarSessao() != null)
			{
				return RedirectToAction("Index", "Home");
			}
			return View();
		}

		public IActionResult Logar(UsuarioModel usuario)
		{
			UsuarioModel usuarioDB = _usuarioRepositorio.BuscarPorLogin(usuario);

			try
			{
				if (usuarioDB != null)
				{
					if (usuario.Senha == usuarioDB.Senha)
					{
						_sessao.CriarSessao(usuarioDB);
						return RedirectToAction("Index", "Home");
					}
					else
					{
						TempData["mensagemErro"] = "Senha inválida.";
						return RedirectToAction("Index");
					}

				}
				else
				{
					TempData["mensagemErro"] = "Usuário e/ou senha inválido(s).";
					return RedirectToAction("Index");
				}
			}
			catch (Exception)
			{
				throw;
			}
		}
	}
}
