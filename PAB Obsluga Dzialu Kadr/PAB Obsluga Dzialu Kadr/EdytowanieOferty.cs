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
    public partial class EdytowanieOferty : Form
    {
        String id;

        SqlDataAdapter sda;
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Integrated Security=True;AttachDbFilename=|DataDirectory|\BazaDanych.mdf"); SqlCommand Sq;
        DataTable Stanowiska;

        String indexStanowiska;

        public EdytowanieOferty(String ID)
        {
            id = ID;
            InitializeComponent();

            sda = new SqlDataAdapter("select NAZWA_STANOWISKA, ID_STANOWISKA, ID_DZIALU from STANOWISKA", conn);
            Stanowiska = new DataTable();
            sda.Fill(Stanowiska);

            int ileStanowisk = Stanowiska.Rows.Count;
            for (int i = 0; i < ileStanowisk; i++)
            {
                comboBox1.Items.Add(Convert.ToString(Stanowiska.Rows[i][0]));
            }

            sda = new SqlDataAdapter("select ID__OFERTY, ID_STANOWISKA, NAZWA_STANOWISKA, OPIS, WYMOGI, WYNAGRODZENIE, DOSTEPNE_MIEJSCA from OFERTY where ID__OFERTY='"+id+"'", conn);
            DataTable Oferty = new DataTable();
            sda.Fill(Oferty);

            for (int i = 0; i < ileStanowisk; i++)
            {
                if (Convert.ToString(Stanowiska.Rows[i][1]).Equals(Convert.ToString(Oferty.Rows[0][1])))
                {
                    indexStanowiska = Convert.ToString(Stanowiska.Rows[i][1]);
                    comboBox1.SelectedIndex = i;
                }
            }

            textBox2.Text = Convert.ToString(Oferty.Rows[0][2]);
            textBox3.Text = Convert.ToString(Oferty.Rows[0][3]);
            textBox4.Text = Convert.ToString(Oferty.Rows[0][4]);
            textBox5.Text = Convert.ToString(Oferty.Rows[0][5]);
            textBox6.Text = Convert.ToString(Oferty.Rows[0][6]);
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

        private void button2_Click(object sender, EventArgs e)
        {
            Sq = new SqlCommand("DELETE FROM OFERTY WHERE ID__OFERTY='" + id + "'", conn);
            conn.Open();
            SqlDataReader SDR = Sq.ExecuteReader();
            conn.Close();

            MessageBox.Show("Usunięto Oferte!", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);

            PrzeglądanieBDAdmin PBDA = new PrzeglądanieBDAdmin(3);
            PBDA.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Sq = new SqlCommand("UPDATE OFERTY set ID_STANOWISKA='"+indexStanowiska+"', NAZWA_STANOWISKA='"+textBox2.Text+ "', OPIS='" + textBox3.Text + "', WYMOGI='" + textBox4.Text + "', WYNAGRODZENIE='" + textBox5.Text + "', DOSTEPNE_MIEJSCA='" + textBox6.Text + "' where ID__OFERTY='" + id + "'", conn);
            conn.Open();
            SqlDataReader SDR = Sq.ExecuteReader();
            conn.Close();

            MessageBox.Show("Edytowano Oferte!", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);

            PrzeglądanieBDAdmin PBDA = new PrzeglądanieBDAdmin(3);
            PBDA.Show();
            this.Close();
        }

        private void EdytowanieOferty_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
