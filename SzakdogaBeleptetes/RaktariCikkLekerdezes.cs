using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SzakdogaBeleptetes
{
    public partial class RaktariCikkLekerdezes : Form
    {
        public RaktariCikkLekerdezes()
        {
            InitializeComponent();
            DataTable tabla = new DataTable("Selejtek");
            ABKezelo.Kapcsolodas();
            SqlCommand parancs = new SqlCommand("SELECT * FROM SELEJTEK ");
            
        }

        private void RaktariCikkLekerdezes_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'termekekDataSet1.Selejtek' table. You can move, or remove it, as needed.
            this.selejtekTableAdapter.Fill(this.termekekDataSet1.Selejtek);
        }

        private void dataGridView1_AllowUserToAddRowsChanged(object sender, EventArgs e)
        {
           ABKezelo.Listazas();
        }
    }
}
