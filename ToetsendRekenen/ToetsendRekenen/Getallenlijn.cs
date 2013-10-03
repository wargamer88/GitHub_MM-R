using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ToetsendRekenen
{
    public class Getallenlijn
    {
        public int StartGetal { get; set; }
        public int EindGetal { get; set; }
        public int VraagGetal { get; set; }
        public int FoutGetal1 { get; set; }
        public int FoutGetal2 { get; set; }
        public int FoutGetal3 { get; set; }
        public int MiddelGetal { get; set; }

        //Methode voor het genereren van de Getallenlijn.
        public void GetallenlijnGenereren(string subcategorie, string moeilijkheidsgraad)
        {
            //properties leegmaken
            StartGetal = 0;
            EindGetal = 0;
            VraagGetal = 0;
            FoutGetal1 = 0;
            FoutGetal2 = 0;
            FoutGetal3 = 0;

            //Moeilijkheidsgraad bekijken en juiste scope binnengaan
            if (moeilijkheidsgraad == "0-10")
            {
                //Random Variabele aanmaken
                Random R = new Random();
                //Random Start Getal Genereren tussen 0 en 10
                StartGetal = R.Next(0, 10);
                //Random Eind getal Genereren tussen Startgetal en 10
                EindGetal = R.Next(StartGetal, 10);
                //EindGetal omhoog afronden naar een Even Getal
                EindGetal += (EindGetal & 1);
                //Random vraaggetal genereren tussen startgetal en eindgetal
                VraagGetal = R.Next(StartGetal, EindGetal);
                //3 Random foute getallen genereren tussen start getal en eindgetal
                FoutGetal1 = R.Next(StartGetal, EindGetal);
                FoutGetal2 = R.Next(StartGetal, EindGetal);
                FoutGetal3 = R.Next(StartGetal, EindGetal);
                MiddelGetal = EindGetal / 2;   
            }
            if(moeilijkheidsgraad == "0-100")
            {
                //Random Variabele aanmaken
                Random R = new Random();
                //Random Start Getal Genereren tussen 0 en 10
                StartGetal = R.Next(0, 100);
                //Random Eind getal Genereren tussen Startgetal en 10
                EindGetal = R.Next(StartGetal, 100);
                //EindGetal omhoog afronden naar een Even Getal
                EindGetal += (EindGetal & 1);
                //Random vraaggetal genereren tussen startgetal en eindgetal
                VraagGetal = R.Next(StartGetal, EindGetal);
                //3 Random foute getallen genereren tussen start getal en eindgetal
                FoutGetal1 = R.Next(StartGetal, EindGetal);
                FoutGetal2 = R.Next(StartGetal, EindGetal);
                FoutGetal3 = R.Next(StartGetal, EindGetal);
                MiddelGetal = EindGetal / 2;          
            }

        }
    }
}