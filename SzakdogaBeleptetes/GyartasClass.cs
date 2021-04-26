using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SzakdogaBeleptetes
{
    class GyartasClass : TorzsCikkClass
    {
        int? torzsCikk_id;
        string cikkszam;
        string cikkMegnevezese;
        string anyagMuvelet;
        int komponensIgeny;
        string mertekegyseg;
        string felkeszSzint;
        string dopAzonosito;
        string RendelesSzam;
        DateTime KezdesDatuma;
        DateTime BefejezesDatuma;

        public int? TorzsCikk_id { get => torzsCikk_id; set => torzsCikk_id = value; }
        public string Cikkszam { get => cikkszam; set => cikkszam = value; }
        public string CikkMegnevezese { get => cikkMegnevezese; set => cikkMegnevezese = value; }
        public string AnyagMuvelet { get => anyagMuvelet; set => anyagMuvelet = value; }
        public int KomponensIgeny { get => komponensIgeny; set => komponensIgeny = value; }
        public string Mertekegyseg { get => mertekegyseg; set => mertekegyseg = value; }
        public string FelkeszSzint { get => felkeszSzint; set => felkeszSzint = value; }
        public string DopAzonosito { get => dopAzonosito; set => dopAzonosito = value; }
        public string RendelesSzam1 { get => RendelesSzam; set => RendelesSzam = value; }
        public DateTime KezdesDatuma1 { get => KezdesDatuma; set => KezdesDatuma = value; }
        public DateTime BefejezesDatuma1 { get => BefejezesDatuma; set => BefejezesDatuma = value; }

        public GyartasClass(int? torzsCikk_id, string cikkszam, string cikkMegnevezese, string anyagMuvelet, int komponensIgeny, string mertekegyseg, string felkeszSzint, string dopAzonosito, string rendelesSzam1, DateTime kezdesDatuma1, DateTime befejezesDatuma1)
        {
            TorzsCikk_id = torzsCikk_id;
            Cikkszam = cikkszam;
            CikkMegnevezese = cikkMegnevezese;
            AnyagMuvelet = anyagMuvelet;
            KomponensIgeny = komponensIgeny;
            Mertekegyseg = mertekegyseg;
            FelkeszSzint = felkeszSzint;
            DopAzonosito = dopAzonosito;
            RendelesSzam1 = rendelesSzam1;
            KezdesDatuma1 = kezdesDatuma1;
            BefejezesDatuma1 = befejezesDatuma1;
        }

        public GyartasClass(string cikkszam, string cikkMegnevezese, string anyagMuvelet, int komponensIgeny, string mertekegyseg, string felkeszSzint, string dopAzonosito, string rendelesSzam1, DateTime kezdesDatuma1, DateTime befejezesDatuma1)
        {
            Cikkszam = cikkszam;
            CikkMegnevezese = cikkMegnevezese;
            AnyagMuvelet = anyagMuvelet;
            KomponensIgeny = komponensIgeny;
            Mertekegyseg = mertekegyseg;
            FelkeszSzint = felkeszSzint;
            DopAzonosito = dopAzonosito;
            RendelesSzam1 = rendelesSzam1;
            KezdesDatuma1 = kezdesDatuma1;
            BefejezesDatuma1 = befejezesDatuma1;
        }

        public GyartasClass()
        {
        }
    }
}
