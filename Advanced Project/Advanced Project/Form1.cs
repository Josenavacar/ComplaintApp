using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Advanced_Project
{
    public partial class Form1 : Form
    {

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


        private void LblGarbage_Click(object sender, EventArgs e)
        {

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
            if (lbStudentList.Items.Count <= 1)
            {
                MessageBox.Show("Not enough students, for this app to function you need at least 2.");
            }
            else
            {
                timer1.Start();
                if (lbStudentList.Items.Count >= 2)
                {
                    tabControl1.TabPages.Remove(tabStart);
                    tabControl1.TabPages.Add(tabClean);
                    tabControl1.TabPages.Add(tabGarbage);
                    tabControl1.TabPages.Add(tabItems);
                    tabControl1.TabPages.Add(tabComplaint);
                    tabControl1.TabPages.Add(tabDisplay);
                }

                lblCleaner.Text = Students[0];
                lblGarbage.Text = Students[1];

                foreach (string a in Students)
                {
                    clbStudents.Items.Add(a);
                    cbStudents.Items.Add(a);
                    cbDisplay.Items.Add(a);
                }
            }

            if (Students.Count == 2)
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
            lblTimeCleaning.Text = Convert.ToString(time);
            lblTimeGarbage.Text = Convert.ToString(time);
            if (time % 10 == 0)
            {
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
            if (tbComplaint.TextLength > 10 && cbStudents.SelectedItem != null)
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
    }
}
