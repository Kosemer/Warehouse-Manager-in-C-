﻿using System;
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
    public partial class SelejtWindowForm2 : Form
    {

        SqlConnection kapcsolat = new SqlConnection(@"Data Source=DESKTOP-O0AMG2J\SQLSERVER;Initial Catalog=SMKExtended;Integrated Security=True");
        SqlDataAdapter adapter;
        IUpdate2 mCallBack2;

        public string gyartasID;
        public string felkeszSzint;
        public string cikkMegnevezese;
        public string keszletMennyiseg;
        public string mertekegyseg;
        public string raktar;
        public string dopAzonosito;
        public string rendelesSzam;
        public string modositasIdeje;

        public SelejtWindowForm2(IUpdate2 callBack2)
        {
            InitializeComponent();
            this.mCallBack2 = callBack2;
        }

        private void SelejtWindowForm2_Load(object sender, EventArgs e)
        {
            ABKezelo.Kapcsolodas();
            // Selejtezési ok COMBOBOX FELTÖLTÉS
            selejtezesiOkMegnCMB.Items.Clear();
            kapcsolat.Open();
            string query = "SELECT * FROM SelejtezesiOkTable";

            using (var command = new SqlCommand(query, kapcsolat))
            {
                var list = new ArrayList();
                var reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        selejtezesiOkMegnCMB.Items.Add(new KeyValuePair<string, int>(reader.GetString(2), reader.GetInt32(0)));
                    }
                }
                else
                {
                    MessageBox.Show("HIBA VAN WAZZEE!!!");
                }

                reader.Close();
                kapcsolat.Close();
            }

            selejtezesiOkMegnCMB.DisplayMember = "key";
            selejtezesiOkMegnCMB.ValueMember = "value";
        }

        private void selejtezesiOkMegnCMB_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlCommand parancs = new SqlCommand("SELECT * FROM SelejtezesiOkTable WHERE SelejtezesiOkMegnevezes = '" + selejtezesiOkMegnCMB.Text + "'", kapcsolat);
            kapcsolat.Open();
            parancs.ExecuteNonQuery();
            SqlDataReader reader;
            reader = parancs.ExecuteReader();
            while (reader.Read())
            {
                string seletjtezesiOk = (string)reader["SelejtezesiOk"].ToString();
                selejtezesiOkTXB.Text = seletjtezesiOk;
            }
            kapcsolat.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public Boolean isFormValid()
        {
            setFormColors();

            if (selejtezendoMTXB.isFormValid() && selejtezesiOkMegnCMB.isFormValid())
            {
                return true;
            }
            return false;
        }

        private void setFormColors()
        {
            selejtezendoMTXB.setBackgroundColor(); selejtezesiOkMegnCMB.setBackgroundColor();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (isFormValid())
            {
                int beirtselejtMennyiseg = int.Parse(selejtezendoMTXB.Text);
                int aktualisKeszlet = int.Parse(keszletMennyiseg);
                int szamoltMennyiseg = aktualisKeszlet - beirtselejtMennyiseg;

                DateTime modIdo = DateTime.Parse(modositasIdeje);

                if (szamoltMennyiseg >= 0)
                {
                    // A kivonandó mennyiség kiszámolása
                    int mennyisegFrissites = aktualisKeszlet - beirtselejtMennyiseg;

                    // Selejtezett termékek táblaba beszúrás
                    string lekerdezes = "INSERT INTO [SelejtezettTermekek] ([FelkeszSzint], [CikkMegnevezese] ,[SelejtezettMennyiseg], [Mertekegyseg], [SelejtezesOka], [Megjegyzes], [Raktar], [DopAzonosito], [RendelesSzam], [ModositasIdeje]) VALUES (@felkeszSzint, @cikkMegnevezese, @selejtezettMennyiseg, @mertekegyseg, @selejtezesOka, @megjegyzes, @raktar, @dopAzonosito, @rendelesSzam, @modositasIdeje)";
                    using (SqlCommand parancs2 = new SqlCommand(lekerdezes, kapcsolat))
                    {
                        kapcsolat.Open();
                        parancs2.Parameters.AddWithValue("@felkeszSzint", felkeszSzint);
                        parancs2.Parameters.AddWithValue("@cikkMegnevezese", cikkMegnevezese);
                        parancs2.Parameters.AddWithValue("@selejtezettMennyiseg", selejtezendoMTXB.Text);
                        parancs2.Parameters.AddWithValue("@mertekegyseg", mertekegyseg);
                        parancs2.Parameters.AddWithValue("@selejtezesOka", selejtezesiOkMegnCMB.Text);
                        parancs2.Parameters.AddWithValue("@megjegyzes", megjegyzesTXB.Text);
                        parancs2.Parameters.AddWithValue("@raktar", raktar);
                        parancs2.Parameters.AddWithValue("@dopAzonosito", dopAzonosito);
                        parancs2.Parameters.AddWithValue("@rendelesSzam", rendelesSzam);
                        parancs2.Parameters.AddWithValue("@modositasIdeje", modositasIdeje);
                        parancs2.ExecuteNonQuery();
                        kapcsolat.Close();
                    }

                    // Gyártás tábla frissítés
                    string lekerdezes2 = "UPDATE [Maradekok] SET ModositasIdeje = @modositasIdeje, Mennyiseg = @mennyiseg  WHERE Maradek_Id = '" + gyartasID + "'";
                    using (SqlCommand parancs2 = new SqlCommand(lekerdezes2, kapcsolat))
                    {
                        kapcsolat.Open();
                        parancs2.Parameters.AddWithValue("@modositasIdeje", dateTimePicker1.Value.ToString("yyyy-MM-dd"));
                        parancs2.Parameters.AddWithValue("@mennyiseg", mennyisegFrissites);
                        parancs2.ExecuteNonQuery();
                        kapcsolat.Close();
                    }
                    mCallBack2.isFinished(true);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("A készleten lévő mennyiségnél nem lehet többet selejtezni!");
                }
            }
            else
            {
                MessageBox.Show("Kérem töltse ki az összes mezőt!");
            }
        }
    }
}
