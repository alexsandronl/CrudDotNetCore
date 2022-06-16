using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CrudDemo.Dominio.Entidades
{
    public class BaseClass
    {
        public Guid? Id { get; set; }
        public DateTime DataDoCadastro { get; set; }

        [JsonIgnore]
        public bool IndicadorRegistroNovo { get => Id == null; }
    }
}
