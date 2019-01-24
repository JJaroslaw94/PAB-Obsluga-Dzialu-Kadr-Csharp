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
    public partial class DodawanieOfert : Form
    {
        SqlDataAdapter sda;
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Integrated Security=True;AttachDbFilename=|DataDirectory|\BazaDanych.mdf"); SqlCommand Sq;
        DataTable Stanowiska;

        String indexStanowiska;

        public DodawanieOfert()
        {
            InitializeComponent();

            sda = new SqlDataAdapter("select NAZWA_STANOWISKA, ID_STANOWISKA, ID_DZIALU from STANOWISKA", conn);
            Stanowiska = new DataTable();
            sda.Fill(Stanowiska);

            int ileStanowisk = Stanowiska.Rows.Count;
            for (int i = 0; i < ileStanowisk; i++)
            {
                comboBox1.Items.Add(Convert.ToString(Stanowiska.Rows[i][0]));
            }

        }

        private void button7_Click(object sender, EventArgs e)
        {
            PrzeglądanieBDAdmin PBDA = new PrzeglądanieBDAdmin(3);
            PBDA.Show();
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int indexWybranego = comboBox1.SelectedIndex;

            sda = new SqlDataAdapter("select NAZWA_DZIALU from DZIAL where ID_DZIALU = '" + Convert.ToString(Stanowiska.Rows[indexWybranego][2]) + "'", conn);
            DataTable Dzialy = new DataTable();
            sda.Fill(Dzialy);

            label8.Text = Convert.ToString(Dzialy.Rows[0][0]);
            indexStanowiska = Convert.ToString(Stanowiska.Rows[indexWybranego][1]);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Sq = new SqlCommand("INSERT INTO OFERTY (ID_STANOWISKA, NAZWA_STANOWISKA, OPIS, WYMOGI, WYNAGRODZENIE, DOSTEPNE_MIEJSCA) VALUES ('" + indexStanowiska + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','"+ textBox6.Text + "')", conn);
            conn.Open();
            SqlDataReader SDR = Sq.ExecuteReader();
            conn.Close();

            MessageBox.Show("Dodano Oferte!", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);

            PrzeglądanieBDAdmin PBDA = new PrzeglądanieBDAdmin(3);
            PBDA.Show();
            this.Close();
        }

        private void DodawanieOfert_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();

        }
    }
}
