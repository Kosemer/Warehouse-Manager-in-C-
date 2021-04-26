using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SzakdogaBeleptetes
{
    class ExtraTextbox : TextBox
    {

        public Boolean isFormValid1()
        {
            Boolean result = true;
            if (this.Text == "")
            {
                this.BackColor = Color.Salmon;
                result = false;
            }
            return result;
        }

        private string egyediSzoveg;
        public bool isFormValid;

        public string TextboxText
        {
            get { return egyediSzoveg; }
            set
            {
                isFormValid = false;
                this.BackColor = Color.Empty;
                this.Text = "Keresés...";
                egyediSzoveg = value;
                this.GotFocus += (source, e) =>
                {
                    if (string.IsNullOrEmpty(this.Text) || this.Text == "Keresés...")
                    {

                        this.Text = "";
                        this.ForeColor = Color.Black;
                        this.BackColor = Color.Empty;
                    }

                };

                this.LostFocus += (source, e) =>
                {
                    if (string.IsNullOrEmpty(this.Text))
                    {
                        this.Text = "Keresés...";
                    }
                    else
                    {
                        this.BackColor = Color.Empty;
                    }
                };
            }
        }

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            this.BackColor = Color.Empty;
        }
    }
}
