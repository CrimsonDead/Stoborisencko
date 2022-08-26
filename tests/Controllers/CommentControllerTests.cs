namespace tests.Controllers
{
    [TestClass]
    public class CommentControllerTests
    {
        [TestMethod]
        public void GetReturnsComments()
        {
            //Arrange
            var logger = new Mock<ILogger<CommentController>>();
            var repository = new Mock<IRepository<Comment>>();
            var controller = new CommentController(logger.Object, repository.Object);

            //Act
            var response = controller.GetComments();

            //Assert
            Assert.IsTrue(response.Value is List<Comment>);
        }

    }
}