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
    public partial class Dodawanie_Pracownika : Form
    {

        SqlDataAdapter sda;
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\workspace\PAB-Obsluga-Dzialu-Kadr-Csharp\PAB Obsluga Dzialu Kadr\PAB Obsluga Dzialu Kadr\BazaDanych.mdf;Integrated Security=True");
        SqlCommand Sq;
        DataTable Stanowiska;
        String id;

        String IDDZIALU;
        String IDSTANOWISKA;

        public Dodawanie_Pracownika()
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

            sda = new SqlDataAdapter("select NAZWA_DZIALU, ID_DZIALU from DZIAL", conn);
            DataTable Dzialy2 = new DataTable();
            sda.Fill(Dzialy2);

            int ileDzialow = Dzialy2.Rows.Count;
            for (int i = 0; i < ileDzialow; i++)
            {
                comboBox2.Items.Add(Convert.ToString(Dzialy2.Rows[i][0]));
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PrzeglądanieBDAdmin PBDA = new PrzeglądanieBDAdmin(0);
            PBDA.Show();
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int indexWybranego = comboBox1.SelectedIndex;
            IDSTANOWISKA = Convert.ToString(Stanowiska.Rows[indexWybranego][1]);

            sda = new SqlDataAdapter("select NAZWA_DZIALU from DZIAL where ID_DZIALU = '" + Convert.ToString(Stanowiska.Rows[indexWybranego][2]) + "'", conn);
            DataTable Dzialy = new DataTable();
            sda.Fill(Dzialy);

            nAZWA_DZIALULabel1.Text = Convert.ToString(Dzialy.Rows[0][0]);
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            int indexWybranego = comboBox2.SelectedIndex;

            sda = new SqlDataAdapter("select NAZWA_DZIALU, ID_DZIALU from DZIAL", conn);
            DataTable Dzialy2 = new DataTable();
            sda.Fill(Dzialy2);

            IDDZIALU = Convert.ToString(Dzialy2.Rows[indexWybranego][1]);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Sq = new SqlCommand("INSERT INTO PRACOWNICY (ID_STANOWISKA, ID_DZIALU, IMIE_PRACOWNIKA, NAZWISKO_PRACOWNIKA, E_MAIL_PRACOWNIKA, HASLO_PRACOWNIKA) VALUES ('" + IDSTANOWISKA + "','"+IDDZIALU+"','" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "')", conn);
            conn.Open();
            SqlDataReader SDR = Sq.ExecuteReader();
            conn.Close();

            MessageBox.Show("Dodano Pracownika!", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);

            PrzeglądanieBDAdmin PBDA = new PrzeglądanieBDAdmin(0);
            PBDA.Show();
            this.Close();
        }
    }
}
