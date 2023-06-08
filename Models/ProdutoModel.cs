using System.ComponentModel.DataAnnotations;

namespace storeclothes.Models
{
	public class ProdutoModel
	{
		public int Id { get; set; }
		[Required(ErrorMessage = "Digite o nome")]
		public string Nome { get; set; }
		[Required(ErrorMessage = "Digite o tamanho do produto")]
		public string Tamanho { get; set; }
		[Required(ErrorMessage = "Digite o preço")]
		public decimal Preco { get; set; }
	}
}
