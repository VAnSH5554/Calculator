using Calculator.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Calculator.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index(double? num1, double? num2, string operation)
        {
            if (num1.HasValue && num2.HasValue)
            {
                double result = 0;

                switch (operation)
                {
                    case "add":
                        result = num1.Value + num2.Value;
                        break;

                    case "subtract":
                        result = num1.Value - num2.Value;
                        break;

                    case "multiply":
                        result = num1.Value * num2.Value;
                        break;

                    case "divide":
                        if (num2.Value != 0)
                        {
                            result = num1.Value / num2.Value;
                        }
                        else
                        {
                            ViewBag.Error = "Cannot divide by zero.";
                        }
                        break;
                }

                ViewBag.Result = result;
            }

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
