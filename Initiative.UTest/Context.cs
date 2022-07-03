using Microsoft.EntityFrameworkCore;

namespace Initiative.UTest
{
    public class Context : DbContext 
    {
        public DbSet<Moeda>? Moeda { get; set; }
        public DbSet<Valor>? Valores { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseJet(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\bypass\Testes\Initiative\Teste.accdb;");
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Valor>().HasNoKey();
        }

    }
    public class Moeda
    {
        public int Id { get; set; }
        public string? Descritivo { get; set; }
        public double Valor { get; set; }
        public string Formato { get; set; }
    }
    public class Valor
    {
        public double ? Valores { get; set; }
        public string ? Decomposto { get; set; }
    }
}
