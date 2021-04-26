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
    public partial class WelcomeScreen : Form
    {
        int mozgas = 2;
        public WelcomeScreen()
        {
            
            InitializeComponent();
            
        }

        private void formRun()
        {
            Application.Run(new WelcomeScreen());
        }

        private void WelcomeScreen_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            panelSlide.Left += 2;
            if (panelSlide.Left > 350)
            {
                panelSlide.Left = 230;
            }
            if (panelSlide.Left < 0)
            {
                mozgas = 2;
            }
        }

        /*private void timer2_Tick(object sender, EventArgs e)
        {
            this.Opacity -= 0.1;
            if (this.Opacity == 0)
            {
                timer2.Stop();
                this.Close();
            }
        }*/
    }
}
