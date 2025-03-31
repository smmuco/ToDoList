using Microsoft.AspNetCore.Mvc;
using ToDoList.Core.Entities;
using ToDoList.Core.Interfaces;


namespace ToDoList.WebUI.Controllers
{
    public class ToDoController : Controller
    {
        private readonly ITodoRepository _todoRepository;
        public ToDoController(ITodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }

        // Create GET action
        public IActionResult Create()
        {
            return View();
        }

        // Create POST action
        [HttpPost]
        public async Task<IActionResult> CreateAsync(ToDoItem todo)
        {
            if (ModelState.IsValid)
            {
                await _todoRepository.AddAsync(todo);
                return RedirectToAction(nameof(Index));
            }
            return View(todo);
        }

        // Delete GET action  
        public IActionResult Delete(int id)
        {
            var todo = _todoRepository.GetByIdAsync(id);
            if (todo == null)
            {
                return NotFound();
            }
            return View(todo);
        }

        // Delete POST action
        [HttpPost]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _todoRepository.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        // Update GET action
        public IActionResult Update(int id)
        {
            var todo = _todoRepository.GetByIdAsync(id);
            if (todo == null)
            {
                return NotFound();
            }
            return View(todo);
        }

        // Update POST action
        [HttpPost]
        public async Task<IActionResult> UpdateAsync(ToDoItem todo)
        {
            if (ModelState.IsValid)
            {
                await _todoRepository.UpdateAsync(todo);
                return RedirectToAction(nameof(Index));
            }
            return View(todo);
        }

        public async Task<IActionResult> Index()
        {
            var todos = await _todoRepository.GetAllTodosAsync();
            return View(todos);
        }
    }
}
