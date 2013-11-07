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
        }

        public string RandomBreuk()
        {
            int getal1;
            int getal2;
            bool Bool = false;
            string[] randomelk = new string[10];
            Random R = new Random();
            randomelk[0] = Gang100[R.Next(Gang100.Length)];
            randomelk[1] = Gang50[R.Next(Gang50.Length)];
            randomelk[2] = Gang25[R.Next(Gang25.Length)];
            randomelk[3] = Gang20[R.Next(Gang20.Length)];
            randomelk[4] = Gang10[R.Next(Gang10.Length)];
            randomelk[5] = Gang8[R.Next(Gang8.Length)];
            randomelk[6] = Gang5[R.Next(Gang5.Length)];
            randomelk[7] = Gang4[R.Next(Gang4.Length)];
            randomelk[8] = Gang3[R.Next(Gang3.Length)];
            randomelk[9] = Gang2[R.Next(Gang2.Length)];

            string random = randomelk[R.Next(randomelk.Length)];

            do
            {
                Bool = false;
                if (random == null)
                {
                    random = randomelk[R.Next(randomelk.Length)];
                    Bool = true;
                }
            }
            while (Bool);

            string[] split = random.Split("/".ToArray());

            do
            {
                Bool = false;
                getal1 = Convert.ToInt16(split[0]);
                getal2 = Convert.ToInt16(split[1]);
                if (getal1 == getal2 | random == null)
                {
                    do
                    {
                    random = randomelk[R.Next(randomelk.Length)];
                    if (random == null)
                    {
                        do
                        {
                             random = randomelk[R.Next(randomelk.Length)];
                        }
                        while(random != null);
                        split = random.Split("/".ToArray());
                        getal1 = Convert.ToInt16(split[0]);
                        getal2 = Convert.ToInt16(split[1]);
                    }
                    if (getal1 == getal2)
                    {
                        do
                        {
                             random = randomelk[R.Next(randomelk.Length)];
                        }
                        while(random != null);
                        split = random.Split("/".ToArray());
                        getal1 = Convert.ToInt16(split[0]);
                        getal2 = Convert.ToInt16(split[1]);
                    }
                    Bool = true;
                    } while (true);
                }


            }
            while (Bool);
            return random;
        }

        public decimal RandomAntwoord(string breuk)
        {
            string[] split = breuk.Split("/".ToArray());
            int getal1 = Convert.ToInt16(split[0]);
            int getal2 = Convert.ToInt16(split[1]);
     
            decimal antwoord = (decimal)getal1 / getal2;
            return antwoord;
        }

        public bool PreventRepeatingQuestions(string antwoord, List<string> vragen)
        {
            if (vragen.Count != 1)
            {
                for (int i = 0; i < vragen.Count; i++)
                {
                    if (vragen[i] == antwoord)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public bool LessThan3DecimalPlaces(decimal dec)
        {
            decimal value = dec * 1000;
            return value == Math.Floor(value);
        }

        public string Deelbarebreuken(string breuk)
        {
            string[] split = breuk.Split("/".ToArray());
            int getal1 = Convert.ToInt16(split[0]);
            int getal2 = Convert.ToInt16(split[1]);
            int heelgetal1 = 0;
            int heelgetal2 = 0;
            string breukantwoord = "";
            #region 100,50,25 en 20
            //100
            if (getal2 == 100 || heelgetal2 == 100)
            {
                #region 100
                int modusgetal5 = getal1 % 5;
                int modusgetal4 = getal1 % 4;
                int modusgetal2 = getal1 % 2;
                if (modusgetal5 == 0)
                {
                    heelgetal1 = getal1 / 5;
                    heelgetal2 = getal2 / 5;
                }
                else if (modusgetal4 == 0)
                {
                    heelgetal1 = getal1 / 4;
                    heelgetal2 = getal2 / 4;
                }
                else if (modusgetal2 == 0)
                {
                    heelgetal1 = getal1 / 2;
                    heelgetal2 = getal2 / 2;
                }
                else
                {
                    heelgetal1 = getal1;
                    heelgetal2 = getal2;
                }
                #endregion
            }
            //50
            if (getal2 == 50 || heelgetal2 == 50)
            {
                #region 50
                int modusgetal5 = getal1 % 5;
                int modusgetal2 = getal1 % 2;
                if (modusgetal5 == 0)
                {
                    heelgetal1 = getal1 / 5;
                    heelgetal2 = getal2 / 5;
                }
                else if (modusgetal2 == 0)
                {
                    heelgetal1 = getal1 / 2;
                    heelgetal2 = getal2 / 2;
                }
                else
                {
                    heelgetal1 = getal1;
                    heelgetal2 = getal2;
                }
                #endregion
            }
            //25
            if (getal2 == 25 || heelgetal2 == 25)
            {
                #region 25
                int modusgetal5 = getal1 % 5;
                if (modusgetal5 == 0)
                {
                    heelgetal1 = getal1 / 5;
                    heelgetal2 = getal2 / 5;
                }
                else
                {
                    heelgetal1 = getal1;
                    heelgetal2 = getal2;
                }
                #endregion
            }
            //20
            if (getal2 == 20 || heelgetal2 == 20)
            {
                #region 20
                int modusgetal5 = getal1 % 5;
                int modusgetal4 = getal1 % 4;
                int modusgetal2 = getal1 % 2;
                if (modusgetal5 == 0)
                {
                    heelgetal1 = getal1 / 5;
                    heelgetal2 = getal2 / 5;
                }
                else if (modusgetal4 == 0)
                {
                    heelgetal1 = getal1 / 4;
                    heelgetal2 = getal2 / 4;
                }
                else if (modusgetal2 == 0)
                {
                    heelgetal1 = getal1 / 2;
                    heelgetal2 = getal2 / 2;
                }
                else
                {
                    heelgetal1 = getal1;
                    heelgetal2 = getal2;
                }
                #endregion
            }
            #endregion
            #region 10,8,5,4,3 en 2
            //10
            if (getal2 == 10 || heelgetal2 == 10)
            {
                #region 10
                int modusgetal5 = getal1 % 5;
                int modusgetal2 = getal1 % 2;
                if (modusgetal5 == 0)
                {
                    heelgetal1 = getal1 / 5;
                    heelgetal2 = getal2 / 5;
                }
                else if (modusgetal2 == 0)
                {
                    heelgetal1 = getal1 / 2;
                    heelgetal2 = getal2 / 2;
                }
                else
                {
                    heelgetal1 = getal1;
                    heelgetal2 = getal2;
                }
                #endregion
            }
            //8
            if (getal2 == 8 || heelgetal2 == 8)
            {
                #region 8
                int modusgetal8 = getal1 % 8;
                int modusgetal4 = getal1 % 4;
                int modusgetal2 = getal1 % 2;
                if (modusgetal8 == 0)
                {
                    heelgetal1 = getal1 / 8;
                    heelgetal2 = getal2 / 8;
                }
                else if (modusgetal4 == 0)
                {
                    heelgetal1 = getal1 / 4;
                    heelgetal2 = getal2 / 4;
                }
                else if (modusgetal2 == 0)
                {
                    heelgetal1 = getal1 / 2;
                    heelgetal2 = getal2 / 2;
                }
                else
                {
                    heelgetal1 = getal1;
                    heelgetal2 = getal2;
                }
                #endregion
            }
            //5
            if (getal2 == 5 || heelgetal2 == 5)
            {
                #region 5
                int modusgetal5 = getal1 % 5;
                if (modusgetal5 == 0)
                {
                    heelgetal1 = getal1 / 5;
                    heelgetal2 = getal2 / 5;
                }
                else
                {
                    heelgetal1 = getal1;
                    heelgetal2 = getal2;
                }
                #endregion
            }
            //4
            if (getal2 == 4 || heelgetal2 == 4)
            {
                #region 4
                int modusgetal4 = getal1 % 4;
                int modusgetal2 = getal1 % 2;
                if (modusgetal4 == 0)
                {
                    heelgetal1 = getal1 / 4;
                    heelgetal2 = getal2 / 4;
                }
                else if (modusgetal2 == 0)
                {
                    heelgetal1 = getal1 / 2;
                    heelgetal2 = getal2 / 2;
                }
                else
                {
                    heelgetal1 = getal1;
                    heelgetal2 = getal2;
                }
                #endregion
            }
            //3
            if (getal2 == 3 || heelgetal2 == 3)
            {
                #region 3
                int modusgetal3 = getal1 % 3;
                if (modusgetal3 == 0)
                {
                    heelgetal1 = getal1 / 3;
                    heelgetal2 = getal2 / 3;
                }
                else
                {
                    heelgetal1 = getal1;
                    heelgetal2 = getal2;
                }
                #endregion
            }
            //2
            if (getal2 == 2 || heelgetal2 == 2)
            {
                #region 2
                int modusgetal2 = getal1 % 2;
                if (modusgetal2 == 0)
                {
                    heelgetal1 = getal1 / 2;
                    heelgetal2 = getal2 / 2;
                }
                else
                {
                    heelgetal1 = getal1;
                    heelgetal2 = getal2;
                }
                #endregion
            }
            #endregion

            breukantwoord = heelgetal1 + "/" + heelgetal2;

            return breukantwoord;
        }
    }
}