using AthleteSportTournaments.DTOs;
using AthleteSportTournamentsApp.Controllers;
using AthleteSportTournamentsApp.Data;
using AthleteSportTournamentsApp.DTOs;
using AthleteSportTournamentsApp.Service;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace AthleteSportAppTest
{
    [TestFixture]
    public class TournamentControllerTests
    {
        private Mock<ITournamentService> _mockTournamentService;
        private Mock<IMapper> _mockMapper;
        private TournamentController _tournamentController;

        [SetUp]
        public void Setup()
        {
            _mockTournamentService = new Mock<ITournamentService>();
            _mockMapper = new Mock<IMapper>();
            _tournamentController = new TournamentController(_mockTournamentService.Object, _mockMapper.Object);
        }

        [Test]
        public async Task GetTournamentById_ExistingId_ReturnsOkResult()
        {
            // Arrange
            int existingId = 1;
            var existingTournament = new Tournament();
            var tournamentDTO = new TournamentDTO();
            _mockTournamentService.Setup(service => service.GetById(existingId)).ReturnsAsync(existingTournament);
            _mockMapper.Setup(mapper => mapper.Map<TournamentDTO>(existingTournament)).Returns(tournamentDTO);

            // Act
            var result = await _tournamentController.GetTournamentById(existingId) as OkObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.StatusCode);
        }

        [Test]
        public async Task GetTournamentById_NonExistingId_ReturnsNotFoundResult()
        {
            // Arrange
            int nonExistingId = 99;
            _mockTournamentService.Setup(service => service.GetById(nonExistingId)).ReturnsAsync(null as Tournament);

            // Act
            var result = await _tournamentController.GetTournamentById(nonExistingId) as NotFoundResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(404, result.StatusCode);
        }


        [Test]
        public async Task UpdateTournament_ExistingId_ValidDTO_ReturnsOkResult()
        {
            // Arrange
            int existingId = 1;
            var tournamentDTO = new TournamentDTO();
            var updatedTournament = new Tournament();
            _mockMapper.Setup(mapper => mapper.Map<Tournament>(tournamentDTO)).Returns(updatedTournament);
            _mockTournamentService.Setup(service => service.Update(updatedTournament));
            _mockTournamentService.Setup(service => service.GetById(existingId)).ReturnsAsync(updatedTournament);

            // Act
            var result = await _tournamentController.UpdateTournament(existingId, tournamentDTO) as OkObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.StatusCode);
        }

        [Test]
        public async Task UpdateTournament_NonExistingId_ValidDTO_ReturnsNotFoundResult()
        {
            // Arrange
            int nonExistingId = 99;
            var tournamentDTO = new TournamentDTO();
            _mockTournamentService.Setup(service => service.GetById(nonExistingId)).ReturnsAsync(null as Tournament);

            // Act
            var result = await _tournamentController.UpdateTournament(nonExistingId, tournamentDTO) as NotFoundResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(404, result.StatusCode);
        }

        [Test]
        public async Task DeleteTournament_ExistingId_ReturnsNoContentResult()
        {
            // Arrange
            int existingId = 1;
            _mockTournamentService.Setup(service => service.Delete(existingId));

            // Act
            var result = await _tournamentController.DeleteTournament(existingId) as NoContentResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(204, result.StatusCode);
        }
    }
}