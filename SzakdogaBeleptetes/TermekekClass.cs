using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SzakdogaBeleptetes
{

    class TermekekClass
    {

        int? id;
        string cikkszam;
        string cikkMegnevezes;
        string sarzsszam;
        double mennyiseg;
        string mertekegyseg;
        double ertek;
        string tipusa;
        string raktar;
        string selejtezes_oka;
        string meSzam;
        string megjegyzes;
        DateTime atvetel_ideje;
        DateTime lejarat_ideje;

        public int? Id
        {
            get => id;
            set
            {
                if (!id.HasValue)
                {
                    id = value;
                }
                else
                {
                    throw new InvalidOperationException("Az Id csak egyszer kaphat értéket!");
                }
            }
        }
        public string Cikkszam
        {
            get => cikkszam;
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    cikkszam = value;
                }
                else
                {
                    throw new ArgumentException("A cikkszám nem lehet üres!");
                }
            }
        }
        public string CikkMegnevezes
        {
            get => cikkMegnevezes;
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    cikkMegnevezes = value;
                }
                else
                {
                    throw new ArgumentException("A cikk megnevezése nem lehet üres!");
                }
            }
        }
        public string Sarzsszam
        {
            get => sarzsszam;
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    sarzsszam = value;
                }
                else
                {
                    throw new ArgumentException("A sarzsszám nem lehet üres!");
                }
            }
        }
        public double Mennyiseg
        {
            get => mennyiseg;
            set
            {
                if (value > 0)
                {
                    mennyiseg = value;
                }
                else
                {
                    throw new ArgumentException("Mennyiség", "A mennyiség nem lehet nulla vagy annál kevesebb!");
                }
            }
        }
        public double Ertek
        {
            get => ertek;
            set
            {
                if (value >= 0)
                {
                    ertek = value;
                }
                else
                {
                    throw new ArgumentException("Érték", "Az érték nem lehet kevesebb nullánál!");
                }
            }
        }
        public string MeSzam
        {
            get => meSzam;
            set
            {
                if (value.Length < 15)
                {
                    meSzam = value;
                }
                else
                {
                    throw new ArgumentException("ME zám", "Az ME szám hossza nem lehet több 15 karakternél!");
                }
            }
        }
        public string Megjegyzes { get => megjegyzes; set => megjegyzes = value; }
        internal string Mertekegyseg
        {
            get => mertekegyseg;
            set => mertekegyseg = value;
        }
        public DateTime Atvetel_ideje { get => atvetel_ideje; set => atvetel_ideje = value; }
        public DateTime Lejarat_ideje { get => lejarat_ideje; set => lejarat_ideje = value; }
        internal string Tipusa { get => tipusa; set => tipusa = value; }
        public string Raktar { get => raktar; set => raktar = value; }
        public string Selejtezes_oka { get => selejtezes_oka; set => selejtezes_oka = value; }

        public TermekekClass(int? id, string cikkszam, string cikkMegnevezes, string sarzsszam, double mennyiseg, string mertekegyseg, double ertek, string tipusa, string raktar, string selejtezes_oka, string meSzam, string megjegyzes, DateTime atvetel_ideje, DateTime lejarat_ideje)
        {
            Id = id;
            Cikkszam = cikkszam;
            CikkMegnevezes = cikkMegnevezes;
            Sarzsszam = sarzsszam;
            Mennyiseg = mennyiseg;
            this.mertekegyseg = mertekegyseg;
            Ertek = ertek;
            this.tipusa = tipusa;
            this.raktar = raktar;
            this.selejtezes_oka = selejtezes_oka;
            MeSzam = meSzam;
            Megjegyzes = megjegyzes;
            Atvetel_ideje = atvetel_ideje;
            Lejarat_ideje = lejarat_ideje;
        }

        public TermekekClass(string cikkszam, string cikkMegnevezes, string sarzsszam, double mennyiseg, string
            mertekegyseg, double ertek, string tipusa, string raktar, string selejtezes_oka, string meSzam, string megjegyzes, DateTime atvetel_ideje, DateTime lejarat_ideje)
        {
            Cikkszam = cikkszam;
            CikkMegnevezes = cikkMegnevezes;
            Sarzsszam = sarzsszam;
            Mennyiseg = mennyiseg;
            this.mertekegyseg = mertekegyseg;
            Ertek = ertek;
            this.tipusa = tipusa;
            this.raktar = raktar;
            this.selejtezes_oka = selejtezes_oka;
            MeSzam = meSzam;
            Megjegyzes = megjegyzes;
            Atvetel_ideje = atvetel_ideje;
            Lejarat_ideje = lejarat_ideje;
        }

        public TermekekClass()
        {
        }

        public override string ToString()
        {
            return $"[{id}] - {cikkszam} {cikkMegnevezes} {sarzsszam} {mennyiseg} {mertekegyseg} {ertek} {tipusa} {raktar} {selejtezes_oka} {meSzam} {megjegyzes} {atvetel_ideje} {lejarat_ideje}";
        }
    }
}
