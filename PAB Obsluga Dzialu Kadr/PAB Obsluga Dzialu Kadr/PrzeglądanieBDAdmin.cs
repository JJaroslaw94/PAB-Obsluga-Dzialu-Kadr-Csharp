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
    public partial class PrzeglądanieBDAdmin : Form
    {
        //Lista nalożonych na siebie paneli
        //działa jak CardLayout
        List<Panel> ListaPaneli = new List<Panel>();

        public PrzeglądanieBDAdmin(int Okno)
        {
            InitializeComponent();

            ListaPaneli.Add(panel1);
            ListaPaneli.Add(panel2);
            ListaPaneli.Add(panel3);
            ListaPaneli.Add(panel4);
            ListaPaneli.Add(panel5);

            ListaPaneli[0].Hide();
            ListaPaneli[1].Hide();
            ListaPaneli[2].Hide();
            ListaPaneli[3].Hide();
            ListaPaneli[4].Hide();

            ListaPaneli[Okno].Show();

            SqlDataAdapter sda;
            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Integrated Security=True;AttachDbFilename=|DataDirectory|\BazaDanych.mdf");
            //CZ1 Pracownicy

            listView1.FullRowSelect = true;
            ListViewExtender extender1 = new ListViewExtender(listView1);
            ListViewButtonColumn buttonAction1 = new ListViewButtonColumn(7);
            buttonAction1.Click += buttonMulti1;
            buttonAction1.FixedWidth = true;
            extender1.AddColumn(buttonAction1);

            sda = new SqlDataAdapter("select ID_PRACOWNIKA, ID_STANOWISKA, ID_DZIALU, IMIE_PRACOWNIKA, NAZWISKO_PRACOWNIKA, E_MAIL_PRACOWNIKA, HASLO_PRACOWNIKA from PRACOWNICY", conn);
            DataTable Pracownicy = new DataTable();
            sda.Fill(Pracownicy);

            List<String> ListaID = new List<String>();
            List<Button> ListaPrzyciskow = new List<Button>();
            int xTabeli = Pracownicy.Rows.Count;
            for (int i = 0; i < xTabeli; i++)
            {
                ListViewItem dana = new ListViewItem(Convert.ToString(i+1),0);
                
                int yTabeli = Pracownicy.Columns.Count;
                for (int ii = 0; ii <yTabeli+1; ii++)
                {
                    if (ii == 0)
                    {
                        ListaID.Add(Convert.ToString(Pracownicy.Rows[i][ii]));
                    }else
                    if (ii == 1)
                    {
                        sda = new SqlDataAdapter("select NAZWA_STANOWISKA from STANOWISKA where ID_STANOWISKA ='" + Convert.ToString(Pracownicy.Rows[i][ii]) + "'", conn);
                        DataTable stanowisko = new DataTable();
                        sda.Fill(stanowisko);
                        dana.SubItems.Add(Convert.ToString(stanowisko.Rows[0][0]));
                    }
                    else
                    if (ii == 2)
                    {
                        sda = new SqlDataAdapter("select NAZWA_DZIALU from DZIAL where ID_DZIALU ='" + Convert.ToString(Pracownicy.Rows[i][ii]) + "'", conn);
                        DataTable dzial = new DataTable();
                        sda.Fill(dzial);
                        dana.SubItems.Add(Convert.ToString(dzial.Rows[0][0]));
                    }
                    else
                    if (ii == yTabeli)
                    {
                        dana.SubItems.Add(Convert.ToString(Pracownicy.Rows[i][0]));

                    }
                    else
                    {
                        dana.SubItems.Add(Convert.ToString(Pracownicy.Rows[i][ii]));
                    }
                }

                listView1.Items.Add(dana);
            }

            //CZ2 Stanowiska

            listView2.FullRowSelect = true;
            ListViewExtender extender2 = new ListViewExtender(listView2);
            ListViewButtonColumn buttonAction2 = new ListViewButtonColumn(5);
            buttonAction2.Click += buttonMulti2;
            buttonAction2.FixedWidth = true;
            extender2.AddColumn(buttonAction2);

            sda = new SqlDataAdapter("select ID_STANOWISKA, ID_DZIALU, NAZWA_STANOWISKA, MIEJSCA, UPRAWNIENIA from STANOWISKA", conn);
            DataTable Stanowiska = new DataTable();
            sda.Fill(Stanowiska);

            List<String> ListaIDS = new List<String>();
            List<Button> ListaPrzyciskowS = new List<Button>();
            int xTabeliS = Stanowiska.Rows.Count;
            for (int i = 0; i < xTabeliS; i++)
            {
                ListViewItem danaS = new ListViewItem(Convert.ToString(i + 1), 0);

                int yTabeli = Stanowiska.Columns.Count;
                for (int ii = 0; ii < yTabeli + 1; ii++)
                {
                    if (ii == 0)
                    {
                        ListaIDS.Add(Convert.ToString(Stanowiska.Rows[i][ii]));
                    }
                    else
                    if (ii == 1)
                    {
                        sda = new SqlDataAdapter("select NAZWA_DZIALU from DZIAL where ID_DZIALU ='" + Convert.ToString(Stanowiska.Rows[i][ii]) + "'", conn);
                        DataTable dzial = new DataTable();
                        sda.Fill(dzial);
                        danaS.SubItems.Add(Convert.ToString(dzial.Rows[0][0]));
                    }
                    else
                    if (ii == yTabeli)
                    {
                        danaS.SubItems.Add(Convert.ToString(Stanowiska.Rows[i][0]));

                    }
                    else
                    {
                        danaS.SubItems.Add(Convert.ToString(Stanowiska.Rows[i][ii]));
                    }
                    
                }
                listView2.Items.Add(danaS);
            }

            //CZ3 Podania

            listView3.FullRowSelect = true;
            ListViewExtender extender3 = new ListViewExtender(listView3);
            ListViewButtonColumn buttonAction3 = new ListViewButtonColumn(11);
            buttonAction3.Click += buttonMulti3;
            buttonAction3.FixedWidth = true;
            extender3.AddColumn(buttonAction3);

            sda = new SqlDataAdapter("select ID_PODANIA, ID_STANOWISKA, IMIE_PRACOWNIKA, NAZWISKO_PRACOWNIKA, WIEK, RODZAJ_WYKSZTALCENIA, MIEJSCE_ZAMIESZKANIA, DLUGOSC_STAZU, DATA_OTRZYMANIA, STAN, TELEFON from PODANIA", conn);
            DataTable Podania = new DataTable();
            sda.Fill(Podania);

            List<String> ListaIDPod = new List<String>();
            List<Button> ListaPrzyciskowPod = new List<Button>();
            int xTabeliPod = Podania.Rows.Count;
            for (int i = 0; i < xTabeliPod; i++)
            {
                ListViewItem danaPod = new ListViewItem(Convert.ToString(i + 1), 0);

                int yTabeli = Podania.Columns.Count;
                for (int ii = 0; ii < yTabeli + 1; ii++)
                {
                    if (ii == 0)
                    {
                        ListaIDPod.Add(Convert.ToString(Podania.Rows[i][ii]));
                    }
                    else
                    if (ii == 1)
                    {
                        sda = new SqlDataAdapter("select NAZWA_STANOWISKA from STANOWISKA where ID_STANOWISKA ='" + Convert.ToString(Podania.Rows[i][ii]) + "'", conn);
                        DataTable stan = new DataTable();
                        sda.Fill(stan);
                        danaPod.SubItems.Add(Convert.ToString(stan.Rows[0][0]));
                    }
                    else
                    if (ii == yTabeli)
                    {
                        danaPod.SubItems.Add(Convert.ToString(Podania.Rows[i][0]));
                    }
                    else
                    if (ii == 9)
                    {
                        if (Convert.ToString(Podania.Rows[i][ii]).Equals("0"))
                        {
                            danaPod.SubItems.Add("Nie sprawdzone");
                        }
                        if (Convert.ToString(Podania.Rows[i][ii]).Equals("1"))
                        {
                            danaPod.SubItems.Add("Odłożone");
                        }
                        if (Convert.ToString(Podania.Rows[i][ii]).Equals("2"))
                        {
                            danaPod.SubItems.Add("Zaakceptowane");
                        }
                    }
                    else
                    {
                        danaPod.SubItems.Add(Convert.ToString(Podania.Rows[i][ii]));
                    }


                }
                listView3.Items.Add(danaPod);
            }

            //CZ4 Oferty

            listView4.FullRowSelect = true;
            ListViewExtender extender4 = new ListViewExtender(listView4);
            ListViewButtonColumn buttonAction4 = new ListViewButtonColumn(7);
            buttonAction4.Click += buttonMulti4;
            buttonAction4.FixedWidth = true;
            extender4.AddColumn(buttonAction4);

            sda = new SqlDataAdapter("select ID__OFERTY, ID_STANOWISKA, NAZWA_STANOWISKA, OPIS, WYMOGI, WYNAGRODZENIE, DOSTEPNE_MIEJSCA from OFERTY", conn);
            DataTable Oferty = new DataTable();
            sda.Fill(Oferty);

            List<String> ListaIDO = new List<String>();
            List<Button> ListaPrzyciskowO = new List<Button>();
            int xTabeliO = Oferty.Rows.Count;
            for (int i = 0; i < xTabeliO; i++)
            {
                ListViewItem danaO = new ListViewItem(Convert.ToString(i + 1), 0);

                int yTabeli = Oferty.Columns.Count;
                for (int ii = 0; ii < yTabeli + 1; ii++)
                {
                    if (ii == 0)
                    {
                        ListaIDO.Add(Convert.ToString(Oferty.Rows[i][ii]));
                    }
                    else
                    if (ii == 1)
                    {
                        sda = new SqlDataAdapter("select NAZWA_STANOWISKA from STANOWISKA where ID_STANOWISKA ='" + Convert.ToString( Oferty.Rows[i][ii]) + "'", conn);
                        DataTable of = new DataTable();
                        sda.Fill(of);
                        danaO.SubItems.Add(Convert.ToString(of.Rows[0][0]));
                    }
                    else
                    if (ii == yTabeli)
                    {
                        danaO.SubItems.Add(Convert.ToString(Oferty.Rows[i][0]));
                    }
                    else                   
                    {
                        danaO.SubItems.Add(Convert.ToString(Oferty.Rows[i][ii]));
                    }
                }
                listView4.Items.Add(danaO);
            }

            //CZ5 Dzialy

            listView5.FullRowSelect = true;
            ListViewExtender extender5 = new ListViewExtender(listView5);
            ListViewButtonColumn buttonAction5 = new ListViewButtonColumn(2);
            buttonAction5.Click += buttonMulti5;
            buttonAction5.FixedWidth = true;
            extender5.AddColumn(buttonAction5);

            sda = new SqlDataAdapter("select ID_DZIALU, NAZWA_DZIALU from DZIAL", conn);
            DataTable Dzialy = new DataTable();
            sda.Fill(Dzialy);

            List<String> ListaIDD = new List<String>();
            List<Button> ListaPrzyciskowD = new List<Button>();
            int xTabeliD = Dzialy.Rows.Count;
            for (int i = 0; i < xTabeliD; i++)
            {
                ListViewItem danaD = new ListViewItem(Convert.ToString(i + 1), 0);

                int yTabeli = Dzialy.Columns.Count;
                for (int ii = 0; ii < yTabeli + 1; ii++)
                {
                    if (ii == 0)
                    {
                        ListaIDD.Add(Convert.ToString(Dzialy.Rows[i][ii]));
                    }
                    else
                    if (ii == yTabeli)
                    {
                        danaD.SubItems.Add(Convert.ToString(Dzialy.Rows[i][0]));
                    }
                    else
                    {
                        danaD.SubItems.Add(Convert.ToString(Dzialy.Rows[i][ii]));
                    }
                }
                listView5.Items.Add(danaD);
            }

        }

        private void buttonMulti1(object sender, ListViewColumnMouseEventArgs e)
        {
            EdycjaPracownikow EP = new EdycjaPracownikow(e.SubItem.Text);
            EP.Show();
            this.Close();
        }

        private void buttonMulti2(object sender, ListViewColumnMouseEventArgs e)
        {
            EdytowanieStanowiska ES = new EdytowanieStanowiska(e.SubItem.Text);
            ES.Show();
            this.Close();
        }

        private void buttonMulti3(object sender, ListViewColumnMouseEventArgs e)
        {
            EdytujPodania EP = new EdytujPodania(e.SubItem.Text);
            EP.Show();
            this.Close();
        }

        private void buttonMulti4(object sender, ListViewColumnMouseEventArgs e)
        {
            EdytowanieOferty EO = new EdytowanieOferty(e.SubItem.Text);
            EO.Show();
            this.Close();
        }

        private void buttonMulti5(object sender, ListViewColumnMouseEventArgs e)
        {
            EdytowanieDzialow ED = new EdytowanieDzialow(e.SubItem.Text);
            ED.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ListaPaneli[0].Show();
            ListaPaneli[1].Hide();
            ListaPaneli[2].Hide();
            ListaPaneli[3].Hide();
            ListaPaneli[4].Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ListaPaneli[0].Hide();
            ListaPaneli[1].Show();
            ListaPaneli[2].Hide();
            ListaPaneli[3].Hide();
            ListaPaneli[4].Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ListaPaneli[0].Hide();
            ListaPaneli[1].Hide();
            ListaPaneli[2].Show();
            ListaPaneli[3].Hide();
            ListaPaneli[4].Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ListaPaneli[0].Hide();
            ListaPaneli[1].Hide();
            ListaPaneli[2].Hide();
            ListaPaneli[3].Show();
            ListaPaneli[4].Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ListaPaneli[0].Hide();
            ListaPaneli[1].Hide();
            ListaPaneli[2].Hide();
            ListaPaneli[3].Hide();
            ListaPaneli[4].Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Dodawanie_Pracownika EP = new Dodawanie_Pracownika();
            EP.Show();
            this.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Menu F1 = new Menu();
            F1.Show();
            this.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            DodawanieStanowiska DS = new DodawanieStanowiska();
            DS.Show();
            this.Close();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            DodawanieOfert DO = new DodawanieOfert();
            DO.Show();
            this.Close();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            DodawanieDzialu DD = new DodawanieDzialu();
            DD.Show();
            this.Close();
        }

        private void PrzeglądanieBDAdmin_Load(object sender, EventArgs e)
        {

        }
    }
}
