using TicketingSolution.Core.Model;

namespace TicketingSolution.Core.Domain;

public class TicketBooking : ServiceBookingBase
{
    public int TicketId { get; set; }
    public static int Id { get; set; }
}