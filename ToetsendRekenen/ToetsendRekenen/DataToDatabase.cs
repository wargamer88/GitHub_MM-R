using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Web;
using System.Web.UI.WebControls;

namespace ToetsendRekenen
{
    public class DataToDatabase
    {
        //#region Methodes
        //public Image byteArrayToImage(byte[] byteArrayIn)
        //{
        //    MemoryStream ms = new MemoryStream(byteArrayIn);
        //    Image returnImage = Image.FromStream(ms);
        //    return returnImage;
        //}

        //public Byte[] imageToByteArray(Image imageIn)
        //{
        //    MemoryStream ms = new MemoryStream();
        //    imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
        //    Byte[] test = ms.ToArray();
        //    return test;
        //}
        //#endregion

        public byte[] ImagetoByte(string p_postedImageFileName, string[] p_fileType)
        {
            bool isValidFileType = false;
            FileInfo file = new FileInfo(p_postedImageFileName);

            foreach (string strExtensionType in p_fileType)

            {

                if (strExtensionType == file.Extension)

                {

                    isValidFileType = true;

                    break;

                }

            }

            if (isValidFileType)

            {

                FileStream fs = new FileStream(p_postedImageFileName, FileMode.Open, FileAccess.Read);

                BinaryReader br = new BinaryReader(fs);

                byte[] image = br.ReadBytes((int)fs.Length);

                br.Close();

                fs.Close();

                return image;

            }

            return null;
        }

        public Byte[] ImagetoByteArray(Image Image)
        {
            byte[] bytes;
            IFormatter formatter = new BinaryFormatter();
            using (MemoryStream stream = new MemoryStream())
            {
                formatter.Serialize(stream, Image);
                bytes = stream.ToArray();
            }
            return bytes;
        }

        public Image ByteArraytoImage(Byte[] Bytes)
        {
            IFormatter formatter = new BinaryFormatter();
            using (MemoryStream stream = new MemoryStream(Bytes))
            {
                return (Image)formatter.Deserialize(stream);
               
            }
        }
    }
}