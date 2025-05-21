using CrudDemo.Infraestrutura.Repositorio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudDemo.IoC
{
    public class DbContextOptionsFactory
    {
        public static DbContextOptions<ContextoEF> Get()
        {
            var builder = new DbContextOptionsBuilder<ContextoEF>();
            DbContextConfigurer.Configure(
                builder,
                "Host=localhost;Port=5432;Pooling=true;Database=CrudDemo;User Id=postgres;Password=masterkey;");

            return builder.Options;
        }
    }
}
