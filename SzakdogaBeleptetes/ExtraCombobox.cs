using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SzakdogaBeleptetes
{
    class ExtraCombobox : ComboBox
    {
        private string egyediSzoveg;
        public bool isFormValid;

        public string TextboxText
        {
            get { return egyediSzoveg; }
            set
            {
                isFormValid = false;
                this.BackColor = Color.Empty;
                this.Text = "Válasszon a listából!";
                egyediSzoveg = value;
                this.GotFocus += (source, e) =>
                {
                    if (string.IsNullOrEmpty(this.Text) || this.Text == "Válasszon a listából!")
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
                        this.Text = "Válasszon a listából!";
                        this.BackColor = Color.Salmon;
                    }
                    else
                    {
                        this.BackColor = Color.Empty;
                    }
                };
            }
        }


        //protected override void OnTextChanged(EventArgs e)
        //{
        //    base.OnTextChanged(e);

        //    if (this.Text == string.Empty)
        //    {
        //        this.BackColor = Color.Red;
        //    }
        //    else
        //    {
        //        this.BackColor = Color.Empty;
        //    }

        //    /* if (this.Text != ""  && ) {
        //         isFormValid = true;
        //     }*/
        //}
    }
}

