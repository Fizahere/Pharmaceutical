using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pharmaceutical.Data;
using Pharmaceutical.Models;

namespace Pharmaceutical.Controllers
{
    public class BlendingsController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IWebHostEnvironment _env;
        public BlendingsController(ApplicationDbContext dbContext,IWebHostEnvironment env) {

            _dbContext = dbContext;
            _env= env;
        }
        public IActionResult Blendings()
        {
            var BlendingData = _dbContext.Blendings.ToList();
            return View(BlendingData);
        }

        [HttpPost]
        public IActionResult AddBlendings(Blending request,IFormFile BlendingImage)    
        
        {
            string path = Path.Combine(_env.WebRootPath, "images", Path.GetFileName(BlendingImage.FileName));
            BlendingImage.CopyTo(new FileStream(path, FileMode.Create));
            request.BlendingImage = BlendingImage.FileName;

            _dbContext.Blendings.Add(request);
            _dbContext.SaveChanges();

            return RedirectToAction("Blendings");
       }

        public IActionResult EditBlending(int id)
        {
            var dataToEdit = _dbContext.Blendings.Find(id);
            return View(dataToEdit);
        }

        [HttpPost]
        public IActionResult EditBlending(Blending b, IFormFile BlendingImage)
        {
            string path = Path.Combine(_env.WebRootPath, "images", Path.GetFileName(BlendingImage.FileName));
            BlendingImage.CopyTo(new FileStream(path, FileMode.Create));
            //b.BlendingImage = BlendingImage.FileName;

            var dataToEdit = _dbContext.Blendings.Where(e => e.BlendingID == b.BlendingID).FirstOrDefault();
            dataToEdit.Name = b.Name;
            dataToEdit.Model = b.Model;
            dataToEdit.Capacity = b.Capacity;
            dataToEdit.TypeOfBlending = b.TypeOfBlending;
            dataToEdit.MixingSpeed = b.MixingSpeed;
            dataToEdit.MixingTime = b.MixingTime;
            dataToEdit.Weight = b.Weight;
            dataToEdit.length = b.length;
            dataToEdit.Width = b.Width;
            dataToEdit.Height = b.Height;
            dataToEdit.BlendingImage = BlendingImage.FileName;
            _dbContext.SaveChanges();
            return RedirectToAction("Blendings");
        }

        public IActionResult DeleteBlending(int id)
        {
            Blending blendingToDelete = _dbContext.Blendings.Find(id);
            _dbContext.Blendings.Remove(blendingToDelete);
            _dbContext.SaveChanges();
            return RedirectToAction("Blendings");
        }


    }
}
