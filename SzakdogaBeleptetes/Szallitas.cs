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
using System.IO;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace SzakdogaBeleptetes
{
    public partial class Szallitas : Form
    {
        SqlConnection kapcsolat = new SqlConnection(@"Data Source=DESKTOP-O0AMG2J\SQLSERVER;Initial Catalog=SMKExtended;Integrated Security=True");
        string cikkMegnevezese;
        int szallitottMennyiseg = 0;
        //int foglaltMennyiseg = 0;
        string mertekegyseg;
        string cim;
        string orszag;
        string nev;
        string szallitmanyid;

        public Szallitas()
        {
            InitializeComponent();
        }

        public void TextBoxokTorlese()
        {
            SzallAzonTXB.Text = "";
            SzallNevTXB.Text = "";
            LetrehozvaTXB.Text = "";
            StatuszTXB.Text = "";
            SulyTXB.Text = "";
            dataGridView1.Rows[0].Cells[0].Value = "";
            dataGridView1.Rows[0].Cells[1].Value = "";
            dataGridView1.Rows[0].Cells[2].Value = "";
            dataGridView1.Rows[0].Cells[3].Value = "";
            dataGridView1.Rows[0].Cells[4].Value = "";
            dataGridView1.Rows[0].Cells[5].Value = "";
            dataGridView1.Rows[0].Cells[6].Value = "";
        }

        private void SzallAzonTXB_Leave(object sender, EventArgs e)
        {
            SqlCommand command;
            try
            {
                ABKezelo.Kapcsolodas();
                StatuszTXB.Text = "Előzetes";
                List<string> lista = new List<string>();
                kapcsolat.Open();
                command = kapcsolat.CreateCommand();
                command.CommandType = CommandType.Text;
               
                command.CommandText = "SELECT SzallitmanyAzon FROM SzallitmanyLetrehozasa";
                command.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(dt);

                foreach (DataRow dr in dt.Rows)
                {
                    lista.Add(dr["SzallitmanyAzon"].ToString());
                }
                if (SzallAzonTXB.Text != "")
                {
                    int n = lista.Count;
                    //MessageBox.Show(n.ToString());
                    string keresett = SzallAzonTXB.Text;
                    //MessageBox.Show(keresett);
                    int i = 0;
                    while (i < n && lista[i] != keresett)
                    {
                        //MessageBox.Show(i.ToString());
                        i++;
                    }
                    if (i < n)
                    {
                        //MessageBox.Show(i.ToString());
                        SqlCommand parancs = new SqlCommand("SELECT * FROM SzallitmanyLetrehozasa WHERE SzallitmanyAzon = '" + SzallAzonTXB.Text + "'", kapcsolat);
                        parancs.ExecuteNonQuery();
                        SqlDataReader reader2;
                        reader2 = parancs.ExecuteReader();
                        while (reader2.Read())
                        {
                            string Nev = (string)reader2["Nev"].ToString();
                            string datum = (string)reader2["LetrehozasDatuma"].ToString();
                            string cikkszam = (string)reader2["Cikkszam"].ToString();
                            string CikkMegnevezese = (string)reader2["CikkMegnevezese"].ToString();
                            int ErtekesitesiMenny = (int)reader2["ErtekesitesiMenny"];
                            //int KeszletMennyiseg = (int)reader2["KeszletMennyiseg"];
                            string Orszag = (string)reader2["Orszag"].ToString();
                            string Cim = (string)reader2["Cim"].ToString();
                            string Mertekegyseg = (string)reader2["Mertekegyseg"].ToString();
                            string GyartasID = (string)reader2["gyartasID"].ToString();
                            string szallitmanyId = (string)reader2["Szallitmany_Id"].ToString();
                            int szallitottMenny = (int)reader2["SzallitottMennyiseg"];
                            int foglaltMennyiseg = (int)reader2["FoglaltMennyiseg"];
                            int foglalandoMennyiseg = (int)reader2["FoglalandoMennyiseg"];

                            SzallNevTXB.Text = Nev;
                            LetrehozvaTXB.Text = datum;
                            gyartsaId.Text = GyartasID;
                            cikkMegnevezese = CikkMegnevezese;
                            mertekegyseg = Mertekegyseg;
                            cim = Cim;
                            orszag = Orszag;
                            nev = Nev;
                            SulyTXB.Text = 0.ToString();
                            szallitmanyid = szallitmanyId;
                            szallitottMennyiseg = szallitottMenny;
                            //ertCikkszam = cikkszam;

                            dataGridView1.Rows[0].Cells[1].Value = cikkszam;
                            dataGridView1.Rows[0].Cells[2].Value = CikkMegnevezese;
                            dataGridView1.Rows[0].Cells[3].Value = ErtekesitesiMenny;
                            dataGridView1.Rows[0].Cells[4].Value = szallitottMenny;
                            dataGridView1.Rows[0].Cells[5].Value = ErtekesitesiMenny;
                            dataGridView1.Rows[0].Cells[6].Value = foglaltMennyiseg;
                            dataGridView1.Rows[0].Cells[7].Value = foglalandoMennyiseg;
                            dataGridView1.Rows[0].Cells[8].Value = Mertekegyseg;
                        }
                        kapcsolat.Close();
                        SqlCommand parancs2 = new SqlCommand("SELECT * FROM Gyartas WHERE GyartasID = '" + gyartsaId.Text + "'", kapcsolat);
                        kapcsolat.Open();
                        parancs2.ExecuteNonQuery();
                        //SqlDataReader reader2;
                        reader2 = parancs2.ExecuteReader();
                        while (reader2.Read())
                        {
                            int KeszletMennyiseg = (int)reader2["KeszletMennyiseg"];
                            dataGridView1.Rows[0].Cells[5].Value = KeszletMennyiseg;
                        }
                        button5.Enabled = true;
                        button7.Enabled = true;
                        button2.Enabled = true;
                        button3.Enabled = true;
                        kapcsolat.Close();
                    }
                    else
                    {
                        MessageBox.Show("Nincs ilyen szállítmány az adatbázisban!");
                        SzallAzonTXB.Text = "";
                        button5.Enabled = false;
                        button7.Enabled = false;
                        button2.Enabled = false;
                        button3.Enabled = false;
                        kapcsolat.Close();
                    }
                    //MessageBox.Show(n.ToString());
                }
            }
            catch (Exception ex)
            {
                throw new AbKivetel("Sikertelen csatlakozás az adatbázisaal!", ex);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            TextBoxokTorlese();
        }

        public Boolean isFormValid()
        {
            setFormColors();

            if (SzallAzonTXB.isFormValid() && LetrehozvaTXB.isFormValid() && SzallNevTXB.isFormValid() && foglaltMennyTxb.isFormValid())
            {
                return true;
            }
            return false;
        }

        private void setFormColors()
        {
            SzallAzonTXB.setBackgroundColor(); SzallNevTXB.setBackgroundColor(); foglaltMennyTxb.setBackgroundColor();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (isFormValid())
            {
                int foglaltMenny = (int)dataGridView1.Rows[0].Cells[6].Value;
                int keszletMenny = (int)dataGridView1.Rows[0].Cells[5].Value;
                if (keszletMenny > 0)
                {
                    //int kapcsoltErtMenny = (int)dataGridView1.Rows[0].Cells[3].Value;
                    //int szallitottMenny = (int)dataGridView1.Rows[0].Cells[4].Value;
                    int foglalandoMenny = (int)dataGridView1.Rows[0].Cells[7].Value;
                    dataGridView1.Rows[0].Cells[6].Value = foglaltMennyTxb.Text;
                    int fogMenny = int.Parse(foglaltMennyTxb.Text);

                    // Összes foglalt mennyiség számolása
                    int osszFoglalt = foglaltMenny + fogMenny;
                    dataGridView1.Rows[0].Cells[6].Value = osszFoglalt;
                    eppFoglaltTXB.Text = osszFoglalt.ToString();
                    szalitottTXB.Text = osszFoglalt.ToString();

                    // Még foglalandó mennyiség számolása
                    dataGridView1.Rows[0].Cells[7].Value = foglalandoMenny - fogMenny;
                    // Hátralévő készlet számolása
                    dataGridView1.Rows[0].Cells[5].Value = keszletMenny - fogMenny;
                    foglaltMennyTxb.Text = "";
                    eppFoglaltTXB.Text = "";

                    string cikk = (string)dataGridView1.Rows[0].Cells[1].Value;
                    string megnevezes = (string)dataGridView1.Rows[0].Cells[2].Value;
                    int ertMennyiseg = (int)dataGridView1.Rows[0].Cells[3].Value;
                    int szallitottMenny = (int)dataGridView1.Rows[0].Cells[4].Value;
                    int keszletMennyiseg = (int)dataGridView1.Rows[0].Cells[5].Value;
                    int foglaltMennyiseg = (int)dataGridView1.Rows[0].Cells[6].Value;
                    int foglalandoMennyiseg = (int)dataGridView1.Rows[0].Cells[7].Value;
                    string mertekegyseg = (string)dataGridView1.Rows[0].Cells[8].Value;
                    //int osszesSzalitott = szallitottMenny + foglaltMennyiseg;
                    string lekerdezes2 = "INSERT INTO [Szallitott] ([SzallitmanyAzonosito], [Letrehozva], [BruttoSuly], [VevoNeve] ,[ErtekesitesiCikkszam], [Megnevezes], [KapcsoltErtMennyiseg], [SzallitottMennyiseg], [KeszletMennyiseg], [foglaltMennyiseg], [foglalandoMennyiseg], [Mertekegyseg], [Statusz]) VALUES (@szallitmanyAzonosito, @letrehozva, @bruttoSuly, @vevoNeve, @ertekesitesiCikkszam, @megnevezes, @kapcsoltErtMennyiseg, @szallitottMennyiseg, @keszletMennyiseg, @foglaltMennyiseg, @foglalandoMennyiseg, @mertekegyseg, @statusz)";
                    using (SqlCommand parancs2 = new SqlCommand(lekerdezes2, kapcsolat))
                    {
                        kapcsolat.Open();
                        parancs2.Parameters.AddWithValue("@szallitmanyAzonosito", SzallAzonTXB.Text);
                        parancs2.Parameters.AddWithValue("@letrehozva", LetrehozvaTXB.Text);
                        parancs2.Parameters.AddWithValue("@bruttoSuly", SulyTXB.Text);
                        parancs2.Parameters.AddWithValue("@vevoNeve", SzallNevTXB.Text);
                        parancs2.Parameters.AddWithValue("@ertekesitesiCikkszam", cikk);
                        parancs2.Parameters.AddWithValue("@megnevezes", megnevezes);
                        parancs2.Parameters.AddWithValue("@kapcsoltErtMennyiseg", ertMennyiseg);
                        parancs2.Parameters.AddWithValue("@szallitottMennyiseg", szallitottMennyiseg);
                        parancs2.Parameters.AddWithValue("@keszletMennyiseg", keszletMennyiseg);
                        parancs2.Parameters.AddWithValue("@foglaltMennyiseg", foglaltMennyiseg);
                        parancs2.Parameters.AddWithValue("@foglalandoMennyiseg", foglalandoMennyiseg);
                        parancs2.Parameters.AddWithValue("@mertekegyseg", mertekegyseg);
                        parancs2.Parameters.AddWithValue("@Statusz", StatuszTXB.Text);
                        parancs2.ExecuteNonQuery();
                        kapcsolat.Close();
                    }
                    //Szállítmány létrehozása tábla frissítése
                    string lekerdezes = "UPDATE [SzallitmanyLetrehozasa] SET SzallitottMennyiseg = @szallitottMennyiseg, FoglaltMennyiseg = @foglaltMennyiseg, FoglalandoMennyiseg = @foglalandoMennyiseg  WHERE Szallitmany_Id = '" + szallitmanyid + "'";
                    using (SqlCommand parancs2 = new SqlCommand(lekerdezes, kapcsolat))
                    {
                        kapcsolat.Open();
                        parancs2.Parameters.AddWithValue("@szallitottMennyiseg", szallitottMennyiseg);
                        parancs2.Parameters.AddWithValue("@foglaltMennyiseg", foglaltMennyiseg);
                        parancs2.Parameters.AddWithValue("@foglalandoMennyiseg", foglalandoMennyiseg);
                        parancs2.ExecuteNonQuery();
                        kapcsolat.Close();
                    }
                    //Gyártás tábla frissítés
                    string lekerdezes1 = "UPDATE [Gyartas] SET KeszletMennyiseg = @keszletMennyiseg WHERE GyartasID = '" + gyartsaId.Text + "'";
                    using (SqlCommand parancs2 = new SqlCommand(lekerdezes1, kapcsolat))
                    {
                        kapcsolat.Open();
                        parancs2.Parameters.AddWithValue("@keszletMennyiseg", keszletMennyiseg);
                        parancs2.ExecuteNonQuery();
                        kapcsolat.Close();
                    }
                    Frissites();
                }
                else
                {
                    MessageBox.Show("Nincs elegendő mennyiség a foglaláshoz!");
                }
            }
            else
            {
                MessageBox.Show("Kérem töltse ki az összes mezőt!");
            }
        }

        public void Frissites()
        {
            kapcsolat.Open();
            SqlCommand parancs = new SqlCommand("SELECT * FROM SzallitmanyLetrehozasa WHERE SzallitmanyAzon = '" + SzallAzonTXB.Text + "'", kapcsolat);
            parancs.ExecuteNonQuery();
            SqlDataReader reader2;
            reader2 = parancs.ExecuteReader();
            while (reader2.Read())
            {
                string Nev = (string)reader2["Nev"].ToString();
                string datum = (string)reader2["LetrehozasDatuma"].ToString();
                string cikkszam = (string)reader2["Cikkszam"].ToString();
                string CikkMegnevezese = (string)reader2["CikkMegnevezese"].ToString();
                int ErtekesitesiMenny = (int)reader2["ErtekesitesiMenny"];
                //int KeszletMennyiseg = (int)reader2["KeszletMennyiseg"];
                string Orszag = (string)reader2["Orszag"].ToString();
                string Cim = (string)reader2["Cim"].ToString();
                string Mertekegyseg = (string)reader2["Mertekegyseg"].ToString();
                string GyartasID = (string)reader2["gyartasID"].ToString();
                string szallitmanyId = (string)reader2["Szallitmany_Id"].ToString();
                int szallitottMenny = (int)reader2["SzallitottMennyiseg"];
                int foglaltMennyiseg = (int)reader2["FoglaltMennyiseg"];
                int foglalandoMennyiseg = (int)reader2["FoglalandoMennyiseg"];

                SzallNevTXB.Text = Nev;
                LetrehozvaTXB.Text = datum;
                gyartsaId.Text = GyartasID;
                cikkMegnevezese = CikkMegnevezese;
                mertekegyseg = Mertekegyseg;
                cim = Cim;
                orszag = Orszag;
                nev = Nev;
                SulyTXB.Text = 0.ToString();
                szallitmanyid = szallitmanyId;
                szallitottMennyiseg = szallitottMenny;
                //ertCikkszam = cikkszam;

                dataGridView1.Rows[0].Cells[1].Value = cikkszam;
                dataGridView1.Rows[0].Cells[2].Value = CikkMegnevezese;
                dataGridView1.Rows[0].Cells[3].Value = ErtekesitesiMenny;
                dataGridView1.Rows[0].Cells[4].Value = szallitottMenny;
                dataGridView1.Rows[0].Cells[5].Value = ErtekesitesiMenny;
                dataGridView1.Rows[0].Cells[6].Value = foglaltMennyiseg;
                dataGridView1.Rows[0].Cells[7].Value = foglalandoMennyiseg;
                dataGridView1.Rows[0].Cells[8].Value = Mertekegyseg;
            }
            kapcsolat.Close();
            SqlCommand parancs2 = new SqlCommand("SELECT * FROM Gyartas WHERE GyartasID = '" + gyartsaId.Text + "'", kapcsolat);
            kapcsolat.Open();
            parancs2.ExecuteNonQuery();
            //SqlDataReader reader2;
            reader2 = parancs2.ExecuteReader();
            while (reader2.Read())
            {
                int KeszletMennyiseg = (int)reader2["KeszletMennyiseg"];
                dataGridView1.Rows[0].Cells[5].Value = KeszletMennyiseg;
            }
            button5.Enabled = true;
            button7.Enabled = true;
            kapcsolat.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            kapcsolat.Open();
            SqlCommand parancs = new SqlCommand("SELECT * FROM SzallitmanyLetrehozasa WHERE SzallitmanyAzon = '" + SzallAzonTXB.Text + "'", kapcsolat);
            parancs.ExecuteNonQuery();
            SqlDataReader reader2;
            reader2 = parancs.ExecuteReader();
            while (reader2.Read())
            {
                int szallitottMenny = (int)reader2["SzallitottMennyiseg"];
                szallitottMennyiseg = szallitottMenny;
            }
            kapcsolat.Close();

            DateTime datum = DateTime.Now;
            Bitmap kep = Properties.Resources.pdf_kep;
            System.Drawing.Image image = kep;
            e.Graphics.DrawImage(image, 25, 25, image.Width, image.Height);

            e.Graphics.DrawString("Szállítmány azonosító: " + SzallAzonTXB.Text, new System.Drawing.Font("Arial", 10, FontStyle.Regular),
                Brushes.Black, new Point(550, 200));

            e.Graphics.DrawString("Dátum: " + datum.ToShortDateString(), new System.Drawing.Font("Arial", 10), Brushes.Black, new Point(35, 200));
            e.Graphics.DrawString(elvalasztoLB.Text, new System.Drawing.Font("Arial", 12), Brushes.Black, new Point(35, 210));
            e.Graphics.DrawString("Szállító:", new System.Drawing.Font("Arial", 12), Brushes.Black, new Point(35, 230));
            e.Graphics.DrawString("SMK Security Company Nyrt.", new System.Drawing.Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(35, 250));
            e.Graphics.DrawString("Budapest", new System.Drawing.Font("Arial", 12), Brushes.Black, new Point(35, 270));
            e.Graphics.DrawString("Biztos utca 13.", new System.Drawing.Font("Arial", 12), Brushes.Black, new Point(35, 290));
            e.Graphics.DrawString("1023", new System.Drawing.Font("Arial", 12), Brushes.Black, new Point(35, 310));
            e.Graphics.DrawString("Magyarország", new System.Drawing.Font("Arial", 12), Brushes.Black, new Point(35, 330));

            e.Graphics.DrawString("Vevő:", new System.Drawing.Font("Arial", 12), Brushes.Black, new Point(550, 230));
            e.Graphics.DrawString(nev, new System.Drawing.Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(550, 250));
            e.Graphics.DrawString(cim, new System.Drawing.Font("Arial", 12), Brushes.Black, new Point(550, 270));
            e.Graphics.DrawString(orszag, new System.Drawing.Font("Arial", 12), Brushes.Black, new Point(550, 330));

            e.Graphics.DrawString(elvalasztoLB.Text, new System.Drawing.Font("Arial", 12), Brushes.Black, new Point(35, 340));
            e.Graphics.DrawString("Cikkszám", new System.Drawing.Font("Arial", 10), Brushes.Black, new Point(35, 375));
            e.Graphics.DrawString("Megnevezés", new System.Drawing.Font("Arial", 10), Brushes.Black, new Point(35, 400));
            e.Graphics.DrawString("Mennyiség", new System.Drawing.Font("Arial", 10), Brushes.Black, new Point(700, 385));
            e.Graphics.DrawString("Egység", new System.Drawing.Font("Arial", 10), Brushes.Black, new Point(600, 385));
            e.Graphics.DrawString(elvalasztoLB.Text, new System.Drawing.Font("Arial", 12), Brushes.Black, new Point(35, 405));


            e.Graphics.DrawString(cikkMegnevezese, new System.Drawing.Font("Arial", 12), Brushes.Black, new Point(35, 435));
            e.Graphics.DrawString(szallitottMennyiseg.ToString(), new System.Drawing.Font("Arial", 12), Brushes.Black, new Point(730, 435));
            e.Graphics.DrawString("Darab", new System.Drawing.Font("Arial", 12), Brushes.Black, new Point(600, 435));

            e.Graphics.DrawString(vonalLB.Text, new System.Drawing.Font("Arial", 12), Brushes.Black, new Point(150, 900));
            e.Graphics.DrawString("Átadó", new System.Drawing.Font("Arial", 12), Brushes.Black, new Point(200, 925));
            e.Graphics.DrawString(vonalLB.Text, new System.Drawing.Font("Arial", 12), Brushes.Black, new Point(500, 900));
            e.Graphics.DrawString("Átvevő", new System.Drawing.Font("Arial", 12), Brushes.Black, new Point(550, 925));
        }

        private void Szallitas_Load(object sender, EventArgs e)
        {
            dataGridView1.Rows.Add("","","","","","","","","");
        }

        private void SzallAzonTXB_TextChanged(object sender, EventArgs e)
        {
            if (SzallAzonTXB.TextLength <= 0)
            {
                TextBoxokTorlese();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (szalitottTXB.Text != "")
            {
                int szallitottMenny = (int)dataGridView1.Rows[0].Cells[4].Value;
                int foglaltMennyiseg = (int)dataGridView1.Rows[0].Cells[6].Value;
                int foglalandomenny = (int)dataGridView1.Rows[0].Cells[7].Value;
                //MessageBox.Show(foglalandomenny.ToString());
                int osszesSzalitott = szallitottMenny + foglaltMennyiseg;
                string lekerdezes = "UPDATE [SzallitmanyLetrehozasa] SET SzallitottMennyiseg = @szallitottMennyiseg, FoglaltMennyiseg = @foglaltMennyiseg WHERE Szallitmany_Id = '" + szallitmanyid + "'";
                using (SqlCommand parancs2 = new SqlCommand(lekerdezes, kapcsolat))
                {
                    kapcsolat.Open();
                    parancs2.Parameters.AddWithValue("@szallitottMennyiseg", osszesSzalitott);
                    parancs2.Parameters.AddWithValue("@foglaltMennyiseg", 0);
                    parancs2.ExecuteNonQuery();
                    kapcsolat.Close();
                }
                //szalitottTXB.Text = "";
                Frissites();
            }
            else
            {
                MessageBox.Show("Nincs foglalt mennyiség!");
            }
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

        private void button7_MouseHover(object sender, EventArgs e)
        {
            nyomtatasLB.Visible = true;
        }

        private void button7_MouseLeave(object sender, EventArgs e)
        {
            nyomtatasLB.Visible = false;
        }

        private void button8_MouseHover(object sender, EventArgs e)
        {
            torlesLB.Visible = true;
        }

        private void button8_MouseLeave(object sender, EventArgs e)
        {
            torlesLB.Visible = false;
        }

        private void button5_MouseHover(object sender, EventArgs e)
        {
            mentesLb.Visible = true;
        }

        private void button5_MouseLeave(object sender, EventArgs e)
        {
            mentesLb.Visible = false;
        }

        private void button2_MouseHover(object sender, EventArgs e)
        {
            szallitasLB.Visible = true;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            szallitasLB.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Frissites();
        }

        private void button3_MouseHover(object sender, EventArgs e)
        {
            frissitesLB.Visible = true;
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            frissitesLB.Visible = false;
        }
    }
}
