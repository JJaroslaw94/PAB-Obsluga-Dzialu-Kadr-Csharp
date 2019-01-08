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
    public partial class OknoPodaniaGoscia : Form
    {
        int indexDzialu1;
        String stanowisko;
        public OknoPodaniaGoscia(String Stanowisko)
        {
            stanowisko = Stanowisko;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OknoGoscia1 og1 = new OknoGoscia1();
            og1.Show();
            this.Dispose();
        }

        private void pODANIABindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.pODANIABindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dataSet1);
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



            label1.Text = Convert.ToString(dataSet1.PODANIA.Count());
            pODANIABindingSource.AddNew();
            dATA_OTRZYMANIADateTimePicker.Value = DateTime.Now;
            iD_PODANIATextBox.Text = Convert.ToString(dataSet1.PODANIA.Count());
            sTANTextBox.Text = "0";
            iD_STANOWISKATextBox.Text = "0";
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

        private void nAZWA_STANOWISKAComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            String wybraneStanowisko = nAZWA_STANOWISKAComboBox.Text;
            label1.Text = wybraneStanowisko;
            iD_STANOWISKATextBox.Text = Convert.ToString(nAZWA_STANOWISKAComboBox.SelectedIndex);

            //TODO naprawic powyzszy wpis. ma miec powiazanie z tablica stanowiska (ID)

            dZIALBindingSource.MoveFirst();
            int index = dZIALBindingSource.Find("ID_DZIALU",iD_DZIALULabel3.Text);
            indexDzialu1 = index;
            for (int i = 0; i < index; i++)
                dZIALBindingSource.MoveNext();
            label3.Text = Convert.ToString(index);

            dZIALBindingSource.ResetBindings(true);


        }

        private void nAZWA_DZIALULabel_Click(object sender, EventArgs e)
        {

        }

        private void nAZWA_DZIALULabel1_Click(object sender, EventArgs e)
        {

        }

        private void iD_DZIALULabel3_TextChanged(object sender, EventArgs e)
        {
    
        }
    }
}
