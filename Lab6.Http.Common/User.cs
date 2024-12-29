namespace Lab6.Http.Common;

public class TaskItem
{
    public TaskItem()
    {
    }

    public TaskItem(int id, string name, string active)
    {
        Id = id;
        Name= name;
        Active = active;

    }

    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Active { get; set; } = string.Empty;

}
