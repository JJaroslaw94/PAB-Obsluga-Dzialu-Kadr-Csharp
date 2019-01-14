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
    public partial class EdytujPodania : Form
    {
        String id;
        public EdytujPodania(String ID)
        {
            id = ID;
            InitializeComponent();
        }
    }
}
