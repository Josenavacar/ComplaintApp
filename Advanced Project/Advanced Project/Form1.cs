using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Advanced_Project
{
    public partial class Form1 : Form
    {
        Students lastClean, lastTask;
        List<Students> Clients = new List<Students>();

        List<string> Students = new List<string>();
        List<int> Cleaner = new List<int>();
        List<int> Garbager = new List<int>();
        List<int> ComplaintCount = new List<int>();
        private int time = 0;
        private int next_student_cl = 1;
        private int next_student_gb = 2;
        string clbPrint;

        public Form1()
        {
            InitializeComponent();
            Start();
        }

        private void Start()
        {
            tabControl1.TabPages.Clear();
            tabControl1.TabPages.Add(tabStart);
        }

        private string clbPrinting()
        {
            foreach (string a in clbStudents.CheckedItems)
            {
                clbPrint += a + ", ";
            }
            clbPrint = clbPrint.Remove(clbPrint.Length - 2);
            return clbPrint;
        }

        private void DisplayItemListBox()
        {
            foreach (string a in lbHiddenDisplayItems.Items)
            {
                if (a.Contains(cbDisplay.Text))
                {
                    int b = a.IndexOf("€");
                    b++;
                    lbDisplayItems.Items.Add(a.Substring(0, b));
                }
            }
        }

        private void BtnCleaner_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Student: " + lblCleaner.Text + " has been reported.");
            int indexOfStudent = Students.FindIndex(c => c.Equals(lblCleaner.Text));
            int value = Cleaner[indexOfStudent];
            value++;
            Cleaner[indexOfStudent] = value;
        }

        private void BtnGarbage_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Student: " + lblGarbage.Text + " has been reported.");
            int indexOfStudent = Students.FindIndex(c => c.Equals(lblGarbage.Text));
            int value = Garbager[indexOfStudent];
            value++;
            Cleaner[indexOfStudent] = value;
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            int p = 0;
            int j = lbStudentList.Items.Count;
            int z = lbTasks.Items.Count;

            if (lbStudentList.Items.Count <= 1)
            {
                MessageBox.Show("Not enough students, for this app to function you need at least 2.");
            }
            else
            {
                while (p < j)
                {
                    Students auxStudent = new Students(lbStudentList.Items[p].ToString());
                    Clients.Add(auxStudent);
                    p++;
                }

                lastClean = Clients[0];
                lastTask = Clients[1];

                timer1.Start();
                if (lbStudentList.Items.Count >= 2)
                {
                    tabControl1.TabPages.Remove(tabStart);
                    tabControl1.TabPages.Add(tabTasks);
                    //tabControl1.TabPages.Add(tabClean);
                    //tabControl1.TabPages.Add(tabGarbage);
                    tabControl1.TabPages.Add(tabItems);
                    tabControl1.TabPages.Add(tabComplaint);
                    tabControl1.TabPages.Add(tabDisplay);
                }

                lblCleaner.Text = Students[0];
                lblGarbage.Text = Students[1];

                foreach (Students a in Clients)
                {
                    clbStudents.Items.Add(a.getName());
                    cbStudents.Items.Add(a.getName());
                    cbDisplay.Items.Add(a.getName());

                    //clbStudents.Items.Add(a);
                    //cbStudents.Items.Add(a);
                    //cbDisplay.Items.Add(a);
                }
            }

            int i = 0;
            foreach (string task in lbTasks.Items)
            {
                Clients[i].addTask(task);

                if (i == Clients.Count - 1)
                {
                    i = 0;
                }
                else
                {
                    i++;
                }
            }

            if (Clients.Count == 2)
            {

                next_student_gb = 0;
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (tbStudentName.Text.Any(c => char.IsDigit(c)) == false)
            {
                if (lbStudentList.Items.Contains(tbStudentName.Text))
                {
                    MessageBox.Show("Student already exists.");
                }
                else
                {
                    Students.Add(tbStudentName.Text);
                    Cleaner.Add(0);
                    Garbager.Add(0);
                    ComplaintCount.Add(0);
                    lbStudentList.Items.Add(tbStudentName.Text);
                }
            }
            tbStudentName.Text = "";
        }

        private void BtnRemove_Click(object sender, EventArgs e)
        {
            string student = Convert.ToString(lbStudentList.SelectedItem);
            if (student != "")
            {
                Students.Remove(student);
                Cleaner.Remove(0);
                Garbager.Remove(0);
                ComplaintCount.Remove(0);
                lbStudentList.Items.Remove(student);
            }
            else if (student == "")
            {
                Students.Remove(tbStudentName.Text);
                Cleaner.Remove(0);
                Garbager.Remove(0);
                ComplaintCount.Remove(0);
                lbStudentList.Items.Remove(tbStudentName.Text);
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            timer1.Stop();
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            time += 1;
            lblTimeTask.Text = Convert.ToString(time);
            lblTimeGarbage.Text = Convert.ToString(time);
            lblTimeCleaning.Text = Convert.ToString(time);
            if (time % 10 == 0)
            {
                //int items = lbTasks.Items.Count;

                //foreach(Students student in Clients)
                //{
                //    foreach(string task in lbTasks.Items)
                //    {
                //        if(student.isTasking(task))
                //        {
                //            int aux = lbTasks.Items.IndexOf(task);
                //            student.stopTasking(task);
                //            Students newTasker = previousStudent(student.getName());
                //            newTasker.addTask(task);
                //        }
                //    }
                //}

                //for (int i = 0; i < items; i++)
                //{
                //    string task = lbTasks.Items[i].ToString();

                //    lbDebug.Items.Add(task);

                //    aux = lbTasks.Items.IndexOf(task) + 1;

                //    if (aux >= lbTasks.Items.Count)
                //    {
                //        aux = 0;
                //    }

                //    lbDebug.Items.Add(aux);

                //    lbTasks.SelectedItem = lbTasks.Items[i];
                //    string tasker = lblTasking.Text;

                //    lbDebug.Items.Add(tasker);

                //    Students working = getStudent(tasker);
                //    working.stopTasking(task);
                //    working.addTask(lbTasks.Items[aux].ToString());
                //}


                //foreach(string task in lbTasks.Items)
                //{
                //    aux = lbTasks.Items.IndexOf(task) + 1;
                //    if(aux >= lbTasks.Items.Count)
                //    {
                //        aux = 0;
                //    }

                //    lbTasks.SelectedItem = task;
                //    string tasker = lblTasking.Text;
                //    Students working = getStudent(tasker);
                //    working.stopTasking(task);
                //    working.addTask(lbTasks.Items[aux].ToString());
                //}

                lblCleaner.Text = Students[next_student_cl];
                lblGarbage.Text = Students[next_student_gb];
                next_student_gb++;
                next_student_cl++;
                if (next_student_gb >= Students.Count)
                {
                    next_student_gb = 1;
                }

                if(next_student_cl >= Students.Count)
                {
                    next_student_cl = 0;
                }
            }
        }

        private void BtnSubmit_Click(object sender, EventArgs e)
        {
            if (tbComplaint.TextLength > 0 && cbStudents.SelectedItem != null)
            {
                MessageBox.Show("Your complaint has been sent.");
                int indexOfStudent = Students.FindIndex(c => c.Equals(cbStudents.Text));
                int value = ComplaintCount[indexOfStudent];
                value++;
                ComplaintCount[indexOfStudent] = value;
            }
            else if (tbComplaint.TextLength < 5)
            {
                MessageBox.Show("Error! Your complaint is too short.");
            }
            else if (cbStudents.SelectedItem == null)
            {
                MessageBox.Show("You have to pick a student you would like to report.");
            }
        }

        private void BtnItems_Click(object sender, EventArgs e)
        {
            if (lbItems.SelectedIndex > -1 && tbItemPrice.Text != "" && clbStudents.CheckedItems.Count > 0)
            {
                MessageBox.Show("Your complaint has been sent.");
                lbHiddenDisplayItems.Items.Add("Item: " + Convert.ToString(lbItems.SelectedItem) + " - Price: " + tbItemPrice.Text + " € " + " - Student(s) who didn't pay: " + clbPrinting());
                clbPrint = "";
            }
        }

        private void CbDisplay_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbDisplay.Items.Clear();
            lbDisplay.Items.Add("Number of times reported for not cleaning => " + Cleaner[cbDisplay.SelectedIndex]);
            lbDisplay.Items.Add("Number of times reported for not taking out the garbage => " + Garbager[cbDisplay.SelectedIndex]);
            lbDisplay.Items.Add("Number of times custom report has been made => " + ComplaintCount[cbDisplay.SelectedIndex]); 

            lbDisplayItems.Items.Clear();
            DisplayItemListBox();
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            if (lbItems.Items.Contains(tbGrocer.Text))
            {
                MessageBox.Show("Item already listed.");
            }
            else
            {
                lbItems.Items.Add(tbGrocer.Text);
            }

            tbGrocer.Text = "";
        }

        private void btnDelItem_Click(object sender, EventArgs e)
        {
            if (tbGrocer.Text == "")
            {
                if (lbItems.SelectedItem != null)
                {
                    int aux = lbItems.SelectedIndex;
                    lbItems.Items.RemoveAt(aux);
                }
                else
                {
                    MessageBox.Show("Select an item please.");
                }
            }
            else
            {
                if (!lbItems.Items.Contains(tbGrocer.Text))
                {
                    MessageBox.Show("Item not listed.");
                }
                int index = lbItems.Items.IndexOf(tbGrocer.Text);
                lbItems.Items.RemoveAt(index);
            }
            tbGrocer.Text = "";
        }

        private void lbTasks_SelectedIndexChanged(object sender, EventArgs e)
        {
            string res = "";
            foreach(Students student in Clients)
            {
                if(student.isTasking(lbTasks.SelectedItem.ToString()))
                {
                    res = student.getName();
                }
            }

            lblTasking.Text = res;
        }

        private void btnAddCleaning_Click(object sender, EventArgs e)
        {
            string cleaning = tbCleaning.Text;

            lbTasks.SelectedIndex = lbTasks.Items.Count - 1;
            string aux1 = lblTasking.Text;
            Students next = nextStudent(aux1);
            int auxnext = Clients.IndexOf(next);

            if (lbTasks.Items.Contains(cleaning))
            {
                MessageBox.Show("That task is already listed");
            }
            else if(cleaning.Length <= 3)
            {
                MessageBox.Show("Insufficient characters");
            }
            else
            {
                lbTasks.Items.Add(cleaning);
                Clients[auxnext].addTask(cleaning);
            }
        }
        
        private Students nextStudent(string student)
        {
            int aux = 0;
            foreach(Students client in Clients)
            {
                if(client.getName() == student)
                {
                    aux = Clients.IndexOf(client);
                }
            }

            if(aux == Clients.Count - 1)
            {
                return Clients[0];
            }
            else
            {
                return Clients[aux + 1];
            }
        }

        private Students previousStudent(string student)
        {
            int aux = 0;
            foreach (Students client in Clients)
            {
                if (client.getName() == student)
                {
                    aux = Clients.IndexOf(client);
                }
            }

            if (aux == 0)
            {
                return Clients[Clients.Count - 1];
            }
            else
            {
                return Clients[aux - 1];
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int items = lbTasks.Items.Count;
            int aux = 0;
            for (int i = 0; i < items; i++)
            {
                string task = lbTasks.Items[i].ToString();


                aux = lbTasks.Items.IndexOf(task) + 1;

                if (aux >= lbTasks.Items.Count)
                {
                    aux = 0;
                }

                lbTasks.SelectedItem = lbTasks.Items[i];
                string tasker = lblTasking.Text;

                Students working = getStudent(tasker);
                working.stopTasking(task);
                working.addTask(lbTasks.Items[aux].ToString());
            }
        }

        private void btnRemoveCleaning_Click(object sender, EventArgs e)
        {
            if (lbTasks.Items.Count == 2)
            {
                MessageBox.Show("Can't have less than two tasks");
            }
            else
            {
                int aux = lbTasks.SelectedIndex;
                if (lbTasks.SelectedIndex != lbTasks.Items.Count - 1)
                {
                    lbTasks.SelectedIndex = lbTasks.SelectedIndex + 1;
                }
                else
                {
                    lbTasks.SelectedIndex = 0;
                }
                lbTasks.Items.RemoveAt(aux);
            }

        }

        private Students getStudent(string name)
        {
            Students res = null;
            foreach(Students client in Clients)
            {
                if(client.getName() == name)
                {
                    return client;
                }
            }

            return res;
        }
    }
}
