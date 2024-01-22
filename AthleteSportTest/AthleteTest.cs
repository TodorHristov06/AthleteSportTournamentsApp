using AthleteSportTournamentsApp.Controllers;
using AthleteSportTournamentsApp.DTOs;
using AthleteSportTournamentsApp.Models.Service;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace AthleteSportTest
{
    [TestFixture]
    public class AthleteControllerTests
    {
        private AthleteController _athleteController;
        private Mock<IAthleteService> _mockAthleteService;

        [SetUp]
        public void Setup()
        {
            // Mock the IAthleteService
            _mockAthleteService = new Mock<IAthleteService>();

            // Create the AthleteController with the mocked service
            _athleteController = new AthleteController(_mockAthleteService.Object);
        }

        [Test]
        public void GetAllAthletes_ShouldReturnOkResult()
        {
            // Arrange
            _mockAthleteService.Setup(service => service.GetAllAthletes())
                               .Returns(new List<AthleteDTO>());

            // Act
            var result = _athleteController.GetAllAthletes() as OkObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.StatusCode);
        }

        [Test]
        public void GetAthleteById_ExistingId_ShouldReturnOkResult()
        {
            // Arrange
            int existingAthleteId = 1;
            _mockAthleteService.Setup(service => service.GetAthleteById(existingAthleteId))
                               .Returns(new AthleteDTO());

            // Act
            var result = _athleteController.GetAthleteById(existingAthleteId) as OkObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.StatusCode);
        }
    }
}