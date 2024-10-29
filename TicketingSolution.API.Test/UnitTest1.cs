using Microsoft.Extensions.Logging;
using Moq;
using Shouldly;
using TicketingSolution.API.Controllers;
using Xunit;

namespace TicketingSolution.API.Test;

public class UnitTest1
{
    [Fact]
    public void Should_Return_Forecast_Results()
    {
        // Arrange
        var loggerMock = new Mock<ILogger<WeatherForecastController>>(); // we mock the logger because it is injected in the WeatherForecastController constructor
        var controller = new WeatherForecastController(loggerMock.Object); // inject the logger
        
        // Act
        var result = controller.Get();

        // Assert
        result.ShouldNotBeNull();
        result.Count().ShouldBeGreaterThan(1);
    }
}