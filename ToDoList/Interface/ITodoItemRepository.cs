using ToDoList;

public interface ITodoItemRepository
{
    Task<List<TodoItem>> GetAllTodoItems();
    Task<TodoItem> GetTodoItem(int id);
    Task<TodoItem> CreateTodoItem(TodoItem todoItem);
    Task<TodoItem> UpdateTodoItem(string TodoItem, TodoItem todoItem);
    Task<TodoItem> DeleteTodoItem(TodoItem todoItem);

    Task<TodoItem> FindTodoItemByName(string todoItemName);
    Task<TodoItem> FindTodoItemByDate(DateTime dateTime);

    
}