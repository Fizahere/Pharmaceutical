using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Pharmaceutical.Data;
using Pharmaceutical.Models;
using System.IO;

namespace Pharmaceutical.Controllers
{
    public class ClientPanelController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly IWebHostEnvironment _env;
        public ClientPanelController(ApplicationDbContext db, IWebHostEnvironment env)
        {
            _env = env;
            _db = db;

        }
        public IActionResult Index()
        {
            var projects = _db.Tablets.ToList();
            return View(projects);
        }
        public IActionResult Tablet()
        {
            var tablets = _db.Tablets.ToList();
            //return Ok(tablets);
            return View(tablets);
        }
        public IActionResult TabletDetail(int id)
        {
            ViewBag.singleTablet = _db.Tablets.Find(id);
            //return Ok(singleProduct);
            return View();
        }
        public IActionResult Capsules(int id)
        {
            var capsule = _db.Capsules.ToList();
            return View(capsule);
        }
        public IActionResult CapsulesDetail(int id)
        {
            ViewBag.singleCapsule = _db.Capsules.Find(id);
            //return Ok(singleProduct);
            return View();
        }
        public IActionResult LiquidFilling()
        {
            var liquidFilling = _db.LiquidFillings.ToList();
            return View(liquidFilling);
        }
        public IActionResult LiquidFillingDetail(int id)
        {
            ViewBag.singleLiquidFilling = _db.LiquidFillings.Find(id);
            //return Ok(singleProduct);
            return View();
        }
        public IActionResult Blending()
        {
            var blending = _db.Blendings.ToList();
            return View(blending);
        }
        public IActionResult BlendingDetail(int id)
        {
            ViewBag.singleBlending = _db.Blendings.Find(id);
            //return Ok(singleProduct);
            return View();
        }
        public IActionResult ProcessEquipment()
        {
            var processEquipment = _db.ProcessEquipments.ToList();
            return View(processEquipment);
        }
        public IActionResult ProcessEquipmentDetail(int id)
        {
            ViewBag.singleProcessEquipment = _db.ProcessEquipments.Find(id);
            //return Ok(singleProduct);
            return View();
        }
        public IActionResult UsedEquipment()
        {
            var UsedEquipment = _db.UsedEquipments.ToList();
            return View(UsedEquipment);
        }
        public IActionResult UsedEquipmentDetail(int id)
        {
            ViewBag.singleUsedEquipment = _db.UsedEquipments.Find(id);
            //return Ok(singleProduct);
            return View();
        }
        public IActionResult About()
        {
            return View();
        }
        public IActionResult QuoteUs()
        {
            if(HttpContext.Session.GetString("userId") != null)
            {
                return View();
            }
            return Redirect("~/Auth/Login");
        }

        [HttpPost]
        public IActionResult QuoteUs(Quote request )
        {
            //if(ModelState.IsValid)
            //{ 
              Quote q = new Quote();
                q.UserId= request.UserId;
              q.FirstName = request.FirstName;
              q.LastName = request.LastName;
              q.Address = request.Address;
              q.CompanyName = request.CompanyName;
              q.City = request.City;
              q.State = request.State;
              q.Country = request.Country;
              q.Phone = request.Phone;
              q.PostalCode = request.PostalCode;
              q.Comments = request.Comments;
              _db.Quotes.Add(request);
              _db.SaveChanges();
              ModelState.Clear();
              ViewBag.success = true;
              return View();
            //}
            //return View(request);
        }
        public IActionResult ContactUs()
        {
            return View();
        }
        public IActionResult Career()
        {
            return View();
        }
        public IActionResult CareerForm()
        {
            if (HttpContext.Session.GetString("userId") != null)
            {
                return View();
            }
            return Redirect("~/Auth/Login");
        }
        [HttpPost]
        public IActionResult CareerForm(UserCareer careerform, IFormFile Resume)
        {
            try
            {
            //return Ok(careerform);
            string path = Path.Combine(_env.WebRootPath, "Resume", Path.GetFileName(Resume.FileName));
            Resume.CopyTo(new FileStream(path, FileMode.Create));
            UserCareer career = new UserCareer
            {
                Name = careerform.Name,
                FatherName = careerform.FatherName,
                Address = careerform.Address,
                PhoneNumber = careerform.PhoneNumber,
                Gender = careerform.Gender,
                DateOfBirth = careerform.DateOfBirth,
                EmailAddress = careerform.EmailAddress,
                Education = careerform.Education,
                Degree = careerform.Degree,
                Specialization = careerform.Specialization,
                School = careerform.School,
                CGPA = careerform.CGPA,
                PassingYear = careerform.PassingYear,
                Resume = Resume.FileName,
                UserId = careerform.UserId,
            };
            _db.UserCareers.Add(career);
            _db.SaveChanges();
            ModelState.Clear();
                ViewBag.success = true;
                return RedirectToAction("Index");
            }
            catch
            {
                return View("Sorry Something went wrong");
            }
            //return View(careerform);
        }
    }
}
