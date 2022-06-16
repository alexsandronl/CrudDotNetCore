using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudDemo.RepositorioEF.Repositorio
{
    public class ContextoEFFactory : IDesignTimeDbContextFactory<ContextoEF>
    {
        public ContextoEF CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ContextoEF>();
            optionsBuilder.UseNpgsql("DefaultConnection");

            return new ContextoEF(optionsBuilder.Options);
        }
    }
}
