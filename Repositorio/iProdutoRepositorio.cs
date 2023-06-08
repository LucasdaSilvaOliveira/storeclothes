using storeclothes.Models;

namespace storeclothes.Repositorio
{
	public interface iProdutoRepositorio
	{
		ProdutoModel Adicionar(ProdutoModel produto);
		List<ProdutoModel> BuscarDados();
		ProdutoModel BuscarPorId(int Id);
		ProdutoModel Atualizar(ProdutoModel produto);
	}
}
