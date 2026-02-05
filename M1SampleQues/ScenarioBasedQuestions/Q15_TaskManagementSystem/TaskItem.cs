using System;

public class TaskItem
{
    public int TaskId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Priority { get; set; } // High / Medium / Low
    public string Status { get; set; }   // ToDo / InProgress / Completed
    public DateTime DueDate { get; set; }
    public string AssignedTo { get; set; }

    public TaskItem(int taskId, string title, string description, string priority, DateTime dueDate, string assignee)
    {
        TaskId = taskId;
        Title = title;
        Description = description;
        Priority = priority;
        Status = "ToDo";
        DueDate = dueDate;
        AssignedTo = assignee;
    }
}
