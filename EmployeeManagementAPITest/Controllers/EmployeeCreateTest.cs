using EmployeeManagement.Dto;
using EmployeeManagement.Interfaces;
using EmployeeManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagementAPITest.Controllers
{
    public class EmployeeCreateTest
    {
        [Fact]
        public async Task Create_ShouldReturnCreated()
        {
            var dto =
                new EmployeeCreateDto
                {
                    EmployeeName = "John",
                    Email = "john@test.com",
                    Department = "IT",
                    DateOfJoining = DateTime.Now
                };

            var mockRepo =
                new Mock<IEmployeeRepositary>();

            mockRepo
                .Setup(x =>
                    x.AddEmployee(
                        It.IsAny<Employee>(),
                        It.IsAny<CancellationToken>()))
                .ReturnsAsync(new Employee
                {
                    EmployeeId = 1
                });

            var controller =
                new EmployeesController(
                    mockRepo.Object);

            var result =
                await controller.PostEmployee(
                    dto,
                    CancellationToken.None);

            var okResult =
    Assert.IsType<OkObjectResult>(
        result.Result);
        }
    }
}
