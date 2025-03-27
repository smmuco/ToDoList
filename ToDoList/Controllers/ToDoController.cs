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
        // Add GET action
        public IActionResult Create()
        {
            return View();
        }
        // Add POST action
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
            var todo = _todoRepository.GetById(id);
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
        // Edit GET action
        public IActionResult Update(int id)
        {
            var todo = _todoRepository.GetById(id);
            if (todo == null)
            {
                return NotFound();
            }
            return View(todo);
        }
        // Edit POST action
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

        public IActionResult Index()
        {
            var todos = _todoRepository.GetAllTodosAsync();
            return View(todos);
        }
    }
}
