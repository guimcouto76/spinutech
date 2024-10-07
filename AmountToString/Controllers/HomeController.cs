using AmountToString.Interfaces;
using AmountToString.Models;
using AmountToString.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AmountToString.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly INumberToWordsConverter _numberToWordsConverter;

        public HomeController(ILogger<HomeController> logger, INumberToWordsConverter numberToWordsConverter)
        {
            _logger = logger;
            _numberToWordsConverter = numberToWordsConverter;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(decimal amount)
        {
            var model = new AmountModel
            {
                Amount = amount,
                AmountInWords = _numberToWordsConverter.ConvertAmountToWords(amount)
            };

            return View(model);
        }

        [HttpGet]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
