using CleanArchMvc.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CleanArchMvc.Infra.Data.Context
{
    public class AplicationDbContext : DbContext
    {
        public AplicationDbContext(DbContextOptions<AplicationDbContext> options) : base(options) { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        // Método chamado durante a criação do modelo, onde são aplicadas configurações adicionais
        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Chama o método OnModelCreating da classe base para garantir que qualquer lógica definida nela também seja executada
            base.OnModelCreating(builder);

            // Aplica as configurações de mapeamento das entidades definidas no assembly onde a classe AplicationDbContext está localizada
            builder.ApplyConfigurationsFromAssembly(typeof(AplicationDbContext).Assembly);
        }
    }
}
