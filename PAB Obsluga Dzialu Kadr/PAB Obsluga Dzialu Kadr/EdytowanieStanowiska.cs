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
    public partial class EdytowanieStanowiska : Form
    {
        SqlDataAdapter sda;
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Integrated Security=True;AttachDbFilename=|DataDirectory|\BazaDanych.mdf"); SqlCommand Sq;
        DataTable Stanowisko;

        String IDDZIALU;

        String id;
        public EdytowanieStanowiska(String ID)
        {
            id = ID;
            InitializeComponent();

            sda = new SqlDataAdapter("select NAZWA_DZIALU, ID_DZIALU from DZIAL", conn);
            DataTable Dzialy2 = new DataTable();
            sda.Fill(Dzialy2);

            int ileDzialow = Dzialy2.Rows.Count;
            for (int i = 0; i < ileDzialow; i++)
            {
                comboBox1.Items.Add(Convert.ToString(Dzialy2.Rows[i][0]));
            }

            sda = new SqlDataAdapter("select ID_DZIALU, NAZWA_STANOWISKA, MIEJSCA, UPRAWNIENIA from STANOWISKA where ID_STANOWISKA='"+id+"'", conn);
            Stanowisko = new DataTable();
            sda.Fill(Stanowisko);

            for (int i = 0; i < ileDzialow; i++)
            {
                if (Convert.ToString(Dzialy2.Rows[i][1]).Equals(Convert.ToString(Stanowisko.Rows[0][0])))
                {
                    IDDZIALU = Convert.ToString(Dzialy2.Rows[i][1]);
                    comboBox1.SelectedIndex = i;
                }
            }

            textBox2.Text = Convert.ToString(Stanowisko.Rows[0][1]);
            textBox3.Text = Convert.ToString(Stanowisko.Rows[0][2]);
            textBox4.Text = Convert.ToString(Stanowisko.Rows[0][3]);

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
            Sq = new SqlCommand("UPDATE STANOWISKA set ID_DZIALU='"+IDDZIALU+"' , NAZWA_STANOWISKA='"+textBox2.Text+"', MIEJSCA='"+ textBox3.Text + "', UPRAWNIENIA='"+ textBox4.Text + "' where ID_STANOWISKA='"+id+"'", conn);
            conn.Open();
            SqlDataReader SDR = Sq.ExecuteReader();
            conn.Close();

            MessageBox.Show("Zmieniono Stanowisko!", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);

            PrzeglądanieBDAdmin PBDA = new PrzeglądanieBDAdmin(1);
            PBDA.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Boolean mozna = true;
            String trescBledu = "Nie mozna usunac stanowiska " + Stanowisko.Rows[0][1] + " ponieważ: ";

            sda = new SqlDataAdapter("select count(*) from PRACOWNICY where ID_STANOWISKA='"+id+"'", conn);
            DataTable check1 = new DataTable();
            sda.Fill(check1);

            if( Convert.ToString(check1.Rows[0][0]) != "0")
            {
                mozna = false;
                trescBledu = trescBledu + "\nIstnieją jeszcze pracownicy na tym stanowisku";
            }

            sda = new SqlDataAdapter("select count(*) from OFERTY where ID_STANOWISKA='" + id + "'", conn);
            DataTable check2 = new DataTable();
            sda.Fill(check2);

            if (Convert.ToString(check2.Rows[0][0]) != "0")
            {
                mozna = false;
                trescBledu = trescBledu + "\nIstnieją jeszcze oferty na to stanowisko";
            }

            sda = new SqlDataAdapter("select count(*) from Podania where ID_STANOWISKA='" + id + "'", conn);
            DataTable check3 = new DataTable();
            sda.Fill(check3);

            if (Convert.ToString(check3.Rows[0][0]) != "0")
            {
                mozna = false;
                trescBledu = trescBledu + "\nIstnieją jeszcze podania na to stanowisko";
            }

            if (mozna)
                {
                    Sq = new SqlCommand("DELETE FROM STANOWISKA WHERE ID_STANOWISKA='" + id + "'", conn);
                    conn.Open();
                    SqlDataReader SDR = Sq.ExecuteReader();
                    conn.Close();

                    MessageBox.Show("Usunięto STANOWISKO!", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    PrzeglądanieBDAdmin PBDA = new PrzeglądanieBDAdmin(1);
                    PBDA.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show(trescBledu, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

        }

        private void button7_Click(object sender, EventArgs e)
        {
            PrzeglądanieBDAdmin PBDA = new PrzeglądanieBDAdmin(1);
            PBDA.Show();
            this.Close();
        }

        private void EdytowanieStanowiska_Load(object sender, EventArgs e)
        {

        }

        private void EdytowanieStanowiska_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
