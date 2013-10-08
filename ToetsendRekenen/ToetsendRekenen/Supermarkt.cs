using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Drawing;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Collections;

namespace ToetsendRekenen
{
    public class Supermarkt
    {
        DataToDatabase DD = new DataToDatabase();
        List<String> imagesList = new List<String>();

        SqlConnection thisConnection = new SqlConnection(@"Server=www.dbss.nl;Database=PVB1314-003;User Id=miromi;
Password=romimi;");

        public int AfbeeldingsID { get; set; }
        public byte[] Afbeelding { get; set; }
        public decimal Supermarktprijs { get; set; }
        public decimal[] price { get; set; }
        public decimal sum { get; set; }
        public string[,] producten { get; set; }
        public string productenlabel { get; set; }
        
        //Methode om naar database te sturen
        public void NaarDB()
        {
            thisConnection.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO Afbeelding (Afbeelding) VALUES (@Afbeelding)");
            foreach (var img in imagesList)
            {
                Image i = Image.FromFile(img);
                var test = DD.ImagetoByteArray(i);
                cmd.Parameters.AddWithValue("@Afbeelding", test);
                cmd.Connection = thisConnection;
                cmd.ExecuteNonQuery();
            }
            
        }


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

        //Maakt een random lijstje van de producten
        public string Randomlijst(string[,] producten)
        {
            Random R = new Random();
            int teller = 0;
            string[] alleproducten = new string[producten.Length/2];
            ArrayList randomlist = new ArrayList();
            int C = 0;
            int rc = randomlist.Count;
            int tellerR = 0;

            for (int arr = 0; arr < producten.Length / 2; arr++)
            {
                int j = 0;
                //alleproducten = new string[arr];
                var perproduct = producten[arr, j];
                alleproducten[teller] = perproduct;
                teller++;
                
            }

            for (int i = 0; i < R.Next(0, C = Convert.ToInt16(producten.Length /1.5)); i++)
            {
                string test = alleproducten[R.Next(alleproducten.Length)];
                randomlist.Add(test);
                    productenlabel += test + "<br />";
            }

            for (int i = 0; i < randomlist.Count; i++)
            {
                var test = randomlist[tellerR];
                for (int j = 0; j < randomlist.Count; j++)
                {
                    var test1 = randomlist[tellerR];
                }
                tellerR++;
            }
            
            return productenlabel;

        }

       
       public List<String> GetImagesPath(String folderName)
        {

            DirectoryInfo Folder;
            FileInfo[] Images;

            Folder = new DirectoryInfo(folderName);
            Images = Folder.GetFiles();

            for (int i = 0; i < Images.Length; i++)
            {
                imagesList.Add(String.Format(@"{0}/{1}", folderName, Images[i].Name));
            }


            return imagesList;
        }

       public void PlaatjeNaarDatabase()
       {
           
           foreach (var img in imagesList)
           {
               Image i = Image.FromFile(img);
           }
       }
       public string PlaatjesNaarScherm()
       {
           string plaatjestekst = "";
           int teller = 0;
           for (int i = 0; i < imagesList.Count; i++)
           {
               plaatjestekst = "<img src='C:/Users/Michael/Documents/GitHub/GitHub_MM-R/ToetsendRekenen/ToetsendRekenen/Images/Supermarkt/pop-can-clip-art.jpg' />";
           }
           return plaatjestekst;
       }
    }
}