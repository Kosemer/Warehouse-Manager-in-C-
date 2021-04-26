using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SzakdogaBeleptetes
{
    public partial class SMK : Form
    {
        public SMK()
        {
            InitializeComponent();
            

            textBox1.KeyDown += new KeyEventHandler(tb_KeyDown);
            textBox2.KeyDown += new KeyEventHandler(tb_KeyDown);


            SqlConnection kapcsolat = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|AdatbazisLogin.mdf;Integrated Security=True");
            SqlDataAdapter adapter = new SqlDataAdapter("Select UserName, Password From Login", kapcsolat);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            

            // Set to no text.
            textBox1.Text = dt.Rows[0][0].ToString();
            textBox2.Text = dt.Rows[0][1].ToString();
            // The password character is an asterisk.
            textBox2.PasswordChar = '*';
            // The control will allow no more than 14 characters.
            textBox2.MaxLength = 8;

        }



        void tb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1.PerformClick();
            }
        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.TextLength > 0)        //Még nem tökéletes ez a része...
                {
                    SqlConnection kapcsolat = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|AdatbazisLogin.mdf;Integrated Security=True");
                    SqlDataAdapter adapter = new SqlDataAdapter("Select Count(*) From Login where UserName='" + textBox1.Text + 
                        "'and Password ='" + textBox2.Text + "'", kapcsolat);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    if (dt.Rows[0][0].ToString() == "1")
                    {
                        this.Hide();
                        ProgramForm belepve = new ProgramForm();
                        belepve.Show();

                 /*   SqlConnection kapcsolat2 = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|Remember.mdf;Integrated Security=True");
                    SqlDataAdapter adapter2 = new SqlDataAdapter("Insert into Remember (User) VALUES ("+textBox1.Text+") ", kapcsolat2);
                    DataTable d2t = new DataTable();
                    adapter2.Fill(d2t);*/
                }
                    else
                    {
                        MessageBox.Show("Hibás felhasználónév vagy jelszó!");
                    }
                }
                else
                {
                    MessageBox.Show("Add meg a felhasználóneved!");
                }
        }
    }
}
