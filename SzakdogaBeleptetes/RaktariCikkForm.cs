using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls.UI;

namespace SzakdogaBeleptetes
{
    public partial class RaktariCikkForm : Form
    {
        UJFelvitelForm UJFelvitel = new UJFelvitelForm();
        internal List<GyartasAtvetel_KiadasClass> lista = new List<GyartasAtvetel_KiadasClass>();
        SqlConnection kapcsolat = new SqlConnection(@"Data Source=DESKTOP-O0AMG2J\SQLSERVER;Initial Catalog=SMKExtended;Integrated Security=True");
        SqlDataAdapter adapter;
        public RaktariCikkForm()
        {
            InitializeComponent();
            //AdatbazisbanFilter("");
            //dataGridView1.Refresh();
        }
        // JAVITANI kell!!
        public void AdatbazisbanFilter(string talaltElem)
        {
            //SqlConnection kapcsolat;
            // Egy külön SqlConnection kell a Filterek, hogy ne zárja le a kapcsolatot a Load.
            SqlConnection kapcsolat = new SqlConnection(@"Data Source=DESKTOP-O0AMG2J\SQLSERVER;Initial Catalog=SMKExtended;Integrated Security=True");
            try
            {
                ABKezelo.Kapcsolodas();
                //kapcsolat = new SqlConnection();
                //kapcsolat.ConnectionString = ConfigurationManager.ConnectionStrings["GyartasAtvetel_Kiadas"].ConnectionString;

                kapcsolat.Open();
                string keresettTabla = "SELECT Cikkszam, FelkeszSzint, CikkMegnvezese, Muvelet, Statusz, RendeleseiSzam, Dop, SorozatMeret, Mertekegyseg, HatralevoMennyiseg, MozgatottMennyiseg, Irany, RaktarKeszlet, Raktar, Megjegyzes, ModositasIdeje FROM GyartasAtvetel_Kiadas WHERE LOWER (CikkMegnvezese) LIKE '" + talaltElem.ToLower() + "%' OR LOWER (Cikkszam) LIKE '" + talaltElem.ToLower() + "%'";
                SqlDataAdapter adapter = new SqlDataAdapter(keresettTabla, kapcsolat);
                DataTable tabla = new DataTable("GyartasAtvetel_Kiadas");
                adapter.Fill(tabla);
                dataGridView1.DataSource = tabla;
            }
            catch (Exception ex)
            {
                throw new AbKivetel("Sikertelen csatlakozás az adatbázisaal!", ex);
            }
        }

        private void RaktariCikkForm_Load(object sender, EventArgs e)
        {
            ABKezelo.Kapcsolodas();
            SqlCommand parancs = new SqlCommand("SELECT Cikkszam, FelkeszSzint, CikkMegnvezese, Muvelet, Statusz, RendeleseiSzam, Dop, SorozatMeret, Mertekegyseg, HatralevoMennyiseg, MozgatottMennyiseg, Irany, RaktarKeszlet, Raktar, Megjegyzes, ModositasIdeje FROM GyartasAtvetel_Kiadas", kapcsolat);
            List<GyartasAtvetel_KiadasClass> termek = new List<GyartasAtvetel_KiadasClass>();
            DataTable tabla = new DataTable();
            kapcsolat.Open();
            using (SqlDataReader reader = parancs.ExecuteReader())
            {
                while (reader.Read())
                {
                    termek.Add(new GyartasAtvetel_KiadasClass(
                            //(int)reader["gyartas_Id"],
                            reader["cikkszam"].ToString(),
                            reader["felkeszSzint"].ToString(),
                            reader["cikkMegnvezese"].ToString(),
                            reader["muvelet"].ToString(),
                            reader["statusz"].ToString(),
                            reader["rendeleseiSzam"].ToString(),
                            reader["dop"].ToString(),
                            (int)reader["sorozatMeret"],
                            reader["mertekegyseg"].ToString(),
                            (int)reader["hatralevoMennyiseg"],
                            (int)reader["mozgatottMennyiseg"],
                            (string)reader["irany"],
                            (int)reader["raktarKeszlet"],
                            reader["raktar"].ToString(),
                            reader["megjegyzes"].ToString(),
                            (DateTime)reader["modositasIdeje"]
                            ));

                }
                kapcsolat.Close();
            }
            adapter = new SqlDataAdapter(parancs);
            adapter.Fill(tabla);
            dataGridView1.DataSource = tabla;
            dataGridView1.DataMember = tabla.TableName;
            textBox2.Text =  dataGridView1.RowCount.ToString();
        }

        //Szűrés textbox
        private void keresesTXB_TextChanged_1(object sender, EventArgs e)
        {
            if (keresesTXB.Text != "Keresés...")
            {
                AdatbazisbanFilter(keresesTXB.Text);
                textBox2.Text = dataGridView1.RowCount.ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
            //worksheet = workbook.Sheets["@Lap1"];
            worksheet = workbook.ActiveSheet;
            worksheet.Name = "Tabla";

            for (int i = 1; i < dataGridView1.Columns.Count + 1; i++)
            {
                worksheet.Cells[1, i] = dataGridView1.Columns[i - 1].HeaderText;
            }

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                for (int j = 0; j < dataGridView1.Columns.Count; j++)
                {
                    worksheet.Cells[i + 2, j + 1] = dataGridView1.Rows[i].Cells[j].Value.ToString();
                }
            }

            var saveFileDialoge = new SaveFileDialog();
            saveFileDialoge.FileName = "tabla";
            saveFileDialoge.DefaultExt = ".xlsx";
            if (saveFileDialoge.ShowDialog() == DialogResult.OK)
            {
                workbook.SaveAs(saveFileDialoge.FileName, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            }
            app.Quit();
        }

        private void button2_MouseHover(object sender, EventArgs e)
        {
            exportLb.Visible = true;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            exportLb.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            button1.Image = Properties.Resources.icons8_close_windowred_16;
            ablakBezarasLB.Visible = true;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.Image = Properties.Resources.icons8_close_window_16;
            ablakBezarasLB.Visible = false;
        }
    }
}
