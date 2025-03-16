using ToDoList.Core.Entities;

namespace ToDoList.Core.Interfaces
{
    public interface ITodoRepository
    {
        List<ToDoItem>GetAllTodos();
        ToDoItem GetById(int id);
        void Add(ToDoItem item);
        void Update(ToDoItem item);
        void Delete(int id);
    }
}
