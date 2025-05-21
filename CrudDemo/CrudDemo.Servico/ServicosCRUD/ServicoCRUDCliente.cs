using CrudDemo.Dominio.Entidades;
using CrudDemo.Dominio.Interfaces;
using CrudDemo.Infraestrutura.ServicosRepositorio;
using CrudDemo.Servico.Validations;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudDemo.Servico.ServicosCRUD
{
    public class ServicoCRUDCliente : ServicoCRUDBase<Cliente>, IServicoCRUD<Cliente>
    {
        public ServicoCRUDCliente(IServicoRepositorio<Cliente> repositorio) : base(repositorio) { }

        public override async Task<Guid> Salvar<TValidator>(Cliente registro)
        {
            Validate(registro, new ClienteValidation());
            ((ServicoRepositorioCliente)_baseRepository).ValidaDocumento(registro);
            await _baseRepository.Salvar(registro);
            return registro.Id.Value;
        }

        protected override void Validate(Cliente registro, AbstractValidator<Cliente> validator)
        {
            if (registro == null)
                throw new Exception("É necessário passar um registro como parametros!");

            validator.ValidateAndThrow(registro);
        }
    }
}
