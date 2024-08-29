using Shouldly;
using TicketingSolution.Core.Hanlder;
using TicketingSolution.Core.Model;

namespace TicketingSolution.Core.Test;

public class TicketBookingRequestHandlerTest
{
    [Fact]
    public void ShouldReturnTicketBookingREsponseWithRequestValues()
    {
        // Arrange
        var bookingRequest = new TicketBookingRequest
        {
            Name = "Test Name",
            Family = "Test Family",
            Email = "Test Email",
        };
        var handler = new TicketBookingRequestHandler();
        // Act
        ServiceBookingResult result = handler.BookService(bookingRequest);
        // Assert

        Assert.NotNull(result);
        Assert.Equal(result.Name, bookingRequest.Name);
        Assert.Equal(result.Family, bookingRequest.Family);
        Assert.Equal(result.Email, bookingRequest.Email);

        // Assert by Shouldly
        result.ShouldNotBeNull();
        result.Name.ShouldBe(bookingRequest.Name);
        result.Family.ShouldBe(bookingRequest.Family);
        result.Email.ShouldBe(bookingRequest.Email);
    }
}