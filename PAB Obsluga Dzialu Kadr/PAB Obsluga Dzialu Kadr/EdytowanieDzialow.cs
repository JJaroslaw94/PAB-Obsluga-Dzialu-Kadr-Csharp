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
    public partial class EdytowanieDzialow : Form
    {
        SqlDataAdapter sda;
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Integrated Security=True;AttachDbFilename=|DataDirectory|\BazaDanych.mdf"); SqlCommand Sq;
        DataTable Dzial;

        String id;
        public EdytowanieDzialow(String ID)
        {
            id = ID;
            InitializeComponent();

            sda = new SqlDataAdapter("SELECT ID_DZIALU, NAZWA_DZIALU FROM DZIAL where ID_DZIALU='"+id+"'", conn);
            Dzial = new DataTable();
            sda.Fill(Dzial);

            textBox1.Text = Convert.ToString(Dzial.Rows[0][1]);


        }

        private void button7_Click(object sender, EventArgs e)
        {
            PrzeglądanieBDAdmin PBDA = new PrzeglądanieBDAdmin(4);
            PBDA.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Sq = new SqlCommand("UPDATE DZIAL set NAZWA_DZIALU='" + textBox1.Text + "' where ID_DZIALU='" + id + "'", conn);
            conn.Open();
            SqlDataReader SDR = Sq.ExecuteReader();
            conn.Close();

            MessageBox.Show("Edytowano Dział!", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);

            PrzeglądanieBDAdmin PBDA = new PrzeglądanieBDAdmin(4);
            PBDA.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Boolean mozna = true;
            String trescBledu = "Nie mozna usunac dzialu " + Dzial.Rows[0][1] + " ponieważ: ";

            sda = new SqlDataAdapter("select count(*) from PRACOWNICY where ID_DZIALU='" + id + "'", conn);
            DataTable check1 = new DataTable();
            sda.Fill(check1);

            if (Convert.ToString(check1.Rows[0][0]) != "0")
            {
                mozna = false;
                trescBledu = trescBledu + "\nIstnieją jeszcze pracownicy w tym dziale";
            }

            sda = new SqlDataAdapter("select count(*) from STANOWISKA where ID_DZIALU='" + id + "'", conn);
            DataTable check2 = new DataTable();
            sda.Fill(check2);

            if (Convert.ToString(check2.Rows[0][0]) != "0")
            {
                mozna = false;
                trescBledu = trescBledu + "\nIstnieją jeszcze stanowiska w tym dziale";
            }

            if (mozna)
            {
                Sq = new SqlCommand("DELETE FROM DZIAL WHERE ID_DZIALU='" + id + "'", conn);
                conn.Open();
                SqlDataReader SDR = Sq.ExecuteReader();
                conn.Close();

                MessageBox.Show("Usunięto Pracownika!", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);

                PrzeglądanieBDAdmin PBDA = new PrzeglądanieBDAdmin(4);
                PBDA.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show(trescBledu, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void EdytowanieDzialow_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
