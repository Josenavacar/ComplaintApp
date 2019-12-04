using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServerPart
{
    public partial class Form1 : Form
    {
        List<Students> Students = new List<Students>();
        List<Items> Items = new List<Items>();
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            bool exists = false;
            string student = tbName.Text;
            Students person1 = new Students();

            foreach (Students person in Students)
            {
                if(person.getName() == student)
                {
                    exists = true;
                    person1 = person;
                }
            }

            if (exists)
            {
                person1.addPaid(tbItem.Text);

                string itemName = tbItem.Text;
                int itemPrice = Convert.ToInt32(tbPrice.Text);
                Items aux = new Items();

                aux.setName(itemName);
                aux.setPrice(itemPrice);

                Items.Add(aux);
                lbItems.Items.Add(aux.getName());
                lblPrice.Text = aux.getPrice().ToString();

                foreach(Students human in Students)
                {
                    if(!human.hasPaid(itemName))
                    {
                        lbNotPaid.Items.Add(human.getName());
                    }
                }
            }
            
        }
    }
}
