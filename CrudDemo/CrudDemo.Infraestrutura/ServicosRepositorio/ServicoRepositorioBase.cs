using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Reflection;
using CrudDemo.Dominio.Interfaces;
using CrudDemo.Dominio.Entidades;
using CrudDemo.Infraestrutura.Repositorio;

namespace CrudDemo.Infraestrutura.ServicosRepositorio
{
    public class ServicoRepositorioBase<T> : IServicoRepositorio<T> where T : BaseClass
    {
        protected readonly ContextoEF contexto;

        public ServicoRepositorioBase(ContextoEF context)
        {
            contexto = context;
        }

        public virtual async Task<List<T>> BuscaTodos()
        {
            try
            {
                return await contexto.Set<T>()
                  .AsNoTracking()
                  .ToListAsync();
            }
            catch (Exception ex)
            {
                //Faz algum tipo de log
                throw;
            }
        }

        public virtual async Task<T?> BuscaPorId(Guid id)
        {
            try
            {
                return await contexto.Set<T>()
                   .AsNoTracking()
                   .SingleOrDefaultAsync(p => p.Id == id);
            }
            catch (Exception ex)
            {
                //Faz algum tipo de log
                throw;
            }
        }

        public virtual IQueryable<T> BuscarPorExpressao(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            try
            {
                IQueryable<T> query = contexto.Set<T>()
                    .AsNoTracking()
                    .Where(predicate);
                return query;
            }
            catch (Exception ex)
            {
                //Faz algum tipo de log
                throw;
            }
        }

        public virtual async Task<long> GetTotal(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            try
            {
                int query = await contexto.Set<T>()
                    .AsNoTracking()
                    .CountAsync(predicate);
                return query;
            }
            catch (Exception ex)
            {
                //Faz algum tipo de log
                throw;
            }
        }

        public virtual async Task<Guid> Salvar(T registro)
        {
            try
            {
                if (registro.IndicadorRegistroNovo)
                {
                    registro.DataDoCadastro = DateTime.Now;
                    contexto.Set<T>().Add(registro);
                }
                else
                {
                    var old = await contexto.Set<T>().FindAsync(registro.Id);
                    contexto.Entry(old).CurrentValues.SetValues(registro);

                }
                await contexto.SaveChangesAsync();

                return registro.Id.Value;
            }
            catch (Exception ex)
            {
                //Faz algum tipo de log
                throw;
            }
        }

        public virtual async Task Excluir(Guid id)
        {
            try
            {
                var registro = (T)Activator.CreateInstance(typeof(T));
                registro.Id = id;
                contexto.Remove(contexto.FindTracked<T>(id) ?? registro);
                await contexto.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                //Faz algum tipo de log
                throw;
            }
        }

    }
}
