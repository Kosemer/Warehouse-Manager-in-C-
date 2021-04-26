using System;
using System.Collections;
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

namespace SzakdogaBeleptetes
{
    public partial class UJFelvitelForm : Form
    {
        TermekekClass termekek = new TermekekClass();
        SqlConnection kapcsolat = new SqlConnection(@"Data Source=DESKTOP-O0AMG2J\SQLSERVER;Initial Catalog=SMKDatabase;Integrated Security=True");
        SqlDataAdapter adapter;
        

        public UJFelvitelForm()
        {
            InitializeComponent();
        }

        // DataGridView feltöltés
        public void Feltoltes()
        {
            //List<TermekekClass> aaa = ABKezelo.Listazas();
            /*foreach (var item in aaa)
            {
                MessageBox.Show(item.Lejarat_ideje.ToString());
            }*/
            //dataGridView1.DataSource = aaa;
            SqlCommand parancs = new SqlCommand("select	id, cikkszam, cikk_megnevezese,sarzsszam, mennyiseg ,(SELECT megnevezes FROM Mertekegyseg_tipusa WHERE Id = Termekek.mertekegyseg) AS mertekegyseg,ertek,(SELECT tipus_megnevezese FROM Termek_tipus WHERE Id = Termekek.tipusa) AS tipusa, (SELECT megnevezes FROM Raktar_neve WHERE Id = Termekek.raktar) AS raktar, (SELECT megnevezes FROM Selejtezes_oka WHERE Id = Termekek.selejtezes_oka) AS selejtezes_oka,me_szam,megjegyzes,atvetel_ideje,lejarat_ideje  FROM Termekek", kapcsolat);    
            List<TermekekClass> termek = new List<TermekekClass>();
            DataTable tabla = new DataTable();
            kapcsolat.Open();
            using (SqlDataReader reader = parancs.ExecuteReader())
            {
                while (reader.Read())
                {
                    termek.Add(new TermekekClass(
                            (int)reader["id"],
                            reader["cikkszam"].ToString(),
                            reader["cikk_megnevezese"].ToString(),
                            reader["sarzsszam"].ToString(),
                            (int)reader["mennyiseg"],
                            (string)reader["mertekegyseg"],
                            (int)reader["ertek"],
                            (string)reader["tipusa"],
                            (string)reader["raktar"],
                            (string)reader["selejtezes_oka"],
                            reader["me_szam"].ToString(),
                            reader["megjegyzes"].ToString(),
                            (DateTime)reader["atvetel_ideje"],
                            (DateTime)reader["lejarat_ideje"]
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

        private void UJFelvitelForm_Load(object sender, EventArgs e)
        {
            ABKezelo.Kapcsolodas();
            //ABKezelo.Listazas();
            Feltoltes();
            // MÉRTÉKEGYSÉG COMBOBOX FELTÖLTÉS
            kapcsolat.Open();
            string query = "SELECT * FROM Mertekegyseg_tipusa";

            using (var command = new SqlCommand(query, kapcsolat))
            {
                var list = new ArrayList();
                var reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        mertekFelv.Items.Add(new KeyValuePair<string, int>(reader.GetString(1), reader.GetInt32(0)));
                    }
                }
                else
                {
                    MessageBox.Show("HIBA VAN WAZZEE!!!");
                }

                reader.Close();
                kapcsolat.Close();
            }

            mertekFelv.DisplayMember = "key";
            mertekFelv.ValueMember = "value";




            // TÍPUS COMBOBOX FELTÖLTÉS
            kapcsolat.Open();
            string query2 = "SELECT * FROM  Termek_tipus";

            using (var command = new SqlCommand(query2, kapcsolat))
            {
                var list = new ArrayList();
                var reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        tipusaFelv.Items.Add(new KeyValuePair<string, int>(reader.GetString(1), reader.GetInt32(0)));
                    }
                }
                else
                {
                    MessageBox.Show("HIBA VAN WAZZEE!!!");
                }

                reader.Close();
                kapcsolat.Close();
            }

           tipusaFelv.DisplayMember = "key";
            tipusaFelv.ValueMember = "value";

            // RAKTÁR COMBOBOX FELTÖLTÉS
            kapcsolat.Open();
            string query3 = "SELECT * FROM Raktar_neve";

            using (var command = new SqlCommand(query3, kapcsolat))
            {
                var list = new ArrayList();
                var reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        raktarFelv.Items.Add(new KeyValuePair<string, int>(reader.GetString(1), reader.GetInt32(0)));
                    }
                }
                else
                {
                    MessageBox.Show("HIBA VAN WAZZEE!!!");
                }

                reader.Close();
                kapcsolat.Close();
            }

            raktarFelv.DisplayMember = "key";
            raktarFelv.ValueMember = "value";

            // SELEJTEZÉS OKA COMBOBOX FELTÖLTÉS
            kapcsolat.Open();
            string query4 = "SELECT * FROM Selejtezes_oka";

            using (var command = new SqlCommand(query4, kapcsolat))
            {
                var list = new ArrayList();
                var reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        selejtokaFelv.Items.Add(new KeyValuePair<string, int>(reader.GetString(1), reader.GetInt32(0)));
                    }
                }
                else
                {
                    MessageBox.Show("HIBA VAN WAZZEE!!!");
                }

                reader.Close();
                kapcsolat.Close();
            }

            selejtokaFelv.DisplayMember = "key";
            selejtokaFelv.ValueMember = "value";
        }



        //FELVITEL
        private void button2_Click(object sender, EventArgs e)
        {
            int mertekegyseg = ((KeyValuePair<string, int>)mertekFelv.SelectedItem).Value;
            int tipus = ((KeyValuePair<string, int>)tipusaFelv.SelectedItem).Value;
            int raktar = ((KeyValuePair<string, int>)raktarFelv.SelectedItem).Value;
            int selejtoka = ((KeyValuePair<string, int>)selejtokaFelv.SelectedItem).Value;

            //SqlConnection kapcsolat = new SqlConnection(@"Data Source=DESKTOP-O0AMG2J\SQLSERVER;Initial Catalog=SMKDatabase;Integrated Security=True");

            string lekerdezes = "INSERT INTO [termekek] ([cikkszam], [cikk_megnevezese], [sarzsszam], [mennyiseg], [mertekegyseg], [ertek], [tipusa], [raktar], [selejtezes_oka] [me_szam], [megjegyzes], [atvetel_ideje], [lejarat_ideje]) VALUES (@cikkszám, @cikkmegnevezése, @sarzsszám, @mennyiség, @mértékegység, @érték, @típusa, @raktar, @selejtezes_oka, @meszám, @megjegyzés, @átvételIdeje, @lejáratIdeje)";
            using (SqlCommand parancs2 = new SqlCommand(lekerdezes, kapcsolat))
            {
                kapcsolat.Open();
                parancs2.Parameters.AddWithValue("@cikkszám", CikkszamFelv.Text);
                parancs2.Parameters.AddWithValue("@cikkmegnevezése", cikkmFelv.Text);
                parancs2.Parameters.AddWithValue("@sarzsszám", sarzsFelv.Text);
                parancs2.Parameters.AddWithValue("@mennyiség", mennyiFelv.Text);
                parancs2.Parameters.AddWithValue("@mértékegység", mertekegyseg);
                parancs2.Parameters.AddWithValue("@érték", ertekFelv.Text);
                parancs2.Parameters.AddWithValue("@típusa", tipus);
                parancs2.Parameters.AddWithValue("@raktar", raktar);
                parancs2.Parameters.AddWithValue("@selejtezes_oka", selejtoka);
                parancs2.Parameters.AddWithValue("@meszám", meszFelv.Text);
                parancs2.Parameters.AddWithValue("@megjegyzés", megjFelv.Text);
                parancs2.Parameters.AddWithValue("@átvételIdeje", dateTimePicker1.Value.ToString("yyyy-MM-dd"));
                parancs2.Parameters.AddWithValue("@lejáratIdeje", dateTimePicker2.Value.ToString("yyyy-MM-dd"));
                parancs2.ExecuteNonQuery();
                Feltoltes();
                TextboxTorles();
            }
        }
        // Textboxok törlése
        public void TextboxTorles()
        {
            CikkszamFelv.Text = "";
            cikkmFelv.Text = "";
            sarzsFelv.Text = "";
            mennyiFelv.Text = "";
            mertekFelv.Text = "";
            ertekFelv.Text = "";
            tipusaFelv.Text = "";
            meszFelv.Text = "";
            megjFelv.Text = "";
        }

        // Mégsem gomb
        private void button3_Click(object sender, EventArgs e)
        {
            TextboxTorles();
        }

        private void button1_Click(object sender, EventArgs e)
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
                   parancs.CommandText = "DELETE FROM [Termekek] WHERE id = '" + dataId + "'";
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
            //DateTime atvetel = Convert.ToDateTime(row.Cells["atvetel_ideje"].Value);
            //DateTime lejarat = Convert.ToDateTime(row.Cells["lejarat_ideje"].Value);
            //TimeSpan dila = lejarat - atvetel;
            //dataGridView1.Columns[0].DefaultCellStyle.BackColor = Color.Red;
            
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {

                DateTime atvetel = Convert.ToDateTime(row.Cells["atvetel_ideje"].Value);
                DateTime lejarat = Convert.ToDateTime(row.Cells["lejarat_ideje"].Value);
                DateTime maiNap = DateTime.Now;
                int mennyiseg = Convert.ToInt32(row.Cells[4].Value);
                TimeSpan dila = lejarat - atvetel;
                
                maiNap.AddMonths(3);
                //MessageBox.Show(dila.TotalDays.ToString());
                if (atvetel <= maiNap)
                {
                    row.DefaultCellStyle.BackColor = Color.Red;
                    row.DefaultCellStyle.ForeColor = Color.White;
                    
                    //foreach
                    //row.cells......
                }
                else
                {
                    row.DefaultCellStyle.BackColor = Color.White;
                    row.DefaultCellStyle.ForeColor = Color.Black;
                }
            }










            /*if (this.dataGridView1.Columns[e.ColumnIndex].Name == "Column5")
            {
                if (Convert.ToInt32(e.Value) < 600)
                {
                    e.CellStyle.BackColor = Color.Red;
                }
            }*/

            /*if (this.dataGridView1.Columns[e.ColumnIndex].Name == "lejarat_ideje")
            {
                var lejaratdatum = DateTime.Parse(dataGridView1.Columns["lejarat_ideje"].ToString());
                var maiDatum = DateTime.Now;
                if (lejaratdatum > maiDatum)
                {
                    e.CellStyle.BackColor = Color.Red;
                }
            }*/

            /*foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                DateTime lejaratdatum = DateTime.Parse(dataGridView1.Columns["lejarat_ideje"].ToString());
                DateTime maiDatum = DateTime.Now;
                if (lejaratdatum > maiDatum)
                {
                    e.CellStyle.BackColor = Color.Red;
                }
            }*/
        }

        public void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == "3")
            {
                DateTime lejarat2 = dateTimePicker2.Value;
                DateTime lejarat3 = lejarat2.AddMonths(3);
                textBox1.Text = lejarat3.ToString();
            }

            if (comboBox1.SelectedItem == "6")
            {
                DateTime lejarat2 = dateTimePicker2.Value;
                DateTime lejarat3 = lejarat2.AddMonths(6);
                textBox1.Text = lejarat3.ToString();
            }

            if (comboBox1.SelectedItem == "12")
            {
                DateTime lejarat2 = dateTimePicker2.Value;
                DateTime lejarat3 = lejarat2.AddMonths(12);
                textBox1.Text = lejarat3.ToString();
            }
        }


        private void probatxb_TextChanged(object sender, EventArgs e)
        {
            if (probatxb.Text != "")
            {
                probaLB.Visible = true;
            }

            if (probatxb.Text == "")
            {
                probaLB.Visible = false;
                probatxb.BackColor = Color.White;
            }

            if (probatxb.Text != "" || probatxb.Text.Length < 6) 
            {
                probatxb.BackColor = Color.LightGreen;
            }
        }
    }
}
