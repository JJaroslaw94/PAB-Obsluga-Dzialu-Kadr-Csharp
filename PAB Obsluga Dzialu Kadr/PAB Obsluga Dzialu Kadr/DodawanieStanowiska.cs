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
    public partial class DodawanieStanowiska : Form
    {
        SqlDataAdapter sda;
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Integrated Security=True;AttachDbFilename=|DataDirectory|\BazaDanych.mdf"); SqlCommand Sq;
        DataTable Stanowiska;

        String IDDZIALU;

        public DodawanieStanowiska()
        {
            
            InitializeComponent();

            sda = new SqlDataAdapter("select NAZWA_DZIALU, ID_DZIALU from DZIAL", conn);
            DataTable Dzialy2 = new DataTable();
            sda.Fill(Dzialy2);

            int ileDzialow = Dzialy2.Rows.Count;
            for (int i = 0; i < ileDzialow; i++)
            {
                comboBox1.Items.Add(Convert.ToString(Dzialy2.Rows[i][0]));
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int indexWybranego = comboBox1.SelectedIndex;

            sda = new SqlDataAdapter("select NAZWA_DZIALU, ID_DZIALU from DZIAL", conn);
            DataTable Dzialy2 = new DataTable();
            sda.Fill(Dzialy2);

            IDDZIALU = Convert.ToString(Dzialy2.Rows[indexWybranego][1]);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Sq = new SqlCommand("INSERT INTO STANOWISKA (ID_DZIALU, NAZWA_STANOWISKA, MIEJSCA, UPRAWNIENIA) VALUES ('" + IDDZIALU + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "')", conn);
            conn.Open();
            SqlDataReader SDR = Sq.ExecuteReader();
            conn.Close();

            MessageBox.Show("Dodano Stanowisko!", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);

            PrzeglądanieBDAdmin PBDA = new PrzeglądanieBDAdmin(1);
            PBDA.Show();
            this.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            PrzeglądanieBDAdmin PBDA = new PrzeglądanieBDAdmin(1);
            PBDA.Show();
            this.Close();
        }
    }
}
