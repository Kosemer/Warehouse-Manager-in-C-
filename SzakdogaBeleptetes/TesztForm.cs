using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SzakdogaBeleptetes
{
    public partial class TesztForm : Form
    {
        public TesztForm()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (checkedTextBox1.isFormValid())
            {
                MessageBox.Show("Jó");           
            }
            else
            {
                MessageBox.Show("Nem jó");
            }
        }
    }
}
