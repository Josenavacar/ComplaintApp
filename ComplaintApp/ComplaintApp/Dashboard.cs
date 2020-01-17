using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;
using SimpleTCP;
using MySql.Data.MySqlClient;
using System.Text.RegularExpressions;

namespace ComplaintApp
{
    public partial class Dashboard : DevExpress.XtraEditors.XtraForm
    {
       
        private MySqlConnection con;
        private MySqlCommand cmd;
        private MySqlDataReader dr;
        private string time = DateTime.Now.ToString("HH:mm");
        private string date = DateTime.Now.ToString("dd/MM/yyyy");
        private int i = 0;
        private int seconder = 0;
        private int student_id, on_duty_today, s_complaints, nr_notcleaned, nr_notpaid, nr_paid, money_paid;
        private Int32 count, count1;
        private List<string> HouseRules;

        public Dashboard()
        {
            HouseRules = new List<string>();
            InitializeComponent();
            DevExpress.LookAndFeel.UserLookAndFeel.Default.SkinName = "The Bezier";
            UpdateAll();
            Get_ID();
            UpdateTasks();
            UpdateSharedItems();
            UpdateRules();
            TaskSystem();
            Count_Rows();
            UpdateComplains();

        }
        public void Get_ID()
        {
            cmd = new MySqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "SELECT s_id FROM students LIMIT 1;";
            dr = cmd.ExecuteReader();
            
            while (dr.Read())
            {
                var someValue = dr["s_id"];
                student_id = (int)someValue;
            }
            con.Close();
            i = student_id + 1;

        }

        public void UpdateRules()
        {
            cmd = new MySqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "SELECT house_rule FROM house_rules;";
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                var house_rules = dr["house_rule"].ToString();
                HouseRules.Add(house_rules);
            }
            con.Close();
            int i = 1;
            foreach(string aux in HouseRules)
            {
                listBoxControl5.Items.Add($"{i}. {aux}");
                i++;
            }
            
        }
        public void Count_Rows()
        {
            cmd = new MySqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "SELECT COUNT(*) FROM students;";
            count = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();
            count = count - 1;
        }
        private void Dashboard_Load(object sender, EventArgs e)
        {
            simpleButton9.Visible = false ;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            string cnumber = comboBoxEdit1.SelectedItem.ToString();
            string cnumber1 = cnumber.Substring(0, cnumber.IndexOf(" "));
            cmd = new MySqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = $"INSERT INTO complaints (date,time,username,c_against,complaint) VALUES ('{date}','{time}','{Login.user}','{cnumber}','{textBox1.Text}')";
            dr = cmd.ExecuteReader();
            dr.Close();
            cmd.CommandText = $"SELECT COUNT(*) FROM students WHERE s_firstname='{cnumber1}';";
            count1 = Convert.ToInt32(cmd.ExecuteScalar());
            dr.Close();
            cmd.CommandText = $"UPDATE students SET s_complaints='{count1}' WHERE s_firstname='{cnumber1}'";
            dr = cmd.ExecuteReader();
            MessageBox.Show("Sent");
            comboBoxEdit1.SelectedIndex = -1;
            textBox1.Clear();
            con.Close();
        }

        private void Dashboard_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
            Environment.Exit(-1);
        }
        public void UpdateAll()
        {
            String encrypted_connection = "nmoYTp8xDSccDS07cD/riQ+kmAAIG6DairNfUVJj/wWKwbDBoA8+sPAZcH5J+UvHisGwwaAPPrCYk9Z1HV+FbxG+z3WkNadnoFGEUoxtcPA=";
            encrypted_connection = Login.Decrypt(encrypted_connection, "sblw-3hn8-sqoy19");
            con = new MySqlConnection(encrypted_connection);
            cmd = new MySqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = $"SELECT * FROM students WHERE username not in (SELECT username FROM students WHERE username='admin' or  username='{Login.user}');";
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                var someValue = dr["s_firstname"];
                var someValue1 = dr["s_lastname"];
                comboBoxEdit1.Properties.Items.Add($"{someValue} {someValue1}");
                listBoxControl4.Items.Add($"{someValue} {someValue1}");
            }
            dr.Close();
            cmd.CommandText = $"SELECT * FROM students WHERE username not in (SELECT username FROM students WHERE username='admin');";
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                var someValue2 = dr["s_firstname"];
                var someValue3 = dr["s_lastname"];
                comboBoxEdit2.Properties.Items.Add($"{someValue2} {someValue3}");
            }


            con.Close();
        }
        public void UpdateTasks()
        {
            listBoxControl1.Items.Clear();
            cmd = new MySqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "SELECT task_name FROM tasks;";
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                var someValue = dr["task_name"];
                listBoxControl1.Items.Add(someValue);
            }
            con.Close();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textEdit1.Text))
            {
                MessageBox.Show("Please insert a task name! ");
            }
          
            else
                { 
                cmd = new MySqlCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = $"INSERT INTO tasks (task_name) VALUES ('{textEdit1.Text}')";
                dr = cmd.ExecuteReader();
                con.Close();
                UpdateTasks();
                textEdit1.Text = string.Empty;
            }
        }
        public void getUserData()
        {

            cmd = new MySqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "SELECT student_email,s_firstname,s_lastname FROM students;";
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
               var Email = dr["student_email"];
               var  First_Name = dr["s_firstname"];
               var  Last_name = dr["s_lastname"];
            }

            con.Close();

        }
        public void UpdateSharedItems()
        {
            checkedListBoxControl1.Items.Clear();
            cmd = new MySqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "SELECT g_name,g_price FROM groceries;";
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                var someValue = dr["g_name"];
                var SomeValue1 = dr["g_price"];
                checkedListBoxControl1.Items.Add($"{someValue} - €{SomeValue1}");
            }
            con.Close();
        }

     

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            cmd = new MySqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = $"DELETE FROM tasks WHERE task_name='{listBoxControl1.SelectedItem.ToString()}'";
            dr = cmd.ExecuteReader();
            con.Close();
            UpdateTasks();
            
        }
        public void TaskSystem()
        {
            cmd = new MySqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = $"SELECT * FROM students where on_duty_today={1};";
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                var someValue = dr["s_firstname"];
                var somevalue1 = dr["s_lastname"];
                labelControl5.Text = $"{someValue} {somevalue1}";
            }
            con.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            seconder = 0;
            
            cmd = new MySqlCommand();
            con.Open();
            cmd.Connection = con;
            
            cmd.CommandText = $"UPDATE students SET on_duty_today='0' WHERE on_duty_today='1'";
            dr = cmd.ExecuteReader();
            dr.Close();
            con.Close();
                PickAnother();

            UpdateComplains();
            UpdateTasks();
            UpdateSharedItems();
        }
        private void PickAnother()
        {
            UpdateID();
            cmd = new MySqlCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = $"SELECT * FROM students where s_id={i};";
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    dr.Close();
                    cmd.CommandText = $"UPDATE students SET on_duty_today='1' WHERE s_id='{i}'";
                    dr = cmd.ExecuteReader();
                    con.Close();
                    TaskSystem();
                }
                else
                {
                    dr.Close();
                }
                con.Close();
                i++;
            
         
        }
        public void UpdateID()
        {
            if(i > count)
            {
                Get_ID();
            }
        }
        private void seconds_Tick(object sender, EventArgs e)
        {
            seconder++;
            labelControl10.Text = seconder.ToString();
        }

      

        private void simpleButton6_Click(object sender, EventArgs e)
        {
            string checkedname = listBoxControl4.SelectedItem.ToString();
            string checkedname1 = checkedname.Substring(0, checkedname.IndexOf(" "));
            cmd = new MySqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = $"SELECT * FROM students WHERE s_firstname='{checkedname1}';";
            dr = cmd.ExecuteReader();
            if(dr.Read())
            {
                var someValue = dr["s_firstname"];
               int someValue1 = (int)dr["nr_notpaid"];
                someValue1++;
                dr.Close();
                cmd.CommandText = $"UPDATE students SET nr_notpaid='{someValue1}' WHERE s_firstname='{someValue}'";
                dr = cmd.ExecuteReader();
                con.Close();
            }
            con.Close();
            MessageBox.Show("Sent");
        }
        public void UpdateStatistics()
        {
           
            string statname = comboBoxEdit2.SelectedItem.ToString();
            string statname1 = statname.Substring(0, statname.IndexOf(" "));
            cmd = new MySqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = $"SELECT * FROM students WHERE s_firstname='{statname1}';";
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                 on_duty_today = (int)dr["on_duty_today"];
                s_complaints = (int)dr["s_complaints"];
                 nr_notcleaned = (int)dr["nr_notcleaned"];
                 nr_notpaid = (int)dr["nr_notpaid"];
                nr_paid = (int)dr["times_paid"];
                money_paid = (int)dr["total_balance"];

            }
            dr.Close();
            con.Close();
            string dutystatus = string.Empty;
            if (on_duty_today == 0)
            {
                dutystatus = "No";
            }
            else { dutystatus = "Yes";  }
            listBoxControl3.Items.Clear();
            listBoxControl3.Items.Add($"{comboBoxEdit2.SelectedItem.ToString()}'s statistics:");
            listBoxControl3.Items.Add($"Is on duty today: {dutystatus}");
            listBoxControl3.Items.Add($"Times paid for groceries: {nr_paid}");
            listBoxControl3.Items.Add($"Total money paid: €{money_paid}");
            listBoxControl3.Items.Add($"Times students complained: {s_complaints}");
            listBoxControl3.Items.Add($"Times not cleaned: {nr_notcleaned}");
            listBoxControl3.Items.Add($"Times not paid: {nr_notpaid}");
        }

        private void comboBoxEdit2_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateStatistics();
        }

        private void simpleButton7_Click(object sender, EventArgs e)
        {
            cmd = new MySqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = $"SELECT * FROM students where on_duty_today={1};";
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                var someValue = dr["s_firstname"];
                int someValue1 = (int)dr["nr_notcleaned"];
                dr.Close();
                someValue1++;
                cmd.CommandText = $"UPDATE students SET nr_notcleaned='{someValue1}' WHERE s_firstname='{someValue}'";
                dr = cmd.ExecuteReader();
            }
            dr.Close();
            con.Close();

            MessageBox.Show("Complaint placed");
        }

        private void UpdateComplains()
        {
            listBoxControl6.Items.Clear();
            cmd = new MySqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "SELECT * FROM complaints";
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                string date = dr["date"].ToString();
                string time = dr["time"].ToString();
                string c_against = dr["c_against"].ToString();
                string complaint = dr["complaint"].ToString();
                listBoxControl6.Items.Add($"Date and time : {date} {time}      Complaint against : {c_against}");
                listBoxControl6.Items.Add($"{complaint}");
                listBoxControl6.Items.Add("");
            }
            dr.Close();
            con.Close();
        }

        private void simpleButton8_Click(object sender, EventArgs e)
        {
            checkedListBoxControl1.CheckAll();
            simpleButton8.Visible = false;
            simpleButton9.Visible = true;
        }

        private void simpleButton9_Click(object sender, EventArgs e)
        {
            checkedListBoxControl1.UnCheckAll();
            simpleButton8.Visible = true;
            simpleButton9.Visible = false;
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            SharedItemsControl sharedItemsControl = new SharedItemsControl();
            sharedItemsControl.Show();
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            List<string> values = new List<string>();

            foreach (object o in checkedListBoxControl1.CheckedItems)
                values.Add(o.ToString());

            string selectedItems = String.Join(",", values);
            string result = string.Empty;
            foreach (var c in selectedItems)
            {
                int ascii = (int)c;
                if ((ascii >= 48 && ascii <= 57) || ascii == 44 || ascii == 46)
                    result += c;
            }
            Int32 sum = result.Split(new char[] { ',' })
                   .Select(n => Int32.Parse(n)) 
                   .Sum();                      
            cmd = new MySqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = $"SELECT * FROM students WHERE username='{Login.user}';";
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                string s_firstname = (string)dr["s_firstname"];
                string s_lastname = (string)dr["s_lastname"];
                int nr_paid = (int)dr["times_paid"];
                int total_balance = (int)dr["total_balance"];
                nr_paid++;
                total_balance = total_balance + sum;
                dr.Close();
                cmd.CommandText = $"UPDATE students SET times_paid='{nr_paid}',total_balance='{total_balance}' WHERE s_firstname='{s_firstname}' and s_lastname='{s_lastname}';";
                dr = cmd.ExecuteReader();
                con.Close();
            }
            dr.Close();
            con.Close();
            MessageBox.Show("Payment Confirmed"); 
        }

    }
}