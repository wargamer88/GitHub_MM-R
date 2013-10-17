using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace ToetsendRekenen
{
    public class GetallenLijn
    {
        #region Properties
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
        public double StartKommaGetal { get; set; }
        public double EindKommaGetal { get; set; }
        public double FoutKommaGetal1 { get; set; }
        public double FoutKommaGetal2 { get; set; }
        public double FoutKommaGetal3 { get; set; }
        public double MiddelKommaGetal { get; set; }
        #endregion

        //Methode voor het genereren van de Getallenlijn.
        public void GetallenlijnGenereren(string Categorie, string Subcategorie)
        {
            #region Getallen/0-10
            //Moeilijkheidsgraad bekijken en juiste scope binnengaan
            if (Subcategorie == "0-10" && Categorie == "Getallen" )
            {
                //Random Variabele aanmaken
                Random R = new Random();
                //Random Start Getal Genereren tussen 0 en 10
                StartGetal = R.Next(0, 10);
                //Random Tussenstappen Genereren tussen 0 en 1
                Tussenstapint = 1;
                //Eind Getal bepalen van Tussenstappen
                EindGetal = StartGetal + (Tussenstapint * 10);
                //Random tussenstap positie genereren tussen 1 en 9
                do
                {
                    VraagGetal = R.Next(1, 8);
                }
                while (VraagGetal == 5);

                int antwoord = (VraagGetal * Tussenstapint) + StartGetal;

                //3 Random foute getallen genereren tussen start getal en eindgetal
                do
                {
                FoutGetal1 = R.Next(StartGetal, EindGetal);
                }
                while (FoutGetal1 == antwoord);    
                do
                {
                    FoutGetal2 = R.Next(StartGetal, EindGetal);
                }
                while (FoutGetal2 == FoutGetal1 || FoutGetal2 == antwoord);
                do
                {
                    FoutGetal3 = R.Next(StartGetal, EindGetal);
                }
                while (FoutGetal3 == FoutGetal1 || FoutGetal3 == FoutGetal2 || FoutGetal3 == antwoord);
                MiddelGetal = StartGetal + (Tussenstapint * 5);

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
#endregion
            #region Getallen/0-100
            else if (Subcategorie == "0-100" && Categorie == "Getallen")
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

                int antwoord = (VraagGetal * Tussenstapint) + StartGetal;

                //3 Random foute getallen genereren tussen start getal en eindgetal
                do
                {
                    FoutGetal1 = R.Next(StartGetal, EindGetal);
                }
                while (FoutGetal1 == antwoord);
                do
                {
                    FoutGetal2 = R.Next(StartGetal, EindGetal);
                }
                while (FoutGetal2 == FoutGetal1 || FoutGetal2 == antwoord);
                do
                {
                    FoutGetal3 = R.Next(StartGetal, EindGetal);
                }
                while (FoutGetal3 == FoutGetal1 || FoutGetal3 == FoutGetal2 || FoutGetal3 == antwoord);
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
            #endregion
            #region KommaGetallen/0-10
            else if (Subcategorie == "0-10" && Categorie == "KommaGetallen")
            {
                //Random Variabele aanmaken
                Random R = new Random();
                //Random Start Getal Genereren tussen 0 en 10
                StartKommaGetal = R.Next(0, 10);
                StartKommaGetal = StartKommaGetal + R.NextDouble();
                StartKommaGetal = Math.Round(StartKommaGetal, 1);
                //Random Tussenstappen Genereren tussen 0 en 1
                do
                {
                    Tussenstapdouble = R.NextDouble();
                    Tussenstapdouble = Math.Round(Tussenstapdouble, 1);
                }
                while (Tussenstapdouble == 0.0);
                //Eind Getal bepalen van Tussenstappen
                EindKommaGetal = StartKommaGetal + (Tussenstapdouble * 10);
                //Random tussenstap positie genereren tussen 1 en 9
                do
                {
                    VraagGetal = R.Next(1, 8);
                }
                while (VraagGetal == 5);
                int RoundedStart = Convert.ToInt32(StartKommaGetal);
                int RoundedEind = Convert.ToInt32(EindKommaGetal);
                double antword = (VraagGetal * Tussenstapdouble) + StartKommaGetal;

                //3 Random foute getallen genereren tussen start getal en eindgetal
                do
                {
                    FoutKommaGetal1 = R.Next(RoundedStart, RoundedEind);
                    FoutKommaGetal1 = FoutKommaGetal1 + R.NextDouble();
                    FoutKommaGetal1 = Math.Round(FoutKommaGetal1, 1);
                }
                while (FoutKommaGetal1 == antword);
                do
                {
                    FoutKommaGetal2 = R.Next(RoundedStart, RoundedEind);
                    FoutKommaGetal2 = FoutKommaGetal2 + R.NextDouble();
                    FoutKommaGetal2 = Math.Round(FoutKommaGetal2, 1);
                }
                while (FoutKommaGetal2 == FoutKommaGetal1 || FoutKommaGetal2 == antword);
                do
                {
                    FoutKommaGetal3 = R.Next(RoundedStart, RoundedEind);
                    FoutKommaGetal3 = FoutKommaGetal2 + R.NextDouble();
                    FoutKommaGetal3 = Math.Round(FoutKommaGetal3, 1);
                }
                while (FoutKommaGetal3 == FoutKommaGetal1 || FoutKommaGetal3 == FoutKommaGetal2 || FoutKommaGetal3 == antword);
                MiddelKommaGetal = StartKommaGetal + (Tussenstapdouble * 5);

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
            #endregion
            #region KommaGetallen/0-100
            else if (Subcategorie == "0-100" && Categorie == "KommaGetallen")
            {
                //Random Variabele aanmaken
                Random R = new Random();
                //Random Start Getal Genereren tussen 0 en 10
                StartKommaGetal = R.Next(1, 100);
                StartKommaGetal = StartKommaGetal + R.NextDouble();
                StartKommaGetal = Math.Round(StartKommaGetal, 1);
                //Random Tussenstappen Genereren tussen 0 en 10
                do
                {
                    Tussenstapdouble = R.Next(0, 10);
                    Tussenstapdouble = Tussenstapdouble + R.NextDouble();
                    Tussenstapdouble = Math.Round(Tussenstapdouble, 1);
                }
                while (Tussenstapdouble == 0.0);
                //Eind Getal bepalen van Tussenstappen
                EindKommaGetal = StartKommaGetal + (Tussenstapdouble * 10);
                //Random tussenstap positie genereren tussen 1 en 9
                do
                {
                    VraagGetal = R.Next(1, 8);
                }
                while (VraagGetal == 5);
                int RoundedStart = Convert.ToInt32(StartKommaGetal);
                int RoundedEind = Convert.ToInt32(EindKommaGetal);
                double antword = (VraagGetal * Tussenstapdouble) + StartKommaGetal;

                //3 Random foute getallen genereren tussen start getal en eindgetal
                do
                {
                    FoutKommaGetal1 = R.Next(RoundedStart, RoundedEind);
                    FoutKommaGetal1 = FoutKommaGetal1 + R.NextDouble();
                    FoutKommaGetal1 = Math.Round(FoutKommaGetal1, 1);
                }
                while (FoutKommaGetal1 == antword);
                do
                {
                    FoutKommaGetal2 = R.Next(RoundedStart, RoundedEind);
                    FoutKommaGetal2 = FoutKommaGetal2 + R.NextDouble();
                    FoutKommaGetal2 = Math.Round(FoutKommaGetal2, 1);
                }
                while (FoutKommaGetal2 == FoutKommaGetal1 || FoutKommaGetal2 == antword);
                do
                {
                    FoutKommaGetal3 = R.Next(RoundedStart, RoundedEind);
                    FoutKommaGetal3 = FoutKommaGetal2 + R.NextDouble();
                    FoutKommaGetal3 = Math.Round(FoutKommaGetal3, 1);
                }
                while (FoutKommaGetal3 == FoutKommaGetal1 || FoutKommaGetal3 == FoutKommaGetal2 || FoutKommaGetal3 == antword);
                MiddelKommaGetal = StartKommaGetal + (Tussenstapdouble * 5);

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
            #endregion
            #region Breuken/0-10
            else if (Subcategorie == "0-10" && Categorie == "Breuken")
            {
                //Random Variabele aanmaken
                Random R = new Random();
                //Random Start Getal Genereren tussen 0 en 10
                StartKommaGetal = R.Next(0, 10);
                StartKommaGetal = StartKommaGetal + R.NextDouble();
                StartKommaGetal = Math.Round(StartKommaGetal, 1);
                //Random Tussenstappen Genereren tussen 0 en 1
                do
                {
                    Tussenstapdouble = R.NextDouble();
                    Tussenstapdouble = Math.Round(Tussenstapdouble, 1);
                }
                while (Tussenstapdouble == 0.0);
                //Eind Getal bepalen van Tussenstappen
                EindKommaGetal = StartKommaGetal + (Tussenstapdouble * 10);
                //Random tussenstap positie genereren tussen 1 en 9
                do
                {
                    VraagGetal = R.Next(1, 8);
                }
                while (VraagGetal == 5);
                int RoundedStart = Convert.ToInt32(StartKommaGetal);
                int RoundedEind = Convert.ToInt32(EindKommaGetal);
                double antword = (VraagGetal * Tussenstapdouble) + StartKommaGetal;

                //3 Random foute getallen genereren tussen start getal en eindgetal
                do
                {
                    FoutKommaGetal1 = R.Next(RoundedStart, RoundedEind);
                    FoutKommaGetal1 = FoutKommaGetal1 + R.NextDouble();
                    FoutKommaGetal1 = Math.Round(FoutKommaGetal1, 1);
                }
                while (FoutKommaGetal1 == antword);
                do
                {
                    FoutKommaGetal2 = R.Next(RoundedStart, RoundedEind);
                    FoutKommaGetal2 = FoutKommaGetal2 + R.NextDouble();
                    FoutKommaGetal2 = Math.Round(FoutKommaGetal2, 1);
                }
                while (FoutKommaGetal2 == FoutKommaGetal1 || FoutKommaGetal2 == antword);
                do
                {
                    FoutKommaGetal3 = R.Next(RoundedStart, RoundedEind);
                    FoutKommaGetal3 = FoutKommaGetal2 + R.NextDouble();
                    FoutKommaGetal3 = Math.Round(FoutKommaGetal3, 1);
                }
                while (FoutKommaGetal3 == FoutKommaGetal1 || FoutKommaGetal3 == FoutKommaGetal2 || FoutKommaGetal3 == antword);
                MiddelKommaGetal = StartKommaGetal + (Tussenstapdouble * 5);

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
            #endregion
            #region Breuken/0-100
            else if (Subcategorie == "0-100" && Categorie == "Breuken")
            {
                //Random Variabele aanmaken
                Random R = new Random();
                //Random Start Getal Genereren tussen 0 en 10
                StartKommaGetal = R.Next(0, 100);
                StartKommaGetal = StartKommaGetal + R.NextDouble();
                StartKommaGetal = Math.Round(StartKommaGetal, 1);
                //Random Tussenstappen Genereren tussen 0 en 1
                do
                {
                    Tussenstapdouble = R.NextDouble();
                    Tussenstapdouble = Math.Round(Tussenstapdouble, 1);
                }
                while (Tussenstapdouble == 0.0);
                //Eind Getal bepalen van Tussenstappen
                EindKommaGetal = StartKommaGetal + (Tussenstapdouble * 10);
                //Random tussenstap positie genereren tussen 1 en 9
                do
                {
                    VraagGetal = R.Next(1, 8);
                }
                while (VraagGetal == 5);
                int RoundedStart = Convert.ToInt32(StartKommaGetal);
                int RoundedEind = Convert.ToInt32(EindKommaGetal);
                double antword = (VraagGetal * Tussenstapdouble) + StartKommaGetal;

                //3 Random foute getallen genereren tussen start getal en eindgetal
                do
                {
                    FoutKommaGetal1 = R.Next(RoundedStart, RoundedEind);
                    FoutKommaGetal1 = FoutKommaGetal1 + R.NextDouble();
                    FoutKommaGetal1 = Math.Round(FoutKommaGetal1, 1);
                }
                while (FoutKommaGetal1 == antword);
                do
                {
                    FoutKommaGetal2 = R.Next(RoundedStart, RoundedEind);
                    FoutKommaGetal2 = FoutKommaGetal2 + R.NextDouble();
                    FoutKommaGetal2 = Math.Round(FoutKommaGetal2, 1);
                }
                while (FoutKommaGetal2 == FoutKommaGetal1 || FoutKommaGetal2 == antword);
                do
                {
                    FoutKommaGetal3 = R.Next(RoundedStart, RoundedEind);
                    FoutKommaGetal3 = FoutKommaGetal2 + R.NextDouble();
                    FoutKommaGetal3 = Math.Round(FoutKommaGetal3, 1);
                }
                while (FoutKommaGetal3 == FoutKommaGetal1 || FoutKommaGetal3 == FoutKommaGetal2 || FoutKommaGetal3 == antword);
                MiddelKommaGetal = StartKommaGetal + (Tussenstapdouble * 5);

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
            #endregion

        }

        #region ConvertDecimaltoFractures
            public static string ConvertToFracture(decimal value)
            {
                // get the whole value of the fraction
                decimal mWhole = Math.Truncate(value);

                // get the fractional value
                decimal mFraction = value - mWhole;

                // initialize a numerator and denomintar
                uint mNumerator = 0;
                uint mDenomenator = 1;

                // ensure that there is actual a fraction
                if (mFraction > 0m)
                {
                    // convert the value to a string so that you can count the number of decimal places there are
                    string strFraction = mFraction.ToString().Remove(0, 2);

                    // store teh number of decimal places
                    uint intFractLength = (uint)strFraction.Length;

                    // set the numerator to have the proper amount of zeros
                    mNumerator = (uint)Math.Pow(10, intFractLength);

                    // parse the fraction value to an integer that equals [fraction value] * 10^[number of decimal places]
                    uint.TryParse(strFraction, out mDenomenator);

                    // get the greatest common divisor for both numbers
                    uint gcd = GreatestCommonDivisor(mDenomenator, mNumerator);

                    // divide the numerator and the denominator by the gratest common divisor
                    mNumerator = mNumerator / gcd;
                    mDenomenator = mDenomenator / gcd;
                }

                // create a string builder
                StringBuilder mBuilder = new StringBuilder();

                // add the whole number if it's greater than 0
                if (mWhole > 0m)
                {
                    mBuilder.Append(mWhole);
                }

                // add the fraction if it's greater than 0m
                if (mFraction > 0m)
                {
                    if (mBuilder.Length > 0)
                    {
                        mBuilder.Append(" ");
                    }

                    mBuilder.Append(mDenomenator);
                    mBuilder.Append("/");
                    mBuilder.Append(mNumerator);
                }

                return mBuilder.ToString();
            }

            private static uint GreatestCommonDivisor(uint valA, uint valB)
            {
                // return 0 if both values are 0 (no GSD)
                if (valA == 0 &&
                  valB == 0)
                {
                    return 0;
                }
                // return value b if only a == 0
                else if (valA == 0 &&
                      valB != 0)
                {
                    return valB;
                }
                // return value a if only b == 0
                else if (valA != 0 && valB == 0)
                {
                    return valA;
                }
                // actually find the GSD
                else
                {
                    uint first = valA;
                    uint second = valB;

                    while (first != second)
                    {
                        if (first > second)
                        {
                            first = first - second;
                        }
                        else
                        {
                            second = second - first;
                        }
                    }

                    return first;
                }

            }

            public double Result
            {
                get { return this.result; }
                private set { this.result = value; }
            }
            private double result;

            public double FractionalNumber(string input)
            {
                this.Result = this.Parse(input);

                return Result;
            }

            private double Parse(string input)
            {
                input = (input ?? string.Empty).Trim();
                if (string.IsNullOrEmpty(input))
                {
                    throw new ArgumentNullException("input");
                }

                // standard decimal number (e.g. 1.125)
                if (input.IndexOf('.') != -1 || (input.IndexOf(' ') == -1 && input.IndexOf('/') == -1 && input.IndexOf('\\') == -1))
                {
                    double result;
                    if (double.TryParse(input, out result))
                    {
                        return result;
                    }
                }

                string[] parts = input.Split(new[] { ' ', '/', '\\' }, StringSplitOptions.RemoveEmptyEntries);

                // stand-off fractional (e.g. 7/8)
                if (input.IndexOf(' ') == -1 && parts.Length == 2)
                {
                    double num, den;
                    if (double.TryParse(parts[0], out num) && double.TryParse(parts[1], out den))
                    {
                        return num / den;
                    }
                }

                // Number and fraction (e.g. 2 1/2)
                if (parts.Length == 3)
                {
                    double whole, num, den;
                    if (double.TryParse(parts[0], out whole) && double.TryParse(parts[1], out num) && double.TryParse(parts[2], out den))
                    {
                        return whole + (num / den);
                    }
                }

                // Bogus / unable to parse
                return double.NaN;
            }
        #endregion
    }
}