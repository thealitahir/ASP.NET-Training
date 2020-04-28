using System;
using System.Collections.Generic;
using System.Linq;

namespace TaskCRUD.Models
{
    public class TasksList: ITaskContext
    {
        private readonly List<Task> Tasks;
        public TasksList()
        {
            Tasks = new List<Task>();
            for (var i = 1; i <= 10; i++)
            {
                Task oneTask = new Task();

                oneTask.Id = i;
                oneTask.Title = "Task " + i;
                oneTask.Description = "This is task " + i;
                oneTask.Status = TaskStatus.Open;
                oneTask.Priority = TaskPriority.High;
                Tasks.Add(oneTask);
            }
        }
        public void Add(Task task)
        {
            Tasks.Add(task);
        }
        public List<Task> getTasks()
        {
            return Tasks;
        }
        public Task getTaskById(int? id)
        {
            return Tasks.Find(item => item.Id == id);
        }
        public void editTask(Task task)
        {
           
            Tasks[Tasks.FindIndex(x => x.Id == task.Id)] = task;
        }
        public void deleteTask(int? id)
        {

            Tasks.Remove(Tasks[Tasks.FindIndex(x => x.Id == id)]);
        }
        public bool taskExists(int id)
        {
            if(Tasks.FindIndex(x => x.Id == id) > -1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<Task> search(string searchString)
        {
            IEnumerable<Task> results = Tasks.Where(s => s.Title.ToLower().Contains(searchString.ToLower()) );
            return results.ToList();
        }
    }
}