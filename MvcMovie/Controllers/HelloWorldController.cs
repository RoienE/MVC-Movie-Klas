using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MvcMovie.Library;

// *25/01/2018 MODIFIED at: 01-02-08/02/2018
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
        
        public IActionResult CalcResultOtherPage()
        {
            @ViewData[MyUtilities.SW_CalcAnderePagina_Resultaat] = "nog niet bekend";

            String kGetal01 = "=kGetal01=", kGetal02 = "=kGetal02=";
            int getal01 = 123456,
                getal02 = 987654;

            try
            {
                List<SelectListItem> items = new List<SelectListItem>();

                items.Add(new SelectListItem { Text = "(Niets)", Value = "0", Selected = true });

                items.Add(new SelectListItem { Text = "sec", Value = "1" });

                items.Add(new SelectListItem { Text = "min", Value = "2" });

                items.Add(new SelectListItem { Text = "uur", Value = "3" });

                ViewBag.TijdsKeuze = items;

                kGetal01 = HttpContext.Request.Form["txbGetal01"].ToString();
                try
                {
                    kGetal02 = HttpContext.Request.Form["txbGetal02"].ToString();
                    try
                    {
                        getal01 = int.Parse(kGetal01);
                        try
                        {
                            getal02 = int.Parse(kGetal02);

                            ViewData[MyUtilities.SW_CalcAnderePagina_Resultaat] = "" + (getal01 + getal02);
                        }
                        catch (Exception)
                        {
                            ViewData[MyUtilities.SW_CalcAnderePagina_Resultaat] = "niet berekenbaar [08022018A]";
                        }
                    }
                    catch (Exception)
                    {
                        ViewData[MyUtilities.SW_CalcAnderePagina_Resultaat] = "niet berekenbaar [08022018B]";
                    }
                }
                catch (Exception)
                {
                    ViewData[MyUtilities.SW_CalcAnderePagina_Resultaat] = "niet berekenbaar [08022018C]";
                }
            }
            catch (Exception)
            {
                ViewData[MyUtilities.SW_CalcAnderePagina_Resultaat] = "nog niet bekend"; // "niet berekenbaar [08022018D]";
            }
            return View();
        }

        public IActionResult makeCookie(string TijdsKeuze)
        {
            //
            // D: 08/02/2018
            // P: de nodige waarden worden aangeleverd
            // P: het koekje is gemaakt 
            // G: in view CalcResultOtherPage
            // R: de view CalcResultOtherPage
            // O: / 
            //

            String kHulpString = "=kHulpString=",
                kTijd = "",
                kEenheid = "=kEenheid=";

            int kHulpController = -18020901,
                kKeuze = -18020921;
            CookieOptions kMyOptions = null;

            try
            {
                kTijd = HttpContext.Request.Form["txbTijd"].ToString();

                if(string.IsNullOrEmpty(kTijd) == true)
                {
                    kHulpController = -18020902;
                    kHulpString = "";
                    HttpContext.Response.Cookies.Append(MyUtilities.MY_COOKIE, ViewData["Result"].ToString());
                }
                else
                {
                    kKeuze = int.Parse(TijdsKeuze);
                    if(kKeuze == 1)
                    {
                        kHulpController = 18020903;
                        kMyOptions.Expires = DateTime.Now.AddSeconds(int.Parse(kTijd));
                    }
                    else if(kKeuze == 2)
                    {
                        kHulpController = 18020904;
                        kMyOptions.Expires = DateTime.Now.AddMinutes(int.Parse(kTijd));
                    }
                    else if(kKeuze == 3)
                    {
                        kHulpController = 18020904;
                        kMyOptions.Expires = DateTime.Now.AddHours(int.Parse(kTijd));
                    }
                    else
                    {
                        kHulpController = -18020922;
                    }
                    if(kHulpController < 0)
                    {
                        HttpContext.Response.Cookies.Append(MyUtilities.MY_COOKIE, ViewData["Result"].ToString());
                    }
                    else
                    {
                        HttpContext.Response.Cookies.Append(MyUtilities.MY_COOKIE, ViewData["Result"].ToString(), kMyOptions);
                    }
                }

                @ViewData["Result"] = HttpContext.Request.Form["txbCookiesContent"].ToString();
                // TestComment
                if (String.IsNullOrEmpty(ViewData["Result"].ToString()) == true)
                {
                    kHulpString = "An EMPTY cookie is not allowed: defaultvalue 'abc123' has been assigned to the cookie. \n";
                    @ViewData["Result"] = "abc123";
                }
                else
                {
                    kHulpString = "";
                }
                //
                //
                //
                if (kHulpController < 0)
                {
                    HttpContext.Response.Cookies.Append(MyUtilities.MY_COOKIE, ViewData["Result"].ToString());
                }
                else
                {
                    HttpContext.Response.Cookies.Append(MyUtilities.MY_COOKIE, ViewData["Result"].ToString(), kMyOptions);
                }
                //
                //
                //
                kHulpString += @ViewData["Result"].ToString();
                @ViewData["txaResult"] = "YOEHOE, Cookie with value '" + ViewData["Result"] + "' is added. (--" + DateTime.Now + "--)";
                // @ViewData["txaResult"] = kHulpString;
            }
            catch (Exception)
            {
                @ViewData["txaResult"] = "Het koekje kan nog niet gemaakt worden";
            }

            finally
            {
                List<SelectListItem> items = new List<SelectListItem>();

                items.Add(new SelectListItem { Text = "(Niets)", Value = "0", Selected = true });

                items.Add(new SelectListItem { Text = "sec", Value = "1" });

                items.Add(new SelectListItem { Text = "min", Value = "2" });

                items.Add(new SelectListItem { Text = "uur", Value = "3" });

                ViewBag.TijdsKeuze = items;
            }

            return View("CalcResultOtherPage");
        }

        public IActionResult checkCookie()
        {
            String kHulpString = "=kHulpString=";
            //
            // D: 09/02/2018
            // P: de nodige waarden worden aangeleverd
            // P: het koekje is gecontroleerd 
            // G: in view CalcResultOtherPage
            // R: een instantie van de view CalcResultOtherPage
            // O: / 
            //

            try
            {
                kHulpString = Request.Cookies[MyUtilities.MY_COOKIE];

                if(String.IsNullOrEmpty(kHulpString) == true)
                {
                    @ViewData["txaResult"] = "The cookie does not exist yet.";
                }
                else
                {
                    Console.Beep();
                    @ViewData["txaResult"] = "The cookie exist, with value: " + kHulpString + ".";
                }

            }
            catch (Exception)
            {
                @ViewData["txaResult"] = "Het koekje kan (nog) niet gecontrleerd worden";
            }

            finally
            {
                List<SelectListItem> items = new List<SelectListItem>();

                items.Add(new SelectListItem { Text = "(Niets)", Value = "0", Selected = true });

                items.Add(new SelectListItem { Text = "sec", Value = "1" });

                items.Add(new SelectListItem { Text = "min", Value = "2" });

                items.Add(new SelectListItem { Text = "uur", Value = "3" });

                ViewBag.TijdsKeuze = items;
            }

            return View("CalcResultOtherPage");
        }

        public IActionResult deleteCookie()
        {
            String kHulpString = "=kHulpString=";
            //
            // D: 09/02/2018
            // P: de nodige waarden worden aangeleverd
            // P: het koekje is verwijderd 
            // G: in view CalcResultOtherPage
            // R: een instantie van de view CalcResultOtherPage
            // O: / 
            //

            try
            {
                kHulpString = Request.Cookies[MyUtilities.MY_COOKIE];

                if (String.IsNullOrEmpty(kHulpString) == true)
                {
                    @ViewData["txaResult"] = "The cookie does not exist yet, and can not be deleted.";
                }
                else
                {
                    CookieOptions kMyOptions = new CookieOptions();
                    kMyOptions.Expires = DateTime.Now.AddMinutes(-10);

                    HttpContext.Response.Cookies.Append(MyUtilities.MY_COOKIE, kHulpString, kMyOptions);

                    kHulpString = "YOEHOE, Cookie with value '" + kHulpString + "' is deleted. (--" + DateTime.Now + "--)";
                    @ViewData["txaResult"] = kHulpString;
                }

            }
            catch (Exception)
            {
                @ViewData["txaResult"] = "Het koekje kan (nog) niet gecontrleerd worden";
            }

            finally
            {
                List<SelectListItem> items = new List<SelectListItem>();

                items.Add(new SelectListItem { Text = "(Niets)", Value = "0", Selected = true });

                items.Add(new SelectListItem { Text = "sec", Value = "1" });

                items.Add(new SelectListItem { Text = "min", Value = "2" });

                items.Add(new SelectListItem { Text = "uur", Value = "3" });

                ViewBag.TijdsKeuze = items;
            }

            return View("CalcResultOtherPage");
        }

        public IActionResult QuizHP()
        {
            return View();
        }

        public IActionResult makeCookieQuiz()
        {
            //
            // D: 09/02/2018
            // P: de nodige waarden worden aangeleverd
            // P: het koekje is gemaakt waar de user opgeslaan is
            // G: in view QuizHP
            // R: de view QuizHP
            // O: / 
            //

            String kHulpString = "=kHulpString=";
            //kTijd = "",
            //kEenheid = "=kEenheid=";

            //     int kHulpController = -18020901;
                // kTijdAlsInt = -18020907;
            // CookieOptions kMyOptions = null;

            try
            {
                @ViewData["NaamQuizzer"] = HttpContext.Request.Form["txbName"].ToString();

                if (String.IsNullOrEmpty(ViewData["NaamQuizzer"].ToString()) == true)
                {
                    kHulpString = "The name must be entered. \n";
                    //@ViewData["NaamQuizzer"] = "abc123";
                }
                else
                {
                    kHulpString = "";
                }
                //
                //
                //
                HttpContext.Response.Cookies.Append(MyUtilities.MY_COOKIE, ViewData["NaamQuizzer"].ToString());
                //
                //
                //
                kHulpString += @ViewData["NaamQuizzer"].ToString();
                // @ViewData["txaResult"] = "YOEHOE, Cookie with value '" + ViewData["Result"] + "' is added. (--" + DateTime.Now + "--)";
                // @ViewData["txaResult"] = kHulpString;

            }
              
            catch (Exception)
            {
                @ViewData["txaResult"] = "Het koekje kan nog niet gemaakt worden";
            }

            return View("Quiz1");
        }

        public IActionResult goToQuestion2()
        {
            String antwoord = "=antwoord=";

            antwoord = HttpContext.Request.Form["txbA1"].ToString();
            if(antwoord.ToLower().Equals("pyongyang"))
            {
                return View("Quiz2");
            }
            else
            {
                return View("Quiz1");
            }
        }

        public IActionResult goToQuestion3()
        {
            String antwoord = "=antwoord=";

            antwoord = HttpContext.Request.Form["txbA2"].ToString();
            if (antwoord.ToLower().Equals("pinguin"))
            {
                return View("Quiz3");
            }
            else
            {
                return View("Quiz2");
            }
        }
    }
}
