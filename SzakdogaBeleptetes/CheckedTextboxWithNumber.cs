using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SzakdogaBeleptetes
{
    class CheckedTextboxWithNumber : TextBox
    {
            
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
            base.OnTextChanged(e);  // Hagyom hogy ugyanazt csinálja mint a textbox,megtartom a tulajdonságait.
            if (this.Text != "")
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
            return this.Text == "";
        }
    }
}
