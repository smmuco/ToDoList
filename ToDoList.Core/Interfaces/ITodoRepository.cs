using ToDoList.Core.Entities;

namespace ToDoList.Core.Interfaces
{
    public interface ITodoRepository
    {
        Task<List<ToDoItem>> GetAllTodosAsync();
        Task<ToDoItem> GetByIdAsync(int id);
        Task AddAsync(ToDoItem item);
        Task UpdateAsync(ToDoItem item);
        Task DeleteAsync(int id);
    }
}
