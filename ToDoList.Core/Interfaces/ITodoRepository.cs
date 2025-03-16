using ToDoList.Core.Entities;

namespace ToDoList.Core.Interfaces
{
    public interface ITodoRepository
    {
        public Task<List<ToDoItem>> GetAllTodosAsync();
        public Task<ToDoItem> GetById(int id);
        Task AddAsync(ToDoItem item);
        public Task UpdateAsync(ToDoItem item);
        Task DeleteAsync(int id);
    }
}
