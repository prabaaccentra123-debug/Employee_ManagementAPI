using EmployeeManagement.Interfaces;
using EmployeeManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagementAPITest.Controllers
{
    public class EmployeeNotFound
    {
        [Fact]
        public async Task GetById_ShouldReturnNotFound()
        {
            var mockRepo =
                new Mock<IEmployeeRepositary>();

            mockRepo
                .Setup(x =>
                    x.GetEmployee(
                        100,
                        It.IsAny<CancellationToken>()))
                .ReturnsAsync((Employee)null);

            var controller =
                new EmployeesController(
                    mockRepo.Object);

            var result =
                await controller.GetEmployee(
                    100,
                    CancellationToken.None);

            Assert.IsType<NotFoundObjectResult>(result);
        }
    }
}
