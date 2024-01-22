using AthleteSportTournaments.DTOs;
using AthleteSportTournamentsApp.Controllers;
using AthleteSportTournamentsApp.Models.Service;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace SportTest
{
    [TestFixture]
    public class SportControllerTests
    {
        private SportController _sportController;
        private Mock<ISportService> _mockSportService;

        [SetUp]
        public void Setup()
        {
            // Mock the ISportService
            _mockSportService = new Mock<ISportService>();

            // Create the SportController with the mocked service
            _sportController = new SportController(_mockSportService.Object);
        }

        [Test]
        public void GetAllSports_ShouldReturnOkResult()
        {
            // Arrange
            _mockSportService.Setup(service => service.GetAllSports())
                             .Returns(new List<SportDTO>());

            // Act
            var result = _sportController.GetAllSports() as OkObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.StatusCode);

            // Verify that the service method was called
            _mockSportService.Verify(service => service.GetAllSports(), Times.Once);
        }

        [Test]
        public void GetSportById_ExistingId_ShouldReturnOkResult()
        {
            // Arrange
            int existingSportId = 1;
            _mockSportService.Setup(service => service.GetSportById(existingSportId))
                             .Returns(new SportDTO());

            // Act
            var result = _sportController.GetSportById(existingSportId) as OkObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.StatusCode);

            // Verify that the service method was called
            _mockSportService.Verify(service => service.GetSportById(existingSportId), Times.Once);
        }
    }
}