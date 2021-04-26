using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExtraButton
{
    public partial class ExtraTextboxocska: ComboBox
    {
        public ExtraTextboxocska()
        {
            InitializeComponent();
        }

        private string egyediSzoveg;
        private bool isFormValid = true;

        public string TextboxText
        {
            get { return egyediSzoveg; }
            set
            {
                egyediSzoveg = value;
                GetSetExtra();
            }
        }

        private void GetSetExtra()
        {
            if ((this.Text == egyediSzoveg || (this.Text == string.Empty)))
            {
                this.ForeColor = Color.Gray;
                this.Text = egyediSzoveg;
            }
            else
            {
                this.ForeColor = Color.Black;
            }
        }

        private void ExtraTextboxocska_Enter(object sender, EventArgs e)
        {
            if ((this.Text == egyediSzoveg || (this.Text == string.Empty)))
            {
                this.ForeColor = Color.Black;
                this.Text = string.Empty;
            }
        }

        private void ExtraTextboxocska_Leave(object sender, EventArgs e)
        {
            GetSetExtra();
        }

        private void ExtraTextboxocska_TextChanged(object sender, EventArgs e)
        {
            this.BackColor = Color.Empty;
        }
    }
}
