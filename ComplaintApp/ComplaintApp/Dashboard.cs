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


namespace ComplaintApp
{
    public partial class Dashboard : DevExpress.XtraEditors.XtraForm
    {
       
        MySqlConnection con;
        MySqlCommand cmd;
        MySqlDataReader dr;
        string time = DateTime.Now.ToString("HH:mm");
        string date = DateTime.Now.ToString("dd/MM/yyyy");
        int i = 0;
        int seconder = 0;
        int student_id;
        int rows_num;
        Int32 count;
        Int32 count1;
        int on_duty_today;
        int s_complaints;
        int nr_notcleaned;
        int nr_notpaid;
        List<string> HouseRules = new List<string>();
        public Dashboard()
        {

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
            cmd.CommandText = "SELECT * FROM students WHERE username not in (SELECT username FROM students WHERE username='admin');";
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                var someValue = dr["s_firstname"];
                var someValue1 = dr["s_lastname"];
                comboBoxEdit1.Properties.Items.Add($"{someValue} {someValue1}");
                listBoxControl4.Items.Add($"{someValue} {someValue1}");
                comboBoxEdit2.Properties.Items.Add($"{someValue} {someValue1}");

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
            else if (textBox1.Text.Length < 4)
            {
                MessageBox.Show("The name is not long enough!");
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
            listBoxControl2.Items.Clear();
            cmd = new MySqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "SELECT g_name,g_price FROM groceries;";
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                var someValue = dr["g_name"];
                var SomeValue1 = dr["g_price"];
                listBoxControl2.Items.Add($"{someValue} - €{SomeValue1}");
            }
            con.Close();
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            if (textEdit3.Text == "" || textEdit2.Text == "")
            {
                MessageBox.Show("You cannot send empty things!");
            }
            else { 
            cmd = new MySqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = $"INSERT INTO groceries (g_name,g_price) VALUES ('{textEdit2.Text}','{textEdit3.Text}')";
            dr = cmd.ExecuteReader();
            con.Close();
            UpdateSharedItems();
            }
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

        private void simpleButton5_Click(object sender, EventArgs e)
        {

            string output = listBoxControl2.SelectedItem.ToString();
            string output1 = output.Substring(0, output.LastIndexOf(" -") + 1);
            cmd = new MySqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = $"DELETE FROM groceries WHERE g_name='{output1}'";
            dr = cmd.ExecuteReader();
            con.Close();
            UpdateSharedItems();
        }

        private void simpleButton6_Click(object sender, EventArgs e)
        {
            string checkedname = listBoxControl4.SelectedItem.ToString();
            string checkedname1 = checkedname.Substring(0, checkedname.IndexOf(" "));
           textEdit2.Text = checkedname1;
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

        private void xtraTabControl1_Click(object sender, EventArgs e)
        {

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
    }
}