using EmployeeManagement.Interfaces;
using EmployeeManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagementAPITest.Controllers
{
    public class EmployeeControllerTests
    {
        [Fact]
        public async Task GetById_ShouldReturnEmployee()
        {
            // Arrange
            var mockRepo = new Mock<IEmployeeRepositary>();          

            mockRepo
                .Setup(x => x.GetEmployee(
                    1,
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(new Employee
                {
                    EmployeeId = 1,
                    EmployeeName = "John"
                });

            var controller = new EmployeesController(mockRepo.Object);

            // Act
            var result = await controller.GetEmployee(
                1,
                CancellationToken.None);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);

            var employee = Assert.IsType<Employee>(
                okResult.Value);

            Assert.Equal(1, employee.EmployeeId);
        }
    }
}
