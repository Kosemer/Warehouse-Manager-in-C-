﻿namespace SzakdogaBeleptetes
{
    partial class SelejtWindowForm2
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
            this.label4 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.selejtezesiOkMegnCMB = new SzakdogaBeleptetes.CheckedComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.megjegyzesTXB = new System.Windows.Forms.TextBox();
            this.selejtezesiOkTXB = new System.Windows.Forms.TextBox();
            this.selejtezendoMTXB = new SzakdogaBeleptetes.CheckedTextBox();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label4.Location = new System.Drawing.Point(98, 213);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 17);
            this.label4.TabIndex = 9;
            this.label4.Text = "Módosítás ideje:";
            this.label4.Visible = false;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Checked = false;
            this.dateTimePicker1.Location = new System.Drawing.Point(214, 208);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(214, 22);
            this.dateTimePicker1.TabIndex = 10;
            this.dateTimePicker1.Visible = false;
            // 
            // selejtezesiOkMegnCMB
            // 
            this.selejtezesiOkMegnCMB.FormattingEnabled = true;
            this.selejtezesiOkMegnCMB.Location = new System.Drawing.Point(189, 47);
            this.selejtezesiOkMegnCMB.Name = "selejtezesiOkMegnCMB";
            this.selejtezesiOkMegnCMB.Size = new System.Drawing.Size(242, 24);
            this.selejtezesiOkMegnCMB.TabIndex = 1;
            this.selejtezesiOkMegnCMB.SelectedIndexChanged += new System.EventHandler(this.selejtezesiOkMegnCMB_SelectedIndexChanged);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button2.Location = new System.Drawing.Point(20, 118);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(482, 34);
            this.button2.TabIndex = 3;
            this.button2.Text = "OK";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Salmon;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button1.Location = new System.Drawing.Point(20, 168);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(482, 34);
            this.button1.TabIndex = 4;
            this.button1.Text = "Mégsem";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label3.Location = new System.Drawing.Point(17, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 18);
            this.label3.TabIndex = 8;
            this.label3.Text = "Megjegyzés:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(17, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 18);
            this.label2.TabIndex = 7;
            this.label2.Text = "Selejtezési ok:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(17, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 18);
            this.label1.TabIndex = 6;
            this.label1.Text = "Selejtezendő menny.:";
            // 
            // megjegyzesTXB
            // 
            this.megjegyzesTXB.Location = new System.Drawing.Point(189, 75);
            this.megjegyzesTXB.Name = "megjegyzesTXB";
            this.megjegyzesTXB.Size = new System.Drawing.Size(313, 22);
            this.megjegyzesTXB.TabIndex = 2;
            // 
            // selejtezesiOkTXB
            // 
            this.selejtezesiOkTXB.Enabled = false;
            this.selejtezesiOkTXB.Location = new System.Drawing.Point(437, 47);
            this.selejtezesiOkTXB.Name = "selejtezesiOkTXB";
            this.selejtezesiOkTXB.Size = new System.Drawing.Size(65, 22);
            this.selejtezesiOkTXB.TabIndex = 5;
            // 
            // selejtezendoMTXB
            // 
            this.selejtezendoMTXB.Location = new System.Drawing.Point(189, 18);
            this.selejtezendoMTXB.Name = "selejtezendoMTXB";
            this.selejtezendoMTXB.Size = new System.Drawing.Size(100, 22);
            this.selejtezendoMTXB.TabIndex = 0;
            this.selejtezendoMTXB.TextBoxTextNumber = null;
            // 
            // SelejtWindowForm2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(39)))), ((int)(((byte)(40)))));
            this.ClientSize = new System.Drawing.Size(520, 237);
            this.ControlBox = false;
            this.Controls.Add(this.selejtezendoMTXB);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.selejtezesiOkMegnCMB);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.megjegyzesTXB);
            this.Controls.Add(this.selejtezesiOkTXB);
            this.Name = "SelejtWindowForm2";
            this.Opacity = 0.95D;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Selejtezés";
            this.Load += new System.EventHandler(this.SelejtWindowForm2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private SzakdogaBeleptetes.CheckedComboBox selejtezesiOkMegnCMB;
        public System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox megjegyzesTXB;
        private System.Windows.Forms.TextBox selejtezesiOkTXB;
        private CheckedTextBox selejtezendoMTXB;
    }
}