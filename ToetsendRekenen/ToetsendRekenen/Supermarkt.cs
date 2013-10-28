using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Collections;
using MoreLinq;
using System.Drawing;

using System.Text;
using System.Threading.Tasks;


namespace ToetsendRekenen
{
    public class Supermarkt
    {
        #region properties
        DataToDatabase DD = new DataToDatabase();
        List<String> imagesList = new List<String>();
        public List<Supermarkt> productenFromDBD = new List<Supermarkt>();
        public List<Supermarkt> dist = new List<Supermarkt>();

        SqlConnection thisConnection = new SqlConnection(@"Server=www.dbss.nl;Database=PVB1314-003;User Id=miromi;
Password=romimi;");

        public int AfbeeldingsID { get; set; }
        public byte[] Afbeelding { get; set; }
        public decimal Supermarktprijs { get; set; }
        public decimal[] price { get; set; }
        public decimal sum { get; set; }
        public string[,] producten { get; set; }
        public string productenlabel { get; set; }
        public string pricelabel { get; set; }
        public int aantal { get; set; }
        public string[] ImageUrl { get; set; }
        public List<string> randomlist = new List<string>();


        public Image ImageFromDBD { get; set; }
        public decimal PriceFromDBD { get; set; }
        public string TagFromDBD { get; set; }
        #endregion

        //Methode om naar database te sturen. Handmatig per 1 afbeelding gedaan.
        public void NaarDB()
        {
            try
            {
                thisConnection.Open();
                int teller = 0;
                String savePath = "C:/Users/Michael/Documents/GitHub/GitHub_MM-R/ToetsendRekenen/ToetsendRekenen/Images/Supermarkt";
                GetImagesPath(savePath);
                for (int i = 0; i < imagesList.Count; i++)
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO Afbeelding (Afbeelding) VALUES (@Afbeelding)");
                    SqlParameter pm = new SqlParameter();
                    Image img = Image.FromFile(imagesList[teller]);
                    pm.ParameterName = "@Afbeelding";
                    pm.Value = DD.ImagetoByteArray(img);
                    cmd.Parameters.Add(pm);
                    cmd.Connection = thisConnection;
                    cmd.ExecuteNonQuery();
                    teller++;
                }
                thisConnection.Close();
            }
            catch (SqlException ex)
            {
                System.Web.HttpContext.Current.Response.Write("<SCRIPT LANGUAGE='JavaScript'>alert('Er kon geen verbinding met de database gemaakt. Probeer het later nog eens.')</SCRIPT>");
            }
        }

        //Methode om de database afbeeldingen uit te lezen en op te slaan.
        public List<Supermarkt> VanDB()
        {
            try
            {
                thisConnection.Open();
                int aantalafbeelding = 0;
                int tagteller = 1;
                Image result = null;
                SqlParameter pm = new SqlParameter();
                pm.ParameterName = "@AfbeeldingID";

                SqlCommand cm = new SqlCommand("SELECT * FROM Afbeelding");
                cm.Connection = thisConnection;

                SqlDataReader readcm = cm.ExecuteReader();
                while (readcm.Read())
                {
                    aantalafbeelding++;
                }
                readcm.Close();
                for (int i = 0; i < aantalafbeelding; i++)
                {
                    ImageUrl = new string[aantalafbeelding];

                    string selectString = "[dbo].[GetImageByImageID]";
                    SqlCommand selectCommand = new SqlCommand(selectString, thisConnection);
                    selectCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    selectCommand.Parameters.AddWithValue("@AfbeeldingID", tagteller);

                    selectCommand.Connection = thisConnection;

                    SqlDataReader reader = selectCommand.ExecuteReader();
                    while (reader.Read())
                    {
                        result = Image.FromStream(new MemoryStream((byte[])reader.GetValue(1)));

                        //if (reader["Supermarktprijs"] == "")
                        //{
                        //    PriceFromDBD = 0;
                        //}
                        if (reader["Tag"] == null)
                        {
                            TagFromDBD = "";
                        }
                        else
                        {
                            productenFromDBD.Add(new Supermarkt { ImageFromDBD = result, PriceFromDBD = Convert.ToDecimal(reader["Supermarktprijs"]), TagFromDBD = reader["Tag"].ToString() });
                        }

                    }
                    tagteller++;
                    reader.Close();
                }
                thisConnection.Close();
            }
            catch
            {
                System.Web.HttpContext.Current.Response.Write("<SCRIPT LANGUAGE='JavaScript'>alert('Er kon geen verbinding met de database gemaakt. Probeer het later nog eens.')</SCRIPT>");
            }
            return productenFromDBD;
        }

        //Producten worden ingeladen vanuit de database en prijs word opgehaald en uitgerekend.
        public decimal GetPrice()
        {
            try
            {
                string currentproduct = "";

                thisConnection.Open();

                for (int i = 0; i < dist.Count; i++)
                {
                    decimal oldsum = 0;
                    foreach (var cpro in dist)
                    {
                        currentproduct = cpro.TagFromDBD;
                        SqlParameter pm = new SqlParameter();
                        SqlCommand cmd = new SqlCommand("SELECT * FROM Afbeelding WHERE Tag = @Tag");
                        pm.ParameterName = "@Tag";
                        pm.Value = currentproduct;
                        cmd.Parameters.Add(pm);

                        cmd.Connection = thisConnection;
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            sum = (decimal)reader["Supermarktprijs"];
                            oldsum = oldsum + sum;
                            sum = oldsum;
                        }
                        reader.Close();
                    }
                }

                thisConnection.Close();
            }
            catch (SqlException ex)
            {
                System.Web.HttpContext.Current.Response.Write("<SCRIPT LANGUAGE='JavaScript'>alert('Er kon geen verbinding met de database gemaakt. Probeer het later nog eens.')</SCRIPT>");
            }
            return sum;
        }

        //Genereert altijd een random aantal producten. Minimaal 5 en maximaal 15 omdat er maar 15 producten zijn in de database.
        //Meer dan 15 is natuurlijk mogelijk bij eht aanpassen van de lus dat aangegeven staat als Max product.
        public string Randomlijst()
        {
            Random R = new Random();
            string[] alleproducten = new string[productenFromDBD.Count];

            int rc = randomlist.Count;
            int teller = 0;
            int tellerR = 0;
            int tellerRC = 0;
            int tellerd = 0;
            

            foreach (var ProdTag in productenFromDBD)
            {
                alleproducten[teller] = ProdTag.TagFromDBD;
                teller++;
            }
            //Max Product.
            for (int i = 0; i < R.Next(3, productenFromDBD.Count); i++)
            {
                string product1 = alleproducten[R.Next(alleproducten.Length)];
                randomlist.Add(product1);
            }

            for (int i = 0; i < randomlist.Count; i++)
            {
                var eersteproduct = randomlist[tellerR];
                tellerRC = 0;
                aantal = 0;
                for (int j = 0; j < randomlist.Count; j++)
                {
                    var controleproduct = randomlist[tellerRC];
                    if (eersteproduct == controleproduct)
                    {
                        aantal++;
                    }
                    else
                    {
                    }
                    tellerRC++;
                    
                }
                
                tellerR++;
                dist.Add(new Supermarkt { aantal = aantal, TagFromDBD = eersteproduct });
            }
            string[] disttostring = new string[dist.Count];
            foreach (var aantal in dist)
	        {
                string distincttostring = aantal.aantal + "x " + aantal.TagFromDBD + "<br />";
                disttostring[tellerd] = distincttostring;
                tellerd = tellerd + 1;
	        }

            IEnumerable<string> productendistinct = disttostring.Distinct();

            foreach (string product in productendistinct)
            {
                productenlabel += product;
            }

            return productenlabel;

        }

       //Methode dat alleen gebruikt word indien en plaatjes vanuit de lokale PC moet worden opgehaald om naar de database te schrijven.
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


        //Methode dat zorgt dat de plaatjes die in de database staan random verschijnen op de pagina. (niet af)
       public Image[] PlaatjesNaarScherm()
       {
           Image[] imglist = new Image[productenFromDBD.Count];
           string[] ImageUrl1 = new string[productenFromDBD.Count];
           int teller = 0;
           foreach (var img in productenFromDBD)
           {
               imglist[teller] = img.ImageFromDBD;
               teller++;
           }

           return imglist;
       }
        //Veranderd de volgorde van een lijst.
       public List<string> Shuffle(List<string> list)
       {
           int upper = 1;
           Random r = new Random();
           for (int i = 0; i < upper; i++)
           {
               int randInd = r.Next(i, list.Count);
               var temp = list[i];
               list[i] = list[randInd];
               list[randInd] = temp;
           }
           return list;
       }
    }
}