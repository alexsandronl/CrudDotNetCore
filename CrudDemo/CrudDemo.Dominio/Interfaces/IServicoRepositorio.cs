using CrudDemo.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudDemo.Dominio.Interfaces
{
    public interface IServicoRepositorio<T> where T : BaseClass
    {
        public Task<List<T>> BuscaTodos();
        public Task<T?> BuscaPorId(Guid id);
        public IQueryable<T> BuscarPorExpressao(System.Linq.Expressions.Expression<Func<T, bool>> predicate);
        public Task<long> GetTotal(System.Linq.Expressions.Expression<Func<T, bool>> predicate);
        public Task<Guid> Salvar(T registro);
        public Task Excluir(Guid id);
    }
}
