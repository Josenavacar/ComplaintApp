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



    public partial class Login : DevExpress.XtraEditors.XtraForm
    {
        MySqlConnection con;
        MySqlCommand cmd;
        MySqlDataReader dr;
        public static string user;
        public static string Encrypt(string input, string key)
        {
            byte[] inputArray = UTF8Encoding.UTF8.GetBytes(input);
            TripleDESCryptoServiceProvider tripleDES = new TripleDESCryptoServiceProvider();
            tripleDES.Key = UTF8Encoding.UTF8.GetBytes(key);
            tripleDES.Mode = CipherMode.ECB;
            tripleDES.Padding = PaddingMode.PKCS7;
            ICryptoTransform cTransform = tripleDES.CreateEncryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(inputArray, 0, inputArray.Length);
            tripleDES.Clear();
            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }
        public static string Decrypt(string input, string key)
        {
            byte[] inputArray = Convert.FromBase64String(input);
            TripleDESCryptoServiceProvider tripleDES = new TripleDESCryptoServiceProvider();
            tripleDES.Key = UTF8Encoding.UTF8.GetBytes(key);
            tripleDES.Mode = CipherMode.ECB;
            tripleDES.Padding = PaddingMode.PKCS7;
            ICryptoTransform cTransform = tripleDES.CreateDecryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(inputArray, 0, inputArray.Length);
            tripleDES.Clear();
            return UTF8Encoding.UTF8.GetString(resultArray);
        }
        public Login()
        {
           
            DevExpress.LookAndFeel.UserLookAndFeel.Default.SkinName = "The Bezier";
            InitializeComponent();
            String encrypted_connection = "nmoYTp8xDSccDS07cD/riQ+kmAAIG6DairNfUVJj/wWKwbDBoA8+sPAZcH5J+UvHisGwwaAPPrCYk9Z1HV+FbxG+z3WkNadnoFGEUoxtcPA=";
            encrypted_connection = Decrypt(encrypted_connection, "sblw-3hn8-sqoy19");
            con = new MySqlConnection(encrypted_connection);
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {

            

            user = textEdit1.Text;
            string pass = Encrypt(textEdit2.Text, "sblw-3hn8-sqoy19");
            cmd = new MySqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "SELECT * FROM students where username='" + textEdit1.Text + "' AND password='" + pass + "'";
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                FormShow();
            }
            else
            {
                MessageBox.Show("Invalid username or password","Rejected", MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
            con.Close();
        }
        private void FormShow()
        {
            if (textEdit1.Text == "admin" || dr.Read())
            {
                this.Visible = false;
                AdminForm adminform = new AdminForm();
                adminform.Show();
            }
            else if(textEdit1.Text != "admin" || dr.Read())
            {
                this.Visible = false;
                Dashboard dashboard = new Dashboard();
                dashboard.Show();
            }
        }

        private void Login_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
            Environment.Exit(-1);
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            InsertKey insertForm = new InsertKey();
            insertForm.Show();

        }
    }
}