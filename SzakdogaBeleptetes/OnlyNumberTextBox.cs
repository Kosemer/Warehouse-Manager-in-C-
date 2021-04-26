using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SzakdogaBeleptetes
{
    class OnlyNumberTextBox : TextBox
    {

        public string TextBoxTextNumber
        {
            get { return null; }
            set
            {
                this.KeyPress += OnlyNumberTextBox_KeyPress;
            }
        }

        private void OnlyNumberTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((!char.IsNumber(e.KeyChar)) && (!char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }
    }
}
