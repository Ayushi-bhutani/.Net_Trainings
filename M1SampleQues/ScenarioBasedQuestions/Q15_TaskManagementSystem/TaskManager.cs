using System;
using System.Collections.Generic;
using System.Linq;

public class TaskManager
{
    private List<Project> projects = new List<Project>();
    private int taskCounter = 1;
    private int projectCounter = 1;

    // Create a new project
    public void CreateProject(string name, string manager, DateTime start, DateTime end)
    {
        projects.Add(new Project(projectCounter++, name, manager, start, end));
        Console.WriteLine($"Project '{name}' created successfully.");
    }

    // Add task to a project
    public void AddTask(int projectId, string title, string description, string priority, DateTime dueDate, string assignee)
    {
        var project = projects.FirstOrDefault(p => p.ProjectId == projectId);
        if (project == null)
        {
            Console.WriteLine("Project not found.");
            return;
        }

        project.Tasks.Add(new TaskItem(taskCounter++, title, description, priority, dueDate, assignee));
        Console.WriteLine($"Task '{title}' added to project '{project.ProjectName}'.");
    }

    // Group tasks by priority
    public Dictionary<string, List<TaskItem>> GroupTasksByPriority()
    {
        return projects.SelectMany(p => p.Tasks)
                       .GroupBy(t => t.Priority)
                       .ToDictionary(g => g.Key, g => g.ToList());
    }

    // Get overdue tasks
    public List<TaskItem> GetOverdueTasks()
    {
        return projects.SelectMany(p => p.Tasks)
                       .Where(t => t.DueDate < DateTime.Now && t.Status != "Completed")
                       .ToList();
    }

    // Get tasks by assignee
    public List<TaskItem> GetTasksByAssignee(string assigneeName)
    {
        return projects.SelectMany(p => p.Tasks)
                       .Where(t => t.AssignedTo.Equals(assigneeName, StringComparison.OrdinalIgnoreCase))
                       .ToList();
    }
}
