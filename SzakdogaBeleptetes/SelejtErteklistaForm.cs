using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SzakdogaBeleptetes
{
    public partial class SelejtErteklistaForm : Form
    {

        SqlConnection kapcsolat = new SqlConnection(@"Data Source=DESKTOP-O0AMG2J\SQLSERVER;Initial Catalog=SMKExtended;Integrated Security=True");
        SqlDataAdapter adapter;

        public SelejtErteklistaForm()
        {
            InitializeComponent();
        }

        public void Feltoltes()
        {
            SqlCommand parancs = new SqlCommand("select SelejtezesiOk, SelejtezesiOkMegnevezes FROM SelejtezesiOkTable", kapcsolat);
            List<SelejtezesErteklistaClass> selejtLista = new List<SelejtezesErteklistaClass>();
            DataTable tabla = new DataTable();
            kapcsolat.Open();
            using (SqlDataReader reader = parancs.ExecuteReader())
            {
                while (reader.Read())
                {
                    selejtLista.Add(new SelejtezesErteklistaClass(
                            reader["SelejtezesiOk"].ToString(),
                            reader["SelejtezesiOkMegnevezes"].ToString()
                            ));

                }
                kapcsolat.Close();
            }
            adapter = new SqlDataAdapter(parancs);
            adapter.Fill(tabla);
            dataGridView1.DataSource = tabla;
            dataGridView1.DataMember = tabla.TableName;
        }

        private void SelejtErteklistaForm_Load(object sender, EventArgs e)
        {
            Feltoltes();
        }
    }
}
