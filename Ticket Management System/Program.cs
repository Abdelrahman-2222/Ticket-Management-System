
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Ticket_Management_System.Contracts;
using Ticket_Management_System.Data;
using Ticket_Management_System.Models;
using Ticket_Management_System.Services;

namespace Ticket_Management_System
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(options =>
            {
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                options.IncludeXmlComments(xmlPath);
            });

            builder.Services.AddDbContext<TicketContext>(opt => opt.UseSqlServer(
                builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddScoped<IDepartmentService, DepartmentService>();
            builder.Services.AddScoped<IEmployeeService, EmployeeService>();
            builder.Services.AddScoped<ISupportAgentService, SupportAgentService>();
            builder.Services.AddScoped<ITicketCategoryService, TicketCategoryService>();
            builder.Services.AddScoped<ITicketCommentsService, TicketCommentsService>();
            builder.Services.AddScoped<ITicketHistoryService, TicketHistoryService>();
            builder.Services.AddScoped<ITicketPriorityService, TicketPriorityService>();
            builder.Services.AddScoped<ITicketService, TicketService>();
            builder.Services.AddScoped<ITicketStatusService, TicketStatusService>();



            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
