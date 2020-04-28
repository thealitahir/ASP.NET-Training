using Microsoft.AspNetCore.Mvc;
using TaskCRUD.Models;

namespace TaskCRUD.Controllers
{
    public class TasksController : Controller
    {
        private readonly ITaskContext _tasksList;

        public TasksController(ITaskContext tasksList)
        {
            _tasksList = tasksList;
        }

        [HttpGet]
        public IActionResult Index(string searchString)
        {
            if (searchString != null)
            {
                return View(_tasksList.search(searchString));
            }
            return View(_tasksList.getTasks());
        }

        // GET: Tasks/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var task = _tasksList.getTaskById(id);
            if (task == null)
            {
                return NotFound();
            }

            return View(task);
        }

        // GET: Tasks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tasks/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Title,Description,Status,Priority")] Task task)
        {
            if (ModelState.IsValid)
            {
                _tasksList.Add(task);
                return RedirectToAction(nameof(Index));
            }
            return View(task);
        }

        // GET: Tasks/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var task = Tasks.Find(item => item.Id == id); ;
            var task = _tasksList.getTaskById(id);
            if (task == null)
            {
                return NotFound();
            }
            return View(task);
        }

        // POST: Tasks/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Title,Description,Status,Priority")] Task task)
        {
            if (id != task.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _tasksList.editTask(task);
                return RedirectToAction(nameof(Index));
            }
            return View(task);
        }

        // GET: Tasks/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var task = _tasksList.getTaskById(id);
            if (task == null)
            {
                return NotFound();
            }

            return View(task);
        }

        // POST: Tasks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _tasksList.deleteTask(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Search(string searchString)
        {
            return View(searchString);
        }

        private bool TaskExists(int id)
        {
            return _tasksList.taskExists(id);
        }
    }
}