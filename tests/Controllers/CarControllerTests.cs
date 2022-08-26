namespace tests.Controllers
{
    [TestClass]
    public class CarControllerTests
    {
        [TestMethod]
        public void GetReturnsCars()
        {
            //Arrange
            var logger = new Mock<ILogger<CarController>>();
            var repository = new Mock<IRepository<Car>>();
            var controller = new CarController(logger.Object, repository.Object);

            //Act
            var response = controller.GetCars();

            //Assert
            Assert.IsTrue(response.Value is List<Car>);
        }

        
    }
}