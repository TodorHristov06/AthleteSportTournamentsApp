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
    public class AthleteSportTournamentsAssignmentControllerTests
    {
        private Mock<IAthleteSportTournamentsService> _mockAthleteSportTournamentsService;
        private Mock<IMapper> _mockMapper;
        private AthleteSportTournamentsAssignmentController _athleteSportTournamentsAssignmentController;

        [SetUp]
        public void Setup()
        {
            _mockAthleteSportTournamentsService = new Mock<IAthleteSportTournamentsService>();
            _mockMapper = new Mock<IMapper>();
            _athleteSportTournamentsAssignmentController = new AthleteSportTournamentsAssignmentController(
                _mockAthleteSportTournamentsService.Object,
                _mockMapper.Object
            );
        }

        [Test]
        public async Task GetAssignmentById_ExistingId_ReturnsOkResult()
        {
            // Arrange
            int existingId = 1;
            var existingAssignment = new AthleteTournament();
            var assignmentDTO = new AthleteTournamentDTO();
            _mockAthleteSportTournamentsService.Setup(service => service.GetById(existingId)).ReturnsAsync(existingAssignment);
            _mockMapper.Setup(mapper => mapper.Map<AthleteTournamentDTO>(existingAssignment)).Returns(assignmentDTO);

            // Act
            var result = await _athleteSportTournamentsAssignmentController.GetAssignmentById(existingId) as OkObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.StatusCode);
        }

        [Test]
        public async Task GetAssignmentById_NonExistingId_ReturnsNotFoundResult()
        {
            // Arrange
            int nonExistingId = 99;
            _mockAthleteSportTournamentsService.Setup(service => service.GetById(nonExistingId)).ReturnsAsync(null as AthleteTournament);

            // Act
            var result = await _athleteSportTournamentsAssignmentController.GetAssignmentById(nonExistingId) as NotFoundResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(404, result.StatusCode);
        }

        [Test]
        public async Task CreateAssignment_ValidDTO_ReturnsCreatedAtActionResult()
        {
            // Arrange
            var assignmentDTO = new AthleteTournamentDTO();
            var createdAssignment = new AthleteTournament();
            _mockMapper.Setup(mapper => mapper.Map<AthleteTournament>(assignmentDTO)).Returns(createdAssignment);
            _mockAthleteSportTournamentsService.Setup(service => service.Add(createdAssignment));

            // Act
            var result = await _athleteSportTournamentsAssignmentController.CreateAssignment(assignmentDTO) as CreatedAtActionResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(201, result.StatusCode);
            Assert.AreEqual(nameof(_athleteSportTournamentsAssignmentController.GetAssignmentById), result.ActionName);
        }

        [Test]
        public async Task UpdateAssignment_ExistingId_ValidDTO_ReturnsOkResult()
        {
            // Arrange
            int existingId = 1;
            var assignmentDTO = new AthleteTournamentDTO();
            var updatedAssignment = new AthleteTournament();
            _mockMapper.Setup(mapper => mapper.Map<AthleteTournament>(assignmentDTO)).Returns(updatedAssignment);
            _mockAthleteSportTournamentsService.Setup(service => service.Update(existingId, updatedAssignment));
            _mockAthleteSportTournamentsService.Setup(service => service.GetById(existingId)).ReturnsAsync(updatedAssignment);

            // Act
            var result = await _athleteSportTournamentsAssignmentController.UpdateAssignment(existingId, assignmentDTO) as OkObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.StatusCode);
        }

        [Test]
        public async Task UpdateAssignment_NonExistingId_ValidDTO_ReturnsNotFoundResult()
        {
            // Arrange
            int nonExistingId = 99;
            var assignmentDTO = new AthleteTournamentDTO();
            _mockAthleteSportTournamentsService.Setup(service => service.GetById(nonExistingId)).ReturnsAsync(null as AthleteTournament);

            // Act
            var result = await _athleteSportTournamentsAssignmentController.UpdateAssignment(nonExistingId, assignmentDTO) as NotFoundResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(404, result.StatusCode);
        }

        [Test]
        public async Task DeleteAssignment_ExistingId_ReturnsNoContentResult()
        {
            // Arrange
            int existingId = 1;
            _mockAthleteSportTournamentsService.Setup(service => service.Delete(existingId));

            // Act
            var result = await _athleteSportTournamentsAssignmentController.DeleteAssignment(existingId) as NoContentResult;
        }
    }
}