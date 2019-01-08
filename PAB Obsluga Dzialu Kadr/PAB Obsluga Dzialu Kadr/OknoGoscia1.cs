using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PAB_Obsluga_Dzialu_Kadr
{
    public partial class OknoGoscia1 : Form
    {
        public String Dzial;
        private int IndexPrzegladanychRekordow = 1;

        public OknoGoscia1()
        {        
            InitializeComponent();         
        }

        private void button1_Click(object sender, EventArgs e)
        {            
            Menu podniesienie = new Menu();
            podniesienie.Show();
            this.Dispose();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }


        private void oFERTYBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.oFERTYBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dataSet1);

        }

        private void OknoGoscia1_Load(object sender, EventArgs e)
        {
            // TODO: Ten wiersz kodu wczytuje dane do tabeli 'dataSet1.OFERTY' . Możesz go przenieść lub usunąć.
            this.oFERTYTableAdapter.Fill(this.dataSet1.OFERTY);

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            int ileRekordow = dataSet1.OFERTY.Rows.Count;
            IndexPrzegladanychRekordow--;

            if (IndexPrzegladanychRekordow == 0)
            {
                oFERTYBindingSource.MoveLast();
                IndexPrzegladanychRekordow = ileRekordow;
                
            }      
            else
                oFERTYBindingSource.MovePrevious();
            
                
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int ileRekordow = dataSet1.OFERTY.Rows.Count;
            IndexPrzegladanychRekordow++;

            if (IndexPrzegladanychRekordow == (ileRekordow+1))
            {
                oFERTYBindingSource.MoveFirst();
                IndexPrzegladanychRekordow = 1;
            }
            else
             oFERTYBindingSource.MoveNext();                        
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Dzial = nAZWA_STANOWISKATextBox.Text;
            OknoPodaniaGoscia OPG = new OknoPodaniaGoscia(Dzial);
            OPG.Show();
            this.Dispose();           
        }
    }
}
