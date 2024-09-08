
using System.Text.Json;
using TestTask.BL.Models;

namespace TodoTestTask.BL.Model
{
    public class TODO
    {
        public Project Projects { get; }
        public string NameTask { get; set; }
        public string Condition { get; set; }


        public TODO(string nameTask, string condition, string project)
        {
            NameTask = nameTask;
            Condition = condition;
            Projects = new Project(project);
        }
        public TODO() { }


    }
}
