namespace PAB_Obsluga_Dzialu_Kadr
{
    partial class Menu
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dataSet1 = new PAB_Obsluga_Dzialu_Kadr.DataSet1();
            this.pRACOWNICYBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pRACOWNICYTableAdapter = new PAB_Obsluga_Dzialu_Kadr.DataSet1TableAdapters.PRACOWNICYTableAdapter();
            this.tableAdapterManager = new PAB_Obsluga_Dzialu_Kadr.DataSet1TableAdapters.TableAdapterManager();
            this.buttonMenu1admin = new System.Windows.Forms.Button();
            this.buttonMenu1gosc = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pRACOWNICYBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataSet1
            // 
            this.dataSet1.DataSetName = "DataSet1";
            this.dataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // pRACOWNICYBindingSource
            // 
            this.pRACOWNICYBindingSource.DataMember = "PRACOWNICY";
            this.pRACOWNICYBindingSource.DataSource = this.dataSet1;
            // 
            // pRACOWNICYTableAdapter
            // 
            this.pRACOWNICYTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.DZIALTableAdapter = null;
            this.tableAdapterManager.OFERTYTableAdapter = null;
            this.tableAdapterManager.PODANIATableAdapter = null;
            this.tableAdapterManager.PRACOWNICYTableAdapter = this.pRACOWNICYTableAdapter;
            this.tableAdapterManager.STANOWISKATableAdapter = null;
            this.tableAdapterManager.UpdateOrder = PAB_Obsluga_Dzialu_Kadr.DataSet1TableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // buttonMenu1admin
            // 
            this.buttonMenu1admin.Location = new System.Drawing.Point(12, 12);
            this.buttonMenu1admin.Name = "buttonMenu1admin";
            this.buttonMenu1admin.Size = new System.Drawing.Size(216, 64);
            this.buttonMenu1admin.TabIndex = 0;
            this.buttonMenu1admin.Text = "Jestem Administratorem";
            this.buttonMenu1admin.UseVisualStyleBackColor = true;
            this.buttonMenu1admin.Click += new System.EventHandler(this.buttonMenu1admin_Click);
            // 
            // buttonMenu1gosc
            // 
            this.buttonMenu1gosc.Location = new System.Drawing.Point(12, 82);
            this.buttonMenu1gosc.Name = "buttonMenu1gosc";
            this.buttonMenu1gosc.Size = new System.Drawing.Size(216, 64);
            this.buttonMenu1gosc.TabIndex = 1;
            this.buttonMenu1gosc.Text = "Szukam Pracy";
            this.buttonMenu1gosc.UseVisualStyleBackColor = true;
            this.buttonMenu1gosc.Click += new System.EventHandler(this.buttonMenu1gosc_Click);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(240, 158);
            this.Controls.Add(this.buttonMenu1gosc);
            this.Controls.Add(this.buttonMenu1admin);
            this.Name = "Menu";
            this.Text = "Menu";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pRACOWNICYBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DataSet1 dataSet1;
        private System.Windows.Forms.BindingSource pRACOWNICYBindingSource;
        private DataSet1TableAdapters.PRACOWNICYTableAdapter pRACOWNICYTableAdapter;
        private DataSet1TableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.Button buttonMenu1admin;
        private System.Windows.Forms.Button buttonMenu1gosc;
    }
}

