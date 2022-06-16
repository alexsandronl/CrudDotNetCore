using CrudDemo.Dominio.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudDemo.Dominio.Entidades
{
    public class Cliente : BaseClass
    {
        //ID e Data do Cadastro estão em BaseClass da herança pois poderão ser usados em outras entidades e nao ha pq duplicar nas entidades

        public string NomeCompleto { get; set; }
        public DateTime DataDeNascimento { get; set; }
        public string Documento { get; set; } //Formatado como string para poder aceitar varios outros formatos de documentos no futuro
        public TipoDeDocumentoEnum TipoDeDocumento { get; set; }

        public bool IndicadorClienteAtivo { get; set; }

        #region Campos de Endereço

        public string? Logradouro { get; set; }
        public string? Numero { get; set; }
        public string? Complemento { get; set; }
        public string? Bairro { get; set; }
        public string? Cidade { get; set; }
        public string? UF { get; set; }
        public string? CEP { get; set; }

        #endregion



    }
}
