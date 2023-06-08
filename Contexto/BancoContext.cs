using Microsoft.EntityFrameworkCore;
using storeclothes.Models;

namespace storeclothes.Contexto
{
	public class BancoContext : DbContext
	{
        public BancoContext(DbContextOptions<BancoContext> options) : base(options)
        {
        }

        public DbSet<UsuarioModel> usuarios { get; set; }

        public DbSet<ProdutoModel> produtos { get;set; }
    }
}
