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
            List<int> listOfValues = new List<int>();
            //Shortcut to the Input.csv file
            var path = "~/../Data/Input.csv";
            int total;
            using (StreamReader reader = new StreamReader(path))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] values = line.Split(",");
                    foreach (var item in values)
                    {
                        if (item == "")
                        {
                            listOfValues.Add(0);
                        }
                        else
                        {
                            listOfValues.Add(int.Parse(item));
                        }

                    }
                }
            }
            listOfValues.RemoveRange(20, 5);
            listOfValues.RemoveRange(40, 5);
            listOfValues.RemoveRange(60, 5);

            var value = 0;
            total = 0;
            for (int i = 1; i < listOfValues.Count(); i += 2)
            {
                value += listOfValues[i];
                total = value;
            }
            ViewData["Som"] = total;
            //ViewBag
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
