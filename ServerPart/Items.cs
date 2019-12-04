using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerPart
{
    class Items
    {
        private int price;
        private string name;

        public void setName(string name)
        {
            this.name = name;
        }

        public void setPrice(int price)
        {
            this.price = price;
        }

        public int getPrice()
        {
            return price;
        }

        public string getName()
        {
            return name;
        }
    }
}
