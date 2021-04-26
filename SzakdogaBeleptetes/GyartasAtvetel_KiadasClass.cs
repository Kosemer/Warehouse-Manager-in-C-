using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SzakdogaBeleptetes
{
    class GyartasAtvetel_KiadasClass
    {
        int? gyartas_Id;
        string cikkszam;
        string felkeszSzint;
        string cikkMegnvezese;
        string muvelet;
        string statusz;
        string rendeleseiSzam;
        string dop;
        int sorozatMeret;
        //int keszletMennyiseg;
        string mertekegyseg;
        int hatralevoMennyiseg;
        int mozgatottMennyiseg;
        string irany;
        int raktarKeszlet;
        string raktar;
        string megjegyzes;
        DateTime modositasIdeje;

        public int? Gyartas_Id { get => gyartas_Id; set => gyartas_Id = value; }
        public string Cikkszam { get => cikkszam; set => cikkszam = value; }
        public string FelkeszSzint { get => felkeszSzint; set => felkeszSzint = value; }
        public string CikkMegnvezese { get => cikkMegnvezese; set => cikkMegnvezese = value; }
        public string Muvelet { get => muvelet; set => muvelet = value; }
        public string Statusz { get => statusz; set => statusz = value; }
        public string RendeleseiSzam { get => rendeleseiSzam; set => rendeleseiSzam = value; }
        public string Dop { get => dop; set => dop = value; }
        public int SorozatMeret { get => sorozatMeret; set => sorozatMeret = value; }
        public string Mertekegyseg { get => mertekegyseg; set => mertekegyseg = value; }
        public int HatralevoMennyiseg { get => hatralevoMennyiseg; set => hatralevoMennyiseg = value; }
        public int MozgatottMennyiseg { get => mozgatottMennyiseg; set => mozgatottMennyiseg = value; }
        public string Irany { get => irany; set => irany = value; }
        public int RaktarKeszlet { get => raktarKeszlet; set => raktarKeszlet = value; }
        public string Raktar { get => raktar; set => raktar = value; }
        public string Megjegyzes { get => megjegyzes; set => megjegyzes = value; }
        public DateTime ModositasIdeje { get => modositasIdeje; set => modositasIdeje = value; }

        public GyartasAtvetel_KiadasClass(int? gyartas_Id, string cikkszam, string felkeszSzint, string cikkMegnvezese, string muvelet, string statusz, string rendeleseiSzam, string dop, int sorozatMeret, string mertekegyseg, int hatralevoMennyiseg, int mozgatottMennyiseg, string irany, int raktarKeszlet, string raktar, string megjegyzes, DateTime modositasIdeje)
        {
            Gyartas_Id = gyartas_Id;
            Cikkszam = cikkszam;
            FelkeszSzint = felkeszSzint;
            CikkMegnvezese = cikkMegnvezese;
            Muvelet = muvelet;
            Statusz = statusz;
            RendeleseiSzam = rendeleseiSzam;
            Dop = dop;
            SorozatMeret = sorozatMeret;
            Mertekegyseg = mertekegyseg;
            HatralevoMennyiseg = hatralevoMennyiseg;
            MozgatottMennyiseg = mozgatottMennyiseg;
            Irany = irany;
            RaktarKeszlet = raktarKeszlet;
            Raktar = raktar;
            Megjegyzes = megjegyzes;
            ModositasIdeje = modositasIdeje;
        }

        public GyartasAtvetel_KiadasClass(string cikkszam, string felkeszSzint, string cikkMegnvezese, string muvelet, string statusz, string rendeleseiSzam, string dop, int sorozatMeret, string mertekegyseg, int hatralevoMennyiseg, int mozgatottMennyiseg, string irany, int raktarKeszlet, string raktar, string megjegyzes, DateTime modositasIdeje)
        {
            Cikkszam = cikkszam;
            FelkeszSzint = felkeszSzint;
            CikkMegnvezese = cikkMegnvezese;
            Muvelet = muvelet;
            Statusz = statusz;
            RendeleseiSzam = rendeleseiSzam;
            Dop = dop;
            SorozatMeret = sorozatMeret;
            Mertekegyseg = mertekegyseg;
            HatralevoMennyiseg = hatralevoMennyiseg;
            MozgatottMennyiseg = mozgatottMennyiseg;
            Irany = irany;
            RaktarKeszlet = raktarKeszlet;
            Raktar = raktar;
            Megjegyzes = megjegyzes;
            ModositasIdeje = modositasIdeje;
        }

        public GyartasAtvetel_KiadasClass()
        {
        }
    }
}
