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
    public partial class OknoAdministratora1 : Form
    {
        
        public OknoAdministratora1()
        {
            InitializeComponent();
            
        }


        private void button2_Click_1(object sender, EventArgs e)
        {
            SqlDataAdapter sda;
            DataTable dtt;
            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\workspace\PAB-Obsluga-Dzialu-Kadr-Csharp\PAB Obsluga Dzialu Kadr\PAB Obsluga Dzialu Kadr\BazaDanych.mdf;Integrated Security=True");
            sda = new SqlDataAdapter("select count(*) from STANOWISKA INNER JOIN PRACOWNICY ON STANOWISKA.ID_STANOWISKA = PRACOWNICY.ID_STANOWISKA where PRACOWNICY.E_MAIL_PRACOWNIKA ='" + textBox1.Text + "' and PRACOWNICY.HASLO_PRACOWNIKA='" + textBox2.Text + "' and STANOWISKA.UPRAWNIENIA='Administrator'", conn);
            dtt = new DataTable();
            sda.Fill(dtt);
            if (dtt.Rows[0][0].ToString() == "1")
            {
                this.Hide();
                PrzeglądanieBDAdmin PBDA = new PrzeglądanieBDAdmin(0);

                sda = new SqlDataAdapter("select IMIE_PRACOWNIKA, NAZWISKO_PRACOWNIKA from PRACOWNICY where E_MAIL_PRACOWNIKA ='" + textBox1.Text + "' and HASLO_PRACOWNIKA='" + textBox2.Text + "'", conn);
                DataTable dttt = new DataTable();
                sda.Fill(dttt);

                MessageBox.Show("Witamy "+dttt.Rows[0][0]+" "+dttt.Rows[0][1]+"", "Witamy!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                PBDA.Show();
            }
            else
            {
                sda = new SqlDataAdapter("select count(*) from STANOWISKA INNER JOIN PRACOWNICY ON STANOWISKA.ID_STANOWISKA = PRACOWNICY.ID_STANOWISKA where PRACOWNICY.E_MAIL_PRACOWNIKA ='" + textBox1.Text + "' and PRACOWNICY.HASLO_PRACOWNIKA='" + textBox2.Text + "'", conn);
                dtt = new DataTable();
                sda.Fill(dtt);
                if (dtt.Rows[0][0].ToString() == "1")
                {
                    MessageBox.Show("Przepraszamy! Nie posiadasz uprawnień administratora ", "alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }else
                MessageBox.Show("Prosze podaj poprawny email i haslo", "alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
                
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Menu podniesienie = new Menu();
            podniesienie.Show();
        }

    }
}
