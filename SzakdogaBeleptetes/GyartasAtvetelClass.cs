using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SzakdogaBeleptetes
{
    class GyartasAtvetelClass
    {
        int? gyartas_Id;
        string felkeszSzint;
        string cikkMegnvezese;
        string muvelet;
        string statusz;
        string rendeleseiSzam;
        string dop;
        int sorozatMeret;
        string mertekegyseg;
        int hatralevoMennyiseg;
        DateTime kezdesDatuma;
        DateTime befejezesDatuma;
        int atvettMennyiseg;
        string raktar;
        string megjegyzes;

        public int? Gyartas_Id { get => gyartas_Id; set => gyartas_Id = value; }
        public string FelkeszSzint { get => felkeszSzint; set => felkeszSzint = value; }
        public string CikkMegnvezese { get => cikkMegnvezese; set => cikkMegnvezese = value; }
        public string Muvelet { get => muvelet; set => muvelet = value; }
        public string Statusz { get => statusz; set => statusz = value; }
        public string RendeleseiSzam { get => rendeleseiSzam; set => rendeleseiSzam = value; }
        public string Dop { get => dop; set => dop = value; }
        public int SorozatMeret { get => sorozatMeret; set => sorozatMeret = value; }
        public string Mertekegyseg { get => mertekegyseg; set => mertekegyseg = value; }
        public int HatralevoMennyiseg { get => hatralevoMennyiseg; set => hatralevoMennyiseg = value; }
        public DateTime KezdesDatuma { get => kezdesDatuma; set => kezdesDatuma = value; }
        public DateTime BefejezesDatuma { get => befejezesDatuma; set => befejezesDatuma = value; }
        public int AtvettMennyiseg { get => atvettMennyiseg; set => atvettMennyiseg = value; }
        public string Raktar { get => raktar; set => raktar = value; }
        public string Megjegyzes { get => megjegyzes; set => megjegyzes = value; }

        public GyartasAtvetelClass(int? gyartas_Id, string felkeszSzint, string cikkMegnvezese, string muvelet, string statusz, string rendeleseiSzam, string dop, int sorozatMeret, string mertekegyseg, int hatralevoMennyiseg, DateTime kezdesDatuma, DateTime befejezesDatuma, int atvettMennyiseg, string raktar, string megjegyzes)
        {
            Gyartas_Id = gyartas_Id;
            FelkeszSzint = felkeszSzint;
            CikkMegnvezese = cikkMegnvezese;
            Muvelet = muvelet;
            Statusz = statusz;
            RendeleseiSzam = rendeleseiSzam;
            Dop = dop;
            SorozatMeret = sorozatMeret;
            Mertekegyseg = mertekegyseg;
            HatralevoMennyiseg = hatralevoMennyiseg;
            KezdesDatuma = kezdesDatuma;
            BefejezesDatuma = befejezesDatuma;
            AtvettMennyiseg = atvettMennyiseg;
            Raktar = raktar;
            Megjegyzes = megjegyzes;
        }

        public GyartasAtvetelClass(string felkeszSzint, string cikkMegnvezese, string muvelet, string statusz, string rendeleseiSzam, string dop, int sorozatMeret, string mertekegyseg, int hatralevoMennyiseg, DateTime kezdesDatuma, DateTime befejezesDatuma, int atvettMennyiseg, string raktar, string megjegyzes)
        {
            FelkeszSzint = felkeszSzint;
            CikkMegnvezese = cikkMegnvezese;
            Muvelet = muvelet;
            Statusz = statusz;
            RendeleseiSzam = rendeleseiSzam;
            Dop = dop;
            SorozatMeret = sorozatMeret;
            Mertekegyseg = mertekegyseg;
            HatralevoMennyiseg = hatralevoMennyiseg;
            KezdesDatuma = kezdesDatuma;
            BefejezesDatuma = befejezesDatuma;
            AtvettMennyiseg = atvettMennyiseg;
            Raktar = raktar;
            Megjegyzes = megjegyzes;
        }

        public GyartasAtvetelClass()
        {
        }
    }
}
