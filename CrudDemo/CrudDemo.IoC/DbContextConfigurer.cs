using CrudDemo.Infraestrutura.Repositorio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudDemo.IoC
{
    public class DbContextConfigurer
    {
        public static void Configure(
            DbContextOptionsBuilder<ContextoEF> builder,
            string connectionString)
        {
            builder.UseNpgsql(connectionString);
        }
    }
}
