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

        _ticketBookingService.Save(new TicketBooking
        {
            Name = bookingRequest.Name,
            Family = bookingRequest.Family,
            Email = bookingRequest.Email
        });

        return new ServiceBookingResult
        {
            Name = bookingRequest.Name,
            Family = bookingRequest.Family,
            Email = bookingRequest.Email
        };
    }
}