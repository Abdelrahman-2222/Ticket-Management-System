using Microsoft.EntityFrameworkCore;
using Ticket_Management_System.Models;

namespace Ticket_Management_System.Data
{
    public class TicketContext : DbContext
    {
        public TicketContext(DbContextOptions<TicketContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // --- Fix for TicketStatus/Ticket (Prevent Cascade Delete) ---

            modelBuilder.Entity<Ticket>(entity =>
            {
                entity.HasOne(t => t.Status)
                .WithMany(s => s.Tickets)
                .HasForeignKey(t => t.TicketStatusId)
                .OnDelete(DeleteBehavior.Restrict);

                entity.Property(t => t.SubmittedAt).HasColumnType("datetimeoffset").HasDefaultValueSql("SYSUTCDATETIME()").ValueGeneratedOnAdd();

                entity.HasOne(t => t.Priority)
                .WithMany(p => p.Tickets)
                .HasForeignKey(t => t.TicketPriorityId)
                .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(t => t.Category)
                .WithMany(c => c.Tickets)
                .HasForeignKey(t => t.TicketCategoryId)
                .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(t => t.Employee)
                .WithMany(e => e.Tickets)
                .HasForeignKey(t => t.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(t => t.SupportAgent)
                .WithMany(sa => sa.Tickets)
                .HasForeignKey(t => t.SupportAgentId)
                .OnDelete(DeleteBehavior.SetNull);
            });
            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Department)
                .WithMany(d => d.Employees)
                .HasForeignKey(e => e.DepartmentId)
                .OnDelete(DeleteBehavior.Restrict); 

            modelBuilder.Entity<TicketComment>().Property(t => t.CreatedAt).HasColumnType("datetimeoffset").HasDefaultValueSql("SYSUTCDATETIME()").ValueGeneratedOnAdd();
            modelBuilder.Entity<TicketHistory>().Property(t => t.Timestamp).HasColumnType("datetimeoffset").HasDefaultValueSql("SYSUTCDATETIME()").ValueGeneratedOnAdd();

        }

        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<TicketCategory> TicketCategories { get; set; }
        public DbSet<TicketComment> TicketComments { get; set; }
        public DbSet<SupportAgent> SupportAgents { get; set; }
        public DbSet<TicketHistory> TicketHistories { get; set; }
        public DbSet<TicketPriority> TicketPriorities { get; set; }
        public DbSet<TicketStatus> TicketStatuses { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }


    }
}
