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
     
    public partial class InsertKey : DevExpress.XtraEditors.XtraForm
    {
        MySqlConnection con;
        MySqlCommand cmd,cmd1;
        MySqlDataReader dr,dr1;
        public static string Key_Number;
        private void InsertKey_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
            Environment.Exit(-1);
        }

        public InsertKey()
        {
            DevExpress.LookAndFeel.UserLookAndFeel.Default.SkinName = "The Bezier";
            InitializeComponent();

           
        }
        
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Key_Number = textEdit1.Text;
            String encrypted_connection = "nmoYTp8xDSccDS07cD/riQ+kmAAIG6DairNfUVJj/wWKwbDBoA8+sPAZcH5J+UvHisGwwaAPPrCYk9Z1HV+FbxG+z3WkNadnoFGEUoxtcPA=";
            encrypted_connection = Login.Decrypt(encrypted_connection, "sblw-3hn8-sqoy19");
            con = new MySqlConnection(encrypted_connection);
            string key = textEdit1.Text;
            cmd = new MySqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = $"SELECT reg_key,key_used FROM register_keys where reg_key='{textEdit1.Text}' and key_used='No'";
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                dr.Close();
                this.Visible = false;
                RegisterForm registerForm = new RegisterForm();
                registerForm.Show();
            }
            else
            {
                MessageBox.Show("Invalid key", "Rejected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            con.Close();
        }
    }
}