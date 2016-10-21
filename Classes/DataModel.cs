using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CIS.Classes
{
    public class DataModel
    {

        public class KrtyJson
        {
            public string draw;
            public int recordsTotal;
            public int recordsFiltered;
            public List<KRTy> data;
        }
        public class KRTy
        {
            public int KRT_ID_FARnosti { get; set; }
            public int KRT_Kniha { get; set; }
            public int KRT_Strana { get; set; }
            public int KRT_PoradoveCislo { get; set; }
            public int KRT_ID_OSOby { get; set; }
            public DateTime KRT_Datum { get; set; }
            public string KRT_TitulPred { get; set; }
            public string KRT_Jmeno1 { get; set; }
            public string KRT_Jmeno2 { get; set; }
            public string KRT_Jmeno3 { get; set; }
            public string KRT_Prijmeni { get; set; }
            public string KRT_TitulZa { get; set; }
            public string KRT_Ulice { get; set; }
            public string KRT_CisloPopisne { get; set; }
            public string KRT_Obec { get; set; }
            public string KRT_PSC { get; set; }
            public string KRT_Stat { get; set; }
            public int KRT_ID_MISta { get; set; }
            public int KRT_ID_UDElovatele { get; set; }
            public string KRT_Krstny1 { get; set; }
            public string KRT_Krstny1Pozn { get; set; }
            public string KRT_Krstny2 { get; set; }
            public string KRT_Krstny2Pozn { get; set; }
            public string KRT_Poznamka { get; set; }
            public DateTime KRT_DatumUlozeni { get; set; }
            public int KRT_ID_UZIvatel { get; set; }
            public DateTime KRT_DatumPoslAkt { get; set; }
            public int KRT_ID_UZIvatelPoslAkt { get; set; }
        }
        public class FARnostiJson
        {
            public string draw;
            public int recordsTotal;
            public int recordsFiltered;
            public List<FARnosti> data;
        }
        public class FARnosti
        {
            public int FAR_ID { get; set; }
            public double FAR_IC { get; set; }
            public string FAR_Nazev { get; set; }
            public string FAR_ZkracenyNazev { get; set; }
            public string FAR_NazevPad { get; set; }
            public string FAR_Ulice { get; set; }
            public string FAR_Cislo_Popisne { get; set; }
            public string FAR_Obec { get; set; }
            public string FAR_PSC { get; set; }
            public string FAR_Stat { get; set; }
            public string FAR_Telefon { get; set; }
            public string FAR_Mobil { get; set; }
            public string FAR_Email { get; set; }
            public string FAR_Web { get; set; }
        }
        public class Osoby
        {
            public int  OSO_ID{ get	; set;	 }
            public string OSO_TitulPred { get	; set;	 }
            public string OSO_Jmeno  { get;	 set;	 }
            public string OSO_Prijmeni { get;	 set;	 }
            public string OSO_RodnePrijmeni { get;	 set;	 }
            public string OSO_TitulZa { get;	 set;	 }
            public string OSO_Pohlavi { get;	 set;	 }
            public DateTime OSO_DatumNarozeni  { get;	 set;	 }
            public string OSO_MistoNarozeni  { get;	 set;	 }
            public int OSO_ID_Otec { get	; set;	 }
            public int OSO_ID_Matka { get;	 set;	 }
            public string OSO_Ulice { get	; set;	 }
            public string OSO_CisloPopisne { get	; set	; }
            public string OSO_Obec { get	; set;	 }
            public string OSO_PSC { get;	 set;	 }
            public string OSO_Stat  { get	; set;	 }
            public int  OSO_ID_CIRkve { get	; set;	 }
            public int OSO_ID_STAvy  { get	; set;	 }
            public DateTime OSO_DatumUlozeni { get	; set	; }
            public int OSO_ID_Uzivatel { get;	 set;	 }
            public DateTime OSO_DatumPoslAkt { get	; set;	 }
            public int OSO_ID_UzivatelPoslAkt { get; set; }

        }


    }
}