using Shouldly;
using TicketingSolution.Core.Hanlder;
using TicketingSolution.Core.Model;

namespace TicketingSolution.Core.Test;

public class TicketBookingRequestHandlerTest
{
    private readonly TicketBookingRequestHandler _handler;

    public TicketBookingRequestHandlerTest()
    {
        _handler = new TicketBookingRequestHandler();
    }

    [Fact]
    public void ShouldReturnTicketBookingResponseWithRequestValues()
    {
        // Arrange
        var bookingRequest = new TicketBookingRequest
        {
            Name = "Test Name",
            Family = "Test Family",
            Email = "Test Email",
        };
        // Act
        ServiceBookingResult result = _handler.BookService(bookingRequest);
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

    [Fact]
    public void ShouldThrowExceptionForNullRequest()
    {
        // Assert.Throws<ArgumentNullException>(() => _requestHandler.BookService(null)); // equals to below assertion
        var exception = Should.Throw<ArgumentNullException>(() => _handler.BookService(null));
        exception.ParamName.ShouldBe("bookingRequest");
    }
}