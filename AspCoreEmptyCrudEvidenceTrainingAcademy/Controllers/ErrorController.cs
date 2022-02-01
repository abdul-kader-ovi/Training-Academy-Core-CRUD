using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspCoreEmptyCrudEvidenceTrainingAcademy.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult HttpStatusCodeHandler(int statusCode)
        {
            switch (statusCode)
            {
                case 404:
                    ViewBag.ErrorMessage = "Page Not Found";
                    break;
                default:
                    ViewBag.ErrorMessage = "It seems problem occured";
                    break;
            }
            return View("Error");
        }
    }
}
