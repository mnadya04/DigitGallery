using DigitGallery.Data;
using DigitGallery.Models;
using DigitGallery.Services;
using DigitGallery.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace DigitGallery.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private DigitGalleryService service = new DigitGalleryService();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Drawings()
        {
            IndexDrawingsViewModel drawingModel = new IndexDrawingsViewModel();
            drawingModel.Drawings = service.GetDrawings()
                .Select(x => new IndexDrawingViewModel()
                {
                    Name = x.Name,
                    Artist = x.Artist.Name
                }).ToList();
            drawingModel.DrawingsCount = service.DrawingsCount();
            return View(drawingModel);
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
