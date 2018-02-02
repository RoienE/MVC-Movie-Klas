using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// *25/01/2018
// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MvcMovie.Controllers
{
    public class HelloWorldController : Controller
    {
        /**/
        // GET: /<controller>/
        public IActionResult Index(String pNaam = "Jos", int pAantalKeer = 5)
        {
            ViewData["Name"] = pNaam;
            ViewData["AmountOfTimes"] = pAantalKeer;
            return View();
        }
        /**/

        //public String Index(String pNaam = "Jos", int pAantalKeer = 5)
        //{
        //    //return "Hello, World!";         //"<html><center><h1>Hallo, Wereld!</h1></center></html>";  GEEN HTML IN RETURN

        //    return HtmlEncoder.Default.Encode($"Hello {pNaam}, World! Aantal keer: {pAantalKeer}.");
        //}

        //public String Welcome()
        //{
        //    return "Dit is mijn eigen welkomstwoordje! ;-)";
        //}

        public String MijnSom(int pGetal1 = 1, int pGetal2 = 2)
        {
            int som = pGetal1 + pGetal2;
            return "De som van deze getallen is: " + som;
        }

        public IActionResult Welcome()
        {
            return View();
        }

        public IActionResult DoeBewerking() // gegevens naar server sturen en afhalen via HttpRequest en bewerking uitvoeren
        {
            // Console.Beep();

            String kGetal01 = HttpContext.Request.Form["txbGetal01"].ToString(), kGetal02 = HttpContext.Request.Form["txbGetal02"].ToString();
            // Debug.WriteLine("\n\n\n\t" + kGetal01 + "\n\t" + kGetal02 + "\n\n\n");

            String kResult = "=Result=";
            int getal01 = 123456, getal02 = 987654;
            try
            {
                getal01 = int.Parse(kGetal01);
                getal02 = int.Parse(kGetal02);
                kResult = (getal01 + getal02).ToString();


            }
            catch (Exception exc)
            {
                kResult = "Fout, kijk na.. (" + exc.Message + ")";
                Debug.WriteLine("HelloWorld@02/02/2018_r46; " + exc.StackTrace + " .");
            }

            finally
            {
                ViewData["Resultaat"] = kResult;
                ViewData["Getal 1"] = getal01;
                ViewData["Getal 2"] = getal02;
            }
            return View("Welcome");
        }

        public IActionResult Kopieer()
        {

            String kAantalKeer = HttpContext.Request.Form["txbGetal01"].ToString();
            String kText = HttpContext.Request.Form["inTeVullenText"].ToString();
            int aantalKeer = 123456789;

            String isChecked = HttpContext.Request.Form["chkboxIMG"];
            int onOrOff = 555;

            if (isChecked == null)
            {
                onOrOff = 0;
            }
            else onOrOff = 1;

            try
            {
                aantalKeer = int.Parse(kAantalKeer);
            }
            catch (Exception)
            {
                
            }
            finally
            {
                ViewData["AantalKeer"] = aantalKeer;
                ViewData["Text"] = kText;
                ViewData["OnOrOff"] = onOrOff;
            }
            
            return View("Welcome");
            
        }
        
    }
}
