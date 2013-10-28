using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ToetsendRekenen
{
    public class Klokkijken
    {

        Random rnd = new Random();
        string[] minutenUitgeschreven = new string[] { "één", "twee", "drie", "vier", "vijf", "zes", "zeven", "acht", "negen", "tien", "elf", "twaalf", "dertien", "viertien" };
        string[] urenUitgeschreven = new string[] { "twaalf", "één", "twee", "drie", "vier", "vijf", "zes", "zeven", "acht", "negen", "tien", "elf", "twaalf", "één", "twee", "drie", "vier", "vijf", "zes", "zeven", "acht", "negen", "tien", "elf", "twaalf" };

        public int randomHour()
        {
            int hours;
            hours = rnd.Next(0, 24);
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

                    if(minuten >52 | minuten <=7)
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

        public string answerCheckAnaloogNaarDigitaal(string givenAnswer, string goodAnswer)
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

        public string answerCheckAnaloog(string givenAnswer, string goodAnswer)
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

        public string timeLengthCheck(int time)
        {
            string stringTime = time.ToString();
            if (stringTime.Length == 1)
            {
                stringTime = "0" + stringTime;
            }

            return stringTime;
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

        public string uitgeschrevenAntwoordMaken(int Uren, int minuten)
        {
            string antwoord = "";
            int uren = Uren;
            
            switch (minuten)
            {
                case 0: antwoord = urenUitgeschreven[uren] + " uur"; break;
                case 1: antwoord = minutenUitgeschreven[0] + " minuut over " + urenUitgeschreven[uren] + " uur"; break;
                case 2: antwoord = minutenUitgeschreven[1] + " minuten over " + urenUitgeschreven[uren] + " uur"; break;
                case 3: antwoord = minutenUitgeschreven[2] + " minuten over " + urenUitgeschreven[uren] + " uur"; break;
                case 4: antwoord = minutenUitgeschreven[3] + " minuten over " + urenUitgeschreven[uren] + " uur"; break;
                case 5: antwoord = minutenUitgeschreven[4] + " minuten over " + urenUitgeschreven[uren] + " uur"; break;
                case 6: antwoord = minutenUitgeschreven[5] + " minuten over " + urenUitgeschreven[uren] + " uur"; break;
                case 7: antwoord = minutenUitgeschreven[6] + " minuten over " + urenUitgeschreven[uren] + " uur"; break;
                case 8: antwoord = minutenUitgeschreven[7] + " minuten over " + urenUitgeschreven[uren] + " uur"; break;
                case 9: antwoord = minutenUitgeschreven[8] + " minuten over " + urenUitgeschreven[uren] + " uur"; break;
                case 10: antwoord = minutenUitgeschreven[9] + " minuten over " + urenUitgeschreven[uren] + " uur"; break;
                case 11: antwoord = minutenUitgeschreven[10] + " minuten over " + urenUitgeschreven[uren] + " uur"; break;
                case 12: antwoord = minutenUitgeschreven[11] + " minuten over " + urenUitgeschreven[uren] + " uur"; break;
                case 13: antwoord = minutenUitgeschreven[12] + " minuten over " + urenUitgeschreven[uren] + " uur"; break;
                case 14: antwoord = minutenUitgeschreven[13] + " minuten over " + urenUitgeschreven[uren] + " uur"; break;
                case 15: antwoord = "kwart over " + urenUitgeschreven[uren]; break;
                case 16: antwoord = minutenUitgeschreven[13] + " minuten voor half " + urenUitgeschreven[uren + 1]; break;
                case 17: antwoord = minutenUitgeschreven[12] + " minuten voor half " + urenUitgeschreven[uren + 1]; break;
                case 18: antwoord = minutenUitgeschreven[11] + " minuten voor half " + urenUitgeschreven[uren + 1]; break;
                case 19: antwoord = minutenUitgeschreven[10] + " minuten voor half " + urenUitgeschreven[uren + 1]; break;
                case 20: antwoord = minutenUitgeschreven[9] + " minuten voor half " + urenUitgeschreven[uren + 1]; break;
                case 21: antwoord = minutenUitgeschreven[8] + " minuten voor half " + urenUitgeschreven[uren + 1]; break;
                case 22: antwoord = minutenUitgeschreven[7] + " minuten voor half " + urenUitgeschreven[uren + 1]; break;
                case 23: antwoord = minutenUitgeschreven[6] + " minuten voor half " + urenUitgeschreven[uren + 1]; break;
                case 24: antwoord = minutenUitgeschreven[5] + " minuten voor half " + urenUitgeschreven[uren + 1]; break;
                case 25: antwoord = minutenUitgeschreven[4] + " minuten voor half " + urenUitgeschreven[uren + 1]; break;
                case 26: antwoord = minutenUitgeschreven[3] + " minuten voor half " + urenUitgeschreven[uren + 1]; break;
                case 27: antwoord = minutenUitgeschreven[2] + " minuten voor half " + urenUitgeschreven[uren + 1]; break;
                case 28: antwoord = minutenUitgeschreven[1] + " minuten voor half " + urenUitgeschreven[uren + 1]; break;
                case 29: antwoord = minutenUitgeschreven[0] + " minuut voor half " + urenUitgeschreven[uren + 1]; break;
                case 30: antwoord = "half " + urenUitgeschreven[uren + 1]; break;
                case 31: antwoord = minutenUitgeschreven[0] + " minuut over half " + urenUitgeschreven[uren + 1]; break;
                case 32: antwoord = minutenUitgeschreven[1] + " minuten over half " + urenUitgeschreven[uren + 1]; break;
                case 33: antwoord = minutenUitgeschreven[2] + " minuten over half " + urenUitgeschreven[uren + 1]; break;
                case 34: antwoord = minutenUitgeschreven[3] + " minuten over half " + urenUitgeschreven[uren + 1]; break;
                case 35: antwoord = minutenUitgeschreven[4] + " minuten over half " + urenUitgeschreven[uren + 1]; break;
                case 36: antwoord = minutenUitgeschreven[5] + " minuten over half " + urenUitgeschreven[uren + 1]; break;
                case 37: antwoord = minutenUitgeschreven[6] + " minuten over half " + urenUitgeschreven[uren + 1]; break;
                case 38: antwoord = minutenUitgeschreven[7] + " minuten over half " + urenUitgeschreven[uren + 1]; break;
                case 39: antwoord = minutenUitgeschreven[8] + " minuten over half " + urenUitgeschreven[uren + 1]; break;
                case 40: antwoord = minutenUitgeschreven[9] + " minuten over half " + urenUitgeschreven[uren + 1]; break;
                case 41: antwoord = minutenUitgeschreven[10] + " minuten over half " + urenUitgeschreven[uren + 1]; break;
                case 42: antwoord = minutenUitgeschreven[11] + " minuten over half " + urenUitgeschreven[uren + 1]; break;
                case 43: antwoord = minutenUitgeschreven[12] + " minuten over half " + urenUitgeschreven[uren + 1]; break;
                case 44: antwoord = minutenUitgeschreven[13] + " minuten over half " + urenUitgeschreven[uren + 1]; break;
                case 45: antwoord = "kwart voor " + urenUitgeschreven[uren + 1]; break;
                case 46: antwoord = minutenUitgeschreven[13] + " minuten voor " + urenUitgeschreven[uren + 1] + " uur"; break;
                case 47: antwoord = minutenUitgeschreven[12] + " minuten voor " + urenUitgeschreven[uren + 1] + " uur"; break;
                case 48: antwoord = minutenUitgeschreven[11] + " minuten voor " + urenUitgeschreven[uren + 1] + " uur"; break;
                case 49: antwoord = minutenUitgeschreven[10] + " minuten voor " + urenUitgeschreven[uren + 1] + " uur"; break;
                case 50: antwoord = minutenUitgeschreven[9] + " minuten voor " + urenUitgeschreven[uren + 1] + " uur"; break;
                case 51: antwoord = minutenUitgeschreven[8] + " minuten voor " + urenUitgeschreven[uren + 1] + " uur"; break;
                case 52: antwoord = minutenUitgeschreven[7] + " minuten voor " + urenUitgeschreven[uren + 1] + " uur"; break;
                case 53: antwoord = minutenUitgeschreven[6] + " minuten voor " + urenUitgeschreven[uren + 1] + " uur"; break;
                case 54: antwoord = minutenUitgeschreven[5] + " minuten voor " + urenUitgeschreven[uren + 1] + " uur"; break;
                case 55: antwoord = minutenUitgeschreven[4] + " minuten voor " + urenUitgeschreven[uren + 1] + " uur"; break;
                case 56: antwoord = minutenUitgeschreven[3] + " minuten voor " + urenUitgeschreven[uren + 1] + " uur"; break;
                case 57: antwoord = minutenUitgeschreven[2] + " minuten voor " + urenUitgeschreven[uren + 1] + " uur"; break;
                case 58: antwoord = minutenUitgeschreven[1] + " minuten voor " + urenUitgeschreven[uren + 1] + " uur"; break;
                case 59: antwoord = minutenUitgeschreven[0] + " minuut voor " + urenUitgeschreven[uren + 1] + " uur"; break;
            }

            if (Uren <= 5)
            {
                antwoord += " 's nachts";
            }
            else if (Uren <= 11)
            {
                antwoord += " 's ochtends";
            }
            else if (Uren <= 17)
            {
                antwoord += " 's middags";
            }
            else if (Uren <= 23)
            {
                antwoord += " 's avonds";
            }
            

            return antwoord;
        }

    }
}