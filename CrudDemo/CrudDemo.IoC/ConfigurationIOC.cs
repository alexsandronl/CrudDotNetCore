using Autofac;
using CrudDemo.Dominio.Entidades;
using CrudDemo.Dominio.Interfaces;
using CrudDemo.RepositorioEF.Repositorio;
using CrudDemo.RepositorioEF.ServicosRepositorio;
using CrudDemo.Servico.ServicosCRUD;

namespace CrudDemo.IoC
{
    public class ConfigurationIOC
    {
        public static void Load(ContainerBuilder builder)
        {

            #region IOC Serviços
            builder.RegisterType<ServicoCRUDCliente>().As<IServicoCRUD<Cliente>>();
            #endregion

            #region IOC Repositorios
            builder.RegisterType<ServicoRepositorioCliente>().As<IServicoRepositorio<Cliente>>();
            #endregion

        }
    }
}