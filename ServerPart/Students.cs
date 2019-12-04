using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerPart
{
    class Students
    {
        private int ID;
        private string name;
        private List<string> itemsPaid = new List<string>();
        
        public void setName(string name)
        {
            this.name = name;
        }

        public void setID(int ID)
        {
            this.ID = ID;
        }

        public bool hasPaid(string item)
        {
            if(itemsPaid.Contains(item))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void clearList()
        {
            itemsPaid.Clear();
        }

        public void addPaid(string item)
        {
            itemsPaid.Add(item);
        }

        public void deleteItem(string item)
        {
            int aux = itemsPaid.IndexOf(item);
            itemsPaid.RemoveAt(aux);
        }

        public int getID()
        {
            return ID;
        }

        public string getName()
        {
            return name;
        }
    }
}
