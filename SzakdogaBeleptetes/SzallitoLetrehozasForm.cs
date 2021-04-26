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
    public partial class SzallitoLetrehozasForm : Form
    {
        Random rnd = new Random();
        SqlConnection kapcsolat = new SqlConnection(@"Data Source=DESKTOP-O0AMG2J\SQLSERVER;Initial Catalog=SMKExtended;Integrated Security=True");
        public SzallitoLetrehozasForm()
        {
            InitializeComponent();
        }

        private void CikkszamTXB_Leave(object sender, EventArgs e)
        {
            SqlConnection kapcsolat = new SqlConnection(@"Data Source=DESKTOP-O0AMG2J\SQLSERVER;Initial Catalog=SMKExtended;Integrated Security=True");
            SqlDataReader reader;
            SqlCommand command;
            try
            {
                ABKezelo.Kapcsolodas();
                //kapcsolat = new SqlConnection();
                //kapcsolat.ConnectionString = ConfigurationManager.ConnectionStrings["GyartasAtvetel_Kiadas"].ConnectionString;
                List<string> lista = new List<string>();
                kapcsolat.Open();
                command = kapcsolat.CreateCommand();
                command.CommandType = CommandType.Text;
                //command.CommandText = "SELECT Kesztermek FROM Gyartas WHERE LOWER (Kesztermek) LIKE '" + CikkszamTXB.Text.ToLower() + "%' OR LOWER (Kesztermek) LIKE '" + CikkszamTXB.Text.ToLower() + "%'";
                command.CommandText = "SELECT Kesztermek FROM Gyartas";
                command.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(dt);

                foreach (DataRow dr in dt.Rows)
                {
                    lista.Add(dr["Kesztermek"].ToString());
                }
                if (CikkszamTXB.Text != "")
                {
                    /*foreach (string item in lista)
             {
                 if (item.Length > 1 && CikkszamTXB.Text == item || CikkszamTXB.Text == "")
                 {
                     MessageBox.Show("Jó");
                     //CikkszamTXB.Text = item;
                 }
                 else
                 {
                     MessageBox.Show("Ilyen cikkszám nincs az adatbázisban!");
                 }
             }*/
                    int n = lista.Count;
                    //MessageBox.Show(n.ToString());
                    string keresett = CikkszamTXB.Text;
                    //MessageBox.Show(keresett);
                    int i = 1;
                    while (i < n && lista[i] != keresett)
                    {
                        //MessageBox.Show(i.ToString());
                        i++;
                    }
                    if (i < n)
                    {
                        //MessageBox.Show(i.ToString());
                        SqlCommand parancs = new SqlCommand("SELECT * FROM Gyartas WHERE Kesztermek = '" + CikkszamTXB.Text + "'", kapcsolat);
                        parancs.ExecuteNonQuery();
                        SqlDataReader reader2;
                        reader2 = parancs.ExecuteReader();
                        while (reader2.Read())
                        {
                            string cikkmegnevezes = (string)reader2["CikkMegnevezese"].ToString();
                            int gyartasID = (int)reader2["GyartasID"];
                            CikkMegnTXB.Text = cikkmegnevezes;
                            gyartasIDTXB.Text = gyartasID.ToString();
                        }
                        kapcsolat.Close();
                    }
                    else
                    {
                        MessageBox.Show("Nincs ilyen cikkszám az adatbázisban!");
                        CikkszamTXB.Text = "";
                        CikkMegnTXB.Text = "";
                    }
                    //MessageBox.Show(n.ToString());
                }
            }
            catch (Exception ex)
            {
                throw new AbKivetel("Sikertelen csatlakozás az adatbázisaal!", ex);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NevTXB.Enabled = true;
            SzallitoNeveTxb.Enabled = true;
            CikkszamTXB.Enabled = true;
            CimTXB.Enabled = true;
            ErtekMennyisegTXB.Enabled = true;
            mertekegysegCB.Enabled = true;
            OrszagCB.Enabled = true;
            int randomRendeles = rnd.Next(400, 1200);
            SzallitmanyAzTXB.Text = randomRendeles.ToString();
            LetrehozasIdejeTXB.Text = DateTime.Now.ToString();
        }

        public void TextBoxokTorlese()
        {
            NevTXB.Text = "";
            SzallitoNeveTxb.Text = "";
            CikkszamTXB.Text = "";
            CikkMegnTXB.Text = "";
            ErtekMennyisegTXB.Text = "";
            OrszagCB.Text = "";
            CimTXB.Text = "";
            mertekegysegCB.Text = "";
            SzallitmanyAzTXB.Text = "";
            LetrehozasIdejeTXB.Text = "";
            dataGridView1.Rows[0].Cells[0].Value = "";
            dataGridView1.Rows[0].Cells[1].Value = "";
            dataGridView1.Rows[0].Cells[2].Value = "";
            dataGridView1.Rows[0].Cells[3].Value = "";
        }
        

        private void button8_Click(object sender, EventArgs e)
        {
            TextBoxokTorlese();
        }

        private void SzallitoLetrehozasForm_Load(object sender, EventArgs e)
        {
            ABKezelo.Kapcsolodas();
            kapcsolat.Open();
            string query2 = "SELECT * FROM Orszagok";

            using (var command = new SqlCommand(query2, kapcsolat))
            {
                var list = new ArrayList();
                var reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        OrszagCB.Items.Add(new KeyValuePair<string, int>(reader.GetString(1), reader.GetInt32(0)));
                    }
                }
                else
                {
                    MessageBox.Show("HIBA VAN WAZZEE!!!");
                }

                reader.Close();
                kapcsolat.Close();
            }

            OrszagCB.DisplayMember = "key";
            OrszagCB.ValueMember = "value";

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

            dataGridView1.Rows.Add("", "", "", "","");
        }

        public Boolean isFormValid()
        {
            setFormColors();

            if (CikkMegnTXB.isFormValid() && CikkMegnTXB.isFormValid() && SzallitmanyAzTXB.isFormValid() && NevTXB.isFormValid() && SzallitoNeveTxb.isFormValid() && OrszagCB.isFormValid() && CimTXB.isFormValid() &&
               LetrehozasIdejeTXB.isFormValid() && mertekegysegCB.isFormValid())
            {
                return true;
            }
            return false;
        }

        private void setFormColors()
        {
            CikkszamTXB.setBackgroundColor(); CikkMegnTXB.setBackgroundColor(); SzallitmanyAzTXB.setBackgroundColor();
            NevTXB.setBackgroundColor(); SzallitoNeveTxb.isFormValid(); OrszagCB.isFormValid(); CimTXB.isFormValid(); ErtekMennyisegTXB.isFormValid();
            LetrehozasIdejeTXB.isFormValid(); mertekegysegCB.isFormValid();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (isFormValid())
            {
                string azonosito = dataGridView1.CurrentRow.Cells["Column1"].Value.ToString();
                string nev = dataGridView1.CurrentRow.Cells["Név"].Value.ToString();
                string megnevezes = dataGridView1.CurrentRow.Cells["Column2"].Value.ToString();
                string tipusa = dataGridView1.CurrentRow.Cells["Column3"].Value.ToString();
                string ertek = dataGridView1.CurrentRow.Cells["Column4"].Value.ToString();

                int szallitottMennyiseg = 0;
                //int foglalandoMennyiseg = 0;

                string lekerdezes = "INSERT INTO [SzallitmanyLetrehozasa] ([SzallitmanyAzon], [Nev] ,[SzallitoNeve], [Cikkszam], [CikkMegnevezese], [ErtekesitesiMenny], [Orszag], [Cim], [LetrehozasDatuma], [KapcsolatAzon], [KapcsNev], [KapcsMegnevezes], [KapcsTipusa], [KapcsErtek], [Mertekegyseg], [GyartasID], [SzallitottMennyiseg], [FoglaltMennyiseg], [FoglalandoMennyiseg]) VALUES (@szallitmanyAzon, @nev, @szallitoNeve, @cikkszam, @cikkMegnevezese, @ertekesitesiMenny, @orszag, @cim, @letrehozasDatuma , @kapcsolatAzon, @kapcsNev, @KapcsMegnevezes, @kapcsTipusa, @kapcsErtek, @mertekegyseg, @GyartasID, @szallitottMennyiseg, @foglaltMennyiseg, @foglalandoMennyiseg)";
                using (SqlCommand parancs2 = new SqlCommand(lekerdezes, kapcsolat))
                {
                    kapcsolat.Open();
                    parancs2.Parameters.AddWithValue("@szallitmanyAzon", SzallitmanyAzTXB.Text);
                    parancs2.Parameters.AddWithValue("@nev", NevTXB.Text);
                    parancs2.Parameters.AddWithValue("@szallitoNeve", SzallitoNeveTxb.Text);
                    parancs2.Parameters.AddWithValue("@cikkszam", CikkszamTXB.Text);
                    parancs2.Parameters.AddWithValue("@cikkMegnevezese", CikkMegnTXB.Text);
                    parancs2.Parameters.AddWithValue("@ertekesitesiMenny", ErtekMennyisegTXB.Text);
                    parancs2.Parameters.AddWithValue("@orszag", OrszagCB.Text);
                    parancs2.Parameters.AddWithValue("@cim", CimTXB.Text);
                    parancs2.Parameters.AddWithValue("@letrehozasDatuma", LetrehozasIdejeTXB.Text);
                    parancs2.Parameters.AddWithValue("@kapcsolatAzon", azonosito);
                    parancs2.Parameters.AddWithValue("@kapcsNev", nev);
                    parancs2.Parameters.AddWithValue("@KapcsMegnevezes", megnevezes);
                    parancs2.Parameters.AddWithValue("@kapcsTipusa", tipusa);
                    parancs2.Parameters.AddWithValue("@kapcsErtek", ertek);
                    parancs2.Parameters.AddWithValue("@mertekegyseg", mertekegysegCB.Text);
                    parancs2.Parameters.AddWithValue("@gyartasID", gyartasIDTXB.Text);
                    parancs2.Parameters.AddWithValue("@szallitottMennyiseg", szallitottMennyiseg);
                    parancs2.Parameters.AddWithValue("@foglaltMennyiseg", 0);
                    parancs2.Parameters.AddWithValue("@foglalandoMennyiseg", ErtekMennyisegTXB.Text);
                    parancs2.ExecuteNonQuery();
                    kapcsolat.Close();
                    TextBoxokTorlese();
                }
            }
            else
            {
                MessageBox.Show("Kérem töltse ki az összes mezőt!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
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

        private void button1_MouseHover(object sender, EventArgs e)
        {
            ujLB.Visible = true;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            ujLB.Visible = false;
        }

        private void button5_MouseHover(object sender, EventArgs e)
        {
            mentesLb.Visible = true;
        }

        private void button5_MouseLeave(object sender, EventArgs e)
        {
            mentesLb.Visible = true;
        }

        private void button8_MouseHover(object sender, EventArgs e)
        {
            torlesLB.Visible = true;
        }

        private void button8_MouseLeave(object sender, EventArgs e)
        {
            torlesLB.Visible = false;
        }
    }
}
