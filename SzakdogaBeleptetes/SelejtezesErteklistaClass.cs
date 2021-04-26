using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SzakdogaBeleptetes
{
    class SelejtezesErteklistaClass
    {
        int selejtezesOkaID;
        string SelejtezesiOk;
        string SelejtezesiOkMegnevezes;

        public int SelejtezesOkaID { get => selejtezesOkaID; set => selejtezesOkaID = value; }
        public string SelejtezesiOk1 { get => SelejtezesiOk; set => SelejtezesiOk = value; }
        public string SelejtezesiOkMegnevezes1 { get => SelejtezesiOkMegnevezes; set => SelejtezesiOkMegnevezes = value; }

        public SelejtezesErteklistaClass(int selejtezesOkaID, string selejtezesiOk1, string selejtezesiOkMegnevezes1)
        {
            SelejtezesOkaID = selejtezesOkaID;
            SelejtezesiOk1 = selejtezesiOk1;
            SelejtezesiOkMegnevezes1 = selejtezesiOkMegnevezes1;
        }

        public SelejtezesErteklistaClass(string selejtezesiOk1, string selejtezesiOkMegnevezes1)
        {
            SelejtezesiOk1 = selejtezesiOk1;
            SelejtezesiOkMegnevezes1 = selejtezesiOkMegnevezes1;
        }

        public SelejtezesErteklistaClass()
        {
        }
    }
}
