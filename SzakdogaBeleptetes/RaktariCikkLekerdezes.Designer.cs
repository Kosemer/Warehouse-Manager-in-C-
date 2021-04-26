namespace SzakdogaBeleptetes
{
    partial class RaktariCikkLekerdezes
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
            this.selejtekBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.selejtekBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.selejtekBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn17 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn18 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lejáratiIdőDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.startIdőDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.selejtekBindingSource3 = new System.Windows.Forms.BindingSource(this.components);
            this.termekekDataSet1 = new SzakdogaBeleptetes.TermekekDataSet1();
            this.termekekDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.termekekDataSet = new SzakdogaBeleptetes.TermekekDataSet();
            this.selejtekTableAdapter = new SzakdogaBeleptetes.TermekekDataSet1TableAdapters.SelejtekTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.selejtekBindingSource)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.selejtekBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.selejtekBindingSource2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.selejtekBindingSource3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.termekekDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.termekekDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.termekekDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // selejtekBindingSource
            // 
            this.selejtekBindingSource.DataMember = "Selejtek";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(72, 20);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(833, 22);
            this.textBox1.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(947, 64);
            this.panel1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(3, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 18);
            this.label1.TabIndex = 4;
            this.label1.Text = "Szűrő:";
            // 
            // selejtekBindingSource1
            // 
            this.selejtekBindingSource1.DataMember = "Selejtek";
            // 
            // selejtekBindingSource2
            // 
            this.selejtekBindingSource2.DataMember = "Selejtek";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn10,
            this.dataGridViewTextBoxColumn11,
            this.dataGridViewTextBoxColumn12,
            this.dataGridViewTextBoxColumn13,
            this.dataGridViewTextBoxColumn14,
            this.dataGridViewTextBoxColumn15,
            this.dataGridViewTextBoxColumn16,
            this.dataGridViewTextBoxColumn17,
            this.dataGridViewTextBoxColumn18,
            this.lejáratiIdőDataGridViewTextBoxColumn,
            this.startIdőDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.selejtekBindingSource3;
            this.dataGridView1.Location = new System.Drawing.Point(12, 73);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1142, 205);
            this.dataGridView1.TabIndex = 4;
            this.dataGridView1.AllowUserToAddRowsChanged += new System.EventHandler(this.dataGridView1_AllowUserToAddRowsChanged);
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "Id";
            this.dataGridViewTextBoxColumn10.HeaderText = "Id";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.DataPropertyName = "Cikkszám";
            this.dataGridViewTextBoxColumn11.HeaderText = "Cikkszám";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.DataPropertyName = "Cikk megnevezése";
            this.dataGridViewTextBoxColumn12.HeaderText = "Cikk megnevezése";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            // 
            // dataGridViewTextBoxColumn13
            // 
            this.dataGridViewTextBoxColumn13.DataPropertyName = "Sarzsszám";
            this.dataGridViewTextBoxColumn13.HeaderText = "Sarzsszám";
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            // 
            // dataGridViewTextBoxColumn14
            // 
            this.dataGridViewTextBoxColumn14.DataPropertyName = "Mennyiség";
            this.dataGridViewTextBoxColumn14.HeaderText = "Mennyiség";
            this.dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
            // 
            // dataGridViewTextBoxColumn15
            // 
            this.dataGridViewTextBoxColumn15.DataPropertyName = "Mértékegység";
            this.dataGridViewTextBoxColumn15.HeaderText = "Mértékegység";
            this.dataGridViewTextBoxColumn15.Name = "dataGridViewTextBoxColumn15";
            // 
            // dataGridViewTextBoxColumn16
            // 
            this.dataGridViewTextBoxColumn16.DataPropertyName = "Érték";
            this.dataGridViewTextBoxColumn16.HeaderText = "Érték";
            this.dataGridViewTextBoxColumn16.Name = "dataGridViewTextBoxColumn16";
            // 
            // dataGridViewTextBoxColumn17
            // 
            this.dataGridViewTextBoxColumn17.DataPropertyName = "ME szám";
            this.dataGridViewTextBoxColumn17.HeaderText = "ME szám";
            this.dataGridViewTextBoxColumn17.Name = "dataGridViewTextBoxColumn17";
            // 
            // dataGridViewTextBoxColumn18
            // 
            this.dataGridViewTextBoxColumn18.DataPropertyName = "Megjegyzés";
            this.dataGridViewTextBoxColumn18.HeaderText = "Megjegyzés";
            this.dataGridViewTextBoxColumn18.Name = "dataGridViewTextBoxColumn18";
            // 
            // lejáratiIdőDataGridViewTextBoxColumn
            // 
            this.lejáratiIdőDataGridViewTextBoxColumn.DataPropertyName = "LejáratiIdő";
            this.lejáratiIdőDataGridViewTextBoxColumn.HeaderText = "LejáratiIdő";
            this.lejáratiIdőDataGridViewTextBoxColumn.Name = "lejáratiIdőDataGridViewTextBoxColumn";
            // 
            // startIdőDataGridViewTextBoxColumn
            // 
            this.startIdőDataGridViewTextBoxColumn.DataPropertyName = "StartIdő";
            this.startIdőDataGridViewTextBoxColumn.HeaderText = "StartIdő";
            this.startIdőDataGridViewTextBoxColumn.Name = "startIdőDataGridViewTextBoxColumn";
            // 
            // selejtekBindingSource3
            // 
            this.selejtekBindingSource3.DataMember = "Selejtek";
            this.selejtekBindingSource3.DataSource = this.termekekDataSet1;
            // 
            // termekekDataSet1
            // 
            this.termekekDataSet1.DataSetName = "TermekekDataSet1";
            this.termekekDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // termekekDataSetBindingSource
            // 
            this.termekekDataSetBindingSource.DataSource = this.termekekDataSet;
            this.termekekDataSetBindingSource.Position = 0;
            // 
            // termekekDataSet
            // 
            this.termekekDataSet.DataSetName = "TermekekDataSet";
            this.termekekDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // selejtekTableAdapter
            // 
            this.selejtekTableAdapter.ClearBeforeFill = true;
            // 
            // RaktariCikkLekerdezes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MintCream;
            this.ClientSize = new System.Drawing.Size(1166, 606);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "RaktariCikkLekerdezes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RaktariCikkLekerdezes";
            this.Load += new System.EventHandler(this.RaktariCikkLekerdezes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.selejtekBindingSource)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.selejtekBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.selejtekBindingSource2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.selejtekBindingSource3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.termekekDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.termekekDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.termekekDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.BindingSource selejtekBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cikkszámDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cikkMegnevezéseDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sarzsszámDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn mennyiségDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn mértékegységDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn értékDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn mESzámDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn megjegyzésDataGridViewTextBoxColumn;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.BindingSource selejtekBindingSource1;
        private System.Windows.Forms.BindingSource selejtekBindingSource2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource termekekDataSetBindingSource;
        private TermekekDataSet termekekDataSet;
        private TermekekDataSet1 termekekDataSet1;
        private System.Windows.Forms.BindingSource selejtekBindingSource3;
        private TermekekDataSet1TableAdapters.SelejtekTableAdapter selejtekTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn14;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn15;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn16;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn17;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn18;
        private System.Windows.Forms.DataGridViewTextBoxColumn lejáratiIdőDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn startIdőDataGridViewTextBoxColumn;
    }
}