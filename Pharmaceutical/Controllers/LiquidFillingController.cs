using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using Pharmaceutical.Data;
using Pharmaceutical.Models;

namespace Pharmaceutical.Controllers
{
    public class LiquidFillingController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IWebHostEnvironment _env;
        public LiquidFillingController(ApplicationDbContext dbContext, IWebHostEnvironment env)
        {
            _dbContext = dbContext;
            _env = env;
        }
        public IActionResult LiquidFilling()
        {
            var LiquidFillingData = _dbContext.LiquidFillings.ToList();
            return View(LiquidFillingData);
        }

        [HttpPost]
        public IActionResult AddLiquidFilling(LiquidFilling request,IFormFile LiquidFillingImage)
        {
            string path = Path.Combine(_env.WebRootPath, "images", Path.GetFileName(LiquidFillingImage.FileName));
            LiquidFillingImage.CopyTo(new FileStream(path, FileMode.Create));
            request.LiquidFillingImage = LiquidFillingImage.FileName;

            _dbContext.LiquidFillings.Add(request);
            _dbContext.SaveChanges();

            return RedirectToAction("LiquidFilling");
        }
        public IActionResult EditLiquidFilling(int id)
        {
            var dataToEdit = _dbContext.LiquidFillings.Find(id);
            return View(dataToEdit);
        }

        [HttpPost]
        public IActionResult EditLiquidFilling(LiquidFilling l, IFormFile LiquidFillingImage)
        {
            string path = Path.Combine(_env.WebRootPath, "images", Path.GetFileName(LiquidFillingImage.FileName));
            LiquidFillingImage.CopyTo(new FileStream(path, FileMode.Create));

            var dataToEdit = _dbContext.LiquidFillings.Where(e => e.LiquidFillingID == l.LiquidFillingID).FirstOrDefault();
            dataToEdit.Name = l.Name;
            dataToEdit.AirPressure = l.AirPressure;
            dataToEdit.AirVolume = l.AirVolume;
            dataToEdit.FillingSpeed = l.FillingSpeed;
            dataToEdit.FillingRange = l.FillingRange;
            dataToEdit.LiquidFillingImage = LiquidFillingImage.FileName;
            _dbContext.SaveChanges();
            return RedirectToAction("LiquidFilling");
        }

        public IActionResult DeleteLiquidFilling(int id)
        {
            LiquidFilling lifToDelete = _dbContext.LiquidFillings.Find(id);
            _dbContext.LiquidFillings.Remove(lifToDelete);
            _dbContext.SaveChanges();
            return RedirectToAction("LiquidFilling");
        }

    }
}
