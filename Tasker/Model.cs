namespace Tasker;

public class ToDoList
{
    public int ToDoListId { get; set; }
    public string? ListName { get; set; }

    public List<Task> Tasks { get; } = new();
}

public class Task
{
    public int TaskId { get; set; }
    public string? TaskDescription { get; set; }
    public Boolean TaskComplete { get; set; }

    public int ToDoListId { get; set; }
    public ToDoList? ToDoList { get; set; }
}
