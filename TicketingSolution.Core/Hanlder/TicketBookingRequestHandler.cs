using TicketingSolution.Core.Model;

namespace TicketingSolution.Core.Hanlder;

public class TicketBookingRequestHandler
{
    public TicketBookingRequestHandler()
    {
    }

    public ServiceBookingResult BookService(TicketBookingRequest bookingRequest)
    {
        return new ServiceBookingResult
        {
            Name = bookingRequest.Name,
            Family = bookingRequest.Family,
            Email = bookingRequest.Email
        };
    }
}