using Microsoft.EntityFrameworkCore;

namespace Ticket_Management_System.Data
{
    public class TicketContext : DbContext
    {
        public TicketContext(DbContextOptions<TicketContext> options) : base(options)
        {
        }

    }
}
