using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ToetsendRekenen
{
    public class Breuken
    {
        public string[,] BrArr = new string[101, 101];
        #region Gangbare breuken string
        public string[] Gang100 = new string[101];
        public string[] Gang50 = new string[51];
        public string[] Gang25 = new string[26];
        public string[] Gang20 = new string[21];
        public string[] Gang10 = new string[11];
        public string[] Gang8 = new string[9];
        public string[] Gang5 = new string[6];
        public string[] Gang4 = new string[5];
        public string[] Gang3 = new string[4];
        public string[] Gang2 = new string[3];
        
        #endregion

        public string[,] BreukArray()
        {
            for (int i = 0; i < 101; i++)
            {
                for (int j = 0; j < 101; j++)
                {
                    BrArr[i, j] = i + "/" + j;
                }
            }
            return BrArr;
        }

        public void GangbareBreuken(string[,] Brarr)
        {
            #region 100,50,25 en 20
            //100
            for (int i = 1; i < 101; i++)
            {
                Gang100[i] = BrArr[i, 100];
            }
            //50
            for (int i = 1; i < 51; i++)
            {
                Gang50[i] = BrArr[i, 50];
            }
            //25
            for (int i = 1; i < 26; i++)
            {
                Gang25[i] = BrArr[i, 25];
            }
            //20
            for (int i = 1; i < 21; i++)
            {
                Gang20[i] = BrArr[i, 20];
            }
            #endregion
            #region 10,8,5,4,3 en 2
            //10
            for (int i = 1; i < 11; i++)
            {
                Gang10[i] = BrArr[i, 10];
            }
            //8
            for (int i = 1; i < 9; i++)
            {
                Gang8[i] = BrArr[i, 8];
            }
            //5
            for (int i = 1; i < 6; i++)
            {
                Gang5[i] = BrArr[i, 5];
            }
            //4
            for (int i = 1; i < 5; i++)
            {
                Gang4[i] = BrArr[i, 4];
            }
            //3
            for (int i = 1; i < 4; i++)
            {
                Gang3[i] = BrArr[i, 3];
            }
            //2
            for (int i = 1; i < 3; i++)
            {
                Gang2[i] = BrArr[i, 2];
            }
            #endregion
            #region combine
            
            #endregion
        }

        public void Random()
        {
            Random R = new Random();
            string[] randomgangbarebreuken = new string[Gang100.Length + Gang50.Length + Gang25.Length + Gang20.Length + Gang10.Length + Gang8.Length + Gang5.Length + Gang4.Length + Gang3.Length + Gang2.Length];
            string[] array1 = {  };
            Gang100.CopyTo(randomgangbarebreuken, Gang100.Length);
            var Rgangbarebreuken = Gang100.Concat(Gang50);
            //randomgangbarebreuken.

            var query = from element in Gang100
                        orderby element
                        select element;

            string[] array2 = query.ToArray();
        }
    }
}