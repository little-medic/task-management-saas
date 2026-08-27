using Microsoft.AspNetCore.Mvc;
using TaskManagement.Data;

namespace TaskManagement.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DashboardController : ControllerBase
{
    private readonly AppDbContext _context;

    public DashboardController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult GetDashboard()
    {
        var dashboard = new
        {
            TotalProjects = _context.Projects.Count(),
            TotalTasks = _context.Tasks.Count(),
            TodoTasks = _context.Tasks.Count(t => t.Status == "Todo"),
            InProgressTasks = _context.Tasks.Count(t => t.Status == "In Progress"),
            DoneTasks = _context.Tasks.Count(t => t.Status == "Done")
        };

        return Ok(dashboard);
    }
}