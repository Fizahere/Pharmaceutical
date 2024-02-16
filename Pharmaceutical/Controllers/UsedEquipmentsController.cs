using Microsoft.AspNetCore.Mvc;
using Pharmaceutical.Data;
using Pharmaceutical.Models;

namespace Pharmaceutical.Controllers
{
    public class UsedEquipmentsController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IWebHostEnvironment _env;

        public UsedEquipmentsController(ApplicationDbContext dbContext, IWebHostEnvironment env)
        {
            _dbContext = dbContext;
            _env = env;
        }

        public IActionResult UsedEquipments()
        {
            var usedEquipData = _dbContext.UsedEquipments.ToList();
            return View(usedEquipData);
        }

        [HttpPost]
        public IActionResult AddUsedEquipments(UsedEquipment request,IFormFile UsedEquipmentImage)
        {
            string path = Path.Combine(_env.WebRootPath, "images", Path.GetFileName(UsedEquipmentImage.FileName));
            UsedEquipmentImage.CopyTo(new FileStream(path, FileMode.Create));
            request.UsedEquipmentImage = UsedEquipmentImage.FileName;

            _dbContext.UsedEquipments.Add(request);
            _dbContext.SaveChanges();

            return RedirectToAction("UsedEquipments");
        }

        public IActionResult EditUsedEquip(int id)
        {
            var dataToEdit = _dbContext.UsedEquipments.Find(id);
            return View(dataToEdit);
        }

        [HttpPost]
        public IActionResult EditUsedEquip(UsedEquipment u, IFormFile UsedEquipmentImage)
        {
            string path = Path.Combine(_env.WebRootPath, "images", Path.GetFileName(UsedEquipmentImage.FileName));
            UsedEquipmentImage.CopyTo(new FileStream(path, FileMode.Create));

            var dataToEdit = _dbContext.UsedEquipments.Where(e => e.UsedEquipmentID == u.UsedEquipmentID).FirstOrDefault();
            dataToEdit.Name = u.Name;
            dataToEdit.Model = u.Model;
            dataToEdit.Manufacturer = u.Manufacturer;
            dataToEdit.Condition = u.Condition;
            dataToEdit.PreviousUsage = u.PreviousUsage;
            dataToEdit.ReasonsForSelling = u.ReasonsForSelling;
            dataToEdit.UsedEquipmentImage = UsedEquipmentImage.FileName;
            _dbContext.SaveChanges();
            return RedirectToAction("UsedEquipments");
        }

        public IActionResult DeleteUsedEquip(int id)
        {
            UsedEquipment usedEquipToDelete = _dbContext.UsedEquipments.Find(id);
            _dbContext.UsedEquipments.Remove(usedEquipToDelete);
            _dbContext.SaveChanges();

            return RedirectToAction("UsedEquipments");
        }
    }
}
