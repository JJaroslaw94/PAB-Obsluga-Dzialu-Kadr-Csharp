namespace PAB_Obsluga_Dzialu_Kadr
{
    partial class OknoGoscia1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OknoGoscia1));
            this.buttonPowrotuDoMenu = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.dataSet1 = new PAB_Obsluga_Dzialu_Kadr.DataSet1();
            this.oFERTYBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.oFERTYTableAdapter = new PAB_Obsluga_Dzialu_Kadr.DataSet1TableAdapters.OFERTYTableAdapter();
            this.tableAdapterManager = new PAB_Obsluga_Dzialu_Kadr.DataSet1TableAdapters.TableAdapterManager();
            this.nAZWA_STANOWISKATextBox = new System.Windows.Forms.TextBox();
            this.oPISTextBox = new System.Windows.Forms.TextBox();
            this.wYMOGITextBox = new System.Windows.Forms.TextBox();
            this.wYNAGRODZENIETextBox = new System.Windows.Forms.TextBox();
            this.dOSTEPNE_MIEJSCATextBox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.oFERTYBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonPowrotuDoMenu
            // 
            this.buttonPowrotuDoMenu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonPowrotuDoMenu.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonPowrotuDoMenu.BackgroundImage")));
            this.buttonPowrotuDoMenu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonPowrotuDoMenu.Location = new System.Drawing.Point(12, 341);
            this.buttonPowrotuDoMenu.Name = "buttonPowrotuDoMenu";
            this.buttonPowrotuDoMenu.Size = new System.Drawing.Size(32, 32);
            this.buttonPowrotuDoMenu.TabIndex = 0;
            this.buttonPowrotuDoMenu.UseVisualStyleBackColor = true;
            this.buttonPowrotuDoMenu.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(37, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "Oferty";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(39, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Stanowisko:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(71, 91);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Opis:";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(36, 153);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Wymagania:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(20, 220);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(84, 13);
            this.label8.TabIndex = 8;
            this.label8.Text = "Wynagrodzenie:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(56, 274);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(46, 13);
            this.label10.TabIndex = 10;
            this.label10.Text = "Miejsca:";
            // 
            // dataSet1
            // 
            this.dataSet1.DataSetName = "DataSet1";
            this.dataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // oFERTYBindingSource
            // 
            this.oFERTYBindingSource.DataMember = "OFERTY";
            this.oFERTYBindingSource.DataSource = this.dataSet1;
            // 
            // oFERTYTableAdapter
            // 
            this.oFERTYTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.DZIALTableAdapter = null;
            this.tableAdapterManager.OFERTYTableAdapter = this.oFERTYTableAdapter;
            this.tableAdapterManager.PODANIATableAdapter = null;
            this.tableAdapterManager.PRACOWNICYTableAdapter = null;
            this.tableAdapterManager.STANOWISKATableAdapter = null;
            this.tableAdapterManager.UpdateOrder = PAB_Obsluga_Dzialu_Kadr.DataSet1TableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // nAZWA_STANOWISKATextBox
            // 
            this.nAZWA_STANOWISKATextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.oFERTYBindingSource, "NAZWA_STANOWISKA", true));
            this.nAZWA_STANOWISKATextBox.Location = new System.Drawing.Point(128, 47);
            this.nAZWA_STANOWISKATextBox.Name = "nAZWA_STANOWISKATextBox";
            this.nAZWA_STANOWISKATextBox.ReadOnly = true;
            this.nAZWA_STANOWISKATextBox.Size = new System.Drawing.Size(100, 20);
            this.nAZWA_STANOWISKATextBox.TabIndex = 18;
            // 
            // oPISTextBox
            // 
            this.oPISTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.oFERTYBindingSource, "OPIS", true));
            this.oPISTextBox.Location = new System.Drawing.Point(128, 88);
            this.oPISTextBox.Multiline = true;
            this.oPISTextBox.Name = "oPISTextBox";
            this.oPISTextBox.ReadOnly = true;
            this.oPISTextBox.Size = new System.Drawing.Size(365, 56);
            this.oPISTextBox.TabIndex = 20;
            // 
            // wYMOGITextBox
            // 
            this.wYMOGITextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.oFERTYBindingSource, "WYMOGI", true));
            this.wYMOGITextBox.Location = new System.Drawing.Point(128, 150);
            this.wYMOGITextBox.Multiline = true;
            this.wYMOGITextBox.Name = "wYMOGITextBox";
            this.wYMOGITextBox.ReadOnly = true;
            this.wYMOGITextBox.Size = new System.Drawing.Size(365, 61);
            this.wYMOGITextBox.TabIndex = 22;
            // 
            // wYNAGRODZENIETextBox
            // 
            this.wYNAGRODZENIETextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.oFERTYBindingSource, "WYNAGRODZENIE", true));
            this.wYNAGRODZENIETextBox.Location = new System.Drawing.Point(128, 217);
            this.wYNAGRODZENIETextBox.Name = "wYNAGRODZENIETextBox";
            this.wYNAGRODZENIETextBox.ReadOnly = true;
            this.wYNAGRODZENIETextBox.Size = new System.Drawing.Size(100, 20);
            this.wYNAGRODZENIETextBox.TabIndex = 24;
            // 
            // dOSTEPNE_MIEJSCATextBox
            // 
            this.dOSTEPNE_MIEJSCATextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.oFERTYBindingSource, "DOSTEPNE_MIEJSCA", true));
            this.dOSTEPNE_MIEJSCATextBox.Location = new System.Drawing.Point(128, 271);
            this.dOSTEPNE_MIEJSCATextBox.Name = "dOSTEPNE_MIEJSCATextBox";
            this.dOSTEPNE_MIEJSCATextBox.ReadOnly = true;
            this.dOSTEPNE_MIEJSCATextBox.Size = new System.Drawing.Size(100, 20);
            this.dOSTEPNE_MIEJSCATextBox.TabIndex = 26;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 313);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 27;
            this.button1.Text = "Poprzednie";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(93, 313);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 28;
            this.button2.Text = "Następne";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(363, 313);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(130, 23);
            this.button3.TabIndex = 29;
            this.button3.Text = "Napisz podanie";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // OknoGoscia1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(505, 385);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.nAZWA_STANOWISKATextBox);
            this.Controls.Add(this.oPISTextBox);
            this.Controls.Add(this.wYMOGITextBox);
            this.Controls.Add(this.wYNAGRODZENIETextBox);
            this.Controls.Add(this.dOSTEPNE_MIEJSCATextBox);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonPowrotuDoMenu);
            this.Name = "OknoGoscia1";
            this.Text = "Oferty";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OknoGoscia1_FormClosing);
            this.Load += new System.EventHandler(this.OknoGoscia1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.oFERTYBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonPowrotuDoMenu;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private DataSet1 dataSet1;
        private System.Windows.Forms.BindingSource oFERTYBindingSource;
        private DataSet1TableAdapters.OFERTYTableAdapter oFERTYTableAdapter;
        private DataSet1TableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.TextBox nAZWA_STANOWISKATextBox;
        private System.Windows.Forms.TextBox oPISTextBox;
        private System.Windows.Forms.TextBox wYMOGITextBox;
        private System.Windows.Forms.TextBox wYNAGRODZENIETextBox;
        private System.Windows.Forms.TextBox dOSTEPNE_MIEJSCATextBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
}