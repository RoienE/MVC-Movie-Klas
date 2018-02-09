using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
// 02/08/2018 || 09/02/2018
namespace MvcMovie.Library
{
    public class MyUtilities
    {
        public const String MY_COOKIE = "mc09022018a";

        public const String SW_CalcAnderePagina_Resultaat = "sw08/02/2018A";
    
        public const int STANDAARD_WAARDE_KLEINSTE_GETAL = 0, STANDAARDE_WAARDE_GROOTSTE_GETAL = 1;

        public static int RenderGetal()
        {
            return RenderGetal(STANDAARD_WAARDE_KLEINSTE_GETAL, STANDAARDE_WAARDE_GROOTSTE_GETAL);
        }

        public static int RenderGetal(int kleinsteWaarde, int grootsteWaarde)
        {
            int kRetourWaarde = 123456798, kleinsteWaardeHulp;

            if(kleinsteWaarde < grootsteWaarde)
            {
                
            }
            else
            {
                kleinsteWaardeHulp = grootsteWaarde;
                grootsteWaarde = kleinsteWaarde;
                kleinsteWaarde = kleinsteWaardeHulp;
            }
            
            Random rand = new Random();
            kRetourWaarde = rand.Next(kleinsteWaarde, grootsteWaarde);

            return kRetourWaarde; 
        }

        public static Color RenderRandomColor()
        {
            Color kRetourWaarde = Color.FromArgb(RenderGetal(0, 255), RenderGetal(0, 255), RenderGetal(0, 255));

            return kRetourWaarde;
        }

        public static String RenderIntAlsHex(int pWaarde)
        {
            return pWaarde.ToString("X");
        }

        public static String RenderColorAlsHex(Color pColor)
        {
            // OPGELET: niet echt *zuiver*
            int kDrempelwaarde = 150;

            return RenderIntAlsHex(pColor.R < kDrempelwaarde ? kDrempelwaarde:pColor.R) + 
                RenderIntAlsHex(pColor.G < kDrempelwaarde ? kDrempelwaarde:pColor.G) + 
                RenderIntAlsHex(pColor.B < kDrempelwaarde ? kDrempelwaarde:pColor.B);
        }
    }
}
