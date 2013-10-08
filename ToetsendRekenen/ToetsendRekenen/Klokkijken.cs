﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ToetsendRekenen
{
    public class Klokkijken
    {

        Random rnd = new Random();

        public int randomHour()
        {
            int hours;
            hours = rnd.Next(0, 12);
            return hours;
        }

        public double randomtijd(string wijzer, int tijd, double minuten, int hours)
        {
            
            double min = 0;
            double urenGrades;

            switch (wijzer)
            {
                case "langeWijzer" :
                    switch (tijd)
                    {
                        case 15:
                            min = rnd.Next(0,4) * 15;
                            return min;
                        case 10:
                            min = rnd.Next(0,6) * 10;
                            return min;
                        case 5:
                            min = rnd.Next(0,12) * 5;
                            return min;
                        case 1:
                            min = rnd.Next(0,60);
                            return min;
                    }
                    break;
                case "korteWijzer":
                    urenGrades = hours * 5;

                    if(minuten >52 && minuten <=7)
                    {
                        return urenGrades;
                    }
                    else if (minuten > 7 && minuten <= 22)
                    {
                        return urenGrades += 1.25;
                    }
                    else if (minuten > 22 && minuten <= 37)
                    {
                        return urenGrades += 2.5;
                    }
                    else if (minuten > 37 && minuten <= 52)
                    {
                        return urenGrades += 3.75;
                    }

                    return min;

            }
            return min;
            
        }

        public string answerCheck(string givenAnswer, string goodAnswer)
        {
            if (givenAnswer == goodAnswer)
            {
                return "Dit andwoord is goed";
            }
            else
            {
                return "Dit antwoord is fout";
            }

        }
    }
}