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
    public partial class EdytujPodania : Form
    {
        String id;

        SqlDataAdapter sda;
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Integrated Security=True;AttachDbFilename=|DataDirectory|\BazaDanych.mdf"); SqlCommand Sq;

        public EdytujPodania(String ID)
        {
            id = ID;
            InitializeComponent();

            sda = new SqlDataAdapter("select ID_PODANIA, ID_STANOWISKA, IMIE_PRACOWNIKA, NAZWISKO_PRACOWNIKA, WIEK, RODZAJ_WYKSZTALCENIA, MIEJSCE_ZAMIESZKANIA, DLUGOSC_STAZU, DATA_OTRZYMANIA, STAN, TELEFON from PODANIA where ID_PODANIA='"+id+"'", conn);
            DataTable Podania = new DataTable();
            sda.Fill(Podania);

            sda = new SqlDataAdapter("select NAZWA_STANOWISKA, ID_DZIALU from STANOWISKA where ID_STANOWISKA ='" + Convert.ToString(Podania.Rows[0][1]) + "'", conn);
            DataTable stan = new DataTable();
            sda.Fill(stan);

            sda = new SqlDataAdapter("select NAZWA_DZIALU from DZIAL where ID_DZIALU ='" + Convert.ToString(stan.Rows[0][1]) + "'", conn);
            DataTable dzia = new DataTable();
            sda.Fill(dzia);

            nAZWA_DZIALULabel1.Text = Convert.ToString(dzia.Rows[0][0]);

            label1.Text = Convert.ToString(stan.Rows[0][0]);

            label3.Text = Convert.ToString(Podania.Rows[0][2]);
            label4.Text = Convert.ToString(Podania.Rows[0][3]);
            label5.Text = Convert.ToString(Podania.Rows[0][4]);
            label6.Text = Convert.ToString(Podania.Rows[0][5]);
            label7.Text = Convert.ToString(Podania.Rows[0][6]);
            label8.Text = Convert.ToString(Podania.Rows[0][7]);
            label9.Text = Convert.ToString(Podania.Rows[0][8]);
           
                if (Convert.ToString(Podania.Rows[0][9]).Equals("0"))
                {
                    label10.Text ="Nie sprawdzone";
                }
                if (Convert.ToString(Podania.Rows[0][9]).Equals("1"))
                {
                    label10.Text = "Odłożone";
                }
                if (Convert.ToString(Podania.Rows[0][9]).Equals("2"))
                {
                    label10.Text = "Zaakceptowane";
                }
            
            label12.Text = Convert.ToString(Podania.Rows[0][10]);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PrzeglądanieBDAdmin PBDA = new PrzeglądanieBDAdmin(2);
            PBDA.Show();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Sq = new SqlCommand("UPDATE PODANIA set STAN='2' where ID_PODANIA='" + id + "'", conn);
            conn.Open();
            SqlDataReader SDR = Sq.ExecuteReader();
            conn.Close();

            MessageBox.Show("Zatwierdzono Podanie!", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);

            PrzeglądanieBDAdmin PBDA = new PrzeglądanieBDAdmin(2);
            PBDA.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Sq = new SqlCommand("UPDATE PODANIA set STAN='1' where ID_PODANIA='" + id + "'", conn);
            conn.Open();
            SqlDataReader SDR = Sq.ExecuteReader();
            conn.Close();

            MessageBox.Show("Odłożono Podanie!", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);

            PrzeglądanieBDAdmin PBDA = new PrzeglądanieBDAdmin(2);
            PBDA.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Sq = new SqlCommand("DELETE FROM PODANIA WHERE ID_PODANIA='" + id + "'", conn);
            conn.Open();
            SqlDataReader SDR = Sq.ExecuteReader();
            conn.Close();

            MessageBox.Show("Usunięto Podanie!", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);

            PrzeglądanieBDAdmin PBDA = new PrzeglądanieBDAdmin(2);
            PBDA.Show();
            this.Close();
        }

        private void EdytujPodania_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
