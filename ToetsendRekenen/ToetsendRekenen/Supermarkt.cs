﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;
using System.IO;

namespace ToetsendRekenen
{
    public class Supermarkt
    {
        DataToDatabase DD = new DataToDatabase();

        public int AfbeeldingsID { get; set; }
        public byte[] Afbeelding { get; set; }
        public decimal Supermarktprijs { get; set; }
        public decimal[] price { get; set; }
        public decimal sum { get; set; }
        public string[,] producten { get; set; }
        public string productenlabel { get; set; }

        //Producten worden ingeladen in een array en prijs word opgehaald en uitgerekend.
        public decimal GetPrice()
        {
            producten = new string[,] { { "Appels", "2,69" }, { "Bananen", "2,19" }, { "Melk", "0,83" }, { "Pruimen", "1,41" }, { "Manderijnen", "1,55" }, { "Appelsap", "1,06" }, { "Chocola", "1,87" }, { "Eieren", "1,29" }, { "Peren", "1,69" }, { "Koekjes", "0,81" }, { "Rode Bieten", "1,13" }, { "Blik groente", "1,39" }, { "Thee", "0,93" }, { "Ananas", "1,99" }, { "Frisdrank", "0,39" } };
            price = new decimal[producten.Length / 2];
            int teller = 0;
            for (int arr = 0; arr < producten.Length / 2; arr++)
            {
                int j = 1;
                var test = producten[arr, j];
                decimal test1 = Convert.ToDecimal(test);
                price[teller] = test1;
                teller++;
                sum += price[arr];
            }
            return sum;
        }
        //Hieronder word de lijst met producten gemaakt. Dit word later in een methode gezet van deze pagina.
        public string GetProductsList(string[,] Productenlijst)
        {
            for (int arr = 0; arr < producten.Length / 2; arr++)
            {
                int j = 0;
                var test = producten[arr, j];
                productenlabel += test + "<br />";
            }
            return productenlabel;
        }
        //public string Randomlijst(string[,] producten)
        //{
        //    Random R = new Random();
        //    int teller = 0;
        //    string[] alleproducten;
        //    for (int arr = 0; arr < producten.Length / 2; arr++)
        //    {
        //        int j = 0;
        //        arr = R.Next(producten.Length / 2);
        //        alleproducten = new string[arr];
        //        var perproduct = producten[arr, j];
        //        alleproducten[teller] = perproduct;
        //        if (teller != producten.Length / 2)
        //        {
        //            teller++;
        //        }
        //        else { }
        //        // productenlabel += test + "<br />";

        //    }
        //    return productenlabel;
            
        //}

       
       public List<String> GetImagesPath(String folderName)
        {

            DirectoryInfo Folder;
            FileInfo[] Images;

            Folder = new DirectoryInfo(folderName);
            Images = Folder.GetFiles();
            List<String> imagesList = new List<String>();

            for (int i = 0; i < Images.Length; i++)
            {
                imagesList.Add(String.Format(@"{0}/{1}", folderName, Images[i].Name));
            }


            return imagesList;
        }
        
    }
}