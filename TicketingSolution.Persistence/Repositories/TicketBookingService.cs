using TicketingSolution.Core.DataServices;
using TicketingSolution.Domain.Domain;

namespace Persistence.Repositories;

public class TicketBookingService : ITicketBookingService
{
    public void Save(TicketBooking ticketBooking)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Ticket> GetAvailableTicketS(DateTime date)
    {
        throw new NotImplementedException();
    }
}