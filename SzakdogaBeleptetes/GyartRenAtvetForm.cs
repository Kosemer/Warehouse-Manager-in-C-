using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace SzakdogaBeleptetes
{
    public partial class GyartRenAtvetForm : Form
    {
        public static String VALASSZON_A_LISTABOL = "Válasszon a listából";
        GyartasAtvetelClass atvetel = new GyartasAtvetelClass();
        SqlConnection kapcsolat = new SqlConnection(@"Data Source=DESKTOP-O0AMG2J\SQLSERVER;Initial Catalog=SMKExtended;Integrated Security=True");
        SqlDataAdapter adapter;

        public GyartRenAtvetForm()
        {
            InitializeComponent();
        }

        private void GyartRenAtvetForm_Load(object sender, EventArgs e)
        {
            FelkeszCB.Enabled = false;
            RaktarCB.Enabled = false;
            ABKezelo.Kapcsolodas();
            //Feltoltes();

            //CIKKSZÁM COMBOBOX FELTÖLTÉS
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
        }

        //Félkész ComboBox feltöltése, ha kiválasztotta a cikkszámot. 
        private void CikkszamCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            clearFormExceptCikkszam();
     
            FelkeszCB.Enabled = true;
            FelkeszCB.Items.Clear();
            kapcsolat.Open();
            string query = "SELECT * FROM Gyartas WHERE Cikkszam = '"+CikkszamCB.Text+"'";

            using (var command = new SqlCommand(query, kapcsolat))
            {
                var list = new ArrayList();
                var reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        FelkeszCB.Items.Add(new KeyValuePair<string, int>(reader.GetString(8), reader.GetInt32(0)));
                        //CikkmegnTB.Text = (string)reader["CikkMegnevezese"].ToString();
                    }
                }
                else
                {
                    FelkeszCB.Enabled = false;
                    CikkmegnTB.Clear();
                    MessageBox.Show("Erre a cikkszámra nincs gyártás indítva!");
                }

                reader.Close();
                kapcsolat.Close();
            }
            FelkeszCB.DisplayMember = "key";
            FelkeszCB.ValueMember = "value";


            // Raktár COMBOBOX FELTÖLTÉS
            if (RaktarCB.Items.Count <= 0)
            {
                kapcsolat.Open();
                string query2 = "SELECT * FROM RaktarTable";

                using (var command = new SqlCommand(query2, kapcsolat))
                {
                    var list = new ArrayList();
                    var reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            RaktarCB.Items.Add(new KeyValuePair<string, int>(reader.GetString(1), reader.GetInt32(0)));
                        }
                    }
                    else
                    {
                        MessageBox.Show("HIBA VAN WAZZEE!!!");
                    }

                    reader.Close();
                    kapcsolat.Close();
                }

                RaktarCB.DisplayMember = "key";
                RaktarCB.ValueMember = "value";
            }
        }

        private void clearFormExceptCikkszam()
        {
            FelkeszCB.Text = ""; RaktarCB.Text = ""; CikkmegnTB.Text = ""; MuveletTB.Text = ""; osszAtvettMennyisegTXB.Text = ""; rendelesTXB.Text = "";
            KezdesTB.Text = ""; BefejezesTB.Text = ""; DopTextbox.Text = ""; SorozatMeretTB.Text = "";
            MertekegysegTB.Text = ""; HatralevoMTB.Text = ""; AtvettTB.Text = ""; eddigAtvettTXB.Text = ""; keszletMennyisegTXB.Text = "";
        }

      

        private void FelkeszCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            AtvettTB.Text = "";
            RaktarCB.Text = "";
            MegjegyzesTB.Text = "";

            SqlCommand parancs = new SqlCommand("SELECT * FROM Gyartas WHERE FelkeszSzint = '" + FelkeszCB.Text + "'", kapcsolat);
            kapcsolat.Open();
            parancs.ExecuteNonQuery();
            SqlDataReader reader2;
            reader2 = parancs.ExecuteReader();
            while (reader2.Read())
            {
                IdTxb.Text = (string)reader2["GyartasID"].ToString();
                CikkmegnTB.Text = (string)reader2["CikkMegnevezese"].ToString();
                MuveletTB.Text = (string)reader2["AnyagMuvelet"].ToString();
                rendelesTXB.Text = (string)reader2["RendelesSzam"].ToString();
                KezdesTB.Text = (string)reader2["KezdesDatuma"].ToString();
                DopTextbox.Text = (string)reader2["DopAzonosito"].ToString();
                SorozatMeretTB.Text = (string)reader2["KomponensIgeny"].ToString();
                MertekegysegTB.Text = (string)reader2["Mertekegyseg"].ToString();
                BefejezesTB.Text = (string)reader2["BefejezesDatuma"].ToString();
                HatralevoMTB.Text = (string)reader2["HatralevoMennyiseg"].ToString();
                osszAtvettMennyisegTXB.Text = (string)reader2["OsszesAtvettMennyiseg"].ToString();
                eddigAtvettTXB.Text = (string)reader2["OsszesAtvettMennyiseg"].ToString();
                keszletMennyisegTXB.Text = (string)reader2["KeszletMennyiseg"].ToString();

                /*if (atvett2TXB.Text != "")
                {
                    atvett2TXB.Text = (string)reader2["OsszesAtvettMennyiseg"].ToString();
                }
                else
                {
                    //atvett2TXB.Text = (string)reader2["KomponensIgeny"].ToString();
                }
                // A hátralévő mennyiség kiszámolás
                if (HatralevoMTB.Text != "")
                {
                    int soroMeret = int.Parse(SorozatMeretTB.Text);
                    int atvett = int.Parse(atvett2TXB.Text);
                    int hatralevo = soroMeret - atvett;
                    HatralevoMTB.Text = hatralevo.ToString();
                }
                else
                {
                    HatralevoMTB.Text = (string)reader2["KomponensIgeny"].ToString();
                }*/

                
                StatuszTB.Text = "Elindítva";
            }
            FelkeszCB.Enabled = true;
            AtvettTB.Enabled = true;
            RaktarCB.Enabled = true;
            MegjegyzesTB.Enabled = true;
            kapcsolat.Close();
        }

        private void AtvettTB_TextChanged(object sender, EventArgs e)
        {
            AtvettTB.BackColor = Color.Empty;
            try
            {
                szamoltHatra.Text = (int.Parse(HatralevoMTB.Text) - int.Parse(AtvettTB.Text)).ToString();
            }
            catch 
            {
            }
            
        }

        // Kitöltendő mezők ellenőrzése és színezése,ha nincs kitöltve.
        // Ha lesz rá idő, akkor írok rá egy saját textboxot, hogy átláthatóbb legyen.
        public Boolean isFormValid()
        {
            setFormColors();

            if (CikkszamCB.isFormValid() && FelkeszCB.isFormValid() && RaktarCB.isFormValid() && CikkmegnTB.isFormValid() && MuveletTB.isFormValid() && osszAtvettMennyisegTXB.isFormValid() && rendelesTXB.isFormValid() &&
               KezdesTB.isFormValid() && BefejezesTB.isFormValid() && DopTextbox.isFormValid() && SorozatMeretTB.isFormValid() &&
               MertekegysegTB.isFormValid() && HatralevoMTB.isFormValid() && AtvettTB.isFormValid())
            {
                return true;
             }
            return false;
        }


        private void button5_Click(object sender, EventArgs e)
        {
            if (isFormValid())
            {
                int cikkszam = ((KeyValuePair<string, int>)CikkszamCB.SelectedItem).Value;
                int felkesz = ((KeyValuePair<string, int>)FelkeszCB.SelectedItem).Value;
                int raktar = ((KeyValuePair<string, int>)RaktarCB.SelectedItem).Value;

                // Hogy ne lehessen többet átvenni, mint amennyi a sorozatméret.
                int osszAtvett = int.Parse(eddigAtvettTXB.Text);
                int aktualisanAtvett = int.Parse(AtvettTB.Text);
                int eddigAtvettMennyiseg = osszAtvett + aktualisanAtvett;
                

                int hatrlevo = int.Parse(HatralevoMTB.Text);
                int sorozatm = int.Parse(SorozatMeretTB.Text);

                int atvett = int.Parse(AtvettTB.Text);
                int atvett2 = int.Parse(osszAtvettMennyisegTXB.Text);

                int raktarkeszlet = int.Parse(keszletMennyisegTXB.Text);
                int aktualisKeszlet = atvett + raktarkeszlet;
               
                int teljesatvett = atvett2 + atvett;
                int keszletMennyiseg = teljesatvett;

                if (eddigAtvettMennyiseg <= sorozatm)
                {
                    // Így ezt a textboxokat csak akkor frissíti, ha igaz a feltétel.
                    HatralevoMTB.Text = (atvett + atvett2).ToString();
                    eddigAtvettTXB.Text = (osszAtvett + aktualisanAtvett).ToString();
                    // Gyártási rendelés tábla frissítése 

                    string lekerdezes = "UPDATE [Gyartas] SET HatralevoMennyiseg = @hatralevoMennyiseg, Statusz = @statusz, MozgatottMennyiseg = @mozgatottMennyiseg, Raktar = @raktar, Megjegyzes = @megjegyzes, ModositasIdeje = @modositasIdeje, KeszletMennyiseg = @keszletMennyiseg, Irany = @irany, OsszesAtvettMennyiseg = @osszesAtvettMennyiseg  WHERE GyartasID = '" + IdTxb.Text + "'";
                    using (SqlCommand parancs2 = new SqlCommand(lekerdezes, kapcsolat))
                    {
                        kapcsolat.Open();
                        parancs2.Parameters.AddWithValue("@hatralevoMennyiseg", szamoltHatra.Text);
                        parancs2.Parameters.AddWithValue("@statusz", StatuszTB.Text);
                        parancs2.Parameters.AddWithValue("@mozgatottMennyiseg", teljesatvett);
                        parancs2.Parameters.AddWithValue("@raktar", RaktarCB.Text);
                        parancs2.Parameters.AddWithValue("@megjegyzes", MegjegyzesTB.Text);
                        parancs2.Parameters.AddWithValue("@modositasIdeje", modositasIdeje.Value.ToString("yyyy-MM-dd"));
                        parancs2.Parameters.AddWithValue("@keszletMennyiseg", aktualisKeszlet);
                        parancs2.Parameters.AddWithValue("@irany", iranyTXB.Text);
                        parancs2.Parameters.AddWithValue("@osszesAtvettMennyiseg", eddigAtvettTXB.Text);
                        parancs2.ExecuteNonQuery();
                        kapcsolat.Close();

                    }

                    // Gyártás átvétel tábla feltöltése
                    string lekerdezes2 = "INSERT INTO [GyartasAtvetel_Kiadas] ([Cikkszam], [FelkeszSzint], [CikkMegnvezese], [Muvelet] ,[Statusz], [RendeleseiSzam], [Dop], [SorozatMeret], [Mertekegyseg], [HatralevoMennyiseg], [mozgatottMennyiseg], [Irany], [RaktarKeszlet], [Raktar], [Megjegyzes], [modositasIdeje]) VALUES (@cikkszam, @felkeszSzint, @cikkMegnvezese, @muvelet, @statusz, @rendeleseiSzam, @dop, @sorozatMeret, @mertekegyseg, @hatralevoMennyiseg, @mozgatottMennyiseg, @irany, @raktarKeszlet, @raktar, @megjegyzes, @modositasIdeje)";
                    using (SqlCommand parancs2 = new SqlCommand(lekerdezes2, kapcsolat))
                    {
                        kapcsolat.Open();
                        parancs2.Parameters.AddWithValue("@cikkszam", CikkszamCB.Text);
                        parancs2.Parameters.AddWithValue("@felkeszSzint", FelkeszCB.Text);
                        parancs2.Parameters.AddWithValue("@cikkMegnvezese", CikkmegnTB.Text);
                        parancs2.Parameters.AddWithValue("@muvelet", MuveletTB.Text);
                        parancs2.Parameters.AddWithValue("@statusz", StatuszTB.Text);
                        parancs2.Parameters.AddWithValue("@rendeleseiSzam", rendelesTXB.Text);
                        parancs2.Parameters.AddWithValue("@dop", DopTextbox.Text);
                        parancs2.Parameters.AddWithValue("@sorozatMeret", SorozatMeretTB.Text);
                        parancs2.Parameters.AddWithValue("@mertekegyseg", MertekegysegTB.Text);
                        parancs2.Parameters.AddWithValue("@hatralevoMennyiseg", szamoltHatra.Text);
                        parancs2.Parameters.AddWithValue("@mozgatottMennyiseg", AtvettTB.Text);
                        parancs2.Parameters.AddWithValue("@irany", iranyTXB.Text);
                        parancs2.Parameters.AddWithValue("@raktarKeszlet", aktualisKeszlet);
                        parancs2.Parameters.AddWithValue("@raktar", RaktarCB.Text);
                        parancs2.Parameters.AddWithValue("@megjegyzes", MegjegyzesTB.Text);
                        parancs2.Parameters.AddWithValue("@modositasIdeje", modositasIdeje.Value.ToString("yyyy-MM-dd"));
                        parancs2.ExecuteNonQuery();
                        kapcsolat.Close();
                        TextboxokTorlese();
                        Frissites();
                        timer1.Start();
                        pictureBox2.Enabled = true;
                        pictureBox2.Visible = true;
                    }
                }
                else
                {
                    MessageBox.Show("A sorozatméretnél nem lehet több anyagot átvenni!");
                }
                    
                
            }
            else
            {
                MessageBox.Show("Kérem töltse ki az összes mezőt!");
            }
           

 
        }

        public void TextboxokTorlese()
        {
            AtvettTB.Text = "";
            RaktarCB.Text = "";
            MegjegyzesTB.Text = "";
        }

        public void OsszesTextbTorles()
        {
            CikkszamCB.Text = "";
            CikkmegnTB.Text = "";
            MuveletTB.Text = "";
            StatuszTB.Text = "";
            rendelesTXB.Text = "";
            KezdesTB.Text = "";
            BefejezesTB.Text = "";
            DopTextbox.Text = "";
            SorozatMeretTB.Text = "";
            MertekegysegTB.Text = "";
            HatralevoMTB.Text = "";
            AtvettTB.Text = "";
            MegjegyzesTB.Text = "";
            RaktarCB.Text = "";
            FelkeszCB.Text = "";
            osszAtvettMennyisegTXB.Text = "";
            keszletMennyisegTXB.Text = "";
            eddigAtvettTXB.Text = "";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            OsszesTextbTorles();
        }



        public void Frissites()
        {
            SqlCommand parancs = new SqlCommand("SELECT * FROM Gyartas WHERE FelkeszSzint = '" + FelkeszCB.Text + "'", kapcsolat);
            kapcsolat.Open();
            parancs.ExecuteNonQuery();
            SqlDataReader reader2;
            reader2 = parancs.ExecuteReader();
            while (reader2.Read())
            {
                CikkmegnTB.Text = (string)reader2["CikkMegnevezese"].ToString();
                MuveletTB.Text = (string)reader2["AnyagMuvelet"].ToString();
                rendelesTXB.Text = (string)reader2["RendelesSzam"].ToString();
                KezdesTB.Text = (string)reader2["KezdesDatuma"].ToString();
                DopTextbox.Text = (string)reader2["DopAzonosito"].ToString();
                SorozatMeretTB.Text = (string)reader2["KomponensIgeny"].ToString();
                MertekegysegTB.Text = (string)reader2["Mertekegyseg"].ToString();
                BefejezesTB.Text = (string)reader2["BefejezesDatuma"].ToString();
                HatralevoMTB.Text = (string)reader2["HatralevoMennyiseg"].ToString();
                osszAtvettMennyisegTXB.Text = (string)reader2["OsszesAtvettMennyiseg"].ToString();
                keszletMennyisegTXB.Text = (string)reader2["KeszletMennyiseg"].ToString();

                StatuszTB.Text = "Elindítva";
            }
            int hatralevo = int.Parse(HatralevoMTB.Text);
            if (hatralevo == 0)
            {
                StatuszTB.Text = "Lezárva";
            }
            FelkeszCB.Enabled = true;
            AtvettTB.Enabled = true;
            RaktarCB.Enabled = true;
            MegjegyzesTB.Enabled = true;
            kapcsolat.Close();
        }

        private void setFormColors()
        {
            CikkszamCB.setBackgroundColor(); FelkeszCB.setBackgroundColor(); RaktarCB.setBackgroundColor();           
            AtvettTB.setBackgroundColor();

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
    }

}
