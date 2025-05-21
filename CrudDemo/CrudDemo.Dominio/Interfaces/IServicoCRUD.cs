using CrudDemo.Dominio.Entidades;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudDemo.Dominio.Interfaces
{
    public interface IServicoCRUD<T> where T : BaseClass
    {
        Task<Guid> Salvar<TValidator>(T registro) where TValidator : AbstractValidator<T>;

        Task Excluir(Guid id);

        Task<List<T>> BuscaTodos();

        Task<T?> BuscaPorId(Guid id);
    }
}
