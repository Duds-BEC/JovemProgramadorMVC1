using JovemProgramadorMVC1.Data.Mapeamento;
using JovemProgramadorMVC1.Models;
using Microsoft.EntityFrameworkCore;
namespace JovemProgramadorMVC1.Data
{
    public class JovemProgramadorContexto : DbContext
    {
        public JovemProgramadorContexto(DbContextOptions<JovemProgramadorContexto> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AlunoMapping());
        }
        public DbSet<AlunoModel> Aluno { get; set; }
    }
}
