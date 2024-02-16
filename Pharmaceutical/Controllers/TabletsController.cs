using Microsoft.AspNetCore.Mvc;
using Pharmaceutical.Data;
using Pharmaceutical.Models;

namespace Pharmaceutical.Controllers
{
    public class TabletsController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IWebHostEnvironment _env;
        
        public TabletsController(ApplicationDbContext dbContext, IWebHostEnvironment env)
        {
            _dbContext = dbContext;
            _env = env;
        }
        public IActionResult Tablets()
        {
            var tabletsData = _dbContext.Tablets.ToList();
            return View(tabletsData);
        }

        [HttpPost]
        public IActionResult AddTablets(Tablet request,IFormFile TabletImage)
        {
            string path = Path.Combine(_env.WebRootPath, "images", Path.GetFileName(TabletImage.FileName));
            TabletImage.CopyTo(new FileStream(path, FileMode.Create));
            request.TabletImage = TabletImage.FileName;

            _dbContext.Tablets.Add(request);
            _dbContext.SaveChanges();

            return RedirectToAction("Tablets");
        }
        public IActionResult EditTablet(int id)
        {
            var dataToEdit = _dbContext.Tablets.Find(id);
            return View(dataToEdit);
        }

        [HttpPost]
        public IActionResult EditTablet(Tablet t, IFormFile TabletImage)
        {
            string path = Path.Combine(_env.WebRootPath, "images", Path.GetFileName(TabletImage.FileName));
            TabletImage.CopyTo(new FileStream(path, FileMode.Create));

            var dataToEdit = _dbContext.Tablets.Where(e => e.TabletID == t.TabletID).FirstOrDefault();

            dataToEdit.Name = t.Name;
            dataToEdit.ModelNumber = t.ModelNumber;
            dataToEdit.Dies = t.Dies;
            dataToEdit.MaxPressure = t.MaxPressure;
            dataToEdit.MaxDiameter = t.MaxDiameter;
            dataToEdit.MaxDepthOfFill = t.MaxDepthOfFill;
            dataToEdit.ProductionCapacity = t.ProductionCapacity;
            dataToEdit.MachineSize = t.MachineSize;
            dataToEdit.Netweight = t.Netweight;
            dataToEdit.TabletImage = TabletImage.FileName;

            _dbContext.SaveChanges();
            return RedirectToAction("Tablets");
        }

        public IActionResult DeleteTablets(int id)
        {
            Tablet tabletToDlt = _dbContext.Tablets.Find(id);
                _dbContext.Tablets.Remove(tabletToDlt);
            _dbContext.SaveChanges();

            return RedirectToAction("Tablets");
        }
    }
}
