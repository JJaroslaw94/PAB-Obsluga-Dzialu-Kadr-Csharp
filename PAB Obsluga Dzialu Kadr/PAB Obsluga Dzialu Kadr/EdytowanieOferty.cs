﻿using System;
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
    public partial class EdytowanieOferty : Form
    {
        String id;
        public EdytowanieOferty(String ID)
        {
            id = ID;
            InitializeComponent();
        }
    }
}