namespace ToDoList;

public class Account
{
    
    public int Id { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public virtual List<TodoItem> TodoItems { get; set; }
    public User user{get; set;}
    
    public Account()
    {
        TodoItems = new List<TodoItem>();
    }
    
}