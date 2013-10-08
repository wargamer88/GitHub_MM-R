using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ToetsendRekenen
{
    public class Resultaat : Sessie
    {
        public int ResultaatID { get; set; }
        public string Oefening { get; set; }
        public string Categorie { get; set; }
        public string SubCategorie { get; set; }
        public int AantalGoed { get; set; }
        public int AantalFout { get; set; }
    }
}