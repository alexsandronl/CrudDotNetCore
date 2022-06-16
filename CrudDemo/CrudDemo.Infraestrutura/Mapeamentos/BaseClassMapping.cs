using CrudDemo.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudDemo.Infraestrutura.Mapeamentos
{
    public abstract class BaseClassMapping<T> : IEntityTypeConfiguration<T> where T : BaseClass
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(t => t.DataDoCadastro)
                .IsRequired();

            //Ignore
            builder.Ignore(t => t.IndicadorRegistroNovo);

        }
    }
}
