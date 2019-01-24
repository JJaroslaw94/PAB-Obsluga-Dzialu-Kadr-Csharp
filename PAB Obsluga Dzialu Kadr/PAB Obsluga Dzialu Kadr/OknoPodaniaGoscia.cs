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
    public partial class OknoPodaniaGoscia : Form
    {
        
        String indexStanowiska = "0";
        String stanowisko;
        SqlDataAdapter sda;
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Integrated Security=True;AttachDbFilename=|DataDirectory|\BazaDanych.mdf"); SqlCommand Sq;
        DataTable Stanowiska;

        public OknoPodaniaGoscia(String Stanowisko)
        {
            stanowisko = Stanowisko;
            InitializeComponent();
            

            sda = new SqlDataAdapter("select NAZWA_STANOWISKA, ID_DZIALU, ID_STANOWISKA from STANOWISKA", conn);
            Stanowiska = new DataTable();
            sda.Fill(Stanowiska);
        
            int ileStanowisk = Stanowiska.Rows.Count;
            for (int i = 0; i < ileStanowisk; i++)
            {
                nAZWA_STANOWISKAComboBox.Items.Add(Convert.ToString(Stanowiska.Rows[i][0]));
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OknoGoscia1 og1 = new OknoGoscia1();
            og1.Show();
            this.Close();
        }

        private void OknoPodaniaGoscia_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet1.DZIAL' table. You can move, or remove it, as needed.
            this.dZIALTableAdapter.Fill(this.dataSet1.DZIAL);
            // TODO: Ten wiersz kodu wczytuje dane do tabeli 'dataSet1.STANOWISKA' . Możesz go przenieść lub usunąć.
            this.sTANOWISKATableAdapter.Fill(this.dataSet1.STANOWISKA);
            int IleStanowisk = dataSet1.STANOWISKA.Count();
            // TODO: Ten wiersz kodu wczytuje dane do tabeli 'dataSet1.PODANIA' . Możesz go przenieść lub usunąć.
            this.pODANIATableAdapter.Fill(this.dataSet1.PODANIA);
        }

        private void fillByToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.sTANOWISKATableAdapter.FillBy(this.dataSet1.STANOWISKA);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DateTime czas = DateTime.Now;
            String czasPoConv = czas.Month + "." + czas.Day + "." + czas.Year;
            
            Sq = new SqlCommand("INSERT INTO PODANIA (ID_STANOWISKA, IMIE_PRACOWNIKA, NAZWISKO_PRACOWNIKA, WIEK, RODZAJ_WYKSZTALCENIA, MIEJSCE_ZAMIESZKANIA, DLUGOSC_STAZU, DATA_OTRZYMANIA, STAN, TELEFON) VALUES ('"+ Convert.ToString(indexStanowiska) + "','"+ textBox1.Text +"','"+ textBox2.Text+"','"+ textBox3.Text +"','"+ textBox4.Text+"','"+ textBox5.Text+"','"+ textBox6.Text+"','"+ czasPoConv + "','0','"+ textBox7.Text+ "')", conn);
            conn.Open();
            SqlDataReader SDR = Sq.ExecuteReader();
            conn.Close();

            MessageBox.Show("Podanie wysłano!", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);

            Menu podniesienie = new Menu();
            podniesienie.Show();
            this.Close();
        }

        private void nAZWA_STANOWISKAComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            int indexWybranego = nAZWA_STANOWISKAComboBox.SelectedIndex;

            sda = new SqlDataAdapter("select NAZWA_DZIALU from DZIAL where ID_DZIALU = '" + Convert.ToString(Stanowiska.Rows[indexWybranego][1]) +"'", conn);
            DataTable Dzialy = new DataTable();
            sda.Fill(Dzialy);

            nAZWA_DZIALULabel1.Text = Convert.ToString(Dzialy.Rows[0][0]);
            indexStanowiska = Convert.ToString(Stanowiska.Rows[indexWybranego][2]);
        }

        private void OknoPodaniaGoscia_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
