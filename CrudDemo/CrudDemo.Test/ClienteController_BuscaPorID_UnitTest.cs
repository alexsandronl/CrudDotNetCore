using Autofac;
using Autofac.Builder;
using CrudDemo.Api.Controllers;
using CrudDemo.Dominio.Entidades;
using CrudDemo.Dominio.Interfaces;
using CrudDemo.IoC;
using CrudDemo.Servico.ServicosCRUD;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using FluentAssertions;

namespace CrudDemo.Test
{
    public class ClienteController_BuscaPorID_UnitTest
    {
        private IContainer container;

        public ClienteController_BuscaPorID_UnitTest()
        {
            var containerBuilder = new ContainerBuilder();

            containerBuilder.RegisterModule(new ModuleIOC());
            containerBuilder.RegisterModule(new ModuleIOCEntity());

            this.container = containerBuilder.Build();
        }

        #region Testes

        [Fact]
        public async void Task_Get_BuscaPorId_Return_OkResult()
        {
            //Arrange           
            var postId = Guid.Parse("042d5ae6-0bda-4f06-8425-f444763ce8ff");
            var servicocrud = container.Resolve<IServicoCRUD<Cliente>>();

            //Act
            var registro = await new ClienteController(servicocrud).Get(postId);

            //Assert
            registro.Should().BeOfType<OkObjectResult>();
        }

        [Fact]
        public async void Task_Get_BuscaPorId_Return_NotFoundResult()
        {
            //Arrange           
            var postId = Guid.Parse("000d5ae6-0bda-4f06-8425-f444763ce000");
            var servicocrud = container.Resolve<IServicoCRUD<Cliente>>();

            //Act
            var registro = await new ClienteController(servicocrud).Get(postId);

            //Assert
            registro.Should().BeOfType<NotFoundResult>();
        }

        [Fact]
        public async void Task_Get_BuscaPorId_Return_BadRequestResult()
        {
            //Arrange           
            var postId = Guid.Empty;
            var servicocrud = container.Resolve<IServicoCRUD<Cliente>>();

            //Act
            var registro = await new ClienteController(servicocrud).Get(postId);

            //Assert
            registro.Should().BeOfType<BadRequestObjectResult>();
        }

        [Fact]
        public async void Task_Get_BuscaPorId_MatchResult()
        {
            //Arrange
            var postId = Guid.Parse("042d5ae6-0bda-4f06-8425-f444763ce8ff");
            var servicocrud = container.Resolve<IServicoCRUD<Cliente>>();

            //Act
            var registro = await new ClienteController(servicocrud).Get(postId);

            //Assert
            registro.Should().BeOfType<OkObjectResult>();

            var okResult = registro.Should().BeOfType<OkObjectResult>().Subject;
            var post = okResult.Value.Should().BeAssignableTo<Cliente>().Subject;

            post.NomeCompleto.Equals("Alexsandro Nunes Lacerda");
            post.Cidade.Equals("Divinópolis");
        }

        #endregion
    }
}