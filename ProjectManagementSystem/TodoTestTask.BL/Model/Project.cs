using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoTestTask.BL.Model
{
    public class Project
    {
        private const string FilePath = "users.json";
        public string NameProjects { get; set; }

        public Project() { }

        public Project(string nameProject)
        {
            NameProjects = nameProject;
            string TasksList = JsonConvert.SerializeObject(NameProjects);
            File.WriteAllText(FilePath, TasksList);
        }

    }
}
