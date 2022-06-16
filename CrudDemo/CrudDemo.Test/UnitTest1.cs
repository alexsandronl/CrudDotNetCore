using CrudDemo.Api.Controllers;
using CrudDemo.Servico.ServicosCRUD;

namespace CrudDemo.Test
{
    public class ClienteControllerUnitTest
    {
        

        [Fact]
        public void Test1()
        {

        }

        #region BuscaPorID

        [Fact]
        public async void Task_GetPostById_Return_OkResult()
        {
            //Arrange
           
            var postId = 2;

            //Act
            var data = await controller.GetPost(postId);

            //Assert
            Assert.IsType<OkObjectResult>(data);
        }

        [Fact]
        public async void Task_GetPostById_Return_NotFoundResult()
        {
            //Arrange
            var controller = new PostController(repository);
            var postId = 3;

            //Act
            var data = await controller.GetPost(postId);

            //Assert
            Assert.IsType<NotFoundResult>(data);
        }

        [Fact]
        public async void Task_GetPostById_Return_BadRequestResult()
        {
            //Arrange
            var controller = new PostController(repository);
            int? postId = null;

            //Act
            var data = await controller.GetPost(postId);

            //Assert
            Assert.IsType<BadRequestResult>(data);
        }

        [Fact]
        public async void Task_GetPostById_MatchResult()
        {
            //Arrange
            var controller = new PostController(repository);
            int? postId = 1;

            //Act
            var data = await controller.GetPost(postId);

            //Assert
            Assert.IsType<OkObjectResult>(data);

            var okResult = data.Should().BeOfType<OkObjectResult>().Subject;
            var post = okResult.Value.Should().BeAssignableTo<PostViewModel>().Subject;

            Assert.Equal("Test Title 1", post.Title);
            Assert.Equal("Test Description 1", post.Description);
        }

        #endregion
    }
}