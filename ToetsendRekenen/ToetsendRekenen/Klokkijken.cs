using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ToetsendRekenen
{
    public class Klokkijken
    {
        public int randomtijd(string wijzer, int tijd, int minuten)
        {
            Random rnd = new Random();
            int min = 0;

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
                    min = rnd.Next(0, 12) * 5;

                    if(minuten >52 && minuten <=7)
                    {
                        return min;
                    }
                    else if (minuten > 7 && minuten <= 22)
                    {
                        return min = min + 7;
                    }
                    else if (minuten > 22 && minuten <= 37)
                    {
                        return min = min + 15;
                    }
                    else if (minuten > 37 && minuten <= 52)
                    {
                        return min = min + 23;
                    }

                    return min;

            }
            return min;
            
        }
    }
}