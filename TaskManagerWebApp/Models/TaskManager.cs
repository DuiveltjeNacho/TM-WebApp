namespace TaskManagerWebApp.Models
{
    public class TaskManager
    {
        private readonly TaskManagerDbContext _context;

        public TaskManager(TaskManagerDbContext context)
        {
            _context = context;
        }

        public void AddTask(string name, string description, DateTime dueDate)
        {
            var newTask = new Task
            {
                Name = name,
                Description = description,
                DueDate = dueDate,
                IsCompleted = false
            };

            _context.Tasks.Add(newTask);
            _context.SaveChanges();
        }

        public void DeleteTask(int taskId)
        {
            Task task = _context.Tasks.Find(taskId);

            if (task != null)
            {
                _context.Tasks.Remove(task);
                _context.SaveChanges();
            }
        }

        public List<Task> GetTasks()
        {
            return _context.Tasks.ToList();
        }

        public void ToggleTaskCompletion(int taskId)
        {
            var task = _context.Tasks.Find(taskId);
            if (task != null)
            {
                task.IsCompleted = !task.IsCompleted; 
                _context.SaveChanges();
            }
        }
    }
}

