using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ToetsendRekenen
{
    public class Getallenlijn
    {
        public int[] GetallenlijnGenereren(string subcategorie, string moeilijkheidsgraad)
        {
            int[] Getallenlijn;
            int StartGetal;
            int EindGetal;
            int VraagGetal;
            if(moeilijkheidsgraad == "0-100")
            {
                Random R = new Random();
                StartGetal = R.Next(0, 100);
                EindGetal = R.Next(StartGetal, 100);
                VraagGetal = R.Next(StartGetal, EindGetal);

            }

            Getallenlijn[1] = StartGetal;
            Getallenlijn[2] = EindGetal;



            return testc;
        }
    }
}