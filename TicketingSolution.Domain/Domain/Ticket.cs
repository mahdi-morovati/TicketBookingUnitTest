namespace TicketingSolution.Domain.Domain;

public class Ticket
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<TicketBooking> TicketBooking { get; set; }
}