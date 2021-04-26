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
    public partial class GyartasKiadasForm : Form
    {
        GyartasAtvetelClass atvetel = new GyartasAtvetelClass();
        SqlConnection kapcsolat = new SqlConnection(@"Data Source=DESKTOP-O0AMG2J\SQLSERVER;Initial Catalog=SMKExtended;Integrated Security=True");
        SqlDataAdapter adapter;

        public GyartasKiadasForm()
        {
            InitializeComponent();
        }

        private void GyartasKiadasForm_Load(object sender, EventArgs e)
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

        private void clearFormExceptCikkszam()
        {
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
            KiadottTB.Text = "";
            MegjegyzesTB.Text = "";
            RaktarCB.Text = "";
            FelkeszCB.Text = "";
            raktarmennyisegTXB.Text = "";
        }

        //Félkész ComboBox feltöltése, ha kiválasztotta a cikkszámot.
        private void CikkszamCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            clearFormExceptCikkszam();
            FelkeszCB.Enabled = true;
            FelkeszCB.Items.Clear();
            kapcsolat.Open();
            string query = "SELECT * FROM Gyartas WHERE Cikkszam = '" + CikkszamCB.Text + "'";

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

        private void FelkeszCB_SelectedIndexChanged(object sender, EventArgs e)
        {

            KiadottTB.Text = "";
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
                HatralevoMTB.Text = (string)reader2["MozgatottMennyiseg"].ToString();
                raktarmennyisegTXB.Text = (string)reader2["KeszletMennyiseg"].ToString();

                /*if (raktarmennyisegTXB.Text != "")
                {
                    raktarmennyisegTXB.Text = (string)reader2["KeszletMennyiseg"].ToString();
                }
                else
                {
                    //atvett2TXB.Text = (string)reader2["KomponensIgeny"].ToString();
                }*/

                // A hátralévő mennyiség kiszámolás
                /*if (HatralevoMTB.Text != "")
                {
                    int soroMeret = int.Parse(SorozatMeretTB.Text);
                    MessageBox.Show(raktarmennyisegTXB.Text);
                    int atvett5 = int.Parse(raktarmennyisegTXB.Text);
                    int hatralevo = soroMeret - atvett5;
                    HatralevoMTB.Text = hatralevo.ToString();
                }
                else
                {
                    HatralevoMTB.Text = (string)reader2["KomponensIgeny"].ToString();
                }*/


                StatuszTB.Text = "Elindítva";
            }
            FelkeszCB.Enabled = true;
            KiadottTB.Enabled = true;
            RaktarCB.Enabled = true;
            MegjegyzesTB.Enabled = true;
            kapcsolat.Close();
        }

        public Boolean isFormValid()
        {
            setFormColors();

            if (CikkszamCB.isFormValid() && FelkeszCB.isFormValid() && RaktarCB.isFormValid() && KiadottTB.isFormValid())
            {
                return true;
            }
            return false;
        }

        private void setFormColors()
        {
            CikkszamCB.setBackgroundColor(); FelkeszCB.setBackgroundColor(); RaktarCB.setBackgroundColor();
            KiadottTB.setBackgroundColor();

        }

        // MENTÉS gomb
        private void button5_Click(object sender, EventArgs e)
        {
            if (isFormValid())
            {
                int cikkszam = ((KeyValuePair<string, int>)CikkszamCB.SelectedItem).Value;
                int felkesz = ((KeyValuePair<string, int>)FelkeszCB.SelectedItem).Value;
                int raktar = ((KeyValuePair<string, int>)RaktarCB.SelectedItem).Value;
                int hatrlevo = int.Parse(HatralevoMTB.Text);
                int sorozatm = int.Parse(SorozatMeretTB.Text);

                int kiadott = int.Parse(KiadottTB.Text);
                int atvett2 = int.Parse(raktarmennyisegTXB.Text);
                int teljeskiadott = atvett2 - kiadott;
                int keszletMennyiseg = teljeskiadott;
                if (atvett2 < kiadott)
                {
                    MessageBox.Show("A készleten lévő mennyiségnél nem lehet több anyagot kiadni!");
                }
                else
                {

                    // Gyártási rendelés tábla frissítése 

                    string lekerdezes = "UPDATE [Gyartas] SET  Statusz = @statusz,  Raktar = @raktar, Megjegyzes = @megjegyzes, ModositasIdeje = @modositasIdeje, KeszletMennyiseg = @keszletMennyiseg, Irany = @irany WHERE GyartasID = '" + IdTxb.Text + "'";
                    using (SqlCommand parancs2 = new SqlCommand(lekerdezes, kapcsolat))
                    {
                        kapcsolat.Open();
                        //parancs2.Parameters.AddWithValue("@hatralevoMennyiseg", szamoltHatra.Text);
                        parancs2.Parameters.AddWithValue("@statusz", StatuszTB.Text);
                        //parancs2.Parameters.AddWithValue("@mozgatottMennyiseg", teljeskiadott);
                        parancs2.Parameters.AddWithValue("@raktar", RaktarCB.Text);
                        parancs2.Parameters.AddWithValue("@megjegyzes", MegjegyzesTB.Text);
                        parancs2.Parameters.AddWithValue("@modositasIdeje", modositasIdeje.Value.ToString("yyyy-MM-dd"));
                        parancs2.Parameters.AddWithValue("@keszletMennyiseg", keszletMennyiseg);
                        parancs2.Parameters.AddWithValue("@irany", iranyTXB.Text);
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
                        parancs2.Parameters.AddWithValue("@mozgatottMennyiseg", KiadottTB.Text);
                        parancs2.Parameters.AddWithValue("@irany", iranyTXB.Text);
                        parancs2.Parameters.AddWithValue("@raktarKeszlet", teljeskiadott);
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
            }
            else
            {
                MessageBox.Show("Kérem töltse ki az összes mezőt!");
            }
        }

        public void TextboxokTorlese()
        {
            KiadottTB.Text = "";
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
            KiadottTB.Text = "";
            MegjegyzesTB.Text = "";
            RaktarCB.Text = "";
            FelkeszCB.Text = "";
            raktarmennyisegTXB.Text = "";
        }


        // Törlés gomb
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
                raktarmennyisegTXB.Text = (string)reader2["KeszletMennyiseg"].ToString();
                StatuszTB.Text = "Elindítva";
            }
            FelkeszCB.Enabled = true;
            KiadottTB.Enabled = true;
            RaktarCB.Enabled = true;
            MegjegyzesTB.Enabled = true;
            int Hatralevo = int.Parse(HatralevoMTB.Text);
            if (Hatralevo == 0)
            {
                StatuszTB.Text = "Lezárt";
            }
            kapcsolat.Close();
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

        // A hátralévő mennyiség számolása egy külön textboxban.
        private void KiadottTB_TextChanged_1(object sender, EventArgs e)
        {
            try
            {
                szamoltHatra.Text = (int.Parse(HatralevoMTB.Text) - int.Parse(KiadottTB.Text)).ToString();
            }
            catch
            {
            }
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
    }
}
