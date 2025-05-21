using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudDemo.Dominio.Enums
{
    public enum TipoDeDocumentoEnum
    {
        [Description("CPF")]
        CPF = 0,
        [Description("RG")]
        RG = 1

        //Pode serem adicionados novos tipos de documentos caso seja necessário
    }
}
