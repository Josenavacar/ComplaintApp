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
        public Dashboard()
        {

            InitializeComponent();
            DevExpress.LookAndFeel.UserLookAndFeel.Default.SkinName = "The Bezier";
            String encrypted_connection = "nmoYTp8xDSccDS07cD/riQ+kmAAIG6DairNfUVJj/wWKwbDBoA8+sPAZcH5J+UvHisGwwaAPPrCYk9Z1HV+FbxG+z3WkNadnoFGEUoxtcPA=";
            encrypted_connection = Login.Decrypt(encrypted_connection, "sblw-3hn8-sqoy19");
            con = new MySqlConnection(encrypted_connection);
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

        SimpleTcpClient client;
        private void Dashboard_Load(object sender, EventArgs e)
        {
           // client = new SimpleTcpClient(); 
            //client.StringEncoder = Encoding.UTF8;
          //  client.Connect("127.0.0.1", Convert.ToInt32("8888"));
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            // client.WriteLineAndGetReply(textBox1.Text+"$", TimeSpan.FromSeconds(3));
            cmd = new MySqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = $"INSERT INTO complaints (date,time,username,c_against,complaint) VALUES ('{date}','{time}','{Login.user}','{comboBoxEdit1.SelectedItem.ToString()}','{textBox1.Text}')";
            dr = cmd.ExecuteReader();
                MessageBox.Show("Sent");
            textBox1.Clear();
            con.Close();
        }

        private void Dashboard_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
            Environment.Exit(-1);
        }
    }
}