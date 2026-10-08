using TodoAppWebApi.Enum;

namespace TodoAppWebApi.Models;

public class TaskModel
{
    public int Id { get; set; }
    public string Task { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public TaskPriority Priority { get; set; }
    public Enum.TaskStatus Status { get; set; }
    public DateTime DueDate { get; set; }
}
