using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ToetsendRekenen
{
    public class Klokkijken
    {

        Random rnd = new Random();
        string[] getallenUitgeschreven = new string[]{"één", "twee", "drie", "vier", "vijf", "zes", "zeven", "acht", "negen", "tien", "elf", "twaalf", "dertien", "viertien"};

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
            int uren;

            if (Uren >= 13)
            {
                uren = Uren - 12;
            }
            else if (Uren == 0)
            {
                uren = 12;
            }
            else
            {
                uren = Uren;
            }

            switch (minuten)
            {
                case 0: antwoord = getallenUitgeschreven[uren - 1] + " uur"; break;
                case 1: antwoord = getallenUitgeschreven[0] + " minuut over " + getallenUitgeschreven[uren - 1] + " uur"; break;
                case 2: antwoord = getallenUitgeschreven[1] + " minuten over " + getallenUitgeschreven[uren - 1] + " uur"; break;
                case 3: antwoord = getallenUitgeschreven[2] + " minuten over " + getallenUitgeschreven[uren - 1] + " uur"; break;
                case 4: antwoord = getallenUitgeschreven[3] + " minuten over " + getallenUitgeschreven[uren - 1] + " uur"; break;
                case 5: antwoord = getallenUitgeschreven[4] + " minuten over " + getallenUitgeschreven[uren - 1] + " uur"; break;
                case 6: antwoord = getallenUitgeschreven[5] + " minuten over " + getallenUitgeschreven[uren - 1] + " uur"; break;
                case 7: antwoord = getallenUitgeschreven[6] + " minuten over " + getallenUitgeschreven[uren - 1] + " uur"; break;
                case 8: antwoord = getallenUitgeschreven[7] + " minuten over " + getallenUitgeschreven[uren - 1] + " uur"; break;
                case 9: antwoord = getallenUitgeschreven[8] + " minuten over " + getallenUitgeschreven[uren - 1] + " uur"; break;
                case 10: antwoord = getallenUitgeschreven[9] + " minuten over " + getallenUitgeschreven[uren - 1] + " uur"; break;
                case 11: antwoord = getallenUitgeschreven[10] + " minuten over " + getallenUitgeschreven[uren - 1] + " uur"; break;
                case 12: antwoord = getallenUitgeschreven[11] + " minuten over " + getallenUitgeschreven[uren - 1] + " uur"; break;
                case 13: antwoord = getallenUitgeschreven[12] + " minuten over " + getallenUitgeschreven[uren - 1] + " uur"; break;
                case 14: antwoord = getallenUitgeschreven[13] + " minuten over " + getallenUitgeschreven[uren - 1] + " uur"; break;
                case 15: antwoord = "kwart over " + getallenUitgeschreven[uren - 1]; break;
                case 16: antwoord = getallenUitgeschreven[13] + " minuten voor half " + getallenUitgeschreven[uren]; break;
                case 17: antwoord = getallenUitgeschreven[12] + " minuten voor half " + getallenUitgeschreven[uren]; break;
                case 18: antwoord = getallenUitgeschreven[11] + " minuten voor half " + getallenUitgeschreven[uren]; break;
                case 19: antwoord = getallenUitgeschreven[10] + " minuten voor half " + getallenUitgeschreven[uren]; break;
                case 20: antwoord = getallenUitgeschreven[9] + " minuten voor half " + getallenUitgeschreven[uren]; break;
                case 21: antwoord = getallenUitgeschreven[8] + " minuten voor half " + getallenUitgeschreven[uren]; break;
                case 22: antwoord = getallenUitgeschreven[7] + " minuten voor half " + getallenUitgeschreven[uren]; break;
                case 23: antwoord = getallenUitgeschreven[6] + " minuten voor half " + getallenUitgeschreven[uren]; break;
                case 24: antwoord = getallenUitgeschreven[5] + " minuten voor half " + getallenUitgeschreven[uren]; break;
                case 25: antwoord = getallenUitgeschreven[4] + " minuten voor half " + getallenUitgeschreven[uren]; break;
                case 26: antwoord = getallenUitgeschreven[3] + " minuten voor half " + getallenUitgeschreven[uren]; break;
                case 27: antwoord = getallenUitgeschreven[2] + " minuten voor half " + getallenUitgeschreven[uren]; break;
                case 28: antwoord = getallenUitgeschreven[1] + " minuten voor half " + getallenUitgeschreven[uren]; break;
                case 29: antwoord = getallenUitgeschreven[0] + " minuten voor half " + getallenUitgeschreven[uren]; break;
                case 30: antwoord = "half " + getallenUitgeschreven[uren]; break;
                case 31: antwoord = getallenUitgeschreven[0] + " minuten over half " + getallenUitgeschreven[uren]; break;
                case 32: antwoord = getallenUitgeschreven[1] + " minuten over half " + getallenUitgeschreven[uren]; break;
                case 33: antwoord = getallenUitgeschreven[2] + " minuten over half " + getallenUitgeschreven[uren]; break;
                case 34: antwoord = getallenUitgeschreven[3] + " minuten over half " + getallenUitgeschreven[uren]; break;
                case 35: antwoord = getallenUitgeschreven[4] + " minuten over half " + getallenUitgeschreven[uren]; break;
                case 36: antwoord = getallenUitgeschreven[5] + " minuten over half " + getallenUitgeschreven[uren]; break;
                case 37: antwoord = getallenUitgeschreven[6] + " minuten over half " + getallenUitgeschreven[uren]; break;
                case 38: antwoord = getallenUitgeschreven[7] + " minuten over half " + getallenUitgeschreven[uren]; break;
                case 39: antwoord = getallenUitgeschreven[8] + " minuten over half " + getallenUitgeschreven[uren]; break;
                case 40: antwoord = getallenUitgeschreven[9] + " minuten over half " + getallenUitgeschreven[uren]; break;
                case 41: antwoord = getallenUitgeschreven[10] + " minuten over half " + getallenUitgeschreven[uren]; break;
                case 42: antwoord = getallenUitgeschreven[11] + " minuten over half " + getallenUitgeschreven[uren]; break;
                case 43: antwoord = getallenUitgeschreven[12] + " minuten over half " + getallenUitgeschreven[uren]; break;
                case 44: antwoord = getallenUitgeschreven[13] + " minuten over half " + getallenUitgeschreven[uren]; break;
                case 45: antwoord = "kwart voor " + getallenUitgeschreven[uren]; break;
                case 46: antwoord = getallenUitgeschreven[13] + " minuten voor " + getallenUitgeschreven[uren] + " uur"; break;
                case 47: antwoord = getallenUitgeschreven[12] + " minuten voor " + getallenUitgeschreven[uren] + " uur"; break;
                case 48: antwoord = getallenUitgeschreven[11] + " minuten voor " + getallenUitgeschreven[uren] + " uur"; break;
                case 49: antwoord = getallenUitgeschreven[10] + " minuten voor " + getallenUitgeschreven[uren] + " uur"; break;
                case 50: antwoord = getallenUitgeschreven[9] + " minuten voor " + getallenUitgeschreven[uren] + " uur"; break;
                case 51: antwoord = getallenUitgeschreven[8] + " minuten voor " + getallenUitgeschreven[uren] + " uur"; break;
                case 52: antwoord = getallenUitgeschreven[7] + " minuten voor " + getallenUitgeschreven[uren] + " uur"; break;
                case 53: antwoord = getallenUitgeschreven[6] + " minuten voor " + getallenUitgeschreven[uren] + " uur"; break;
                case 54: antwoord = getallenUitgeschreven[5] + " minuten voor " + getallenUitgeschreven[uren] + " uur"; break;
                case 55: antwoord = getallenUitgeschreven[4] + " minuten voor " + getallenUitgeschreven[uren] + " uur"; break;
                case 56: antwoord = getallenUitgeschreven[3] + " minuten voor " + getallenUitgeschreven[uren] + " uur"; break;
                case 57: antwoord = getallenUitgeschreven[2] + " minuten voor " + getallenUitgeschreven[uren] + " uur"; break;
                case 58: antwoord = getallenUitgeschreven[1] + " minuten voor " + getallenUitgeschreven[uren] + " uur"; break;
                case 59: antwoord = getallenUitgeschreven[0] + " minuten voor " + getallenUitgeschreven[uren] + " uur"; break;
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