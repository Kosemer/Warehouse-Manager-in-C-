using System;
using System.Collections;
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
    public partial class Gyartasi_rendelesForm : Form
    {
        Random rnd = new Random();
        string kesztermek;
        GyartasClass gyartasok = new GyartasClass();
        SqlConnection kapcsolat = new SqlConnection(@"Data Source=DESKTOP-O0AMG2J\SQLSERVER;Initial Catalog=SMKExtended;Integrated Security=True");
        SqlDataAdapter adapter;
        public Gyartasi_rendelesForm()
        {
            InitializeComponent();
        }

        // CIKKSZÁM COMBOBOX KITÖLTÉS
        private void CikkszamCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            clearFormExceptCikkszam();

            int randomRendeles = rnd.Next(250, 400);
            int dopRandom = rnd.Next(204501, 207500);
            SqlCommand parancs = new SqlCommand("SELECT * FROM TorzsCikk WHERE Raktari_cikkszam = '" + CikkszamCB.Text + "'", kapcsolat);
            kapcsolat.Open();
            parancs.ExecuteNonQuery();
            SqlDataReader reader;
            reader = parancs.ExecuteReader();
            while (reader.Read())
            {
                string cikkmegnevezes = (string)reader["Cikk_megnevezese"].ToString();
                string dopAzonosito = reader["DopAzonosito"].ToString();
                string rendelesiSzam = (string)reader["RendelesiSzam"].ToString();

                CikkmegnTB.Text = cikkmegnevezes;
                rendelesTXB.Text = rendelesiSzam;
                DopTextbox.Text = dopAzonosito;
            }
            kapcsolat.Close();

            muveletComboBox.Enabled = true;
            mertekegysegCB.Enabled = true;
            komponensTXB.Enabled = true;
            Feltoltes();
           // DataGriviewColor();
        }

        private void clearFormExceptCikkszam()
        {
            CikkmegnTB.Text = "";
            muveletComboBox.Text = "";
            komponensTXB.Text = "";
            mertekegysegCB.Text = "";
            felkeszTextbox.Text = "";
            DopTextbox.Text = "";
            rendelesTXB.Text = "";
        }

        private void Gyartasi_rendelesForm_Load(object sender, EventArgs e)
        {
            ABKezelo.Kapcsolodas();
            //Feltoltes();
            // CIKKSZÁM COMBOBOX FELTÖLTÉS
            CikkszamCB.Items.Clear();
            kapcsolat.Open();
            string query = "SELECT * FROM TorzsCikk";

            using (var command = new SqlCommand(query, kapcsolat))
            {
                var list = new ArrayList();
                var reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        CikkszamCB.Items.Add(new KeyValuePair<string, int>(reader.GetString(1), reader.GetInt32(0)));
                    }
                }
                else
                {
                    MessageBox.Show("HIBA VAN WAZZEE!!!");
                }
                
                reader.Close();
                kapcsolat.Close();
            }

            CikkszamCB.DisplayMember = "key";
            CikkszamCB.ValueMember = "value";

            // Mértékegység COMBOBOX FELTÖLTÉS
            kapcsolat.Open();
            string query1 = "SELECT * FROM MertekegysegTable";

            using (var command = new SqlCommand(query1, kapcsolat))
            {
                var list = new ArrayList();
                var reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        mertekegysegCB.Items.Add(new KeyValuePair<string, int>(reader.GetString(1), reader.GetInt32(0)));
                    }
                }
                else
                {
                    MessageBox.Show("HIBA VAN WAZZEE!!!");
                }

                reader.Close();
                kapcsolat.Close();
            }

            mertekegysegCB.DisplayMember = "key";
            mertekegysegCB.ValueMember = "value";

            // Művelet COMBOBOX FELTÖLTÉS
            kapcsolat.Open();
            string query2 = "SELECT * FROM AnyagmuveletTable";

            using (var command = new SqlCommand(query2, kapcsolat))
            {
                var list = new ArrayList();
                var reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        muveletComboBox.Items.Add(new KeyValuePair<string, int>(reader.GetString(1), reader.GetInt32(0)));
                    }
                }
                else
                {
                    MessageBox.Show("HIBA VAN WAZZEE!!!");
                }

                reader.Close();
                kapcsolat.Close();
            }

            muveletComboBox.DisplayMember = "key";
            muveletComboBox.ValueMember = "value";
        }

        private void muveletComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            SqlCommand parancs = new SqlCommand("SELECT * FROM AnyagmuveletTable WHERE MuveletNeve = '" + muveletComboBox.Text + "'", kapcsolat);
            kapcsolat.Open();
            parancs.ExecuteNonQuery();
            SqlDataReader reader;
            reader = parancs.ExecuteReader();
            while (reader.Read())
            {
                string muveletRovidites = (string)reader["MuveletRovidites"].ToString();
                if (muveletComboBox.Text == "Késztermék")
                {
                    felkeszTextbox.Text = CikkszamCB.Text;
                    
                    kesztermek = felkeszTextbox.Text;
                    //MessageBox.Show(kesztermek);
                }
                else
                {
                    felkeszTextbox.Text = CikkszamCB.Text + "-" + muveletRovidites;
                    kesztermek = "";
                }
            }
            kapcsolat.Close();
        }

        public Boolean isFormValid()
        {
            setFormColors();

            if (CikkszamCB.isFormValid() && CikkmegnTB.isFormValid() && muveletComboBox.isFormValid() && komponensTXB.isFormValid() && mertekegysegCB.isFormValid() && felkeszTextbox.isFormValid() && rendelesTXB.isFormValid() &&
               DopTextbox.isFormValid())
            {
                return true;
            }
            return false;
        }

        private void setFormColors()
        {
            CikkszamCB.setBackgroundColor(); CikkmegnTB.setBackgroundColor(); muveletComboBox.setBackgroundColor();
            komponensTXB.setBackgroundColor(); mertekegysegCB.isFormValid(); felkeszTextbox.isFormValid(); rendelesTXB.isFormValid(); DopTextbox.isFormValid();

        }

        public void Feltoltes()
        {
            
            //List<TermekekClass> aaa = ABKezelo.Listazas();
            /*foreach (var item in aaa)
            {
                MessageBox.Show(item.Lejarat_ideje.ToString());
            }*/
            //dataGridView1.DataSource = aaa;
            int cikkszam = ((KeyValuePair<string, int>)CikkszamCB.SelectedItem).Value;
            SqlCommand parancs = new SqlCommand("select	GyartasID, cikkszam, cikkMegnevezese, anyagMuvelet, komponensIgeny, mertekegyseg, felkeszSzint, dopAzonosito, RendelesSzam, KezdesDatuma, BefejezesDatuma FROM Gyartas WHERE (cikkszam = '" + CikkszamCB.Text+"')", kapcsolat);
            List<GyartasClass> gyartas = new List<GyartasClass>();
            DataTable tabla = new DataTable();
            kapcsolat.Open();
            using (SqlDataReader reader = parancs.ExecuteReader())
            {
                while (reader.Read())
                {
                    gyartas.Add(new GyartasClass(
                            (int)reader["GyartasID"],
                            reader["cikkszam"].ToString(),
                            reader["cikkMegnevezese"].ToString(),
                            reader["anyagMuvelet"].ToString(),
                            (int)reader["komponensIgeny"],
                            (string)reader["mertekegyseg"],
                            (string)reader["felkeszSzint"],
                            reader["dopAzonosito"].ToString(),
                            reader["RendelesSzam"].ToString(),
                            (DateTime)reader["KezdesDatuma"],
                            (DateTime)reader["BefejezesDatuma"]
                            ));

                }
                kapcsolat.Close();
            }
            adapter = new SqlDataAdapter(parancs);
            adapter.Fill(tabla);
            dataGridView1.DataSource = tabla;
            dataGridView1.DataMember = tabla.TableName;
            //return dataGridView1.RowCount - 1;

        }


        public void TextboxTorles()
        {
            CikkszamCB.Text = "";
            CikkmegnTB.Text = "";
            muveletComboBox.Text = "";
            komponensTXB.Text = "";
            mertekegysegCB.Text = "";
            felkeszTextbox.Text = "";
            DopTextbox.Text = "";
            rendelesTXB.Text = "";
        }

        public void TextboxTorlesReszleges()
        {
            muveletComboBox.Text = "";
            komponensTXB.Text = "";
            mertekegysegCB.Text = "";
            felkeszTextbox.Text = "";
            //DopTextbox.Text = "";
            //rendelesTXB.Text = "";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                //MessageBox.Show(dataGridView1.CurrentRow.Cells["Id"].Value.ToString());

                kapcsolat.Open();
                // A datagridview kijelölt sor id-ja.
                string dataId;
                dataId = dataGridView1.CurrentRow.Cells["Id"].Value.ToString();
                SqlCommand parancs = kapcsolat.CreateCommand();
                parancs.Parameters.Clear();
                parancs.Transaction = kapcsolat.BeginTransaction();
                parancs.CommandType = CommandType.Text;
                parancs.CommandText = "DELETE FROM [Gyartas] WHERE TorzsCikk_id = '" + dataId + "'";
                parancs.ExecuteScalar();
                parancs.Transaction.Commit();
                kapcsolat.Close();
                Feltoltes();
                int rowindex = dataGridView1.CurrentCell.RowIndex;
                dataGridView1.Rows.RemoveAt(rowindex);

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            /*if (CikkszamCB.Text != "")
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    int egy = Convert.ToInt32(row.Cells[5].Value);
                    int ketto = Convert.ToInt32(row.Cells[0].Value);
                    
                    

                    if (egy <= ketto)
                    {
                        row.DefaultCellStyle.BackColor = Color.Red;
                        row.DefaultCellStyle.ForeColor = Color.White;
                    }
                    else
                    {
                        row.DefaultCellStyle.BackColor = Color.White;
                        row.DefaultCellStyle.BackColor = Color.Black;
                    }
                }
            }*/

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (isFormValid())
            {
         
                int cikkszam = ((KeyValuePair<string, int>)CikkszamCB.SelectedItem).Value;
                int mertekegyseg = ((KeyValuePair<string, int>)mertekegysegCB.SelectedItem).Value;
                int muvelet = ((KeyValuePair<string, int>)muveletComboBox.SelectedItem).Value;
                int sorozatmeret = int.Parse(komponensTXB.Text);

                //SqlConnection kapcsolat = new SqlConnection(@"Data Source=DESKTOP-O0AMG2J\SQLSERVER;Initial Catalog=SMKDatabase;Integrated Security=True");

                string lekerdezes = "INSERT INTO [Gyartas] ([Cikkszam], [CikkMegnevezese] ,[AnyagMuvelet], [KomponensIgeny], [Mertekegyseg], [FelkeszSzint], [DopAzonosito], [RendelesSzam], [KezdesDatuma], [BefejezesDatuma], [ModositasIdeje], [MozgatottMennyiseg], [OsszesAtvettMennyiseg], [HatralevoMennyiseg], [KeszletMennyiseg], [Raktar], [Kesztermek]) VALUES (@cikkszam, @cikkMegnevezese, @anyagMuvelet, @komponensIgeny, @mertekegyseg, @felkeszSzint, @dopAzonosito, @rendelesSzam, @kezdesDatuma, @befejezesDatuma, @modositasIdeje, @mozgatottMennyiseg, @osszesAtvettMennyiseg, @hatralevoMennyiseg, @keszletMennyiseg, @raktar, @kesztermek)";
                using (SqlCommand parancs2 = new SqlCommand(lekerdezes, kapcsolat))
                {
                    kapcsolat.Open();
                    parancs2.Parameters.AddWithValue("@cikkszam", CikkszamCB.Text);
                    parancs2.Parameters.AddWithValue("@cikkMegnevezese", CikkmegnTB.Text);
                    parancs2.Parameters.AddWithValue("@anyagMuvelet", muveletComboBox.Text);
                    parancs2.Parameters.AddWithValue("@komponensIgeny", komponensTXB.Text);
                    parancs2.Parameters.AddWithValue("@mertekegyseg", mertekegysegCB.Text);
                    parancs2.Parameters.AddWithValue("@felkeszSzint", felkeszTextbox.Text);
                    parancs2.Parameters.AddWithValue("@dopAzonosito", DopTextbox.Text);
                    parancs2.Parameters.AddWithValue("@rendelesSzam", rendelesTXB.Text);
                    parancs2.Parameters.AddWithValue("@kezdesDatuma", kezdesTP.Value.ToString("yyyy-MM-dd"));
                    parancs2.Parameters.AddWithValue("@befejezesDatuma", befejezesTP.Value.ToString("yyyy-MM-dd"));
                    parancs2.Parameters.AddWithValue("@modositasIdeje", modositasDTP.Value.ToString("yyyy-MM-dd"));
                    parancs2.Parameters.AddWithValue("@mozgatottMennyiseg", 0);
                    parancs2.Parameters.AddWithValue("@osszesAtvettMennyiseg", 0);
                    parancs2.Parameters.AddWithValue("@hatralevoMennyiseg", sorozatmeret);
                    parancs2.Parameters.AddWithValue("@keszletMennyiseg", 0);
                    parancs2.Parameters.AddWithValue("@raktar", "");
                    parancs2.Parameters.AddWithValue("@kesztermek", kesztermek);
                    parancs2.ExecuteNonQuery();
                    kapcsolat.Close();
                    Feltoltes();
                    TextboxTorlesReszleges();
                    timer1.Start();
                    pictureBox2.Enabled = true;
                    pictureBox2.Visible = true;
                }
            }
            else
            {
                MessageBox.Show("Kérem töltse ki az összes mezőt!");
            }

        }

        private void button8_Click(object sender, EventArgs e)
        {
            TextboxTorles();
        }

        private void button5_MouseHover(object sender, EventArgs e)
        {
            mentesLb.Visible = true;
        }

        private void button5_MouseLeave(object sender, EventArgs e)
        {
            mentesLb.Visible = false;
        }

        private void button8_MouseHover(object sender, EventArgs e)
        {
            torlesLB.Visible = true;
        }

        private void button8_MouseLeave(object sender, EventArgs e)
        {
            torlesLB.Visible = false;
        }

        private void button7_MouseHover(object sender, EventArgs e)
        {
            frissitesLB.Visible = true;
        }

        private void button7_MouseLeave(object sender, EventArgs e)
        {
            frissitesLB.Visible = false;
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            pictureBox2.Enabled = false;
            pictureBox2.Visible = false;
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


        /*public void DataGriviewColor()
        {
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                int egy = Int32.Parse(dataGridView1.Rows[i].Cells[4].Value.ToString());
                if (egy < 3)
                {
                    dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                }
            }
        }*/
    }
}
