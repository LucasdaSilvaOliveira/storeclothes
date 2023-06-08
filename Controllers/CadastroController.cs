using Microsoft.AspNetCore.Mvc;
using storeclothes.Models;
using storeclothes.Repositorio;

namespace storeclothes.Controllers
{
	public class CadastroController : Controller
	{

		private readonly iUsuarioRepositorio _usuarioRepositorio;
        public CadastroController(iUsuarioRepositorio usuarioRepositorio)
        {
			_usuarioRepositorio = usuarioRepositorio;
        }
        public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Cadastrar(UsuarioModel usuario)
		{
			if (ModelState.IsValid)
			{
				_usuarioRepositorio.Adicionar(usuario);
				return RedirectToAction("Index", "Login");
			}
			else
			{
				return View("Index", usuario);
			}

		}
	}
}
