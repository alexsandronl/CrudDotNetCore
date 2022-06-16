using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudDemo.IoC
{
    public class ModuleIOCEntity : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            ConfigurationIOCEntity.Load(builder);
        }
    }
}
