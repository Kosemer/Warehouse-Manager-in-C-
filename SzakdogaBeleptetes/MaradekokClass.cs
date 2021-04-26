using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SzakdogaBeleptetes
{
    class MaradekokClass
    {
        int maradek_Id;
        string cikkszam;
        string felkeszSzint;
        string cikkMegnevezese;
        int mennyiseg;
        string mertekegyseg;
        string irany;
        string raktar;
        int dopAzonosito;
        int rendelesiSzam;
        string bevetelezesIdeje;
        string lejaratIdeje;
        string modositasIdeje;

        public int Maradek_Id { get => maradek_Id; set => maradek_Id = value; }
        public string Cikkszam { get => cikkszam; set => cikkszam = value; }
        public string FelkeszSzint { get => felkeszSzint; set => felkeszSzint = value; }
        public string CikkMegnevezese { get => cikkMegnevezese; set => cikkMegnevezese = value; }
        public int Mennyiseg { get => mennyiseg; set => mennyiseg = value; }
        public string Mertekegyseg { get => mertekegyseg; set => mertekegyseg = value; }
        public string Irany { get => irany; set => irany = value; }
        public string Raktar { get => raktar; set => raktar = value; }
        public int DopAzonosito { get => dopAzonosito; set => dopAzonosito = value; }
        public int RendelesiSzam { get => rendelesiSzam; set => rendelesiSzam = value; }
        public string BevetelezesIdeje { get => bevetelezesIdeje; set => bevetelezesIdeje = value; }
        public string LejaratIdeje { get => lejaratIdeje; set => lejaratIdeje = value; }
        public string ModositasIdeje { get => modositasIdeje; set => modositasIdeje = value; }

        public MaradekokClass(int maradek_Id, string cikkszam, string felkeszSzint, string cikkMegnevezese, int mennyiseg, string mertekegyseg, string irany, string raktar, int dopAzonosito, int rendelesiSzam, string bevetelezesIdeje, string lejaratIdeje, string modositasIdeje)
        {
            Maradek_Id = maradek_Id;
            Cikkszam = cikkszam;
            FelkeszSzint = felkeszSzint;
            CikkMegnevezese = cikkMegnevezese;
            Mennyiseg = mennyiseg;
            Mertekegyseg = mertekegyseg;
            Irany = irany;
            Raktar = raktar;
            DopAzonosito = dopAzonosito;
            RendelesiSzam = rendelesiSzam;
            BevetelezesIdeje = bevetelezesIdeje;
            LejaratIdeje = lejaratIdeje;
            ModositasIdeje = modositasIdeje;
        }

        public MaradekokClass(string cikkszam, string felkeszSzint, string cikkMegnevezese, int mennyiseg, string mertekegyseg, string irany, string raktar, int dopAzonosito, int rendelesiSzam, string bevetelezesIdeje, string lejaratIdeje, string modositasIdeje)
        {
            Cikkszam = cikkszam;
            FelkeszSzint = felkeszSzint;
            CikkMegnevezese = cikkMegnevezese;
            Mennyiseg = mennyiseg;
            Mertekegyseg = mertekegyseg;
            Irany = irany;
            Raktar = raktar;
            DopAzonosito = dopAzonosito;
            RendelesiSzam = rendelesiSzam;
            BevetelezesIdeje = bevetelezesIdeje;
            LejaratIdeje = lejaratIdeje;
            ModositasIdeje = modositasIdeje;
        }

        public MaradekokClass()
        {
        }
    }
}
