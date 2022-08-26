namespace tests.Controllers
{
    [TestClass]
    public class ServiceControllerTests
    {
        [TestMethod]
        public void GetReturnsServices()
        {
            //Arrange
            var logger = new Mock<ILogger<ServiceController>>();
            var repository = new Mock<IRepository<Service>>();
            var controller = new ServiceController(logger.Object, repository.Object);

            //Act
            var response = controller.GetServices();

            //Assert
            Assert.IsTrue(response.Value is List<Service>);
        }
    }
}