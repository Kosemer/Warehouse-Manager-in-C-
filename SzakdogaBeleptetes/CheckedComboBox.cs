using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SzakdogaBeleptetes
{
    class CheckedComboBox : ComboBox
    {

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            DroppedDown=true;
       
        }

        public static String VALASSZON_A_LISTABOL = "Válasszon a listából";
        public Boolean isFormValid()
        {
            //Boolean result = true;
            if (condition())
            {
                setBackgroundColor();
                return false;
            }
            return true;
        }

        protected override void OnTextChanged(EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Text))
            {
                Text = VALASSZON_A_LISTABOL;
            }
            base.OnTextChanged(e);  // Hagyom hogy ugyanazt csinálja mint a textbox,megtartom a tulajdonságait.
            if (this.Text != "" || this.Text == VALASSZON_A_LISTABOL)
            {
                this.BackColor = Color.Empty;
            }

        }
        public void setBackgroundColor()
        {
            if (condition())
            {
                this.BackColor = Color.Salmon;
            }
        }

        public Boolean condition()
        {
            return this.Text == "" || this.Text == VALASSZON_A_LISTABOL;
        }

      
    }
}
