using GlobalGamesCet49.Dados.Entidades;
using Microsoft.EntityFrameworkCore;

namespace GlobalGamesCet49.Dados
{
    public class DataContext : DbContext
    {
        public DbSet<ContactoOrcamento> ContactoOrcamentos { get; set; }

     
        public DbSet<Jogador> Jogador { get; set; }


        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        /* caminho - public DbSet<GlobalGamesCet49.Dados.Entidades.Jogador> Jogador { get; set; }*/

    }
}
