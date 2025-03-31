using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Core.Entities;
using ToDoList.Core.Interfaces;
using ToDoList.Models;

namespace ToDoList.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ITodoRepository _todoRepository;

        public HomeController(ILogger<HomeController> logger, ITodoRepository todoRepository)
        {
            _logger = logger;
            _todoRepository = todoRepository;
        }

        public async Task<IActionResult> IndexAsync()
        {
            var todos = await _todoRepository.GetAllTodosAsync();
            if (todos == null)
            {
                todos = new List<ToDoItem>();
            }
            return View(todos);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
