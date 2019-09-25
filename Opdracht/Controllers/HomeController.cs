using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Opdracht.Models;

namespace Opdracht.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            //List van integers initialiseert
            List<int> listOfValues = new List<int>();
            //Pakt de juiste bestand in de gegeven map
            var path = "~/../Data/Input.csv";
            int total;
            using (StreamReader reader = new StreamReader(path))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    //Wordt in een array van string values gezet en vervolgens in de List<int> listOfValues gezet.
                    string[] values = line.Split(",");
                    foreach (var item in values)
                    {
                        //Als er geen waarde bestaat voor de item == "", geef er een 0 waarde toe
                        if (item == "")
                        {
                            listOfValues.Add(0);
                        }
                        //Als er wel een waarde bestaat in de gegeven item converteer het naar int en voeg het toe naar de listOfValues
                        else
                        {
                            listOfValues.Add(int.Parse(item));
                        }

                    }
                }
            }
            //Tot nu toe bestaat de listOfValues uit 75 items, maar de laatste 5 items van elke rij moet nog weggehaald worden
            //Dus per rij, laatste 5 items weghalen zodat het aan het eind de listOfValues 60 items bevat
            listOfValues.RemoveRange(20, 5);
            listOfValues.RemoveRange(40, 5);
            listOfValues.RemoveRange(60, 5);

            var value = 0;
            total = 0;
            //For Loop over de ListOfValues, beginnen met 1, want je wilt alle waardes van even kolommen berekenen.
            //Itereert en skipt oneven kolommon door i += 2 te doen.
            //Vervolgens krijg je de totale waarde in de total variable, de uitkomst moet dan 120 zijn
            for (int i = 1; i < listOfValues.Count(); i += 2)
            {
                value += listOfValues[i];
                total = value;
            }
            //Met de ViewData kan ik vervolgens dit variable linken naar een view.
            ViewData["Totaal"] = total;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
