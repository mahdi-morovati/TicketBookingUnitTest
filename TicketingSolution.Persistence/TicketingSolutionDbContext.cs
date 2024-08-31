using Microsoft.EntityFrameworkCore;
using TicketingSolution.Domain.Domain;

namespace Persistence;

public class TicketingSolutionDbContext : DbContext
{
    DbSet<Ticket> Tickets { get; set; }
    DbSet<TicketBooking> TicketBookings { get; set; }

    public TicketingSolutionDbContext(DbContextOptions<TicketingSolutionDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Ticket>().HasData(
            new Ticket { Id = 1, Name = "To Shiraz" },
            new Ticket { Id = 2, Name = "To Esfahan" },
            new Ticket { Id = 3, Name = "To Mashhad" }
        );
    }
}