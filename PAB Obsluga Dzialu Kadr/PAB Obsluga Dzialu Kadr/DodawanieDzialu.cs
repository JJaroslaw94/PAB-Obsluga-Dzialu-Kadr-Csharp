using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PAB_Obsluga_Dzialu_Kadr
{
    public partial class DodawanieDzialu : Form
    {
        SqlDataAdapter sda;
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Integrated Security=True;AttachDbFilename=|DataDirectory|\BazaDanych.mdf"); SqlCommand Sq;

        public DodawanieDzialu()
        {
            InitializeComponent();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            PrzeglądanieBDAdmin PBDA = new PrzeglądanieBDAdmin(4);
            PBDA.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Sq = new SqlCommand("INSERT INTO DZIAL (NAZWA_DZIALU) VALUES ('" + textBox1.Text + "')", conn);
            conn.Open();
            SqlDataReader SDR = Sq.ExecuteReader();
            conn.Close();

            MessageBox.Show("Dodano Dział!", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);

            PrzeglądanieBDAdmin PBDA = new PrzeglądanieBDAdmin(4);
            PBDA.Show();
            this.Close();
        }

        private void DodawanieDzialu_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
