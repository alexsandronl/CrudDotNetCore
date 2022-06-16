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
    public class MapCliente : BaseClassMapping<Cliente>
    {
        public override void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.Property(t => t.NomeCompleto)
                 .IsRequired()
                 .HasMaxLength(150);

            builder.Property(t => t.DataDeNascimento)
                .IsRequired();

            builder.Property(t => t.Documento)
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(t => t.IndicadorClienteAtivo)
                .IsRequired();

            builder.Property(t => t.TipoDeDocumento)
                .IsRequired();

            builder.Property(t => t.Logradouro)
                .HasMaxLength(100)
                .IsRequired(false);

            builder.Property(t => t.Numero)
                .HasMaxLength(15)
                .IsRequired(false);

            builder.Property(t => t.Complemento)
                .HasMaxLength(50)
                .IsRequired(false);

            builder.Property(t => t.Bairro)
                .HasMaxLength(50)
                .IsRequired(false);

            builder.Property(t => t.Cidade)
                .HasMaxLength(50)
                .IsRequired(false);

            builder.Property(t => t.UF)
                .HasMaxLength(2)
                .IsRequired(false);

            builder.Property(t => t.CEP)
                .HasMaxLength(8)
                .IsRequired(false);

        }
    }
}
