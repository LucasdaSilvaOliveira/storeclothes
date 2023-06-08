using System.ComponentModel.DataAnnotations;

namespace storeclothes.Models
{
	public class UsuarioModel
	{
		public int Id { get; set; }
		[Required(ErrorMessage = "Digite seu nome pessoal")]
		public string NomePessoal { get; set; }
		[Required(ErrorMessage = "Digite o nome da sua empresa")]
		public string NomeEmpresa { get; set; }
		[Required(ErrorMessage = "Digite o login")]
		public string Login { get; set; }
		[Required(ErrorMessage = "Digite a senha")]
		public string Senha { get; set; }
	}
}
