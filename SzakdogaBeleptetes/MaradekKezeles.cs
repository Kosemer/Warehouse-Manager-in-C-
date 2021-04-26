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

    public interface IUpdate2
    {
        void isFinished(bool eredmeny);
    }

    public partial class MaradekKezeles : Form, IUpdate2
    {
        SqlConnection kapcsolat = new SqlConnection(@"Data Source=DESKTOP-O0AMG2J\SQLSERVER;Initial Catalog=SMKExtended;Integrated Security=True");
        SqlDataAdapter adapter;
        public MaradekKezeles()
        {
            InitializeComponent();
        }

        public void isFinished(bool eredmeny)
        {
            Feltoltes();
        }

        private void ExcelBtn_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
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

        private void torlesBtn_Click(object sender, EventArgs e)
        {
            cikkszamTXB.Text = "";
            CikkmegnTB.Text = "";
            felkeszCB.Text = "";
            mennyisegTXB.Text = "";
            mertekegysegCB.Text = "";
            DopTextbox.Text = "";
            rendelesTXB.Text = "";
            megorzesiIdoCB.Text = "";
            raktarCB.Text = "";
            lejaratIdejeTXB.Text = "";
        }

        public void TextboxokTorlese()
        {
            cikkszamTXB.Text = "";
            CikkmegnTB.Text = "";
            felkeszCB.Text = "";
            mennyisegTXB.Text = "";
            mertekegysegCB.Text = "";
            DopTextbox.Text = "";
            rendelesTXB.Text = "";
            megorzesiIdoCB.Text = "";
            raktarCB.Text = "";
            lejaratIdejeTXB.Text = "";
            bevetelezesDT.Text = "";
        }

        private void cikkszamTXB_Leave(object sender, EventArgs e)
        {
            SqlConnection kapcsolat = new SqlConnection(@"Data Source=DESKTOP-O0AMG2J\SQLSERVER;Initial Catalog=SMKExtended;Integrated Security=True");
            SqlDataReader reader;
            SqlCommand command;
            try
            {
                ABKezelo.Kapcsolodas();
                List<string> lista = new List<string>();
                kapcsolat.Open();
                command = kapcsolat.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT Cikkszam FROM Gyartas";
                command.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(dt);

                foreach (DataRow dr in dt.Rows)
                {
                    lista.Add(dr["Cikkszam"].ToString());
                }
                if (cikkszamTXB.Text != "")
                {
                    int n = lista.Count;
                    string keresett = cikkszamTXB.Text;
                    int i = 1;
                    while (i < n && lista[i] != keresett)
                    {
                        i++;
                    }
                    if (i < n)
                    {
                        SqlCommand parancs = new SqlCommand("SELECT * FROM Gyartas WHERE Cikkszam = '" + cikkszamTXB.Text + "'", kapcsolat);
                        parancs.ExecuteNonQuery();
                        SqlDataReader reader2;
                        reader2 = parancs.ExecuteReader();
                        while (reader2.Read())
                        {
                            string cikkmegnevezes = reader2["CikkMegnevezese"].ToString();
                            string felkeszSzint = reader2["FelkeszSzint"].ToString();
                            string dopAzonosito = reader2["DopAzonosito"].ToString();
                            string rendelesSzam = reader2["RendelesSzam"].ToString();
                            int gyartasID = (int)reader2["GyartasID"];

                            CikkmegnTB.Text = cikkmegnevezes;
                            felkeszCB.Enabled = true;
                            DopTextbox.Text = dopAzonosito;
                            rendelesTXB.Text = rendelesSzam;
                            gyartasIdTXB.Text = gyartasID.ToString();
                        }
                        kapcsolat.Close();

                        // Félkész szint ComboBox feltöltés
                        if (felkeszCB.Items.Count <= 0)
                        {
                            kapcsolat.Open();
                            string query = "SELECT * FROM Gyartas WHERE Cikkszam = '" + cikkszamTXB.Text + "'";

                            using (var command2 = new SqlCommand(query, kapcsolat))
                            {
                                var list = new ArrayList();
                                var reader1 = command2.ExecuteReader();

                                if (reader1.HasRows)
                                {
                                    while (reader1.Read())
                                    {
                                        felkeszCB.Items.Add(new KeyValuePair<string, int>(reader1.GetString(8), reader1.GetInt32(0)));
                                    }
                                }
                                else
                                {
                                    felkeszCB.Enabled = false;
                                    CikkmegnTB.Clear();
                                    MessageBox.Show("Erre a cikkszámra nincs gyártás indítva!");
                                }

                                reader1.Close();
                                kapcsolat.Close();
                            }
                            felkeszCB.DisplayMember = "key";
                            felkeszCB.ValueMember = "value";
                            mennyisegTXB.Enabled = true;
                            kapcsolat.Close();
                        }

                        // Mértékegység COMBOBOX FELTÖLTÉS
                        if (mertekegysegCB.Items.Count <= 0)
                        {
                            kapcsolat.Open();
                            string query3 = "SELECT * FROM MertekegysegTable";
                            mertekegysegCB.Enabled = true;
                            megorzesiIdoCB.Enabled = true;
                            raktarCB.Enabled = true;

                            using (var command2 = new SqlCommand(query3, kapcsolat))
                            {
                                var list = new ArrayList();
                                var reader3 = command2.ExecuteReader();

                                if (reader3.HasRows)
                                {
                                    while (reader3.Read())
                                    {
                                        mertekegysegCB.Items.Add(new KeyValuePair<string, int>(reader3.GetString(1), reader3.GetInt32(0)));
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("HIBA VAN WAZZEE!!!");
                                }

                                reader3.Close();
                                kapcsolat.Close();
                            }

                            mertekegysegCB.DisplayMember = "key";
                            mertekegysegCB.ValueMember = "value";
                            kapcsolat.Close();
                        }                        
                    }
                    else
                    {
                        MessageBox.Show("Nincs ilyen cikkszám az adatbázisban!");
                        cikkszamTXB.Text = "";
                        CikkmegnTB.Text = "";
                        kapcsolat.Close();
                    }

                    // Raktár COMBOBOX FELTÖLTÉS
                    if (raktarCB.Items.Count <= 0)
                    {
                        kapcsolat.Open();
                        string query4 = "SELECT * FROM RaktarTable";

                        using (var command4 = new SqlCommand(query4, kapcsolat))
                        {
                            var list = new ArrayList();
                            var reader4 = command4.ExecuteReader();

                            if (reader4.HasRows)
                            {
                                while (reader4.Read())
                                {
                                    raktarCB.Items.Add(new KeyValuePair<string, int>(reader4.GetString(1), reader4.GetInt32(0)));
                                }
                            }
                            else
                            {
                                MessageBox.Show("HIBA VAN WAZZEE!!!");
                            }

                            reader4.Close();
                            kapcsolat.Close();
                        }

                        raktarCB.DisplayMember = "key";
                        raktarCB.ValueMember = "value";
                    }
                }
            }
            catch (Exception ex)
            {
                throw new AbKivetel("Sikertelen csatlakozás az adatbázisaal!", ex);
            }
        }

        private void MaradekKezeles_Load(object sender, EventArgs e)
        {
            megorzesiIdoCB.Items.Add(3 + " hónap");
            megorzesiIdoCB.Items.Add(6 + " hónap");
            megorzesiIdoCB.Items.Add(12 + " hónap");
            Feltoltes();
            talalatokSzamaTXB.Text = dataGridView1.RowCount.ToString();
        }

        private void megorzesiIdoCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            DateTime bevetDatum = bevetelezesDT.Value;

            switch (megorzesiIdoCB.Text)
            {
                case "3 hónap":
                    DateTime haromHonap = bevetDatum.AddMonths(3);
                    lejaratIdejeTXB.Text = haromHonap.ToShortDateString();
                    break;
                case "6 hónap":
                    DateTime hatHonap = bevetDatum.AddMonths(6);
                    lejaratIdejeTXB.Text = hatHonap.ToShortDateString();
                    break;
                case "12 hónap":
                    DateTime egyEv = bevetDatum.AddMonths(12);
                    lejaratIdejeTXB.Text = egyEv.ToShortDateString();
                    break;
                default:
                    break;
            }
        }

        public Boolean isFormValid()
        {
            setFormColors();

            if (cikkszamTXB.isFormValid() && felkeszCB.isFormValid() && CikkmegnTB.isFormValid() && mennyisegTXB.isFormValid() &&
                mertekegysegCB.isFormValid() && raktarCB.isFormValid() && DopTextbox.isFormValid() && rendelesTXB.isFormValid() &&
                lejaratIdejeTXB.isFormValid() && megorzesiIdoCB.isFormValid())
            {
                return true;
            }
            return false;
        }

        private void setFormColors()
        {
            cikkszamTXB.setBackgroundColor(); felkeszCB.setBackgroundColor(); CikkmegnTB.setBackgroundColor();
            mennyisegTXB.setBackgroundColor(); mertekegysegCB.setBackgroundColor(); raktarCB.setBackgroundColor();
            DopTextbox.setBackgroundColor(); rendelesTXB.setBackgroundColor(); megorzesiIdoCB.setBackgroundColor(); mertekegysegCB.setBackgroundColor();

        }

        private void MentesBtn_Click(object sender, EventArgs e)
        {
            if (isFormValid())
            {
                string lekerdezes2 = "INSERT INTO [Maradekok] ([Cikkszam], [FelkeszSzint], [CikkMegnevezese], [Mennyiseg] ,[Mertekegyseg], [Raktar], [DopAzonosito], [RendelesiSzam], [BevetelezesIdeje], [LejaratIdeje], [Irany], [ModositasIdeje]) VALUES (@cikkszam, @felkeszSzint, @cikkMegnevezese, @mennyiseg, @mertekegyseg, @raktar, @dopAzonosito, @rendelesiSzam, @bevetelezesIdeje, @lejaratIdeje, @irany, @modositasIdeje)";
                using (SqlCommand parancs2 = new SqlCommand(lekerdezes2, kapcsolat))
                {
                    kapcsolat.Open();
                    parancs2.Parameters.AddWithValue("@cikkszam", cikkszamTXB.Text);
                    parancs2.Parameters.AddWithValue("@felkeszSzint", felkeszCB.Text);
                    parancs2.Parameters.AddWithValue("@cikkMegnevezese", CikkmegnTB.Text);
                    parancs2.Parameters.AddWithValue("@mennyiseg", mennyisegTXB.Text);
                    parancs2.Parameters.AddWithValue("@mertekegyseg", mertekegysegCB.Text);
                    parancs2.Parameters.AddWithValue("@raktar", raktarCB.Text);
                    parancs2.Parameters.AddWithValue("@dopAzonosito", DopTextbox.Text);
                    parancs2.Parameters.AddWithValue("@rendelesiSzam", rendelesTXB.Text);
                    parancs2.Parameters.AddWithValue("@bevetelezesIdeje", bevetelezesDT.Text);
                    parancs2.Parameters.AddWithValue("@lejaratIdeje", lejaratIdejeTXB.Text);
                    parancs2.Parameters.AddWithValue("@Irany", "+");
                    parancs2.Parameters.AddWithValue("@modositasIdeje", bevetelezesDT.Text);
                    parancs2.ExecuteNonQuery();
                    kapcsolat.Close();
                    TextboxokTorlese();
                    Feltoltes();
                    mentesGifTimer.Start();
                    pictureBox2.Enabled = true;
                    pictureBox2.Visible = true;
                    talalatokSzamaTXB.Text = dataGridView1.RowCount.ToString();
                }
            }
            else
            {
                MessageBox.Show("Kérem töltse ki az összes mezőt!");
            }
        }

        public void Feltoltes()
        {
            SqlCommand parancs = new SqlCommand("select	maradek_Id, cikkszam ,felkeszSzint, cikkMegnevezese, mennyiseg, mertekegyseg, raktar, dopAzonosito, rendelesiSzam, bevetelezesIdeje, lejaratIdeje, irany, modositasIdeje FROM Maradekok", kapcsolat);
            List<MaradekokClass> maradek = new List<MaradekokClass>();
            DataTable tabla = new DataTable();
            kapcsolat.Open();
            using (SqlDataReader reader = parancs.ExecuteReader())
            {
                while (reader.Read())
                {
                    maradek.Add(new MaradekokClass(
                            (int)reader["maradek_Id"],
                            (string)reader["cikkszam"],
                            (string)reader["felkeszSzint"],
                            reader["cikkMegnevezese"].ToString(),
                            (int)reader["mennyiseg"],
                            (string)reader["mertekegyseg"],
                            (string)reader["irany"],
                            (string)reader["raktar"],
                            (int)reader["dopAzonosito"],
                            (int)reader["rendelesiSzam"],
                            (string)reader["bevetelezesIdeje"],
                            (string)reader["lejaratIdeje"],
                            (string)reader["modositasIdeje"]
                            ));

                }
                kapcsolat.Close();
            }
            adapter = new SqlDataAdapter(parancs);
            adapter.Fill(tabla);
            dataGridView1.DataSource = tabla;
            dataGridView1.DataMember = tabla.TableName;
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    //DateTime bevetelezes = Convert.ToDateTime(row.Cells[9].Value);
                    DateTime lejarat = Convert.ToDateTime(row.Cells[10].Value);
                    //string valami = row.Cells[10].Value.ToString();
                    //MessageBox.Show(valami);
                    DateTime maiNap = DateTime.Now;
                    //TimeSpan elteltIdo = bevetelezes - lejarat;
                    if (maiNap >= lejarat)
                    {
                        row.DefaultCellStyle.BackColor = Color.Salmon;
                        //MessageBox.Show(elteltIdo.ToString());
                    }
                else
                {
                    row.DefaultCellStyle.BackColor = Color.Empty;
                }
                }
        }

        private void selejtezesBtn_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows != null)
            {
                SelejtWindowForm2 selejtek = new SelejtWindowForm2(this);
                selejtek.gyartasID = this.dataGridView1.CurrentRow.Cells["maradek_Id"].Value.ToString();
                selejtek.felkeszSzint = this.dataGridView1.CurrentRow.Cells["felkeszSzint"].Value.ToString();
                selejtek.cikkMegnevezese = this.dataGridView1.CurrentRow.Cells["cikkMegnevezese"].Value.ToString();
                selejtek.keszletMennyiseg = this.dataGridView1.CurrentRow.Cells["mennyiseg"].Value.ToString();
                selejtek.mertekegyseg = this.dataGridView1.CurrentRow.Cells["mertekegyseg"].Value.ToString();
                selejtek.raktar = this.dataGridView1.CurrentRow.Cells["raktar"].Value.ToString();
                selejtek.dopAzonosito = this.dataGridView1.CurrentRow.Cells["dopAzonosito"].Value.ToString();
                selejtek.rendelesSzam = this.dataGridView1.CurrentRow.Cells["rendelesiSzam"].Value.ToString();
                selejtek.modositasIdeje = this.dataGridView1.CurrentRow.Cells["modositasIdeje"].Value.ToString();
                selejtek.ShowDialog();
            }
            else
            {
                MessageBox.Show("Jelölje ki a selejtezni kívánt sort!");
            }
        }

        public void AdatbazisbanFilter(string talaltElem)
        {
            SqlConnection kapcsolat = new SqlConnection(@"Data Source=DESKTOP-O0AMG2J\SQLSERVER;Initial Catalog=SMKExtended;Integrated Security=True");
            try
            {
                ABKezelo.Kapcsolodas();
                kapcsolat.Open();
                string keresettTabla = "SELECT Maradek_Id, Cikkszam, FelkeszSzint, CikkMegnevezese, Mennyiseg, Mertekegyseg, Raktar, DopAzonosito, RendelesiSzam, BevetelezesIdeje, LejaratIdeje, Irany, ModositasIdeje FROM Maradekok WHERE LOWER (CikkMegnevezese) LIKE '" + talaltElem.ToLower() + "%' OR LOWER (Cikkszam) LIKE '" + talaltElem.ToLower() + "%'";
                SqlDataAdapter adapter = new SqlDataAdapter(keresettTabla, kapcsolat);
                DataTable tabla = new DataTable("Maradekok");
                adapter.Fill(tabla);
                dataGridView1.DataSource = tabla;

            }
            catch (Exception ex)
            {
                throw new AbKivetel("Sikertelen csatlakozás az adatbázisaal!", ex);
            }
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

        private void MentesBtn_MouseHover(object sender, EventArgs e)
        {
            mentesLb.Visible = true;
        }

        private void MentesBtn_MouseLeave(object sender, EventArgs e)
        {
            mentesLb.Visible = false;
        }

        private void torlesBtn_MouseHover(object sender, EventArgs e)
        {
            torlesLB.Visible = true;
        }

        private void torlesBtn_MouseLeave(object sender, EventArgs e)
        {
            torlesLB.Visible = false;
        }

        private void selejtezesBtn_MouseLeave(object sender, EventArgs e)
        {
            selejtezesLB.Visible = false;
        }

        private void selejtezesBtn_MouseHover(object sender, EventArgs e)
        {
            selejtezesLB.Visible = true;
        }

        private void ExcelBtn_MouseHover(object sender, EventArgs e)
        {
            exportLb.Visible = true;
        }

        private void ExcelBtn_MouseLeave(object sender, EventArgs e)
        {
            exportLb.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void keresesTXB_TextChanged(object sender, EventArgs e)
        {
            if (keresesTXB.Text != "Keresés...")
            {
                AdatbazisbanFilter(keresesTXB.Text);
                talalatokSzamaTXB.Text = dataGridView1.RowCount.ToString();
            }
        }

        private void mentesGifTimer_Tick(object sender, EventArgs e)
        {
            mentesGifTimer.Stop();
            pictureBox2.Enabled = false;
            pictureBox2.Visible = false;
        }

        private void bevetelezesDT_ValueChanged(object sender, EventArgs e)
        {
            megorzesiIdoCB.Text = "";
            lejaratIdejeTXB.Text = "";
        }
    }
}
