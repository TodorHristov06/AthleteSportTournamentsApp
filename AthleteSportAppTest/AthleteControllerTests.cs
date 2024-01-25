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
    public class AthleteControllerTests
    {
        private Mock<IAthleteService> _mockAthleteService;
        private Mock<IMapper> _mockMapper;
        private AthleteController _athleteController;

        [SetUp]
        public void Setup()
        {
            _mockAthleteService = new Mock<IAthleteService>();
            _mockMapper = new Mock<IMapper>();
            _athleteController = new AthleteController(_mockAthleteService.Object, _mockMapper.Object);
        }

        [Test]
        public async Task GetAllAthletes_ReturnsOkResult()
        {
            // Arrange
            var athletes = new List<Athlete>();
            var athleteDTOs = new List<AthleteDTO>();
            _mockAthleteService.Setup(service => service.GetAll()).ReturnsAsync(athletes);
            _mockMapper.Setup(mapper => mapper.Map<List<AthleteDTO>>(athletes)).Returns(athleteDTOs);

            // Act
            var result = await _athleteController.GetAllAthletes() as OkObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.StatusCode);
        }

        [Test]
        public async Task GetAthleteById_ExistingId_ReturnsOkResult()
        {
            // Arrange
            int existingId = 1;
            var existingAthlete = new Athlete();
            var athleteDTO = new AthleteDTO();
            _mockAthleteService.Setup(service => service.GetById(existingId)).ReturnsAsync(existingAthlete);
            _mockMapper.Setup(mapper => mapper.Map<AthleteDTO>(existingAthlete)).Returns(athleteDTO);

            // Act
            var result = await _athleteController.GetAthleteById(existingId) as OkObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.StatusCode);
        }

        [Test]
        public async Task GetAthleteById_NonExistingId_ReturnsNotFoundResult()
        {
            // Arrange
            int nonExistingId = 99;
            _mockAthleteService.Setup(service => service.GetById(nonExistingId)).ReturnsAsync(null as Athlete);

            // Act
            var result = await _athleteController.GetAthleteById(nonExistingId) as NotFoundResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(404, result.StatusCode);
        }

        [Test]
        public async Task UpdateAthlete_ExistingId_ValidDTO_ReturnsOkResult()
        {
            // Arrange
            int existingId = 1;
            var athleteDTO = new AthleteDTO();
            var updatedAthlete = new Athlete();
            _mockMapper.Setup(mapper => mapper.Map<Athlete>(athleteDTO)).Returns(updatedAthlete);
            _mockAthleteService.Setup(service => service.Update(updatedAthlete));
            _mockAthleteService.Setup(service => service.GetById(existingId)).ReturnsAsync(updatedAthlete);

            // Act
            var result = await _athleteController.UpdateAthlete(existingId, athleteDTO) as OkObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.StatusCode);
        }

        [Test]
        public async Task UpdateAthlete_NonExistingId_ValidDTO_ReturnsNotFoundResult()
        {
            // Arrange
            int nonExistingId = 99;
            var athleteDTO = new AthleteDTO();
            _mockAthleteService.Setup(service => service.GetById(nonExistingId)).ReturnsAsync(null as Athlete);

            // Act
            var result = await _athleteController.UpdateAthlete(nonExistingId, athleteDTO) as NotFoundResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(404, result.StatusCode);
        }
    }
}