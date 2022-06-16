using CrudDemo.Dominio.Entidades;
using CrudDemo.Dominio.Enums;
using CrudDemo.Dominio.Interfaces;
using CrudDemo.Infraestrutura.Repositorio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudDemo.Infraestrutura.ServicosRepositorio
{
    public class ServicoRepositorioCliente : ServicoRepositorioBase<Cliente>, IServicoRepositorio<Cliente>
    {
        [DebuggerStepThrough]
        public ServicoRepositorioCliente(ContextoEF context) : base(context) { }

        #region Sobrecargas

        public override async Task<List<Cliente>> BuscaTodos()
        {
            return await contexto.Cliente
              .AsNoTracking()
              .OrderBy(p => p.NomeCompleto)
              .ToListAsync();
        }

        public override async Task<Guid> Salvar(Cliente registro)
        {
            return await base.Salvar(registro);
        }

        public override Task Excluir(Guid id)
        {
            ValidaExclusaoRegistro(id);
            return base.Excluir(id);
        }

        #endregion

        #region Validacoes

        public void ValidaDocumento(Cliente Registro)
        {
            if (Registro.Id == null) //Em caso de novo registro, verificar se ja existe o documento cadastrado
            {
                if (BuscarPorExpressao(p => p.Documento.Trim().ToUpper() == Registro.Documento.Trim().ToUpper() && p.TipoDeDocumento == Registro.TipoDeDocumento).SingleOrDefault() != null)
                    throw new ValidationException("Já existe um cliente com este documento");
            }
            else //Em caso de edição, verificar se o registro se o documento que ja existe no banco é do cliente ou se ja existe em outro cliente
            {
                if (BuscarPorExpressao(p => p.Documento.Trim().ToUpper() == Registro.Documento.Trim().ToUpper() && p.TipoDeDocumento == Registro.TipoDeDocumento && p.Id != Registro.Id).SingleOrDefault() != null)
                    throw new ValidationException("Já existe um cliente com este documento");
            }
        }

        public void ValidaExclusaoRegistro(Guid id)
        {
            //Valida se por acaso este cliente ja está associado com FK em alguma outra tabela, ou se por alguma regra de negocio, nao permita a exclusao
            //e retorne uma mensagem amigavel
        }

        #endregion Validacoes

        #region Outros

        public async Task<Cliente?> BuscaPorDocumento(string documento, TipoDeDocumentoEnum tipo)
        {
            return await contexto.Cliente.SingleOrDefaultAsync(p => p.Documento.Trim().ToUpper() == documento.Trim().ToUpper() && p.TipoDeDocumento == tipo);
        }

        #endregion
    }
}
