using System.Data.Entity;
using Microsoft.EntityFrameworkCore;
using ToDoList.Core.Entities;
using ToDoList.Core.Interfaces;
using ToDoList.Data;

namespace ToDoList.Core.Repositories
{
    public class TodoRepository : ITodoRepository
    {
        private readonly DatabaseContext _context;
        public TodoRepository(DatabaseContext context)  
        {
            _context = context;
        }
        public async Task AddAsync(ToDoItem item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }
            await _context.ToDos.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var todo = await _context.ToDos.FindAsync(id);
            if(todo != null)
            {
            _context.ToDos.Remove(todo);
            await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Item not found");
            }
        }

        public async Task<List<ToDoItem>> GetAllTodosAsync()
        {
            return await _context.ToDos.ToListAsync();
        }

        public async Task<ToDoItem> GetById(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("ID must be greater than zero.",nameof(id));
            }
            return await _context.ToDos.FirstAsync(x=>x.Id==id);
        }
        
        public async Task UpdateAsync(ToDoItem item)
        {
            var todo = _context.ToDos.Find(item.Id);
            if (todo != null)
            {
                todo.Name = item.Name;
                todo.Description = item.Description;
                todo.IsCompleted = item.IsCompleted;
                _context.ToDos.Update(todo);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Item not found");
            }
        }
    }
}
