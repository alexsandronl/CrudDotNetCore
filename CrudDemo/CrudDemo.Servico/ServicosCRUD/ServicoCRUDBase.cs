using CrudDemo.Dominio.Entidades;
using CrudDemo.Dominio.Interfaces;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudDemo.Servico.ServicosCRUD
{
    public class ServicoCRUDBase<T> : IServicoCRUD<T> where T : BaseClass
    {
        protected readonly IServicoRepositorio<T> _baseRepository;

        public ServicoCRUDBase(IServicoRepositorio<T> baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public virtual async Task<Guid> Salvar<TValidator>(T registro) where TValidator : AbstractValidator<T>
        {
            Validate(registro, Activator.CreateInstance<TValidator>());
            await _baseRepository.Salvar(registro);
            return registro.Id.Value;
        }

        public virtual async Task Excluir(Guid id) => await _baseRepository.Excluir(id);

        public virtual async Task<List<T>> BuscaTodos() => await _baseRepository.BuscaTodos();

        public virtual async Task<T?> BuscaPorId(Guid id) => await _baseRepository.BuscaPorId(id);

        protected virtual void Validate(T registro, AbstractValidator<T> validator)
        {
            if (registro == null)
                throw new Exception("É necessário passar um registro como parametros!");

            validator.ValidateAndThrow(registro);
        }
    }
}
