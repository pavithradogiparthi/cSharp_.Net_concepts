using System.Diagnostics;
using EFCore_Loading.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCore_Loading.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ApplicationDbContext _db;

        public HomeController(ILogger<HomeController> logger,ApplicationDbContext db)
        {
            _logger = logger;
            _db= db;
        }

        public IActionResult Index()
        {//explict loading
            Villa? villaTemp = _db.Villas.FirstOrDefault(a=>a.Id==1);
            _db.Entry(villaTemp).Collection(u=>u.VillaAmenity).Load();

            VillaAmenity? villaAmenityTemp = _db.VillaAmenities.FirstOrDefault(a => a.Id == 1);
            _db.Entry(villaAmenityTemp).Reference(u => u.Villa).Load();

            //eager loading
            List<Villa>eager_villas=_db.Villas.Include(u=>u.VillaAmenity).ToList();
        
         //lazy loading
            var  villas = _db.Villas;
            var totalVillas= villas.Count();
          
            foreach (Villa villa in villas)
            {
                Console.WriteLine(villa.VillaAmenity.ToList()[0].Name);
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
