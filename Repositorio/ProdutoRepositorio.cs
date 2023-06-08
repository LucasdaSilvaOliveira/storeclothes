using storeclothes.Contexto;
using storeclothes.Models;

namespace storeclothes.Repositorio
{
	public class ProdutoRepositorio : iProdutoRepositorio
	{
        private readonly BancoContext _bancoContext;

        public ProdutoRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

		public ProdutoModel Adicionar(ProdutoModel produto)
		{
			_bancoContext.produtos.Add(produto);
			_bancoContext.SaveChanges();
			return produto;
		}

		public List<ProdutoModel> BuscarDados()
		{
			List<ProdutoModel> produtos = _bancoContext.produtos.ToList();
			return produtos;
		}

		public ProdutoModel BuscarPorId(int Id)
		{
			ProdutoModel produto = _bancoContext.produtos.FirstOrDefault(x => x.Id == Id);
			return produto;
		}
		public ProdutoModel Atualizar(ProdutoModel produto)
		{
			_bancoContext.produtos.Update(produto);
			_bancoContext.SaveChanges();
			return produto;
		}
	}
}
