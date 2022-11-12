using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWpfProject.model
{
    public class MyTask
    {
        public int ID { get; set; }
        public DateTime DateCreate { get; set; }
        public DateTime Deadline { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }

        public MyTask(DateTime deadLine, string taskText, string title)
        {
            this.DateCreate = DateTime.Now;
            this.Description = taskText;
            this.Deadline = deadLine;
            this.Title = title;
        }
        public MyTask()
        {

        }

        public TimeSpan GetRemainingTime() => Deadline - DateCreate;
    }
}
