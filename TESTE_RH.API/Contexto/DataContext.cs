using Microsoft.EntityFrameworkCore;
using TESTE_RH.API.Models;

namespace TESTE_RH.API.Contexto
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Pessoa> PessoaDbSet { get; set; }
    }
}
