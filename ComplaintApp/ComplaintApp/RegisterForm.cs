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
    public partial class RegisterForm : DevExpress.XtraEditors.XtraForm
    {
        private MySqlConnection con;
        private MySqlCommand cmd;
        private MySqlDataReader dr;

        public RegisterForm()
        {
            DevExpress.LookAndFeel.UserLookAndFeel.Default.SkinName = "The Bezier";
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            string password = Login.Encrypt(textEdit3.Text, "sblw-3hn8-sqoy19");
            String encrypted_connection = "nmoYTp8xDSccDS07cD/riQ+kmAAIG6DairNfUVJj/wWKwbDBoA8+sPAZcH5J+UvHisGwwaAPPrCYk9Z1HV+FbxG+z3WkNadnoFGEUoxtcPA=";
            encrypted_connection = Login.Decrypt(encrypted_connection, "sblw-3hn8-sqoy19");
            con = new MySqlConnection(encrypted_connection);
            cmd = new MySqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = $"INSERT INTO students (student_email,username,password,s_firstname,s_lastname,on_duty_today,times_paid,total_balance,s_complaints,nr_notcleaned,nr_notpaid) VALUES ('{textEdit1.Text}','{textEdit2.Text}','{password}','{textEdit4.Text}','{textEdit5.Text}','0','0','0','0','0','0')";
            dr = cmd.ExecuteReader();
            dr.Close();
            cmd.CommandText = $"UPDATE register_keys SET key_used='Yes' WHERE reg_key='{InsertKey.Key_Number}'";
            dr = cmd.ExecuteReader();
            con.Close();
            MessageBox.Show("Registered successful, you can login now.", "Register");
            this.Hide();
            Login loginform = new Login();
            loginform.Show();
        }

        private void RegisterForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
            Environment.Exit(-1);
        }
    }
}