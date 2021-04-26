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
    // Interface ahhoz, hogy tudjam a SelejtWindowForm-ról frissítnei a datagridviewt
    public interface IUpdate
    {
        void isFinished(bool eredmeny);
    }
    public partial class Selejtezes : Form, IUpdate
    {
        SqlConnection kapcsolat = new SqlConnection(@"Data Source=DESKTOP-O0AMG2J\SQLSERVER;Initial Catalog=SMKExtended;Integrated Security=True");
        SqlDataAdapter adapter;
        

        public Selejtezes()
        {
            InitializeComponent();
        }

        public void isFinished(bool eredmeny)
        {
            Feltoltes();
        }

        public void Feltoltes()
        {
            SqlCommand parancs = new SqlCommand("select	GyartasID ,felkeszSzint, cikkMegnevezese, keszletMennyiseg, mertekegyseg, raktar, dopAzonosito, rendelesSzam, modositasIdeje FROM Gyartas", kapcsolat);
            List<SelejtezesClass> selejtezes = new List<SelejtezesClass>();
            DataTable tabla = new DataTable();
            kapcsolat.Open();
            using (SqlDataReader reader = parancs.ExecuteReader())
            {
                while (reader.Read())
                {
                    selejtezes.Add(new SelejtezesClass(
                            (int)reader["gyartasID"],
                            (string)reader["felkeszSzint"],
                            reader["cikkMegnevezese"].ToString(),
                            (int)reader["keszletMennyiseg"],
                            (string)reader["mertekegyseg"],
                            (string)reader["raktar"],
                            reader["dopAzonosito"].ToString(),
                            reader["rendelesSzam"].ToString(),
                            (DateTime)reader["modositasIdeje"]
                            ));

                }
                kapcsolat.Close();
            }
            adapter = new SqlDataAdapter(parancs);
            adapter.Fill(tabla);
            dataGridView1.DataSource = tabla;
            dataGridView1.DataMember = tabla.TableName;
        }



        private void Selejtezes_Load(object sender, EventArgs e)
        {
            Feltoltes();
            textBox2.Text = dataGridView1.RowCount.ToString();
        }

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
                string keresettTabla = "SELECT gyartasID, felkeszSzint, cikkMegnevezese, keszletMennyiseg, mertekegyseg, raktar, dopAzonosito, rendelesSzam, modositasIdeje FROM Gyartas WHERE LOWER (CikkMegnevezese) LIKE '" + talaltElem.ToLower() + "%' OR LOWER (FelkeszSzint) LIKE '" + talaltElem.ToLower() + "%'";
                SqlDataAdapter adapter = new SqlDataAdapter(keresettTabla, kapcsolat);
                DataTable tabla = new DataTable("Gyartas");
                adapter.Fill(tabla);
                dataGridView1.DataSource = tabla;

            }
            catch (Exception ex)
            {
                throw new AbKivetel("Sikertelen csatlakozás az adatbázisaal!", ex);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Feltoltes();
        }

        private void button7_MouseHover(object sender, EventArgs e)
        {
            frissitesLB.Visible = true;
        }

        private void button7_MouseLeave(object sender, EventArgs e)
        {
            frissitesLB.Visible = false;
        }

        private void keresesTXB_TextChanged(object sender, EventArgs e)
        {
            if (keresesTXB.Text != "Keresés...")
            {
                AdatbazisbanFilter(keresesTXB.Text);
                textBox2.Text = dataGridView1.RowCount.ToString();
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
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

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows != null)
            {
                SelejtWindowForm selejtek = new SelejtWindowForm(this);
                selejtek.gyartasID = this.dataGridView1.CurrentRow.Cells["gyartasID"].Value.ToString();
                selejtek.felkeszSzint = this.dataGridView1.CurrentRow.Cells["felkeszSzint"].Value.ToString();
                selejtek.cikkMegnevezese = this.dataGridView1.CurrentRow.Cells["cikkMegnevezese"].Value.ToString();
                selejtek.keszletMennyiseg = this.dataGridView1.CurrentRow.Cells["keszletMennyiseg"].Value.ToString();
                selejtek.mertekegyseg = this.dataGridView1.CurrentRow.Cells["mertekegyseg"].Value.ToString();
                selejtek.raktar = this.dataGridView1.CurrentRow.Cells["raktar"].Value.ToString();
                selejtek.dopAzonosito = this.dataGridView1.CurrentRow.Cells["dopAzonosito"].Value.ToString();
                selejtek.rendelesSzam = this.dataGridView1.CurrentRow.Cells["rendelesSzam"].Value.ToString();
                selejtek.modositasIdeje = this.dataGridView1.CurrentRow.Cells["modositasIdeje"].Value.ToString();
                selejtek.ShowDialog();
            }
            else
            {
                MessageBox.Show("Jelölje ki a selejtezni kívánt sort!");
            }
        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            selejtezesLB.Visible = true;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            selejtezesLB.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_MouseHover(object sender, EventArgs e)
        {
            button3.Image = Properties.Resources.icons8_close_windowred_16;
            ablakBezarasLB.Visible = true;
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            button3.Image = Properties.Resources.icons8_close_window_16;
            ablakBezarasLB.Visible = false;
        }
    }
}
