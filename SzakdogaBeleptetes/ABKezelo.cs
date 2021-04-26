using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SzakdogaBeleptetes
{
    class ABKezelo
    {
        static SqlConnection kapcsolat;
        static SqlCommand parancs;

        public static void Kapcsolodas()
        {
            try
            {
                kapcsolat = new SqlConnection();
                kapcsolat.ConnectionString = ConfigurationManager.ConnectionStrings["Termekek"].ConnectionString;
                kapcsolat.Open();
                parancs = new SqlCommand();
                parancs.Connection = kapcsolat;
            }
            catch (Exception ex)
            {
                throw new AbKivetel("Sikertelen csatlakozás az adatbázisaal!", ex);
                
            }
        }

        public static void KapcsolatBontas()
        {
            try
            {
                kapcsolat.Close();
                parancs.Dispose();
            }
            catch (Exception ex)
            {
                throw new AbKivetel("A kapcsolat bontása az adatbázissal sikertelen!", ex);
            }
        }

        public static List<TermekekClass> Listazas()
        {
            try
            {
                parancs.Parameters.Clear();
                parancs.CommandText = "select	id, cikkszam, cikk_megnevezese,sarzsszam, mennyiseg,(SELECT megnevezes FROM Mertekegyseg_tipusa WHERE Id = Termekek.mertekegyseg) AS mertekegyseg,ertek,(SELECT tipus_megnevezese FROM Termek_tipus WHERE Id = Termekek.tipusa) AS tipusa,me_szam,megjegyzes,atvetel_ideje,lejarat_ideje FROM Termekek";
                List<TermekekClass> termek = new List<TermekekClass>();
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
                    return termek;
                }
            }
            catch (Exception ex)
            {
                throw new AbKivetel("A listázás sikertelen!", ex);
            }
        }

        public static void TermekFelvitel(TermekekClass uj)
        {
            //SqlTransaction tran = kapcsolat.BeginTransaction();
            try
            {
                //parancs.Parameters.Clear();
                //parancs.Transaction = tran;
                string lekerdezes = "INSERT INTO [Termekek] ([Cikkszam], [cikk_megnevezese], [sarzsszam], [mennyiseg], [mertekegyseg], [ertek], [tipusa], [raktar], [selejtezes_oka], [me_szam], [megjegyzes], [atvetel_edeje], [lejarat_ideje]) VALUES (@cikkszam, @cikk_megnevezese, @sarzsszam, @mennyiseg, @mertekegyseg, @ertek, @tipusa, @raktar, @selejtezes_oka, @me_szam, @megjegyzes, @atvetel_ideje, @lejarat_ideje)";
                using (SqlCommand parancs2 = new SqlCommand(lekerdezes, kapcsolat))
                {
                    parancs2.Parameters.AddWithValue("@cikkszam", uj.Cikkszam);
                    parancs2.Parameters.AddWithValue("@cikk_megnevezese", uj.CikkMegnevezes);
                    parancs2.Parameters.AddWithValue("@sarzsszam", uj.Sarzsszam);
                    parancs2.Parameters.AddWithValue("@mennyiseg", uj.Mennyiseg);
                    parancs2.Parameters.AddWithValue("@mertekegyseg", uj.Mertekegyseg);
                    parancs2.Parameters.AddWithValue("@ertek", uj.Ertek);
                    parancs2.Parameters.AddWithValue("@tipusa", uj.Tipusa);
                    parancs2.Parameters.AddWithValue("@raktar", uj.Raktar);
                    parancs2.Parameters.AddWithValue("@selejtezes_oka", uj.Selejtezes_oka);
                    parancs2.Parameters.AddWithValue("@me_szam", uj.MeSzam);
                    parancs2.Parameters.AddWithValue("@megjegyzes", uj.Megjegyzes);
                    parancs2.Parameters.AddWithValue("@atvetel_ideje", uj.Atvetel_ideje);
                    parancs2.Parameters.AddWithValue("@lejarat_ideje", uj.Lejarat_ideje);
                    parancs.ExecuteScalar();
                }
                    //parancs.Parameters.AddWithValue("@id", uj.Id);

                    //uj.Id = (int)parancs.ExecuteScalar();
                //    parancs.ExecuteNonQuery();
                //parancs.Transaction.Commit();
            }
            catch (Exception ex)
            {
                try
                {
                    //if (tran != null)
                    //{
                    //    tran.Rollback();
                    //}
                }
                catch (Exception ex2)
                {
                    throw new AbKivetel("Végzetes hiba!", ex2);
                }
                throw new AbKivetel("A felvitel sikertelen!", ex);
            }
        }

        public static void TermekTorles(TermekekClass torol)
        {
            try
            {
                if (torol is TermekekClass termekek)
                {
                    parancs.Parameters.Clear();
                    parancs.Transaction = kapcsolat.BeginTransaction();
                    parancs.CommandText = "DELETE FROM [Termekek] WHERE [Id] = @id";
                    parancs.Parameters.AddWithValue("@id", termekek.Id);
                    parancs.ExecuteNonQuery();
                    parancs.Transaction.Commit();
                }
                
            }
            catch (Exception ex)
            {
                try
                {
                    if (parancs.Transaction != null)
                    {
                        parancs.Transaction.Rollback();
                    }
                }
                catch (Exception ex2)
                {
                    throw new AbKivetel("Végzetes hiba!", ex2);
                }
                throw new AbKivetel("A törlés sikertelen!", ex);
            }
        }

        public static void TermekModositas(TermekekClass modosit)
        {
            parancs.Parameters.Clear();
            ////
        }
    }
}
