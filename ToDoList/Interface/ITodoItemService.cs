using System.Collections.Generic;
using ToDoList;

public interface IAddressService
{
    Task<List<TodoItem>> GetAllTodoItem();
    Task<TodoItem> GetTodoItem(int id);
    Task<TodoItem> CreateTodoItem(TodoItem todoItem);
    Task<TodoItem> UpdateTodoItem(int id);
    Task<TodoItem> DeleteTodoItem(int id);


}