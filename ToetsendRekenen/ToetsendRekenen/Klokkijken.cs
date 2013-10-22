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

        public string uitgeschrevenAntwoordMaken(int uren, int minuten)
        {
            string antwoord = "";

            if (uren >= 13)
            {
                uren = uren - 12;
            }
            

            if (uren == 0)
            {
                uren = 12;
            }

            if (minuten == 0)
            {
                antwoord = getallenUitgeschreven[uren - 1] + " uur";
            }
            else if (minuten == 15)
            {
                antwoord = "Kwart over " + getallenUitgeschreven[uren - 1];
            }
            else if (minuten == 30)
            {
                antwoord = "Half " + getallenUitgeschreven[uren];
            }
            else if (minuten == 45)
            {
                antwoord = "Kwart voor " + getallenUitgeschreven[uren];
            }

            return antwoord;
        }

    }
}