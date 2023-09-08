﻿using Microsoft.AspNetCore.Mvc;

namespace DemoNet7.Controllers
{
    public class ErrorController : Controller
    {
        private readonly ILogger<ErrorController> _logger;

        public ErrorController(ILogger<ErrorController> logger)
        {
            _logger = logger;
        }

        [Route("Error/{statusCode}")]
        public IActionResult NotFound(int statusCode)
        {
            switch (statusCode)
            {
                case 404:
                    ViewBag.ErrorTitle = "The Requested Page is not Exist";
                    break;
                default:
                    ViewBag.ErrorTitle = "Unexpected Error";
                    break;

            }
            return View("Error");
        }

        [Route("Error")]
        public IActionResult ExceptionError()
        {
            ViewBag.ErrorTitle = "Unexpected Error Occured";
            ViewBag.ErrorMessage = "Please report this error to the website administrator";
            return View("Error");
        }
    }
}
