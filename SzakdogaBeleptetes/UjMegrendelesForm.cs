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
    public partial class UjMegrendelesForm : Form
    {
        Random rnd = new Random();
        TorzsCikkClass torzscikkek = new TorzsCikkClass();
        SqlConnection kapcsolat = new SqlConnection(@"Data Source=DESKTOP-O0AMG2J\SQLSERVER;Initial Catalog=SMKExtended;Integrated Security=True");
        SqlDataAdapter adapter;

        public UjMegrendelesForm()
        {
            InitializeComponent();
        }

        private void UjMegrendelesForm_Load(object sender, EventArgs e)
        {
            ABKezelo.Kapcsolodas();

            // TERVEZŐ COMBOBOX FELTÖLTÉS
            kapcsolat.Open();
            string query = "SELECT * FROM TervezoTable";

            using (var command = new SqlCommand(query, kapcsolat))
            {
                var list = new ArrayList();
                var reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        TervezoTB.Items.Add(new KeyValuePair<string, int>(reader.GetString(3), reader.GetInt32(0)));
                    }
                }
                else
                {
                    MessageBox.Show("Üres a tábla!");
                }

                reader.Close();
                kapcsolat.Close();
            }

            TervezoTB.DisplayMember = "key";
            TervezoTB.ValueMember = "value";


            // MÉRTÉKEGYSÉG COMBOBOX FELTÖLTÉS
            kapcsolat.Open();
            string query2 = "SELECT * FROM MertekegysegTable";

            using (var command = new SqlCommand(query2, kapcsolat))
            {
                var list = new ArrayList();
                var reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        MertekegysegCB.Items.Add(new KeyValuePair<string, int>(reader.GetString(1), reader.GetInt32(0)));
                    }
                }
                else
                {
                    MessageBox.Show("HIBA VAN WAZZEE!!!");
                }

                reader.Close();
                kapcsolat.Close();
            }

            MertekegysegCB.DisplayMember = "key";
            MertekegysegCB.ValueMember = "value";

            // CIKK STÁTUSZA COMBOBOX FELTÖLTÉS
            kapcsolat.Open();
            string query3 = "SELECT * FROM CikkStatuszaTable";

            using (var command = new SqlCommand(query3, kapcsolat))
            {
                var list = new ArrayList();
                var reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        CikkstatuszaCB.Items.Add(new KeyValuePair<string, int>(reader.GetString(1), reader.GetInt32(0)));
                    }
                }
                else
                {
                    MessageBox.Show("HIBA VAN WAZZEE!!!");
                }

                reader.Close();
                kapcsolat.Close();
            }

            CikkstatuszaCB.DisplayMember = "key";
            CikkstatuszaCB.ValueMember = "value";

            // KÖNYVELÉSI CSOPORT COMBOBOX FELTÖLTÉS
            kapcsolat.Open();
            string query4 = "SELECT * FROM [dbo].[KonyvelesiCsoportTable]";

            using (var command = new SqlCommand(query4, kapcsolat))
            {
                var list = new ArrayList();
                var reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        KonyvelesicsCB.Items.Add(new KeyValuePair<string, int>(reader.GetString(1), reader.GetInt32(0)));
                    }
                }
                else
                {
                    MessageBox.Show("HIBA VAN WAZZEE!!!");
                }

                reader.Close();
                kapcsolat.Close();
            }

            KonyvelesicsCB.DisplayMember = "key";
            KonyvelesicsCB.ValueMember = "value";

            // TERMEKCSALAD CSOPORT COMBOBOX FELTÖLTÉS
            kapcsolat.Open();
            string query5 = "SELECT * FROM [dbo].[TermekcsaladTable]";

            using (var command = new SqlCommand(query5, kapcsolat))
            {
                var list = new ArrayList();
                var reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        TermékcsaladCB.Items.Add(new KeyValuePair<string, int>(reader.GetString(1), reader.GetInt32(0)));
                    }
                }
                else
                {
                    MessageBox.Show("HIBA VAN WAZZEE!!!");
                }

                reader.Close();
                kapcsolat.Close();
            }

            TermékcsaladCB.DisplayMember = "key";
            TermékcsaladCB.ValueMember = "value";


        }

        // Textboxok törlése
        public void TextboxTorles()
        {
            RaktaricikkTB.Text = "";
            CikkmegTB.Text = "";
            TervezoTB.Text = "";
            mennyisegTB.Text = "";
            MertekegysegCB.Text = "";
            CikkstatuszaCB.Text = "";
            KonyvelesicsCB.Text = "";
            TermékcsaladCB.Text = "";
            dopTXB.Text = "";
            RendelesiszamTXB.Text = "";
        }


        public Boolean isFormValid()
        {
            setFormColors();

            if (RaktaricikkTB.isFormValid() && CikkmegTB.isFormValid() && TervezoTB.isFormValid() && mennyisegTB.isFormValid() &&
                MertekegysegCB.isFormValid() && CikkstatuszaCB.isFormValid() && KonyvelesicsCB.isFormValid() && TermékcsaladCB.isFormValid() &&
                dopTXB.isFormValid() && RendelesiszamTXB.isFormValid())
            {
                return true;
            }
            return false;
        }

        private void setFormColors()
        {
            RaktaricikkTB.setBackgroundColor(); CikkmegTB.setBackgroundColor(); TervezoTB.setBackgroundColor();
            mennyisegTB.setBackgroundColor(); MertekegysegCB.setBackgroundColor(); CikkstatuszaCB.setBackgroundColor();
            KonyvelesicsCB.setBackgroundColor(); TermékcsaladCB.setBackgroundColor(); 

        }


        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                //MessageBox.Show(dataGridView1.CurrentRow.Cells["Id"].Value.ToString());

                kapcsolat.Open();
                // A datagridview kijelölt sor id-ja.
                string dataId;
                SqlCommand parancs = kapcsolat.CreateCommand();
                parancs.Parameters.Clear();
                parancs.Transaction = kapcsolat.BeginTransaction();
                parancs.CommandType = CommandType.Text;
                parancs.CommandText = "DELETE FROM [CikkStatuszaTable] WHERE id = '" + CikkstatuszaCB.SelectedIndex + "'";
                parancs.ExecuteScalar();
                parancs.Transaction.Commit();
                kapcsolat.Close();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            TextboxTorles();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (isFormValid())
            {
                int tervezo = ((KeyValuePair<string, int>)TervezoTB.SelectedItem).Value;
                int mertekegyseg = ((KeyValuePair<string, int>)MertekegysegCB.SelectedItem).Value;
                int cikkstatusza = ((KeyValuePair<string, int>)CikkstatuszaCB.SelectedItem).Value;
                int konyvelesicsoport = ((KeyValuePair<string, int>)KonyvelesicsCB.SelectedItem).Value;
                int termekcsalad = ((KeyValuePair<string, int>)TermékcsaladCB.SelectedItem).Value;

                string lekerdezes = "INSERT INTO [TorzsCikk] ([Raktari_cikkszam], [Cikk_megnevezese], [Tervezo], [Mennyiseg], [Mertekegyseg], [Cikk_statusza], [Konyvelesi_csoport], [Termekcsalad], [Letrehozva], [Modositva], [DopAzonosito], [RendelesiSzam]) VALUES (@raktari_cikkszam, @cikk_megnevezese, @tervezo, @mennyiseg, @mertekegyseg, @cikk_statusza, @konyvelesi_csoport, @termekcsalad, @letrehozva, @modositva, @dopAzonosito, @rendelesiSzam)";
                using (SqlCommand parancs2 = new SqlCommand(lekerdezes, kapcsolat))
                {
                    kapcsolat.Open();
                    parancs2.Parameters.AddWithValue("@raktari_cikkszam", RaktaricikkTB.Text);
                    parancs2.Parameters.AddWithValue("@cikk_megnevezese", CikkmegTB.Text);
                    parancs2.Parameters.AddWithValue("@Tervezo", tervezo);
                    parancs2.Parameters.AddWithValue("@mennyiseg", mennyisegTB.Text);
                    parancs2.Parameters.AddWithValue("@mertekegyseg", mertekegyseg);
                    parancs2.Parameters.AddWithValue("@cikk_statusza", cikkstatusza);
                    parancs2.Parameters.AddWithValue("@konyvelesi_csoport", konyvelesicsoport);
                    parancs2.Parameters.AddWithValue("@termekcsalad", termekcsalad);
                    parancs2.Parameters.AddWithValue("@letrehozva", dateTimePicker1.Value.ToString("yyyy-MM-dd"));
                    parancs2.Parameters.AddWithValue("@Modositva", dateTimePicker2.Value.ToString("yyyy-MM-dd"));
                    parancs2.Parameters.AddWithValue("@dopAzonosito", dopTXB.Text);
                    parancs2.Parameters.AddWithValue("@rendelesiSzam", RendelesiszamTXB.Text);
                    parancs2.ExecuteNonQuery();
                    TextboxTorles();
                    kapcsolat.Close();
                    timer1.Start();
                    pictureBox1.Enabled = true;
                    pictureBox1.Visible = true;
                }
            }
            else
            {
                MessageBox.Show("Kérem töltse ki az összes mezőt!");
            }
        }

        private void TermékcsaladCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            int randomRendeles = rnd.Next(250, 400);
            int dopRandom = rnd.Next(204501, 207500);
            RendelesiszamTXB.Text = randomRendeles.ToString();
            dopTXB.Text = dopRandom.ToString();
        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            mentesLb.Visible = true;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            mentesLb.Visible = false;
        }

        private void button3_MouseHover(object sender, EventArgs e)
        {
            torlesLB.Visible = true;
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            torlesLB.Visible = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            pictureBox1.Enabled = false;
            pictureBox1.Visible = false;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_MouseHover(object sender, EventArgs e)
        {
            button2.Image = Properties.Resources.icons8_close_windowred_16;
            ablakBezarasLB.Visible = true;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.Image = Properties.Resources.icons8_close_window_16;
            ablakBezarasLB.Visible = false;
        }
    }
}
