using EmployeeManagement.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagementAPITest.Controllers
{
    public class DeleteEmployeeTest
    {
        [Fact]
        public async Task Delete_ShouldReturnOk()
        {
            var mockRepo =
                new Mock<IEmployeeRepositary>();

            mockRepo
                .Setup(x =>
                    x.DeleteEmployee(
                        1,
                        It.IsAny<CancellationToken>()))
                .Returns(Task.CompletedTask);

            var controller =
                new EmployeesController(
                    mockRepo.Object);

            var result =
                await controller.DeleteEmployee(
                    1,
                    CancellationToken.None);

            Assert.IsType<OkObjectResult>(
                result);
        }
    }
}
