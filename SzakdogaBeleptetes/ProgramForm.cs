using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SzakdogaBeleptetes
{
    public partial class ProgramForm : Form
    {
        private bool panelNyitva;
        public ProgramForm()
        {
            Thread td = new Thread(new ThreadStart(formRun));
            td.Start();
            Thread.Sleep(1700);
            InitializeComponent();
            ABKezelo.Kapcsolodas();
            td.Abort();
        }

        private void formRun()
        {
            Application.Run(new WelcomeScreen());
        }

        private void ProgramForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            ABKezelo.KapcsolatBontas();
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TobbAbblak<SzallitoLetrehozasForm>();
        }

        // Megoldás arra, hogy a formokat egy panelben lehessen váltogatni. Ne külön ablakban jelenjenek meg.
        public void TobbAbblak<Tobbform>()where Tobbform:Form, new()
        {
            Form lap;
            lap = FoPanel.Controls.OfType<Tobbform>().FirstOrDefault();
            if (lap == null)
            {
                lap = new Tobbform();
                lap.TopLevel = false;
                lap.FormBorderStyle = FormBorderStyle.None;
                lap.Dock = DockStyle.Fill;
                FoPanel.Controls.Add(lap);
                FoPanel.Tag = lap;
                lap.Show();
                lap.BringToFront();
            }
            else
            {
                lap.BringToFront();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            TobbAbblak<RaktariCikkForm>();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TobbAbblak<UjMegrendelesForm>();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            TobbAbblak<Gyartasi_rendelesForm>();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            TobbAbblak<Selejtezes>();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (panelNyitva)
            {
                DropDownPanel.Height += 10;
                if (DropDownPanel.Size == DropDownPanel.MaximumSize)
                {
                    timer1.Stop();
                    panelNyitva = false;
                    button11.Image = Properties.Resources.Névtelen4;
                }
            }
            else
            {
                DropDownPanel.Height -= 10;
                if (DropDownPanel.Size == DropDownPanel.MinimumSize)
                {
                    timer1.Stop();
                    panelNyitva = true;
                    button11.Image = Properties.Resources.Névtelen3;
                }
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {
            //timer1.Start();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            TobbAbblak<Gyartasi_rendelesForm>();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            TobbAbblak<GyartRenAtvetForm>();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            TobbAbblak<GyartasKiadasForm>();
        }


        private void button4_MouseHover(object sender, EventArgs e)
        {
            button4.ImageAlign = ContentAlignment.MiddleRight;
            button4.TextAlign = ContentAlignment.MiddleLeft;
        }

        private void button4_MouseLeave(object sender, EventArgs e)
        {
            button4.ImageAlign = ContentAlignment.MiddleLeft;
            button4.TextAlign = ContentAlignment.MiddleRight;
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            TobbAbblak<TesztForm>();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            TobbAbblak<Szallitas>();
        }

        private void maradekBTN_Click(object sender, EventArgs e)
        {
            TobbAbblak<MaradekKezeles>();
        }

        private void DropDownPanel_Paint(object sender, PaintEventArgs e)
        {
            //timer1.Start();
        }
    }
}
