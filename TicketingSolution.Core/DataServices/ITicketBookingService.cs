using TicketingSolution.Domain.Domain;

namespace TicketingSolution.Core.DataServices;

public interface ITicketBookingService
{
    void Save(TicketBooking ticketBooking);
    IEnumerable<Ticket> GetAvailableTicketS(DateTime date);
}