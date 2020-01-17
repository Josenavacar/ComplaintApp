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
using System.Data.SqlClient;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Security.Cryptography;


namespace ComplaintApp
{
    public partial class AdminForm : DevExpress.XtraEditors.XtraForm
    {
        private MySqlConnection con;
        private MySqlCommand cmd;
        private MySqlDataReader dr;

        public AdminForm()
        {
            DevExpress.LookAndFeel.UserLookAndFeel.Default.SkinName = "The Bezier";
            InitializeComponent();
            String encrypted_connection = "nmoYTp8xDSccDS07cD/riQ+kmAAIG6DairNfUVJj/wWKwbDBoA8+sPAZcH5J+UvHisGwwaAPPrCYk9Z1HV+FbxG+z3WkNadnoFGEUoxtcPA=";
            encrypted_connection = Login.Decrypt(encrypted_connection, "sblw-3hn8-sqoy19");
            con = new MySqlConnection(encrypted_connection);
            UpdateGrid1();
            UpdateStudents();
            UpdateGrid2();
            UpdateIDs();
            UpdateGrid3();
            UpdateComplaints();
        }
        public void UpdateStudents()
        {
            comboBoxEdit1.Properties.Items.Clear();
            comboBoxEdit1.SelectedIndex = -1;
            cmd = new MySqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "SELECT s_firstname,s_lastname FROM students";
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                var someValue = dr["s_firstname"];
                comboBoxEdit1.Properties.Items.Add($"{someValue}");
            }
            con.Close();
        }
     
        private void UpdateGrid1()
        {
            dataGridView2.Rows.Clear();
            dataGridView2.Columns.Clear();
            dataGridView2.Refresh();
            MySqlDataReader reader;
            try
            {
                MySqlCommand command = new MySqlCommand();
                string commandString = "SELECT * FROM students;";
                command.CommandText = commandString;
                command.Connection = con;
                command.Connection.Open();
                reader = command.ExecuteReader();
                this.dataGridView2.Columns.Add("s_id", "Student ID");
                this.dataGridView2.Columns["s_id"].Width = 50;
                this.dataGridView2.Columns.Add("student_email", "student_email");
                this.dataGridView2.Columns["student_email"].Width = 100;
                this.dataGridView2.Columns.Add("username", "Username");
                this.dataGridView2.Columns["username"].Width = 100;
                this.dataGridView2.Columns.Add("password", "password");
                this.dataGridView2.Columns["password"].Width = 100;
                this.dataGridView2.Columns.Add("s_firstname", "s_firstname");
                this.dataGridView2.Columns["s_firstname"].Width = 100;
                this.dataGridView2.Columns.Add("s_lastname", "s_lastname");
                this.dataGridView2.Columns["s_lastname"].Width = 100;
                while (reader.Read())
                {
                    dataGridView2.Rows.Add(reader["s_id"].ToString(), reader["student_email"].ToString(), reader["username"].ToString(), reader["password"].ToString(), reader["s_firstname"].ToString(), reader["s_lastname"].ToString());
                }
                reader.Close();
                command.Connection.Close();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Error: \r\n{0} { ex.ToString()}");
            }
        }
        private void UpdateGrid2()
        {
            dataGridView3.Rows.Clear();
            dataGridView3.Columns.Clear();
            dataGridView3.Refresh();
            MySqlDataReader reader;
            try
            {
                MySqlCommand command = new MySqlCommand();
                string commandString = "SELECT * FROM register_keys;";
                command.CommandText = commandString;
                command.Connection = con;
                command.Connection.Open();
                reader = command.ExecuteReader();
                this.dataGridView3.Columns.Add("key_id", "Key ID");
                this.dataGridView3.Columns["key_id"].Width = 100;
                this.dataGridView3.Columns.Add("reg_key", "Register Key");
                this.dataGridView3.Columns["reg_key"].Width = 400;
                this.dataGridView3.Columns.Add("key_used", "Key used");
                this.dataGridView3.Columns["key_used"].Width = 150;

                while (reader.Read())
                {
                    dataGridView3.Rows.Add(reader["key_id"].ToString(), reader["reg_key"].ToString(), reader["key_used"].ToString());
                }
                reader.Close();
                command.Connection.Close();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Error: \r\n{0} { ex.ToString()}");
            }
        }

        private void UpdateGrid3()
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            dataGridView1.Refresh();
            MySqlDataReader reader;
            try
            {
                MySqlCommand command = new MySqlCommand();
                string commandString = "SELECT rule_id,house_rule FROM house_rules;";
                command.CommandText = commandString;
                command.Connection = con;
                command.Connection.Open();
                reader = command.ExecuteReader();
                this.dataGridView1.Columns.Add("rule_id", "Rule ID");
                this.dataGridView1.Columns["rule_id"].Width = 100;
                this.dataGridView1.Columns.Add("house_rule", "House Rule");
                this.dataGridView1.Columns["house_rule"].Width = 560;

                while (reader.Read())
                {
                    dataGridView1.Rows.Add(reader["rule_id"].ToString(), reader["house_rule"].ToString());
                }
                reader.Close();
                command.Connection.Close();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Error: \r\n{0} { ex.ToString()}");
            }
            comboBoxEdit3.Properties.Items.Clear();
            comboBoxEdit3.SelectedIndex = -1;
            cmd = new MySqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "SELECT rule_id FROM house_rules";
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                var someValue = dr["rule_id"];

                comboBoxEdit3.Properties.Items.Add(someValue);
            }
            con.Close();
        }
        private void simpleButton4_Click(object sender, EventArgs e)
        {
            try
            {
                cmd = new MySqlCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = $"DELETE FROM students WHERE s_firstname='{comboBoxEdit1.SelectedItem.ToString()}'";
                dr = cmd.ExecuteReader();
                //MessageBox.Show("Deleted","Info",MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (MySqlException ex)
            {

                MessageBox.Show($"Error: \r\n{0} { ex.ToString()}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            cmd.Connection.Close();
            UpdateGrid1();
            UpdateStudents();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            cmd = new MySqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = $"INSERT INTO students (s_firstname,s_lastname,s_itemspaid) VALUES ('{textEdit4.Text}','{textEdit5.Text}','0')";
            dr = cmd.ExecuteReader();
            textEdit4.Text = String.Empty;
            textEdit5.Text = String.Empty;
            con.Close();
            UpdateGrid1();
            UpdateStudents();
        }

        private void AdminForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
            Environment.Exit(-1);
        }
        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZasdfghjklzxcvbnmqwertyuiop0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        private void simpleButton5_Click(object sender, EventArgs e)
        {
            textEdit6.Text = RandomString(40);
        }
        public void UpdateIDs()
        {
            comboBoxEdit2.Properties.Items.Clear();
            comboBoxEdit2.SelectedIndex = -1;
            cmd = new MySqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "SELECT key_id FROM register_keys";
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                var someValue = dr["key_id"];

                comboBoxEdit2.Properties.Items.Add(someValue);
            }
            con.Close();
        }
        private void simpleButton6_Click(object sender, EventArgs e)
        {
            cmd = new MySqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = $"INSERT INTO register_keys (reg_key,key_used) VALUES ('{textEdit6.Text}','No')";
            dr = cmd.ExecuteReader();
            textEdit6.Text = String.Empty;
            con.Close();
            UpdateGrid2();
            UpdateIDs();
        }

        private void simpleButton7_Click(object sender, EventArgs e)
        {
            try
            {
                cmd = new MySqlCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = $"DELETE FROM register_keys WHERE key_id='{comboBoxEdit2.SelectedItem.ToString()}'";
                dr = cmd.ExecuteReader();
                //MessageBox.Show("Deleted","Info",MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (MySqlException ex)
            {

                MessageBox.Show($"Error: \r\n{0} { ex.ToString()}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            cmd.Connection.Close();
            UpdateGrid2();
            UpdateIDs();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            try
            {
                cmd = new MySqlCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = $"INSERT INTO house_rules (house_rule) VALUES ('{textEdit1.Text}')";
                dr = cmd.ExecuteReader();
                textEdit1.Text = String.Empty;
                con.Close();
                UpdateGrid3();
            }
            catch (MySqlException ex)
            {

                MessageBox.Show($"Error: \r\n{0} { ex.ToString()}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            try
            {
                cmd = new MySqlCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = $"DELETE FROM house_rules WHERE rule_id='{comboBoxEdit3.SelectedItem.ToString()}'";
                dr = cmd.ExecuteReader();
                
            }
            catch (MySqlException ex)
            {

                MessageBox.Show($"Error: \r\n{0} { ex.ToString()}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            cmd.Connection.Close();
            UpdateGrid3();
        }
        private void UpdateComplaints()
        {
            listBoxControl1.Items.Clear();
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
                string username = dr["username"].ToString();
                listBoxControl1.Items.Add($"Date and time : {date} {time}      Complaint against : {c_against}          Complaint from : {username}");
                listBoxControl1.Items.Add($"{complaint}");
                listBoxControl1.Items.Add("");
            }
            dr.Close();
            con.Close();
        }
    }
}