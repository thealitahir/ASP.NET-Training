using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskCRUD.Models
{
    public interface ITaskContext
    {
        public void Add(Task task);
        public List<Task> getTasks();
        public Models.Task getTaskById(int? id);
        public void editTask(Models.Task task);
        public void deleteTask(int? id);
        public bool taskExists(int id);
        public List<Task> search(string searchString);
    }
}
