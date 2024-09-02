using Microsoft.EntityFrameworkCore;
using Persistence;
using Persistence.Repositories;
using TicketingSolution.Domain.Domain;
using Xunit;

namespace TicketingSolution.Persistence.Test;

public class TicketBookingServiceTest
{
    [Fact]
    public void Should_Return_Available_Services()
    {
        // Arrange
        var date = new DateTime(2024, 08, 31);

        var dbOptions = new DbContextOptionsBuilder<TicketingSolutionDbContext>()
            .UseInMemoryDatabase("AvailableTicketTest",b => b.EnableNullChecks(false))
            .Options;

        using var context = new TicketingSolutionDbContext(dbOptions);
        context.Add(new Ticket { Id = 1, Name = "Ticket 1" });
        context.Add(new Ticket { Id = 2, Name = "Ticket 2" });
        context.Add(new Ticket { Id = 3, Name = "Ticket 3" });


        context.Add(new TicketBooking { TicketId = 1, Date = date });
        context.Add(new TicketBooking { TicketId = 2, Date = date.AddDays(-1) });

        context.SaveChanges();

        var ticketBookingService = new TicketBookingService(context);
        
        // Act
        var availableServices = ticketBookingService.GetAvailableTickets(date);
        
        //Assert
        Assert.Equal(2, availableServices.Count());
        Assert.Contains(availableServices, q => q.Id == 2);
        Assert.Contains(availableServices, q => q.Id == 3);
        Assert.DoesNotContain(availableServices, q => q.Id == 1);

    }
}