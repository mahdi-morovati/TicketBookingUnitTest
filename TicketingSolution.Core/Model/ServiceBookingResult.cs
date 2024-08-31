﻿using TicketingSolution.Core.Enums;

namespace TicketingSolution.Core.Model;

public class ServiceBookingResult : ServiceBookingBase
{
    public BookingResultFlag Flag { get; set; }
    public int? TicketBookId { get; set; }
}