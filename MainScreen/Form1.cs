using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace MainScreen
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }

        private void UpdateComplains()
        {
            lbComplaints.Items.Clear();
            string connetionString = null;
            connetionString = "server=remotemysql.com;database=jN4KuDdDKV;uid=jN4KuDdDKV;pwd=11RF2jyZrv;";
            MySqlConnection cnn = new MySqlConnection(connetionString);
            MySqlDataReader dr;
            MySqlCommand cmd;
            cnn.Open();
            cmd = new MySqlCommand();
            cmd.Connection = cnn;
            cmd.CommandText = "SELECT c_against,complaint FROM complaints";
                dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                var cagainst = dr["c_against"];
                var complaint = dr["complaint"];
                lbComplaints.Items.Add($"Complaint against: {cagainst}");
                lbComplaints.Items.Add(complaint);
                lbComplaints.Items.Add("");
            }
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            UpdateComplains();
        }
    }
}
