using System;
using System.Collections.Generic;
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
    }
}
