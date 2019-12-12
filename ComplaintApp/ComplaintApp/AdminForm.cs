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
        MySqlConnection con;
        MySqlCommand cmd;
        MySqlDataReader dr;
        public AdminForm()
        {
            DevExpress.LookAndFeel.UserLookAndFeel.Default.SkinName = "The Bezier";
            InitializeComponent();
            String encrypted_connection = "nmoYTp8xDSccDS07cD/riQ+kmAAIG6DairNfUVJj/wWKwbDBoA8+sPAZcH5J+UvHisGwwaAPPrCYk9Z1HV+FbxG+z3WkNadnoFGEUoxtcPA=";
            encrypted_connection = Login.Decrypt(encrypted_connection, "sblw-3hn8-sqoy19");
            con = new MySqlConnection(encrypted_connection);
            UpdateGrid();
            ReadData();
            UpdateGrid1();
            UpdateStudents();
        }
        public void UpdateStudents()
        {
            comboBoxEdit1.Properties.Items.Clear();
            comboBoxEdit1.SelectedIndex = -1;
            cmd = new MySqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "SELECT s_firstname FROM students";
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                var someValue = dr["s_firstname"];

                comboBoxEdit1.Properties.Items.Add(someValue);
            }
            con.Close();
        }
        public void ReadData()
        {
            string queryString = "SELECT count(*) from users";
            string queryString1 = "SELECT count(*) from students";
            String encrypted_connection = "nmoYTp8xDSccDS07cD/riQ+kmAAIG6DairNfUVJj/wWKwbDBoA8+sPAZcH5J+UvHisGwwaAPPrCYk9Z1HV+FbxG+z3WkNadnoFGEUoxtcPA=";
            encrypted_connection = Login.Decrypt(encrypted_connection, "sblw-3hn8-sqoy19");
            MySqlConnection con;
            using (con = new MySqlConnection(encrypted_connection))
            {
                MySqlCommand cmd = new MySqlCommand(queryString, con);
                con.Open();

                object count = cmd.ExecuteScalar();
                labelControl5.Text = $"{count}";
            }
            using (con = new MySqlConnection(encrypted_connection))
            {
                MySqlCommand cmd = new MySqlCommand(queryString1, con);
                con.Open();

                object count1 = cmd.ExecuteScalar();
                labelControl7.Text = $"{count1}";
            }
        }
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            string password = Login.Encrypt(textEdit2.Text, "sblw-3hn8-sqoy19");
            cmd = new MySqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = $"INSERT INTO users (username,password) VALUES ('{textEdit1.Text}','{password}')";
            dr = cmd.ExecuteReader();
            //MessageBox.Show("Added","Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            textEdit1.Text = String.Empty;
            textEdit2.Text = String.Empty;
            con.Close();
            UpdateGrid();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            try
            {
                cmd = new MySqlCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = $"DELETE FROM users WHERE username='{textEdit3.Text}'";
                dr = cmd.ExecuteReader();
                //MessageBox.Show("Deleted","Info",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textEdit3.Text = String.Empty;
            }
            catch(MySqlException ex)
            {

                MessageBox.Show($"Error: \r\n{0} { ex.ToString()}","Error",MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            cmd.Connection.Close();
            UpdateGrid();


        }

        private void UpdateGrid()
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            dataGridView1.Refresh();
            MySqlDataReader reader;
            try
            {
                MySqlCommand command = new MySqlCommand();
                string commandString = "SELECT * FROM users;";
                command.CommandText = commandString;
                command.Connection = con;
                command.Connection.Open();
                reader = command.ExecuteReader();
                this.dataGridView1.Columns.Add("user_id", "User ID");
                this.dataGridView1.Columns["user_id"].Width = 100;
                this.dataGridView1.Columns.Add("username", "Username");
                this.dataGridView1.Columns["username"].Width = 150;
                this.dataGridView1.Columns.Add("password", "Password");
                this.dataGridView1.Columns["password"].Width = 250;
                while (reader.Read())
                {
                    dataGridView1.Rows.Add(reader["user_id"].ToString(), reader["username"].ToString(), reader["password"].ToString());
                }
                reader.Close();
                command.Connection.Close();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Error: \r\n{0} { ex.ToString()}");
            }
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
                this.dataGridView2.Columns["s_id"].Width = 100;
                this.dataGridView2.Columns.Add("s_firstname", "First Name");
                this.dataGridView2.Columns["s_firstname"].Width = 150;
                this.dataGridView2.Columns.Add("s_lastname", "Last Name");
                this.dataGridView2.Columns["s_lastname"].Width = 250;
                this.dataGridView2.Columns.Add("s_itemspaid", "Items Paid");
                this.dataGridView2.Columns["s_itemspaid"].Width = 100;
                while (reader.Read())
                {
                    dataGridView2.Rows.Add(reader["s_id"].ToString(), reader["s_firstname"].ToString(), reader["s_lastname"].ToString(), reader["s_itemspaid"].ToString());
                }
                reader.Close();
                command.Connection.Close();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Error: \r\n{0} { ex.ToString()}");
            }
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

        private void labelControl7_Click(object sender, EventArgs e)
        {
            ReadData();
        }

        private void labelControl5_Click(object sender, EventArgs e)
        {
            ReadData(); 
        }
    }
}