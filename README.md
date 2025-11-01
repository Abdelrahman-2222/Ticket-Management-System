# 🎫 Ticket Management System

> A comprehensive, layered ASP.NET Core Web API for enterprise support ticket management with advanced analytics capabilities.

[![.NET 8](https://img.shields.io/badge/.NET-8.0-512BD4?logo=dotnet)](https://dotnet.microsoft.com/)
[![C# 12](https://img.shields.io/badge/C%23-12.0-239120?logo=csharp)](https://learn.microsoft.com/en-us/dotnet/csharp/)
[![EF Core](https://img.shields.io/badge/EF%20Core-8.0-512BD4)](https://learn.microsoft.com/en-us/ef/core/)
[![SQL Server](https://img.shields.io/badge/SQL%20Server-LocalDB-CC2927?logo=microsoftsqlserver)](https://www.microsoft.com/sql-server)

---

## 📋 Overview

A production-ready ticket management system built with modern .NET practices, featuring a clean architecture with separated concerns, comprehensive CRUD operations, and powerful analytics for operational insights.

### ✨ Key Features

- 🔐 **Structured Access Control** - Role-based separation between employees and support agents
- 📊 **Real-time Analytics** - Track resolution times, department metrics, and failure patterns
- 🏗️ **Clean Architecture** - Layered design with proper dependency inversion
- 📝 **Full Audit Trail** - Comprehensive history tracking for all ticket changes
- 💬 **Commenting System** - Threaded discussions on tickets
- 🔍 **Advanced Filtering** - Query by status, priority, category, and more
- 📈 **Performance Metrics** - Monitor SLA compliance and team efficiency

---

## 🛠️ Tech Stack

| Component | Technology |
|-----------|-----------|
| **Framework** | .NET 8 with C# 12 |
| **API** | ASP.NET Core Web API |
| **ORM** | Entity Framework Core 8 |
| **Database** | SQL Server (LocalDB/Full) |
| **Documentation** | Swagger/OpenAPI 3.0 |
| **Architecture** | Layered with Dependency Injection |

---

## 📁 Solution Architecture

```
Ticket Management System/
├── 📂 AppAnnotation/
│   └── AnnotationSettings.cs           # Custom attributes & configs
│
├── 📂 Contracts/                       # Interface definitions (DI)
│   ├── IDepartmentService.cs
│   ├── IEmployeeService.cs
│   ├── ISupportAgentService.cs
│   ├── ITicketService.cs
│   ├── ITicketCategoryService.cs
│   ├── ITicketCommentsService.cs
│   ├── ITicketHistoryService.cs
│   ├── ITicketPriorityService.cs
│   ├── ITicketStatusService.cs
│   └── IAnalyticsService.cs            # 📊 Analytics interface
│
├── 📂 Controllers/                     # API endpoints
│   ├── DepartmentController.cs
│   ├── EmployeeController.cs
│   ├── SupportAgentController.cs
│   ├── TicketController.cs
│   ├── TicketCategoryController.cs
│   ├── TicketCommentController.cs
│   ├── TicketHistoryController.cs
│   ├── TicketPriorityController.cs
│   ├── TicketStatusController.cs
│   └── AnalyticsController.cs          # 📊 Analytics endpoints
│
├── 📂 Data/
│   └── TicketContext.cs                # EF Core DbContext
│
├── 📂 DTOs/                            # Data Transfer Objects
│   ├── DepartmentDTO.cs
│   ├── EmployeeDTO.cs
│   ├── SupportAgentDTO.cs
│   ├── TicketDTO.cs
│   ├── TicketCategoryDTO.cs
│   ├── TicketCommentDTO.cs
│   ├── TicketHistoryDTO.cs
│   ├── TicketPriorityDTO.cs
│   ├── TicketStatusDTO.cs
│   └── Analytics/                      # 📊 Analytics DTOs
│       ├── CommonFailureDTO.cs
│       ├── TopDepartmentDTO.cs
│       └── AverageResolutionTimeDTO.cs
│
├── 📂 Migrations/                      # EF Core migrations
│   ├── 20251029055042_InitialCreate.cs
│   ├── 20251029072423_UpdateEntitiesTimeStamp.cs
│   ├── 20251030200754_ChangeAbstraction.cs
│   └── TicketContextModelSnapshot.cs
│
├── 📂 Models/                          # Domain entities
│   ├── Base/                           # Base classes
│   ├── Department.cs
│   ├── Employee.cs
│   ├── SupportAgent.cs
│   ├── Ticket.cs
│   ├── TicketCategory.cs
│   ├── TicketComment.cs
│   ├── TicketHistory.cs
│   ├── TicketPriority.cs
│   └── TicketStatus.cs
│
├── 📂 Services/                        # Business logic layer
│   ├── DepartmentService.cs
│   ├── EmployeeService.cs
│   ├── SupportAgentService.cs
│   ├── TicketService.cs
│   ├── TicketCategoryService.cs
│   ├── TicketCommentsService.cs
│   ├── TicketHistoryService.cs
│   ├── TicketPriorityService.cs
│   ├── TicketStatusService.cs
│   └── AnalyticsService.cs             # 📊 Analytics business logic
│
├── appsettings.json                    # Configuration
├── Program.cs                          # Application entry point
└── Ticket Management System.http       # HTTP test file
```

---

## 🗄️ Domain Model

### Core Entities

#### **Ticket** (Central Entity)
```csharp
- Id: int (PK)
- Name: string                    // Ticket title/summary
- Description: string             // Detailed description
- SubmittedAt: DateTimeOffset?    // Submission timestamp
- ResolvedAt: DateTime?           // Resolution timestamp
- EmployeeId: int (FK)            // Submitter
- SupportAgentId: int? (FK)       // Assigned agent (nullable)
- TicketStatusId: int (FK)        // Current status
- TicketPriorityId: int (FK)      // Priority level
- TicketCategoryId: int (FK)      // Category classification

Navigations:
- Employee (1:1)
- SupportAgent (0..1:1)
- Status (1:1)
- Priority (1:1)
- Category (1:1)
- Comments (1:N)
- HistoryLogs (1:N)
```

#### **Employee**
```csharp
- Id: int (PK)
- Name: string
- Email: string
- DepartmentId: int (FK)

Navigations:
- Department (1:1)
- SubmittedTickets (1:N)
```

#### **SupportAgent**
```csharp
- Id: int (PK)
- Name: string
- Email: string
- Specialization: string?

Navigations:
- AssignedTickets (1:N)
```

#### **Department**
```csharp
- Id: int (PK)
- Name: string

Navigations:
- Employees (1:N)
```

#### **Lookup Tables**
- **TicketCategory**: Hardware, Software, Network, Access, etc.
- **TicketPriority**: Low, Medium, High, Critical
- **TicketStatus**: Open, In Progress, Resolved, Closed, Reopened

#### **Supporting Entities**
- **TicketComment**: User discussions on tickets
- **TicketHistory**: Comprehensive audit trail of all changes

### 🔗 Relationship Rules

| Foreign Key | On Delete Behavior | Reason |
|-------------|-------------------|---------|
| `Ticket.EmployeeId` | `Restrict` | Preserve ticket history |
| `Ticket.SupportAgentId` | `SetNull` | Allow agent removal |
| `Ticket.StatusId` | `Restrict` | Maintain data integrity |
| `Ticket.PriorityId` | `Restrict` | Maintain data integrity |
| `Ticket.CategoryId` | `Restrict` | Maintain data integrity |
| `TicketComment.TicketId` | `Cascade` | Auto-cleanup |
| `TicketHistory.TicketId` | `Cascade` | Auto-cleanup |

---

## 🚀 Getting Started

### Prerequisites

- ✅ [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- ✅ SQL Server 2019+ or LocalDB
- ✅ Visual Studio 2022+ or VS Code with C# extension
- ✅ Git (optional)

### 📝 Configuration

1. **Update Connection String** in `appsettings.json`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\MSSQLLocalDB;Database=TicketDb;Trusted_Connection=True;MultipleActiveResultSets=true"
  }
}
```

For full SQL Server:
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=YOUR_SERVER;Database=TicketDb;User Id=YOUR_USER;Password=YOUR_PASSWORD;TrustServerCertificate=True"
  }
}
```

### 🔧 Installation & Setup

#### Option 1: Visual Studio

1. **Open Solution**
   ```
   File → Open → Project/Solution → Select Ticket Management System.sln
   ```

2. **Restore Packages**
   ```
   Right-click Solution → Restore NuGet Packages
   ```

3. **Apply Migrations**
   ```
   Tools → NuGet Package Manager → Package Manager Console
   ```
   ```powershell
   Update-Database
   ```

4. **Run Application**
   ```
   Press F5 or click Debug → Start Debugging
   ```

#### Option 2: Command Line

1. **Clone/Navigate to Project**
   ```bash
   cd "Ticket Management System"
   ```

2. **Restore Dependencies**
   ```bash
   dotnet restore
   ```

3. **Apply Migrations**
   ```bash
   dotnet tool install --global dotnet-ef  # If not installed
   dotnet ef database update
   ```

4. **Run Application**
   ```bash
   dotnet run
   ```

5. **Access Swagger UI**
   ```
   https://localhost:5001/swagger
   ```

---

## 📡 API Reference

### 🎫 Ticket Management

#### Create Ticket
```http
POST /api/ticket
Content-Type: application/json

{
  "name": "Laptop screen flickering",
  "description": "Display issues after Windows update",
  "employeeId": 5,
  "ticketCategoryId": 1,
  "ticketPriorityId": 2,
  "ticketStatusId": 1
}
```

#### Get Ticket
```http
GET /api/ticket/{id}
```

#### List All Tickets
```http
GET /api/ticket
```

#### Update Ticket
```http
PUT /api/ticket/{id}
Content-Type: application/json

{
  "id": 42,
  "name": "Updated title",
  "supportAgentId": 3,
  "ticketStatusId": 2
}
```

#### Delete Ticket
```http
DELETE /api/ticket/{id}
```

### 📁 Categories

```http
GET    /api/ticketcategory          # List all
GET    /api/ticketcategory/{id}     # Get by ID
POST   /api/ticketcategory          # Create
PUT    /api/ticketcategory/{id}     # Update
DELETE /api/ticketcategory/{id}     # Delete
```

### 🔴 Priorities

```http
GET    /api/ticketpriority          # List all
GET    /api/ticketpriority/{id}     # Get by ID
POST   /api/ticketpriority          # Create
PUT    /api/ticketpriority/{id}     # Update
DELETE /api/ticketpriority/{id}     # Delete
```

### 📊 Status

```http
GET    /api/ticketstatus            # List all
GET    /api/ticketstatus/{id}       # Get by ID
POST   /api/ticketstatus            # Create
PUT    /api/ticketstatus/{id}       # Update
DELETE /api/ticketstatus/{id}       # Delete
```

### 👥 Employees & Departments

```http
GET    /api/employee                # List all employees
GET    /api/employee/{id}           # Get employee
POST   /api/employee                # Create employee
PUT    /api/employee/{id}           # Update employee
DELETE /api/employee/{id}           # Delete employee

GET    /api/department              # List all departments
GET    /api/department/{id}         # Get department
POST   /api/department              # Create department
PUT    /api/department/{id}         # Update department
DELETE /api/department/{id}         # Delete department
```

### 🛠️ Support Agents

```http
GET    /api/supportagent            # List all agents
GET    /api/supportagent/{id}       # Get agent
POST   /api/supportagent            # Create agent
PUT    /api/supportagent/{id}       # Update agent
DELETE /api/supportagent/{id}       # Delete agent
```

### 💬 Comments

```http
GET    /api/ticketcomment?ticketId={id}     # Get comments for ticket
POST   /api/ticketcomment                   # Add comment
PUT    /api/ticketcomment/{id}              # Update comment
DELETE /api/ticketcomment/{id}              # Delete comment
```

### 📜 History

```http
GET    /api/tickethistory?ticketId={id}     # Get ticket history
GET    /api/tickethistory/{id}              # Get history entry
```

---

## 📊 Analytics Endpoints

### Most Common Hardware Failure

Identifies the most frequently reported issue within a specific category.

```http
GET /api/analytics/hardware/most-common?categoryName=Hardware
```

**Response:**
```json
{
  "failureName": "Hard Drive Failure",
  "count": 42
}
```

**Use Cases:**
- Identify recurring hardware issues
- Plan preventive maintenance
- Budget for hardware replacements
- Vendor quality assessment

---

### Top Department by Ticket Volume

Returns the department that submits the most support tickets.

```http
GET /api/analytics/departments/top
```

**Response:**
```json
{
  "departmentId": 3,
  "departmentName": "Engineering",
  "ticketsCount": 187
}
```

**Use Cases:**
- Resource allocation planning
- Identify departments needing additional IT training
- Support team staffing decisions
- Department-specific infrastructure improvements

---

### Average Resolution Time

Calculates the mean time between ticket submission and resolution.

```http
GET /api/analytics/tickets/average-resolution-time
```

**Response:**
```json
{
  "averageMinutes": 453.5,
  "average": "0d 7h 33m"
}
```

**Use Cases:**
- SLA compliance monitoring
- Team performance tracking
- Process efficiency measurement
- Capacity planning

**Note:** Only includes tickets with both `SubmittedAt` and `ResolvedAt` populated.

---

## 🔌 Dependency Injection Setup

All services are registered in `Program.cs`:

```csharp
// Core Services
builder.Services.AddScoped<ITicketService, TicketService>();
builder.Services.AddScoped<ITicketCategoryService, TicketCategoryService>();
builder.Services.AddScoped<ITicketPriorityService, TicketPriorityService>();
builder.Services.AddScoped<ITicketStatusService, TicketStatusService>();
builder.Services.AddScoped<ITicketCommentsService, TicketCommentsService>();
builder.Services.AddScoped<ITicketHistoryService, TicketHistoryService>();

// People Services
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IDepartmentService, DepartmentService>();
builder.Services.AddScoped<ISupportAgentService, SupportAgentService>();

// Analytics Service (to be implemented)
builder.Services.AddScoped<IAnalyticsService, AnalyticsService>();

// Database Context
builder.Services.AddDbContext<TicketContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
```

---

## ⚠️ Known Considerations

### Data Quality Requirements
- **Resolution Time Analytics**: Requires both `SubmittedAt` and `ResolvedAt` to be populated
- **Category Analysis**: Grouping is based on `Ticket.Name` field - consider using a dedicated `FailureType` field for more granular tracking

### Type Consistency
- Consider aligning timestamp types across the system:
  - `Ticket.SubmittedAt`: `DateTimeOffset?`
  - `Ticket.ResolvedAt`: `DateTime?`
  - `TicketHistory.Timestamp`: Review for consistency

### Performance Optimization
- Add indexes on frequently queried columns:
  - `Ticket.TicketCategoryId`
  - `Ticket.TicketStatusId`
  - `Ticket.EmployeeId`
  - `Employee.DepartmentId`

### Security Enhancements (Future)
- Implement authentication (JWT Bearer tokens)
- Add authorization policies for role-based access
- Validate input with FluentValidation
- Implement rate limiting

---

## 🧪 Testing the API

### Using Swagger UI
1. Run the application
2. Navigate to `https://localhost:5001/swagger`
3. Explore and test all endpoints interactively

### Using the HTTP File
1. Open `Ticket Management System.http` in Visual Studio 2022+
2. Execute requests directly from the IDE

### Sample Test Flow
```http
# 1. Create a department
POST https://localhost:5001/api/department
Content-Type: application/json

{ "name": "IT Support" }

# 2. Create an employee
POST https://localhost:5001/api/employee
Content-Type: application/json

{ "name": "John Doe", "email": "john@company.com", "departmentId": 1 }

# 3. Create a ticket
POST https://localhost:5001/api/ticket
Content-Type: application/json

{
  "name": "Printer not working",
  "description": "Office printer on 3rd floor not responding",
  "employeeId": 1,
  "ticketCategoryId": 1,
  "ticketPriorityId": 2,
  "ticketStatusId": 1
}

# 4. Get analytics
GET https://localhost:5001/api/analytics/departments/top
```

---

## 📚 Additional Resources

- [ASP.NET Core Documentation](https://learn.microsoft.com/en-us/aspnet/core/)
- [Entity Framework Core Docs](https://learn.microsoft.com/en-us/ef/core/)
- [.NET 8 Release Notes](https://learn.microsoft.com/en-us/dotnet/core/whats-new/dotnet-8)
- [Clean Architecture Principles](https://blog.cleancoder.com/uncle-bob/2012/08/13/the-clean-architecture.html)

---

## 🤝 Contributing

When extending this system, follow these guidelines:

1. **Maintain Layer Separation**: Keep Controllers thin, put logic in Services
2. **Use DTOs**: Never expose domain models directly through APIs
3. **Follow Naming Conventions**: Match existing patterns for consistency
4. **Add Migrations**: Always create migrations for model changes
5. **Document Endpoints**: Update this README when adding new endpoints
6. **Write Tests**: Consider adding unit tests for business logic

---

## 📄 License

This project is provided as-is for educational and commercial use.

---

## 📞 Support

For issues or questions:
- Check the Swagger documentation at `/swagger`
- Review the migration history in the `Migrations` folder
- Examine the `TicketContext` for database schema details

---

**Built with ❤️ using .NET 8 and Clean Architecture principles**
