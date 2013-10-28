﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ToetsendRekenen
{
    public class Breuken
    {
        string[,] BrArr = new string[101, 101];
        #region Gangbare breuken string
        string[] Gang100 = new string[101];
        string[] Gang50 = new string[51];
        string[] Gang25 = new string[26];
        string[] Gang20 = new string[21];
        string[] Gang10 = new string[11];
        string[] Gang8 = new string[9];
        string[] Gang5 = new string[6];
        string[] Gang4 = new string[5];
        string[] Gang3 = new string[4];
        string[] Gang2 = new string[3];
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
    }
}