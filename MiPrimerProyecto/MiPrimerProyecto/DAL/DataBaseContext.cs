using Microsoft.EntityFrameworkCore;
using MiPrimerProyecto.DAL.Entities;

namespace MiPrimerProyecto.DAL
{
    public class DataBaseContext : DbContext
    {
        // Asi nos conectamos a la BD por medio de este constructor
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {
            
        }

        //metodo Propio de entity framework core para configurar los indices de cada campo de una tabla en una DB
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Country>().HasIndex(c =>  c.Name).IsUnique();//Aqui se crea un indice del campo Name para la tabla countries
            modelBuilder.Entity<State>().HasIndex("Name", "CountryId").IsUnique();//Con esta instruccion hacemos un indice compuesto
        }

        #region DbSets

        public DbSet<Country> countries { get; set; }

        public DbSet<State> States { get; set; }

        #endregion
    }
}
