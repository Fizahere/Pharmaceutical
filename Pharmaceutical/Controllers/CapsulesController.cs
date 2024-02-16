using Microsoft.AspNetCore.Mvc;
using Pharmaceutical.Data;
using Pharmaceutical.Models;

namespace Pharmaceutical.Controllers
{
    public class CapsulesController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IWebHostEnvironment _env;
        public CapsulesController(ApplicationDbContext dbContext, IWebHostEnvironment env)
        {

            _dbContext = dbContext;
            _env = env;
        }
        public IActionResult Capsules()
        {
            var CapsulesData = _dbContext.Capsules.ToList();
            return View(CapsulesData);
        }

        [HttpPost]
        public IActionResult AddCapsules(Capsule request,IFormFile CapsuleImage)
        {
            string path = Path.Combine(_env.WebRootPath, "images", Path.GetFileName(CapsuleImage.FileName));
            CapsuleImage.CopyTo(new FileStream(path, FileMode.Create));
            request.CapsuleImage = CapsuleImage.FileName;

            _dbContext.Capsules.Add(request);
            _dbContext.SaveChanges();

            return RedirectToAction("Capsules");
        }

        public IActionResult EditCapsule(int id)
        {
            var dataToEdit = _dbContext.Capsules.Find(id);
            return View(dataToEdit);
        }

        [HttpPost]
        public IActionResult EditCapsule(Capsule c, IFormFile CapsuleImage)
        {
            string path = Path.Combine(_env.WebRootPath, "images", Path.GetFileName(CapsuleImage.FileName));
            CapsuleImage.CopyTo(new FileStream(path, FileMode.Create));

            var dataToEdit = _dbContext.Capsules.Where(e => e.CapsuleID == c.CapsuleID).FirstOrDefault();

            dataToEdit.Name = c.Name;
            dataToEdit.Output = c.Output;
            dataToEdit.CapsuleSize = c.CapsuleSize;
            dataToEdit.ShippingWeight = c.ShippingWeight;
            dataToEdit.Profill = c.Profill;
            dataToEdit.length = c.length;
            dataToEdit.Width = c.Width;
            dataToEdit.Height = c.Height;
            dataToEdit.CapsuleImage = CapsuleImage.FileName;

            _dbContext.SaveChanges();
            return RedirectToAction("Capsules");
        }


        public IActionResult DeleteCapsule(int id)
        {
            Capsule capsuleToDelete = _dbContext.Capsules.Find(id);
            _dbContext.Capsules.Remove(capsuleToDelete);
            _dbContext.SaveChanges();
            return RedirectToAction("Capsules");
        }

    }
}

