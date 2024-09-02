using TicketingSolution.Core.DataServices;
using TicketingSolution.Domain.Domain;

namespace Persistence.Repositories;

public class TicketBookingService : ITicketBookingService
{
    private readonly TicketingSolutionDbContext _context;

    public TicketBookingService(TicketingSolutionDbContext context)
    {
        _context = context;
    }

    public void Save(TicketBooking ticketBooking)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Ticket> GetAvailableTickets(DateTime date)
    {
        return _context.Tickets
            .Where(q => !q.TicketBooking.Any(x => x.Date == date))
            .ToList();
    }
}