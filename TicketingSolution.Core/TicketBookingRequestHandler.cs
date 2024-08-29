namespace TicketingSolution.Core;

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