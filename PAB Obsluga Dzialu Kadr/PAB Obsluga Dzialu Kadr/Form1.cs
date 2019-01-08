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
    public partial class Menu : Form
    {
        public OknoGoscia1 og1;

        public Menu()
        {
            InitializeComponent();
        }

        private void pRACOWNICYBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.pRACOWNICYBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dataSet1);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: Ten wiersz kodu wczytuje dane do tabeli 'dataSet1.PRACOWNICY' . Możesz go przenieść lub usunąć.
            this.pRACOWNICYTableAdapter.Fill(this.dataSet1.PRACOWNICY);

        }

        private void buttonMenu1admin_Click(object sender, EventArgs e)
        {
            OknoAdministratora1 oa1 = new OknoAdministratora1();
            this.Hide();
            oa1.Show();
        }

        private void buttonMenu1gosc_Click(object sender, EventArgs e)
        {
            og1 = new OknoGoscia1();
            this.Hide();
            og1.Show();
        }
    }
}
