using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using storeclothes.Models;

namespace storeclothes.ViewComponents
{
	public class Header : ViewComponent
	{
		public async Task<IViewComponentResult> InvokeAsync()
		{
			string sessaoUsuario = HttpContext.Session.GetString("sessaoUsuarioLogado");

			if (string.IsNullOrEmpty(sessaoUsuario)) return null;

			UsuarioModel usuarioLogado = JsonConvert.DeserializeObject<UsuarioModel>(sessaoUsuario);

			return View(usuarioLogado);
		}
	}
}
