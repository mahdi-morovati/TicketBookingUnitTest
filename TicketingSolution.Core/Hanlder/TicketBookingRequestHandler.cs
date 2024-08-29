using TicketingSolution.Core.DataServices;
using TicketingSolution.Core.Domain;
using TicketingSolution.Core.Model;

namespace TicketingSolution.Core.Hanlder;

public class TicketBookingRequestHandler
{
    private readonly ITicketBookingService _ticketBookingService;

    public TicketBookingRequestHandler(ITicketBookingService ticketBookingService)
    {
        _ticketBookingService = ticketBookingService;
    }

    public ServiceBookingResult BookService(TicketBookingRequest bookingRequest)
    {
        if (bookingRequest is null)
        {
            throw new ArgumentNullException(nameof(bookingRequest));
        }

        var availableTickets = _ticketBookingService.GetAvailableTicketS(bookingRequest.Date);
        if (availableTickets.Any())
        {
            _ticketBookingService.Save(CreateTicketBookingObject<TicketBooking>(bookingRequest));
        }

        return CreateTicketBookingObject<ServiceBookingResult>(bookingRequest);
    }

    private static TTicketBooking CreateTicketBookingObject<TTicketBooking>(TicketBookingRequest bookingRequest)
        where TTicketBooking : ServiceBookingBase, new()
    {
        return new TTicketBooking
        {
            Name = bookingRequest.Name,
            Family = bookingRequest.Family,
            Email = bookingRequest.Email
        };
    }
}