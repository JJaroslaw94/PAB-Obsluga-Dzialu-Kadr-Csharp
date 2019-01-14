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
    public partial class EdycjaPracownikow : Form
    {
        SqlDataAdapter sda;
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\workspace\PAB-Obsluga-Dzialu-Kadr-Csharp\PAB Obsluga Dzialu Kadr\PAB Obsluga Dzialu Kadr\BazaDanych.mdf;Integrated Security=True");
        SqlCommand Sq;
        DataTable Stanowiska;
        String id;

        String IDDZIALU;
        String IDSTANOWISKA;

        public EdycjaPracownikow(String ID)
        {
            InitializeComponent();
            id = ID;
            sda = new SqlDataAdapter("select NAZWA_STANOWISKA, ID_STANOWISKA, ID_DZIALU from STANOWISKA", conn);
            Stanowiska = new DataTable();
            sda.Fill(Stanowiska);

            int ileStanowisk = Stanowiska.Rows.Count;
            for (int i = 0; i<ileStanowisk; i++)
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

            sda = new SqlDataAdapter("select ID_PRACOWNIKA, ID_STANOWISKA, ID_DZIALU, IMIE_PRACOWNIKA, NAZWISKO_PRACOWNIKA, E_MAIL_PRACOWNIKA, HASLO_PRACOWNIKA from PRACOWNICY where ID_PRACOWNIKA ='" + ID + "'", conn);
            DataTable Pracownicy = new DataTable();
            sda.Fill(Pracownicy);

            
            for (int i = 0; i < ileStanowisk; i++)
            {
                if (Convert.ToString(Stanowiska.Rows[i][1]).Equals(Convert.ToString(Pracownicy.Rows[0][1])))
                {
                    comboBox1.SelectedIndex = i;
                    IDSTANOWISKA = Convert.ToString(Stanowiska.Rows[i][1]);

                    sda = new SqlDataAdapter("select NAZWA_DZIALU from DZIAL where ID_DZIALU = '" + Convert.ToString(Stanowiska.Rows[i][2]) + "'", conn);
                    DataTable Dzialy = new DataTable();
                    sda.Fill(Dzialy);

                    nAZWA_DZIALULabel1.Text = Convert.ToString(Dzialy.Rows[0][0]);
                }
            }

            
            for (int i = 0; i < ileDzialow; i++)
            {
                if (Convert.ToString(Dzialy2.Rows[i][1]).Equals(Convert.ToString(Pracownicy.Rows[0][2])))
                {
                    IDDZIALU = Convert.ToString(Dzialy2.Rows[i][1]);
                    comboBox2.SelectedIndex = i;
                }                
            }

            textBox1.Text = Convert.ToString(Pracownicy.Rows[0][3]);
            textBox2.Text = Convert.ToString(Pracownicy.Rows[0][4]);
            textBox3.Text = Convert.ToString(Pracownicy.Rows[0][5]);
            textBox4.Text = Convert.ToString(Pracownicy.Rows[0][6]);
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

        private void button2_Click(object sender, EventArgs e)
        {
            PrzeglądanieBDAdmin PBDA = new PrzeglądanieBDAdmin(0);
            PBDA.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Sq = new SqlCommand("UPDATE PRACOWNICY set ID_STANOWISKA='"+IDSTANOWISKA+"', ID_DZIALU='"+IDDZIALU+"', IMIE_PRACOWNIKA='"+textBox1.Text+"', NAZWISKO_PRACOWNIKA='"+ textBox2.Text + "', E_MAIL_PRACOWNIKA='"+ textBox3.Text + "', HASLO_PRACOWNIKA='"+ textBox4.Text + "' where ID_PRACOWNIKA='"+id+"'" , conn);
            conn.Open();
            SqlDataReader SDR = Sq.ExecuteReader();
            conn.Close();

            MessageBox.Show("Zmieniono informacje!", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);

            PrzeglądanieBDAdmin PBDA = new PrzeglądanieBDAdmin(0);
            PBDA.Show();
            this.Close();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            int indexWybranego = comboBox2.SelectedIndex;

            sda = new SqlDataAdapter("select NAZWA_DZIALU, ID_DZIALU from DZIAL", conn);
            DataTable Dzialy2 = new DataTable();
            sda.Fill(Dzialy2);

            IDDZIALU = Convert.ToString(Dzialy2.Rows[indexWybranego][1]);
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Sq = new SqlCommand("DELETE FROM PRACOWNICY WHERE ID_PRACOWNIKA='"+id+"'", conn);
            conn.Open();
            SqlDataReader SDR = Sq.ExecuteReader();
            conn.Close();

            MessageBox.Show("Usunięto Pracownika!", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);

            PrzeglądanieBDAdmin PBDA = new PrzeglądanieBDAdmin(0);
            PBDA.Show();
            this.Close();
        }
    }
}
