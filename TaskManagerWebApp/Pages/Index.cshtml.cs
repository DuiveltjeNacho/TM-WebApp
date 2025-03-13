using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TaskManagerWebApp.Models;

namespace TaskManagerWebApp.Pages;

public class IndexModel : PageModel
{
    private readonly TaskManager _taskManager;

    public List<Models.Task> Tasks { get; set; }

    public IndexModel(TaskManager taskManager)
    {
        _taskManager = taskManager;
    }

    public int Number { get; set; }
    [BindProperty]
    public string? Name { get; set; }
    [BindProperty]
    public string? Description { get; set; }
    [BindProperty]
    public DateTime DueDate { get; set; } = DateTime.Today;
    public bool IsCompleted { get; set; }
    
    public void OnGet()
    {
        Tasks = _taskManager.GetTasks();
    }

    public IActionResult OnPostAddTask()
    {
        _taskManager.AddTask(Name, Description, DueDate);
        Tasks = _taskManager.GetTasks();
        return RedirectToPage();
    }

    public IActionResult OnPostDeleteTask(int taskNumber)
    {
        _taskManager.DeleteTask(taskNumber);
       
        Tasks = _taskManager.GetTasks(); 

        return RedirectToPage();
    }

    public IActionResult OnPostToggleCompleteTask(int taskNumber)
    {
        _taskManager.ToggleTaskCompletion(taskNumber);
        Tasks = _taskManager.GetTasks();

        return RedirectToPage();
    }
}
