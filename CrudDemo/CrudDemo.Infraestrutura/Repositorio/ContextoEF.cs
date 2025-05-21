using CrudDemo.Dominio.Entidades;
using CrudDemo.Infraestrutura.Mapeamentos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudDemo.Infraestrutura.Repositorio
{
    public class ContextoEF : DbContext, IDisposable
    {
        public ContextoEF(DbContextOptions<ContextoEF> options)
            : base(options) { }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseNpgsql(@"Host=localhost;Port=5432;Pooling=true;Database=CrudDemo;User Id=postgres;Password=masterkey;");
        //}

        //DBSets
        public DbSet<Cliente> Cliente { get; set; }
        //public DbSet<DominioEmpresa> DominioEmpresa { get; set; }

        [DebuggerStepThrough]
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Mappings
            modelBuilder.ApplyConfiguration(new MapCliente());
            //modelBuilder.ApplyConfiguration(new MapProduto());

            //Desativando Cascade Delete
            var cascadeFKs = modelBuilder.Model.GetEntityTypes()
                .SelectMany(t => t.GetForeignKeys())
                .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

            foreach (var fk in cascadeFKs)
                fk.DeleteBehavior = DeleteBehavior.Restrict;

            base.OnModelCreating(modelBuilder);
        }



    }
}
