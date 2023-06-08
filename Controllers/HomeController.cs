using Microsoft.AspNetCore.Mvc;
using storeclothes.Filters;
using storeclothes.Models;
using storeclothes.Repositorio;
using storeclothes.Sessao;
using System.Diagnostics;

namespace storeclothes.Controllers
{

	[PaginaUsuarioLogado]
	public class HomeController : Controller
	{

		private readonly iProdutoRepositorio _produtoRepositorio;
		private readonly iSessao _sessao;
		public HomeController(iProdutoRepositorio produtoRepositorio, iSessao sessao)
		{
			_produtoRepositorio = produtoRepositorio;
			_sessao = sessao;
		}
		public IActionResult Index()
		{
			List<ProdutoModel> produtos = _produtoRepositorio.BuscarDados();
			if (_sessao.BuscarSessao() == null)
			{
				return RedirectToAction("Index", "Login");
			}
			else
			{
				return View(produtos);
			}
		}

		public IActionResult FormCadastroProduto()
		{
			return View();
		}
		public IActionResult FormAtualizarProduto(int Id)
		{
			ProdutoModel produto = _produtoRepositorio.BuscarPorId(Id);
			return View(produto);
		}
		public IActionResult CadastrarProduto(ProdutoModel produto)
		{
			if (ModelState.IsValid)
			{
				_produtoRepositorio.Adicionar(produto);
				return RedirectToAction("Index");
			}
			else
			{
				return View("FormCadastroProduto", produto);
			}
		}
		public IActionResult AtualizarProduto(ProdutoModel produto)
		{
			if (ModelState.IsValid)
			{
				if (produto == null) throw new Exception();

				TempData["Sucesso"] = "Produto atualizado com sucesso";
				_produtoRepositorio.Atualizar(produto);
				List<ProdutoModel> produtosList = _produtoRepositorio.BuscarDados();
				return View("Index", produtosList);
			}
			else
			{
				return View("FormAtualizarProduto", produto);
			}

		}

		public IActionResult SairSessao()
		{
			_sessao.RemoverSessao();

			return RedirectToAction("Index", "Login");
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}