using TicketingSolution.Core.Model;

namespace TicketingSolution.Core.Hanlder;

public class TicketBookingRequestHandler
{
    

    public ServiceBookingResult BookService(TicketBookingRequest bookingRequest)
    {
        if (bookingRequest is null)
        {
            throw new ArgumentNullException(nameof(bookingRequest));
        }
        
        return new ServiceBookingResult
        {
            Name = bookingRequest.Name,
            Family = bookingRequest.Family,
            Email = bookingRequest.Email
        };
    }
}