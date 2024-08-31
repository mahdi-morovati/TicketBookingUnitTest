using Moq;
using Shouldly;
using TicketingSolution.Core.DataServices;
using TicketingSolution.Core.Enums;
using TicketingSolution.Core.Hanlder;
using TicketingSolution.Core.Model;
using TicketingSolution.Domain.Domain;

namespace TicketingSolution.Core.Test;

public class TicketBookingRequestHandlerTest
{
    private readonly TicketBookingRequestHandler _handler;
    private readonly TicketBookingRequest _request;
    private readonly Mock<ITicketBookingService> _ticketBookingServiceMock;
    private readonly List<Ticket> _availableTickets;

    public TicketBookingRequestHandlerTest()
    {
        // Arrange
        _request = new TicketBookingRequest
        {
            Name = "Test Name",
            Family = "Test Family",
            Email = "Test Email",
            Date = DateTime.Now
        };

        _availableTickets = new List<Ticket>() { new Ticket() { Id = 1 } };
        _ticketBookingServiceMock = new Mock<ITicketBookingService>();
        _ticketBookingServiceMock.Setup(x => x.GetAvailableTicketS(_request.Date))
            .Returns(_availableTickets);

        _handler = new TicketBookingRequestHandler(_ticketBookingServiceMock.Object);
    }

    [Fact]
    public void Should_Return_Ticket_Booking_Response_With_Request_Values()
    {
        // Act
        ServiceBookingResult result = _handler.BookService(_request);
        // Assert

        Assert.NotNull(result);
        Assert.Equal(result.Name, _request.Name);
        Assert.Equal(result.Family, _request.Family);
        Assert.Equal(result.Email, _request.Email);

        // Assert by Shouldly
        result.ShouldNotBeNull();
        result.Name.ShouldBe(_request.Name);
        result.Family.ShouldBe(_request.Family);
        result.Email.ShouldBe(_request.Email);
    }

    [Fact]
    public void Should_Throw_Exception_For_Null_Request()
    {
        // Assert.Throws<ArgumentNullException>(() => _requestHandler.BookService(null)); // equals to below assertion
        var exception = Should.Throw<ArgumentNullException>(() => _handler.BookService(null));
        exception.ParamName.ShouldBe("bookingRequest");
    }

    [Fact]
    public void Should_Save_Ticket_Booking_Request()
    {
        TicketBooking saveBooking = null;
        _ticketBookingServiceMock.Setup(x => x.Save(It.IsAny<TicketBooking>()))
            .Callback<TicketBooking>(booking => { saveBooking = booking; });

        _handler.BookService(_request);
        _ticketBookingServiceMock.Verify(x => x.Save(It.IsAny<TicketBooking>()), Times.Once);

        saveBooking.ShouldNotBeNull();
        saveBooking.Name.ShouldBe(_request.Name);
        saveBooking.Family.ShouldBe(_request.Family);
        saveBooking.Email.ShouldBe(_request.Email);
        saveBooking.TicketId.ShouldBe(_availableTickets.First().Id);
    }

    [Fact]
    public void Should_Not_Save_Ticket_Booking_Request_If_None_Available()
    {
        _availableTickets.Clear();
        _handler.BookService(_request);
        _ticketBookingServiceMock.Verify(x => x.Save(It.IsAny<TicketBooking>()), Times.Never);
    }

    [Theory]
    [InlineData(BookingResultFlag.Failure, false)]
    [InlineData(BookingResultFlag.Success, true)]
    public void Should_Return_SuccessOrFailure_Flag_In_Result(BookingResultFlag bookingResultFlag, bool isAvailable)
    {
        if (!isAvailable)
        {
            _availableTickets.Clear();
        }
        
        var result = _handler.BookService(_request);
        bookingResultFlag.ShouldBe(result.Flag);
    }

    [Theory]
    [InlineData(1, true)]
    [InlineData(null, false)]
    public void Should_Return_TicketBookingId_In_Result(int? ticketBookingId, bool isAvailable)
    {
        if (!isAvailable)
        {
            _availableTickets.Clear();
        }
        else
        {
            _ticketBookingServiceMock.Setup(x => x.Save(It.IsAny<TicketBooking>()))
                .Callback<TicketBooking>(booking =>
                {
                    TicketBooking.Id = ticketBookingId.Value;
                });
        }

        var result = _handler.BookService(_request);
        result.TicketBookId.ShouldBe(ticketBookingId);
    }
}