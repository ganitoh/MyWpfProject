using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWpfProject.core.model
{
    public class MyTask
    {
        public int ID { get; set; }
        public int UserId { get; set; }
        public DateTime DateCreate { get; set; }
        public DateTime Deadline { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }

        public MyTask(int userId,DateTime deadLine, string taskText, string title)
        {
            this.UserId = userId;
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
