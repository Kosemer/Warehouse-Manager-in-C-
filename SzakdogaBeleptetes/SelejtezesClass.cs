using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SzakdogaBeleptetes
{
    class SelejtezesClass
    {
        int? gyartasID;
        string felkeszSzint;
        string cikkMegnevezese;
        int keszletMennyiseg;
        string mertekegyseg;
        string raktar;
        string dopAzonosito;
        string rendelesSzam;
        DateTime modositasIdeje;

        public int? GyartasID { get => gyartasID; set => gyartasID = value; }
        public string FelkeszSzint { get => felkeszSzint; set => felkeszSzint = value; }
        public string CikkMegnevezese { get => cikkMegnevezese; set => cikkMegnevezese = value; }
        public int KeszletMennyiseg { get => keszletMennyiseg; set => keszletMennyiseg = value; }
        public string Mertekegyseg { get => mertekegyseg; set => mertekegyseg = value; }
        public string Raktar { get => raktar; set => raktar = value; }
        public string DopAzonosito { get => dopAzonosito; set => dopAzonosito = value; }
        public string RendelesSzam { get => rendelesSzam; set => rendelesSzam = value; }
        public DateTime ModositasIdeje { get => modositasIdeje; set => modositasIdeje = value; }

        public SelejtezesClass(int? gyartasID, string felkeszSzint, string cikkMegnevezese, int keszletMennyiseg, string mertekegyseg, string raktar, string dopAzonosito, string rendelesSzam, DateTime modositasIdeje)
        {
            GyartasID = gyartasID;
            FelkeszSzint = felkeszSzint;
            CikkMegnevezese = cikkMegnevezese;
            KeszletMennyiseg = keszletMennyiseg;
            Mertekegyseg = mertekegyseg;
            Raktar = raktar;
            DopAzonosito = dopAzonosito;
            RendelesSzam = rendelesSzam;
            ModositasIdeje = modositasIdeje;
        }

        public SelejtezesClass(string felkeszSzint, string cikkMegnevezese, int keszletMennyiseg, string mertekegyseg, string raktar, string dopAzonosito, string rendelesSzam, DateTime modositasIdeje)
        {
            FelkeszSzint = felkeszSzint;
            CikkMegnevezese = cikkMegnevezese;
            KeszletMennyiseg = keszletMennyiseg;
            Mertekegyseg = mertekegyseg;
            Raktar = raktar;
            DopAzonosito = dopAzonosito;
            RendelesSzam = rendelesSzam;
            ModositasIdeje = modositasIdeje;
        }

        public SelejtezesClass()
        {
        }
    }
}
