using AthleteSportTournaments.DTOs;
using AthleteSportTournamentsApp.Controllers;
using AthleteSportTournamentsApp.Service;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace TournamentTest
{
    [TestFixture]
    public class TournamentControllerTests
    {
        private TournamentController _tournamentController;
        private Mock<ITournamentService> _mockTournamentService;

        [SetUp]
        public void Setup()
        {
            // Mock the ITournamentService
            _mockTournamentService = new Mock<ITournamentService>();

            // Create the TournamentController with the mocked service
            _tournamentController = new TournamentController(_mockTournamentService.Object);
        }

        [Test]
        public void GetAllTournaments_ShouldReturnOkResult()
        {
            // Arrange
            _mockTournamentService.Setup(service => service.GetAllTournaments())
                                  .Returns(new List<TournamentDTO>());

            // Act
            var result = _tournamentController.GetAllTournaments() as OkObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.StatusCode);

            // Verify that the service method was called
            _mockTournamentService.Verify(service => service.GetAllTournaments(), Times.Once);
        }

        [Test]
        public void GetTournamentById_ExistingId_ShouldReturnOkResult()
        {
            // Arrange
            int existingTournamentId = 1;
            _mockTournamentService.Setup(service => service.GetTournamentById(existingTournamentId))
                                  .Returns(new TournamentDTO());

            // Act
            var result = _tournamentController.GetTournamentById(existingTournamentId) as OkObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.StatusCode);

            // Verify that the service method was called
            _mockTournamentService.Verify(service => service.GetTournamentById(existingTournamentId), Times.Once);
        }

    }
}