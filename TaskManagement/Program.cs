using Microsoft.EntityFrameworkCore;
using TaskManagement.Data;
using TaskManagement.Models;
using TaskManagement.Data;
using TaskManagement.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// CORS - allow the React Vite app
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp", policy =>
    {
        policy.WithOrigins("http://localhost:5176")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

// Database
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Enable CORS
app.UseCors("AllowReactApp");

// Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

// Seed data
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

    if (!context.Users.Any())
    {
        var users = new List<User>
        {
            new User
            {
                Name = "Alice Johnson",
                Email = "alice@example.com",
                PasswordHash = "demo123"
            },
            new User
            {
                Name = "Bob Smith",
                Email = "bob@example.com",
                PasswordHash = "demo123"
            },
            new User
            {
                Name = "Emma Davis",
                Email = "emma@example.com",
                PasswordHash = "demo123"
            },
            new User
            {
                Name = "John Wilson",
                Email = "john@example.com",
                PasswordHash = "demo123"
            },
            new User
            {
                Name = "Sophia Brown",
                Email = "sophia@example.com",
                PasswordHash = "demo123"
            }
        };

        context.Users.AddRange(users);
        context.SaveChanges();

        var projects = new List<Project>
        {
            new Project
            {
                Name = "Website Redesign",
                Description = "Redesign the company website."
            },
            new Project
            {
                Name = "Mobile App",
                Description = "Develop a mobile application."
            },
            new Project
            {
                Name = "Marketing Dashboard",
                Description = "Build a dashboard for marketing analytics."
            }
        };

        context.Projects.AddRange(projects);
        context.SaveChanges();

        var tasks = new List<TaskItem>
        {
            new TaskItem
            {
                Title = "Design homepage",
                Description = "Create the homepage layout.",
                Status = "In Progress",
                Priority = "High",
                DueDate = DateTime.UtcNow.AddDays(5),
                ProjectId = projects[0].Id,
                AssignedUserId = users[0].Id
            },
            new TaskItem
            {
                Title = "Create navigation",
                Description = "Implement the website navigation.",
                Status = "Todo",
                Priority = "Medium",
                DueDate = DateTime.UtcNow.AddDays(7),
                ProjectId = projects[0].Id,
                AssignedUserId = users[1].Id
            },
            new TaskItem
            {
                Title = "Fix login bug",
                Description = "Fix authentication issue.",
                Status = "Todo",
                Priority = "High",
                DueDate = DateTime.UtcNow.AddDays(2),
                ProjectId = projects[1].Id,
                AssignedUserId = users[2].Id
            },
            new TaskItem
            {
                Title = "Create dashboard UI",
                Description = "Build the main dashboard interface.",
                Status = "In Progress",
                Priority = "High",
                DueDate = DateTime.UtcNow.AddDays(4),
                ProjectId = projects[2].Id,
                AssignedUserId = users[3].Id
            },
            new TaskItem
            {
                Title = "Write documentation",
                Description = "Document the main features.",
                Status = "Done",
                Priority = "Low",
                DueDate = DateTime.UtcNow.AddDays(-1),
                ProjectId = projects[2].Id,
                AssignedUserId = users[4].Id
            }
        };

        context.Tasks.AddRange(tasks);
        context.SaveChanges();
    }
}

app.Run();