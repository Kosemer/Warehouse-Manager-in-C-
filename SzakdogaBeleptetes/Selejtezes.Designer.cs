namespace SzakdogaBeleptetes
{
    partial class Selejtezes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Selejtezes));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.gyartasID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.felkeszSzint = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cikkMegnevezese = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.keszletMennyiseg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mertekegyseg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.raktar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dopAzonosito = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rendelesSzam = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.modositasIdeje = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.frissitesLB = new System.Windows.Forms.Label();
            this.button7 = new System.Windows.Forms.Button();
            this.exportLb = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.keresesTXB = new SzakdogaBeleptetes.ExtraTextbox();
            this.selejtezesLB = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.ablakBezarasLB = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(169)))), ((int)(((byte)(79)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1482, 70);
            this.panel1.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(12, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(195, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Készlet lekérdezés";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(27, 116);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(25, 24);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 72;
            this.pictureBox1.TabStop = false;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(643, 116);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(67, 22);
            this.textBox2.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(522, 119);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Találatok száma:";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.MintCream;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.NullValue = null;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeight = 25;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.gyartasID,
            this.felkeszSzint,
            this.cikkMegnevezese,
            this.keszletMennyiseg,
            this.mertekegyseg,
            this.raktar,
            this.dopAzonosito,
            this.rendelesSzam,
            this.modositasIdeje});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.Location = new System.Drawing.Point(23, 214);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1436, 625);
            this.dataGridView1.TabIndex = 10;
            // 
            // gyartasID
            // 
            this.gyartasID.DataPropertyName = "gyartasID";
            this.gyartasID.HeaderText = "GyartasID";
            this.gyartasID.Name = "gyartasID";
            this.gyartasID.ReadOnly = true;
            this.gyartasID.Visible = false;
            this.gyartasID.Width = 112;
            // 
            // felkeszSzint
            // 
            this.felkeszSzint.DataPropertyName = "felkeszSzint";
            this.felkeszSzint.HeaderText = "Félkész szint";
            this.felkeszSzint.Name = "felkeszSzint";
            this.felkeszSzint.ReadOnly = true;
            this.felkeszSzint.Width = 135;
            // 
            // cikkMegnevezese
            // 
            this.cikkMegnevezese.DataPropertyName = "cikkMegnevezese";
            this.cikkMegnevezese.HeaderText = "Megnevezése";
            this.cikkMegnevezese.Name = "cikkMegnevezese";
            this.cikkMegnevezese.ReadOnly = true;
            this.cikkMegnevezese.Width = 138;
            // 
            // keszletMennyiseg
            // 
            this.keszletMennyiseg.DataPropertyName = "keszletMennyiseg";
            dataGridViewCellStyle2.Format = "N0";
            dataGridViewCellStyle2.NullValue = null;
            this.keszletMennyiseg.DefaultCellStyle = dataGridViewCellStyle2;
            this.keszletMennyiseg.HeaderText = "Mennyiség";
            this.keszletMennyiseg.Name = "keszletMennyiseg";
            this.keszletMennyiseg.ReadOnly = true;
            this.keszletMennyiseg.Width = 115;
            // 
            // mertekegyseg
            // 
            this.mertekegyseg.DataPropertyName = "mertekegyseg";
            this.mertekegyseg.HeaderText = "Mértékegység";
            this.mertekegyseg.Name = "mertekegyseg";
            this.mertekegyseg.ReadOnly = true;
            this.mertekegyseg.Width = 140;
            // 
            // raktar
            // 
            this.raktar.DataPropertyName = "raktar";
            this.raktar.HeaderText = "Raktár";
            this.raktar.Name = "raktar";
            this.raktar.ReadOnly = true;
            this.raktar.Width = 85;
            // 
            // dopAzonosito
            // 
            this.dopAzonosito.DataPropertyName = "dopAzonosito";
            this.dopAzonosito.HeaderText = "Dop azonosító";
            this.dopAzonosito.Name = "dopAzonosito";
            this.dopAzonosito.ReadOnly = true;
            this.dopAzonosito.Width = 146;
            // 
            // rendelesSzam
            // 
            this.rendelesSzam.DataPropertyName = "rendelesSzam";
            this.rendelesSzam.HeaderText = "Rendelési szám";
            this.rendelesSzam.Name = "rendelesSzam";
            this.rendelesSzam.ReadOnly = true;
            this.rendelesSzam.Width = 155;
            // 
            // modositasIdeje
            // 
            this.modositasIdeje.DataPropertyName = "modositasIdeje";
            this.modositasIdeje.HeaderText = "Módosítás ideje";
            this.modositasIdeje.Name = "modositasIdeje";
            this.modositasIdeje.ReadOnly = true;
            this.modositasIdeje.Width = 154;
            // 
            // frissitesLB
            // 
            this.frissitesLB.AutoSize = true;
            this.frissitesLB.Location = new System.Drawing.Point(957, 165);
            this.frissitesLB.Name = "frissitesLB";
            this.frissitesLB.Size = new System.Drawing.Size(60, 17);
            this.frissitesLB.TabIndex = 8;
            this.frissitesLB.Text = "Frissítés";
            this.frissitesLB.Visible = false;
            // 
            // button7
            // 
            this.button7.BackColor = System.Drawing.Color.MintCream;
            this.button7.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button7.FlatAppearance.BorderSize = 0;
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button7.ForeColor = System.Drawing.Color.Black;
            this.button7.Image = ((System.Drawing.Image)(resources.GetObject("button7.Image")));
            this.button7.Location = new System.Drawing.Point(925, 104);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(123, 58);
            this.button7.TabIndex = 2;
            this.button7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button7.UseVisualStyleBackColor = false;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            this.button7.MouseLeave += new System.EventHandler(this.button7_MouseLeave);
            this.button7.MouseHover += new System.EventHandler(this.button7_MouseHover);
            // 
            // exportLb
            // 
            this.exportLb.AutoSize = true;
            this.exportLb.Location = new System.Drawing.Point(1073, 165);
            this.exportLb.Name = "exportLb";
            this.exportLb.Size = new System.Drawing.Size(48, 17);
            this.exportLb.TabIndex = 9;
            this.exportLb.Text = "Export";
            this.exportLb.Visible = false;
            // 
            // button2
            // 
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.Location = new System.Drawing.Point(1038, 92);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(116, 70);
            this.button2.TabIndex = 3;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            this.button2.MouseLeave += new System.EventHandler(this.button2_MouseLeave);
            this.button2.MouseHover += new System.EventHandler(this.button2_MouseHover);
            // 
            // keresesTXB
            // 
            this.keresesTXB.Location = new System.Drawing.Point(52, 116);
            this.keresesTXB.Name = "keresesTXB";
            this.keresesTXB.Size = new System.Drawing.Size(453, 22);
            this.keresesTXB.TabIndex = 0;
            this.keresesTXB.Text = "Keresés...";
            this.keresesTXB.TextboxText = null;
            this.keresesTXB.TextChanged += new System.EventHandler(this.keresesTXB_TextChanged);
            // 
            // selejtezesLB
            // 
            this.selejtezesLB.AutoSize = true;
            this.selejtezesLB.Location = new System.Drawing.Point(827, 165);
            this.selejtezesLB.Name = "selejtezesLB";
            this.selejtezesLB.Size = new System.Drawing.Size(73, 17);
            this.selejtezesLB.TabIndex = 7;
            this.selejtezesLB.Text = "Selejtezés";
            this.selejtezesLB.Visible = false;
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(803, 92);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(116, 70);
            this.button1.TabIndex = 1;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            this.button1.MouseLeave += new System.EventHandler(this.button1_MouseLeave);
            this.button1.MouseHover += new System.EventHandler(this.button1_MouseHover);
            // 
            // ablakBezarasLB
            // 
            this.ablakBezarasLB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ablakBezarasLB.AutoSize = true;
            this.ablakBezarasLB.Location = new System.Drawing.Point(1414, 108);
            this.ablakBezarasLB.Name = "ablakBezarasLB";
            this.ablakBezarasLB.Size = new System.Drawing.Size(60, 17);
            this.ablakBezarasLB.TabIndex = 12;
            this.ablakBezarasLB.Text = "Bezárás";
            this.ablakBezarasLB.Visible = false;
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Image = ((System.Drawing.Image)(resources.GetObject("button3.Image")));
            this.button3.Location = new System.Drawing.Point(1430, 76);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(40, 29);
            this.button3.TabIndex = 11;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            this.button3.MouseLeave += new System.EventHandler(this.button3_MouseLeave);
            this.button3.MouseHover += new System.EventHandler(this.button3_MouseHover);
            // 
            // Selejtezes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MintCream;
            this.ClientSize = new System.Drawing.Size(1482, 1008);
            this.Controls.Add(this.ablakBezarasLB);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.selejtezesLB);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.exportLb);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.keresesTXB);
            this.Controls.Add(this.frissitesLB);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Name = "Selejtezes";
            this.Text = "Selejtezes";
            this.Load += new System.EventHandler(this.Selejtezes_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label frissitesLB;
        private System.Windows.Forms.Button button7;
        private ExtraTextbox keresesTXB;
        private System.Windows.Forms.Label exportLb;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label selejtezesLB;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label ablakBezarasLB;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.DataGridViewTextBoxColumn gyartasID;
        private System.Windows.Forms.DataGridViewTextBoxColumn felkeszSzint;
        private System.Windows.Forms.DataGridViewTextBoxColumn cikkMegnevezese;
        private System.Windows.Forms.DataGridViewTextBoxColumn keszletMennyiseg;
        private System.Windows.Forms.DataGridViewTextBoxColumn mertekegyseg;
        private System.Windows.Forms.DataGridViewTextBoxColumn raktar;
        private System.Windows.Forms.DataGridViewTextBoxColumn dopAzonosito;
        private System.Windows.Forms.DataGridViewTextBoxColumn rendelesSzam;
        private System.Windows.Forms.DataGridViewTextBoxColumn modositasIdeje;
    }
}