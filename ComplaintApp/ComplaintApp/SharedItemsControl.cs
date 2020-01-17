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
    public partial class SharedItemsControl : DevExpress.XtraEditors.XtraForm
    {
        MySqlConnection con;
        MySqlCommand cmd;
        MySqlDataReader dr;
        public static Dashboard Form;
        Dashboard Dashboard = new Dashboard();
        public SharedItemsControl()
        {
            DevExpress.LookAndFeel.UserLookAndFeel.Default.SkinName = "The Bezier";
            InitializeComponent();
            UpdateListBox1();
        }
        public void UpdateListBox1()
        {
            listBoxControl1.Items.Clear();
            String encrypted_connection = "nmoYTp8xDSccDS07cD/riQ+kmAAIG6DairNfUVJj/wWKwbDBoA8+sPAZcH5J+UvHisGwwaAPPrCYk9Z1HV+FbxG+z3WkNadnoFGEUoxtcPA=";
            encrypted_connection = Login.Decrypt(encrypted_connection, "sblw-3hn8-sqoy19");
            con = new MySqlConnection(encrypted_connection);
            cmd = new MySqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "SELECT g_name,g_price FROM groceries;";
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                var someValue = dr["g_name"];
                var SomeValue1 = dr["g_price"];
                listBoxControl1.Items.Add($"{someValue} - €{SomeValue1}");
            }
            con.Close();
        }
        private void simpleButton2_Click(object sender, EventArgs e)
        {

            string output = listBoxControl1.SelectedItem.ToString();
            string output1 = output.Substring(0, output.LastIndexOf(" -") + 1);
            String encrypted_connection = "nmoYTp8xDSccDS07cD/riQ+kmAAIG6DairNfUVJj/wWKwbDBoA8+sPAZcH5J+UvHisGwwaAPPrCYk9Z1HV+FbxG+z3WkNadnoFGEUoxtcPA=";
            encrypted_connection = Login.Decrypt(encrypted_connection, "sblw-3hn8-sqoy19");
            con = new MySqlConnection(encrypted_connection);
            cmd = new MySqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = $"DELETE FROM groceries WHERE g_name='{output1}'";
            dr = cmd.ExecuteReader();
            con.Close();
            UpdateListBox1();
            Dashboard.UpdateSharedItems();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (textEdit1.Text == "" || textEdit2.Text == "")
            {
                MessageBox.Show("You cannot send empty things!");
            }
            else
            {
                String encrypted_connection = "nmoYTp8xDSccDS07cD/riQ+kmAAIG6DairNfUVJj/wWKwbDBoA8+sPAZcH5J+UvHisGwwaAPPrCYk9Z1HV+FbxG+z3WkNadnoFGEUoxtcPA=";
                encrypted_connection = Login.Decrypt(encrypted_connection, "sblw-3hn8-sqoy19");
                con = new MySqlConnection(encrypted_connection);
                cmd = new MySqlCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = $"INSERT INTO groceries (g_name,g_price) VALUES ('{textEdit1.Text}','{textEdit2.Text}')";
                dr = cmd.ExecuteReader();
                con.Close();
                UpdateListBox1();
                Dashboard.UpdateSharedItems();

            }
        }
    }
}