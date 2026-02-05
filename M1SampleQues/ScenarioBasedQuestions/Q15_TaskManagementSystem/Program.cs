using System;

class Program
{
    static void Main()
    {
        TaskManager manager = new TaskManager();

        // Create projects
        manager.CreateProject("Website Redesign", "Alice", DateTime.Now.AddDays(-5), DateTime.Now.AddMonths(1));
        manager.CreateProject("Mobile App Launch", "Bob", DateTime.Now, DateTime.Now.AddMonths(2));

        // Add tasks
        manager.AddTask(1, "Design Homepage", "Create new homepage layout", "High", DateTime.Now.AddDays(3), "Charlie");
        manager.AddTask(1, "Update Content", "Update all website content", "Medium", DateTime.Now.AddDays(5), "Dave");
        manager.AddTask(2, "API Integration", "Integrate payment API", "High", DateTime.Now.AddDays(7), "Charlie");
        manager.AddTask(2, "Testing", "Perform QA tests", "Low", DateTime.Now.AddDays(10), "Eve");

        // Group tasks by priority
        var grouped = manager.GroupTasksByPriority();
        Console.WriteLine("\nTasks Grouped by Priority:");
        foreach (var group in grouped)
        {
            Console.WriteLine($"\nPriority: {group.Key}");
            foreach (var task in group.Value)
            {
                Console.WriteLine($"Task: {task.Title}, AssignedTo: {task.AssignedTo}, Due: {task.DueDate}");
            }
        }

        // Overdue tasks
        var overdue = manager.GetOverdueTasks();
        Console.WriteLine("\nOverdue Tasks:");
        foreach (var task in overdue)
        {
            Console.WriteLine($"Task: {task.Title}, AssignedTo: {task.AssignedTo}, Due: {task.DueDate}");
        }

        // Tasks by assignee
        var charlieTasks = manager.GetTasksByAssignee("Charlie");
        Console.WriteLine("\nTasks Assigned to Charlie:");
        foreach (var task in charlieTasks)
        {
            Console.WriteLine($"Task: {task.Title}, Priority: {task.Priority}, Status: {task.Status}");
        }
    }
}
