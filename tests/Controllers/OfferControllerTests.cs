namespace tests.Controllers
{
    [TestClass]
    public class OfferControllerTests
    {
        [TestMethod]
        public void GetReturnsOffers()
        {
            //Arrange
            var logger = new Mock<ILogger<OfferController>>();
            var repository = new Mock<IRepository<Offer>>();
            var controller = new OfferController(logger.Object, repository.Object);

            //Act
            var response = controller.GetOffers();

            //Assert
            Assert.IsTrue(response.Value is List<Offer>);
        }

    }
}