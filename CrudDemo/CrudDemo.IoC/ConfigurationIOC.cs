﻿using Autofac;
using CrudDemo.Dominio.Entidades;
using CrudDemo.Dominio.Interfaces;
using CrudDemo.Infraestrutura.Repositorio;
using CrudDemo.Infraestrutura.ServicosRepositorio;
using CrudDemo.Servico.ServicosCRUD;

namespace CrudDemo.IoC
{
    public class ConfigurationIOC
    {
        public static void Load(ContainerBuilder builder)
        {
            //Para caso queira fazer a injeção de dependencia pelo AutoFac em vez de usar a injeção nativa do Asp Net Core
            //builder
            //    .RegisterType<ContextoEF>()
            //    .WithParameter("options", DbContextOptionsFactory.Get())
            //    .InstancePerLifetimeScope();

            #region IOC Serviços
            builder.RegisterType<ServicoCRUDCliente>().As<IServicoCRUD<Cliente>>().InstancePerLifetimeScope();
            #endregion

            #region IOC Repositorios
            builder.RegisterType<ServicoRepositorioCliente>().As<IServicoRepositorio<Cliente>>().InstancePerLifetimeScope();
            #endregion

        }
    }
}