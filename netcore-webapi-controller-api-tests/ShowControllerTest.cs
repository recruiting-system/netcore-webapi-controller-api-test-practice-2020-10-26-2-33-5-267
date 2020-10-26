using System;
using Microsoft.AspNetCore.Mvc;
using Moq;
using netcore_webapi_controller_api.Controllers;
using netcore_webapi_controller_api.Services;
using Xunit;

namespace netcore_webapi_controller_api_tests
{
    public class ShowControllerTest
    {
        [Fact]
        public void GetAll()
        {
            //Arrange
            string expectedMessage = "a beauty tag";
            var mockService = new Mock<ShowService>(null);
            mockService.Setup(service => service.GetShowLabel())
                .Returns(expectedMessage);
            var showController = new ShowController(mockService.Object);

            //Act
            ObjectResult actionResult = showController.GetAll() as ObjectResult;

            //Assert
            Assert.Equal(200, actionResult.StatusCode);
            Assert.Equal(expectedMessage, actionResult.Value);
        }
    }
}
