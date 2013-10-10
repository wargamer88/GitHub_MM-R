using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Drawing;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Collections;
using MoreLinq;

namespace ToetsendRekenen
{
    public class Supermarkt
    {
        DataToDatabase DD = new DataToDatabase();
        List<String> imagesList = new List<String>();
        public List<Supermarkt> productenFromDBD = new List<Supermarkt>();

        SqlConnection thisConnection = new SqlConnection(@"Server=www.dbss.nl;Database=PVB1314-003;User Id=miromi;
Password=romimi;");

        public int AfbeeldingsID { get; set; }
        public byte[] Afbeelding { get; set; }
        public decimal Supermarktprijs { get; set; }
        public decimal[] price { get; set; }
        public decimal sum { get; set; }
        public string[,] producten { get; set; }
        public string productenlabel { get; set; }
        public int aantal { get; set; }

        public Image ImageFromDBD { get; set; }
        public decimal PriceFromDBD { get; set; }
        public string TagFromDBD { get; set; }
        
        //Methode om naar database te sturen. Handmatig per 1 afbeelding gedaan.
        public void NaarDB()
        {
            thisConnection.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO Afbeelding (Afbeelding) VALUES (@Afbeelding)");
                SqlParameter pm = new SqlParameter();
                Image i = Image.FromFile(imagesList[13]);
                pm.ParameterName = "@Afbeelding";
                pm.Value = DD.ImagetoByteArray(i);
                cmd.Parameters.Add(pm);
                cmd.Connection = thisConnection;
                cmd.ExecuteNonQuery();
        }

        //Methode om de database afbeeldingen uit te lezen en op te slaan.
        public void VanDB()
        {
            thisConnection.Open();
            int TellerDB = 1;
            SqlParameter pm = new SqlParameter();
            pm.ParameterName = "@AfbeeldingID";

            for (int i = 0; i < imagesList.Count-1; i++)
            {
                pm.Value = TellerDB;
                SqlCommand cmd = new SqlCommand("SELECT * FROM Afbeelding WHERE AfbeeldingID = " + TellerDB);

                cmd.Connection = thisConnection;

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    byte[] raw = (byte[])reader["Afbeelding"];
                    var test = DD.ByteArraytoImage(raw);

                    productenFromDBD.Add(new Supermarkt { ImageFromDBD = test, PriceFromDBD = Convert.ToDecimal(reader["Supermarktprijs"]), TagFromDBD = reader["Tag"].ToString() });
                }
                TellerDB++;
                reader.Close();
            }
            //return productenFromDBD;
        }

        //Producten worden ingeladen in een array en prijs word opgehaald en uitgerekend.
        public decimal GetPrice()
        {
            price = new decimal[productenFromDBD.Count];
            int teller = 0;
            foreach (var items in productenFromDBD)
            {
                price[teller] = items.PriceFromDBD;
                sum += price[teller];
                teller++;
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

        //Maakt een random lijstje van de producten.

        //NOTE VOOR MORGEN. ZET OPNIEUW IN EEN LIST AANTALLEN EN STRINGS. DISTINCT DE LIST LATER EN STUUR DAT NA DE PAGINA.
        public string Randomlijst()
        {
            Random R = new Random();
            int teller = 0;
            string[] alleproducten = new string[productenFromDBD.Count];
            List<string> randomlist = new List<string>();

            List<Supermarkt> dist = new List<Supermarkt>();
            List<Supermarkt> distinctlijst = new List<Supermarkt>();

            int C = 0;
            int rc = randomlist.Count;
            int tellerR = 0;
            int tellerRC = 0;
            string[] disttostring = new string[dist.Count];
            

            foreach (var ProdTag in productenFromDBD)
            {
                alleproducten[teller] = ProdTag.TagFromDBD;
                teller++;
            }

            for (int i = 0; i < R.Next(3, C = productenFromDBD.Count); i++)
            {
                string test = alleproducten[R.Next(alleproducten.Length)];
                randomlist.Add(test);
            }

            for (int i = 0; i < randomlist.Count; i++)
            {
                var test = randomlist[tellerR];
                tellerRC = 0;
                aantal = 0;
                for (int j = 0; j < randomlist.Count; j++)
                {
                    //var test1 = randomlist[tellerRC];
                    //if (randomlist[tellerR] == randomlist[tellerRC] && tellerR >= tellerRC)
                    //    {
                    //        aantal++;
                    //        randomlist.Remove(randomlist[tellerRC]);
                    //    }
                    //else if (randomlist[tellerR] == randomlist[tellerRC])
                    //    {
                    //        aantal++;
                    //    }
                    //    else
                    //    { 

                    //    }
                    //    tellerRC++;
                    var test1 = randomlist[tellerRC];
                    if (test == test1)
                    {
                        aantal++;
                    }
                    else
                    {
                    }
                    tellerRC++;
                    dist.Add(new Supermarkt { aantal = aantal, TagFromDBD = test });
                }
                tellerR++;
                //var disttest = dist.Distinct(test == test);
                int tellerd = 0;
                for (int q = 0; q < dist.Count; q++)
                {
                    string distincttostring = dist.ToString();
                    disttostring[tellerd] = distincttostring;
                    tellerd++;
                }
                randomlist.Distinct();
                
                productenlabel += aantal + "x  "+ test + "<br />";
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