using TicketingSolution.Domain.BaseModels;

namespace TicketingSolution.Domain.Domain;

public class TicketBooking : ServiceBookingBase
{
    public int TicketId { get; set; }
    public static int Id { get; set; }
}