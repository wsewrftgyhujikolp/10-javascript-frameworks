public class TodoListViewModel
{
    public List<TodoItem> Todos { get; set; }
}

public class TodoItem
{
    public string Text { get; set; }
    public bool IsDone { get; set; }
    public int Id { get; set; }
}