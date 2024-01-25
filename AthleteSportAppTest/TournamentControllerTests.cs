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
    public class SportControllerTests
    {
        private Mock<ISportService> _mockSportService;
        private Mock<IMapper> _mockMapper;
        private SportController _sportController;

        [SetUp]
        public void Setup()
        {
            _mockSportService = new Mock<ISportService>();
            _mockMapper = new Mock<IMapper>();
            _sportController = new SportController(_mockSportService.Object, _mockMapper.Object);
        }

        [Test]
        public async Task GetSportById_ExistingId_ReturnsOkResult()
        {
            // Arrange
            int existingId = 1;
            var existingSport = new Sport();
            var sportDTO = new SportDTO();
            _mockSportService.Setup(service => service.GetById(existingId)).ReturnsAsync(existingSport);
            _mockMapper.Setup(mapper => mapper.Map<SportDTO>(existingSport)).Returns(sportDTO);

            // Act
            var result = await _sportController.GetSportById(existingId) as OkObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.StatusCode);
        }

        [Test]
        public async Task GetSportById_NonExistingId_ReturnsNotFoundResult()
        {
            // Arrange
            int nonExistingId = 99;
            _mockSportService.Setup(service => service.GetById(nonExistingId)).ReturnsAsync(null as Sport);

            // Act
            var result = await _sportController.GetSportById(nonExistingId) as NotFoundResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(404, result.StatusCode);
        }


        [Test]
        public async Task UpdateSport_ExistingId_ValidDTO_ReturnsOkResult()
        {
            // Arrange
            int existingId = 1;
            var sportDTO = new SportDTO();
            var updatedSport = new Sport();
            _mockMapper.Setup(mapper => mapper.Map<Sport>(sportDTO)).Returns(updatedSport);
            _mockSportService.Setup(service => service.Update(updatedSport));
            _mockSportService.Setup(service => service.GetById(existingId)).ReturnsAsync(updatedSport);

            // Act
            var result = await _sportController.UpdateSport(existingId, sportDTO) as OkObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.StatusCode);
        }

        [Test]
        public async Task UpdateSport_NonExistingId_ValidDTO_ReturnsNotFoundResult()
        {
            // Arrange
            int nonExistingId = 99;
            var sportDTO = new SportDTO();
            _mockSportService.Setup(service => service.GetById(nonExistingId)).ReturnsAsync(null as Sport);

            // Act
            var result = await _sportController.UpdateSport(nonExistingId, sportDTO) as NotFoundResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(404, result.StatusCode);
        }

        [Test]
        public async Task DeleteSport_ExistingId_ReturnsNoContentResult()
        {
            // Arrange
            int existingId = 1;
            _mockSportService.Setup(service => service.Delete(existingId));

            // Act
            var result = await _sportController.DeleteSport(existingId) as NoContentResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(204, result.StatusCode);
        }
    }
}