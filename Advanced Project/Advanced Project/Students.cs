using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_Project
{
    class Students
    {
        private string name;
        private List<string> tasks = new List<string>();

        public Students(string name)
        {
            this.name = name;
        }

        public string getName()
        {
            return name;
        }

        public bool isTasking(string task)
        {
            if(tasks.Contains(task))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool addTask(string task)
        {
            if (!tasks.Contains(task))
            {
                tasks.Add(task);
                return true;
            }
            else
            {
                return false;
            }
        }
        

        public bool stopTasking(string task)
        {
            if (tasks.Contains(task))
            {
                tasks.Remove(task);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
