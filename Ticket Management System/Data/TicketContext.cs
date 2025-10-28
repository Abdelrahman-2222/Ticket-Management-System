using Microsoft.EntityFrameworkCore;
using Ticket_Management_System.Models;

namespace Ticket_Management_System.Data
{
    public class TicketContext : DbContext
    {
        public TicketContext(DbContextOptions<TicketContext> options) : base(options)
        {
        }

        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<TicketCategory> TicketCategories { get; set; }
        public DbSet<TicketComment> TicketComments { get; set; }
        public DbSet<SupportAgent> SupportAgents { get; set; }
        public DbSet<TicketHistory> TicketHistories { get; set; }
        public DbSet<TicketPriority> TicketPrioritys { get; set; }
        public DbSet<TicketStatus> TicketStatuses { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }


    }
}
