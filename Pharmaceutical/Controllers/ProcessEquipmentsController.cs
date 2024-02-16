using Microsoft.AspNetCore.Mvc;
using Pharmaceutical.Data;
using Pharmaceutical.Models;

namespace Pharmaceutical.Controllers
{
    public class ProcessEquipmentsController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IWebHostEnvironment _env;
        public ProcessEquipmentsController(ApplicationDbContext dbContext, IWebHostEnvironment env)
        {
            _dbContext = dbContext;
            _env = env;
        }
        public IActionResult ProcessEquipments()
        {
            var processEquipData = _dbContext.ProcessEquipments.ToList();
            return View(processEquipData);
        }

        [HttpPost]
        public IActionResult AddProcessEquipments(ProcessEquipment request,IFormFile ProcessEquipmentImage)
        {
            string path = Path.Combine(_env.WebRootPath, "images", Path.GetFileName(ProcessEquipmentImage.FileName));
            ProcessEquipmentImage.CopyTo(new FileStream(path, FileMode.Create));
            request.ProcessEquipmentImage = ProcessEquipmentImage.FileName;

            _dbContext.ProcessEquipments.Add(request);
            _dbContext.SaveChanges();

            return RedirectToAction("ProcessEquipments");
        }

        public IActionResult EditProcessEquip(int id)
        {
            var dataToEdit = _dbContext.ProcessEquipments.Find(id);
            return View(dataToEdit);
        }

        [HttpPost]
        public IActionResult EditProcessEquip(ProcessEquipment p, IFormFile ProcessEquipmentImage)
        {
            string path = Path.Combine(_env.WebRootPath, "images", Path.GetFileName(ProcessEquipmentImage.FileName));
            ProcessEquipmentImage.CopyTo(new FileStream(path, FileMode.Create));

            var dataToEdit = _dbContext.ProcessEquipments.Where(e => e.ProcessEquipmentID == p.ProcessEquipmentID).FirstOrDefault();
            dataToEdit.Name = p.Name;
            dataToEdit.Model = p.Model;
            dataToEdit.MaterialOfConstruction = p.MaterialOfConstruction;
            dataToEdit.length = p.length;
            dataToEdit.Weight = p.Weight;
            dataToEdit.Width = p.Width;
            dataToEdit.Height = p.Height;
            dataToEdit.ProcessEquipmentImage = ProcessEquipmentImage.FileName;
            _dbContext.SaveChanges();
            return RedirectToAction("ProcessEquipments");
        }

        public IActionResult DeleteProcessEquip(int id)
        {
            ProcessEquipment ProcessEquipToDelete = _dbContext.ProcessEquipments.Find(id);
            _dbContext.ProcessEquipments.Remove(ProcessEquipToDelete);
            _dbContext.SaveChanges();

            return RedirectToAction("ProcessEquipments");
        }
    }
}
