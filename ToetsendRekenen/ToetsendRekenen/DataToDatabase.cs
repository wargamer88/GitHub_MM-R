using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Web;
using System.Drawing;

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