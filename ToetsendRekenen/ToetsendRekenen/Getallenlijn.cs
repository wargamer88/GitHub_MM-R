﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ToetsendRekenen
{
    public class GetallenLijn
    {
        public int StartGetal { get; set; }
        public int EindGetal { get; set; }
        public int VraagGetal { get; set; }
        public int FoutGetal1 { get; set; }
        public int FoutGetal2 { get; set; }
        public int FoutGetal3 { get; set; }
        public int MiddelGetal { get; set; }
        public double Tussenstapdouble { get; set; }
        public int Tussenstapint { get; set; }
        public int RandomPositie1 { get; set; }
        public int RandomPositie2 { get; set; }
        public int RandomPositie3 { get; set; }
        public int RandomPositie4 { get; set; }

        //Methode voor het genereren van de Getallenlijn.
        public void GetallenlijnGenereren(string moeilijkheidsgraad)
        {
            //properties leegmaken
            StartGetal = 0;
            EindGetal = 0;
            VraagGetal = 0;
            FoutGetal1 = 0;
            FoutGetal2 = 0;
            FoutGetal3 = 0;
            Tussenstapdouble = 0;
            Tussenstapint = 0;
            RandomPositie1 = 0;
            RandomPositie2 = 0;
            RandomPositie3 = 0;
            RandomPositie4 = 0;

            //Moeilijkheidsgraad bekijken en juiste scope binnengaan
            if (moeilijkheidsgraad == "0-10")
            {
                //Random Variabele aanmaken
                Random R = new Random();
                //Random Start Getal Genereren tussen 0 en 10
                StartGetal = R.Next(0, 10);
                //Random Tussenstappen Genereren tussen 0 en 1
                Tussenstapdouble = R.Next(0, 1);
                //Eind Getal bepalen van Tussenstappen
                EindGetal = StartGetal + (Convert.ToInt32(Tussenstapdouble * 10));
                //Random tussenstap positie genereren tussen 1 en 9
                do
                {
                    VraagGetal = R.Next(1, 8);
                }
                while (VraagGetal == 5);

                //3 Random foute getallen genereren tussen start getal en eindgetal
                FoutGetal1 = R.Next(StartGetal, EindGetal);
                do
                {
                    FoutGetal2 = R.Next(StartGetal, EindGetal);
                }
                while (FoutGetal2 == FoutGetal1);
                do
                {
                    FoutGetal3 = R.Next(StartGetal, EindGetal);
                }
                while (FoutGetal3 == FoutGetal1 || FoutGetal3 == FoutGetal2);
                MiddelGetal = StartGetal + (Convert.ToInt32(Tussenstapdouble * 5));      
            }
            if(moeilijkheidsgraad == "0-100")
            {
                //Random Variabele aanmaken
                Random R = new Random();
                //Random Start Getal Genereren tussen 0 en 10
                StartGetal = R.Next(0, 100);
                //Random Tussenstappen Genereren tussen 0 en 10
                Tussenstapint = R.Next(0, 10);
                //Eind Getal bepalen van Tussenstappen
                EindGetal = StartGetal + (Convert.ToInt32(Tussenstapint * 10));
                //Random tussenstap positie genereren tussen 1 en 9
                do
                {
                    VraagGetal = R.Next(1, 8);
                }
                while (VraagGetal == 5);
               
                //3 Random foute getallen genereren tussen start getal en eindgetal
                FoutGetal1 = R.Next(StartGetal, EindGetal);
                do
                {
                    FoutGetal2 = R.Next(StartGetal, EindGetal);
                }
                while (FoutGetal2 == FoutGetal1);
                do
                {
                    FoutGetal3 = R.Next(StartGetal, EindGetal);
                }
                while (FoutGetal3 == FoutGetal1 || FoutGetal3 == FoutGetal2);
                MiddelGetal = StartGetal + (Convert.ToInt32(Tussenstapint * 5));   
                
                //Genereer een random positie voor het juiste antwoord (in de Checkboxlist)
                do
                {
                    RandomPositie1 = R.Next(0, 4);
                }
                while (RandomPositie1 == 0);

                //Genereer een random posities voor de foute antwoorden (in de Checkboxlist)
                do
                {
                    RandomPositie2 = R.Next(0, 4);
                }
                while (RandomPositie1 == 0 || RandomPositie2 == RandomPositie1);
                do
                {
                    RandomPositie3 = R.Next(0, 4);
                }
                while (RandomPositie1 == 0 || RandomPositie3 == RandomPositie1 || RandomPositie3 == RandomPositie2);
                do
                {
                    RandomPositie4 = R.Next(0, 4);
                }
                while (RandomPositie1 == 0 || RandomPositie4 == RandomPositie1 || RandomPositie4 == RandomPositie2 || RandomPositie4 == RandomPositie3);
              


            }

        }
    }
}