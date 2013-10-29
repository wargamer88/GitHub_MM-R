using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ToetsendRekenen
{
    public class Sommen
    {
        public int VraagGetal1 { get; set; }
        public int VraagGetal2 { get; set; }
        public int Antwoord { get; set; }
        public string CategorieTeken { get; set; }
        public List<string> Vragen { get; set; }

        public void GenerateSommen(string Categorie, string Subcategorie)
        {
            #region +/0-10
            string vraag = "";
            if (Subcategorie == "0-10" && Categorie == "+")
            {
                do
                {
                    Random R = new Random();
                    VraagGetal1 = R.Next(1, 10);
                    VraagGetal2 = R.Next(1, 10);
                    CategorieTeken = "+";
                    vraag = Convert.ToString(VraagGetal1) + Convert.ToString(VraagGetal2);
                }
                while (PreventRepeatingQuestions(vraag, Vragen));
                Vragen.Add(vraag);
                Antwoord = VraagGetal1 + VraagGetal2;
            } 
            #endregion
            #region +/0-100
            else if (Subcategorie == "0-100" && Categorie == "+")
            {
                do
                {
                    Random R = new Random();
                    VraagGetal1 = R.Next(1, 100);
                    VraagGetal2 = R.Next(1, 100);
                    CategorieTeken = "+";
                    vraag = Convert.ToString(VraagGetal1) + Convert.ToString(VraagGetal2);
                }
                while (PreventRepeatingQuestions(vraag, Vragen));
                Vragen.Add(vraag);
                Antwoord = VraagGetal1 + VraagGetal2;
            } 
            #endregion
            #region +/0-1000
            else if (Subcategorie == "0-1000" && Categorie == "+")
            {
                do
                {
                    Random R = new Random();
                    VraagGetal1 = R.Next(100, 1000);
                    VraagGetal2 = R.Next(100, 1000);
                    CategorieTeken = "+";
                    vraag = Convert.ToString(VraagGetal1) + Convert.ToString(VraagGetal2);
                }
                while (PreventRepeatingQuestions(vraag, Vragen));
                Vragen.Add(vraag);
                Antwoord = VraagGetal1 + VraagGetal2;
            } 
            #endregion
            #region -/0-10
            else if (Subcategorie == "0-10" && Categorie == "-")
            {
                do
                {
                    Random R = new Random();
                    VraagGetal1 = R.Next(1, 10);
                    VraagGetal2 = R.Next(1, VraagGetal1);
                    CategorieTeken = "-";
                    vraag = Convert.ToString(VraagGetal1) + Convert.ToString(VraagGetal2);
                }
                while (PreventRepeatingQuestions(vraag, Vragen));
                Vragen.Add(vraag);
                Antwoord = VraagGetal1 - VraagGetal2;
            } 
            #endregion
            #region -/0-100
            else if (Subcategorie == "0-100" && Categorie == "-")
            {
                do
                {
                    Random R = new Random();
                    VraagGetal1 = R.Next(1, 100);
                    VraagGetal2 = R.Next(1, VraagGetal1);
                    CategorieTeken = "-";
                    vraag = Convert.ToString(VraagGetal1) + Convert.ToString(VraagGetal2);
                }
                while (PreventRepeatingQuestions(vraag, Vragen));
                Vragen.Add(vraag);
                Antwoord = VraagGetal1 - VraagGetal2;
            } 
            #endregion
            #region -/0-1000
            else if (Subcategorie == "0-1000" && Categorie == "-")
            {
                do
                {
                    Random R = new Random();
                    VraagGetal1 = R.Next(100, 1000);
                    VraagGetal2 = R.Next(100, VraagGetal1);
                    CategorieTeken = "-";
                    vraag = Convert.ToString(VraagGetal1) + Convert.ToString(VraagGetal2);
                }
                while (PreventRepeatingQuestions(vraag, Vragen));
                Vragen.Add(vraag);
                Antwoord = VraagGetal1 - VraagGetal2;
            } 
            #endregion
            #region x/0-10
            else if (Subcategorie == "0-10" && Categorie == "x")
            {
                do
                {
                    Random R = new Random();
                    VraagGetal1 = R.Next(1, 10);
                    VraagGetal2 = R.Next(1, 10);
                    CategorieTeken = "x";
                    vraag = Convert.ToString(VraagGetal1) + Convert.ToString(VraagGetal2);
                }
                while (PreventRepeatingQuestions(vraag, Vragen));
                Vragen.Add(vraag);
                Antwoord = VraagGetal1 * VraagGetal2;
            } 
            #endregion
            #region x/0-100
            else if (Subcategorie == "0-100" && Categorie == "x")
            {
                do
                {
                    Random R = new Random();
                    VraagGetal1 = R.Next(1, 100);
                    VraagGetal2 = R.Next(1, 100);
                    CategorieTeken = "x";
                    vraag = Convert.ToString(VraagGetal1) + Convert.ToString(VraagGetal2);
                }
                while (PreventRepeatingQuestions(vraag, Vragen));
                Vragen.Add(vraag);
                Antwoord = VraagGetal1 * VraagGetal2;
            } 
            #endregion
            #region x/0-1000
            else if (Subcategorie == "0-1000" && Categorie == "x")
            {
                do
                {
                    Random R = new Random();
                    VraagGetal1 = R.Next(100, 1000);
                    VraagGetal2 = R.Next(100, 1000);
                    CategorieTeken = "x";
                    vraag = Convert.ToString(VraagGetal1) + Convert.ToString(VraagGetal2);
                }
                while (PreventRepeatingQuestions(vraag, Vragen));
                Vragen.Add(vraag);
                Antwoord = VraagGetal1 * VraagGetal2;
            } 
            #endregion
            #region :/0-10
            else if (Subcategorie == "0-10" && Categorie == ":")
            {
                double ControleAntwoord = 0;
                double VraagGetal1test = 0;
                double VraagGetal2test = 0;
                do
                {
                    Random R = new Random();
                    VraagGetal1test = R.Next(1, 10);
                    VraagGetal2test = R.Next(1, Convert.ToInt32(VraagGetal1test));
                    CategorieTeken = ":";

                    vraag = Convert.ToString(VraagGetal1test) + Convert.ToString(VraagGetal2test);
                    ControleAntwoord = VraagGetal1test / VraagGetal2test;
                }
                while ((Math.Floor(ControleAntwoord)) != ControleAntwoord || PreventRepeatingQuestions(vraag, Vragen));
                VraagGetal1 = Convert.ToInt32(VraagGetal1test);
                VraagGetal2 = Convert.ToInt32(VraagGetal2test);
                Antwoord = VraagGetal1 / VraagGetal2;

            } 
            #endregion
            #region :/0-100
            else if (Subcategorie == "0-100" && Categorie == ":")
            {
                double ControleAntwoord = 0;
                double VraagGetal1test = 0;
                double VraagGetal2test = 0;
                do
                {
                    Random R = new Random();
                    VraagGetal1test = R.Next(1, 100);
                    VraagGetal2test = R.Next(1, Convert.ToInt32(VraagGetal1test));
                    CategorieTeken = ":";

                    vraag = Convert.ToString(VraagGetal1test) + Convert.ToString(VraagGetal2test);
                    ControleAntwoord = VraagGetal1test / VraagGetal2test;
                }
                while ((Math.Floor(ControleAntwoord)) != ControleAntwoord || PreventRepeatingQuestions(vraag, Vragen));
                VraagGetal1 = Convert.ToInt32(VraagGetal1test);
                VraagGetal2 = Convert.ToInt32(VraagGetal2test);
                Antwoord = VraagGetal1 / VraagGetal2;
            } 
            #endregion
            #region :/0-1000
            else if (Subcategorie == "0-1000" && Categorie == ":")
            {
                double ControleAntwoord = 0;
                double VraagGetal1test = 0;
                double VraagGetal2test = 0;
                do
                {
                    Random R = new Random();
                    VraagGetal1test = R.Next(100, 1000);
                    VraagGetal2test = R.Next(100, Convert.ToInt32(VraagGetal1test));
                    CategorieTeken = ":";

                    vraag = Convert.ToString(VraagGetal1test) + Convert.ToString(VraagGetal2test);
                    ControleAntwoord = VraagGetal1test / VraagGetal2test;
                }
                while ((Math.Floor(ControleAntwoord)) != ControleAntwoord || PreventRepeatingQuestions(vraag, Vragen));
                VraagGetal1 = Convert.ToInt32(VraagGetal1test);
                VraagGetal2 = Convert.ToInt32(VraagGetal2test);
                Antwoord = VraagGetal1 / VraagGetal2;
            } 
            #endregion
        }

        public bool PreventRepeatingQuestions(string vraag, List<string> vragen)
        {
            if (vragen.Count != 1)
            {
                for (int i = 0; i < vragen.Count; i++)
                {
                    if (vragen[i] == vraag)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

    }
}