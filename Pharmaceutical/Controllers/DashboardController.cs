using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pharmaceutical.Data;
using Pharmaceutical.Models;
//using Microsoft.EntityFrameworkCore;
//using pharmacutical.Data;
//using pharmacutical.Models;

namespace Pharmaceutical.Controllers
{
    public class DashboardController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public DashboardController(ApplicationDbContext dbContext)
        {
           _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            try
            {
                if (HttpContext.Session.GetString("role") != "Admin")
                {
                    ViewBag.error = "invalid credentials";
                    return Redirect("~/Auth/Login");
                }
                var blendings = _dbContext.Blendings.ToList();
                var capsules = _dbContext.Capsules.ToList();
                var liquidFilling = _dbContext.LiquidFillings.ToList();
                var processEuipments = _dbContext.ProcessEquipments.ToList();
                var quotes = _dbContext.Quotes.ToList();
                var tablets = _dbContext.Tablets.ToList();
                var usedEuipments = _dbContext.UsedEquipments.ToList();
                var users = _dbContext.Users.ToList();

                var viewModel = new RatioChartViewModel
                {

                    Blendings = blendings,
                    Capsules = capsules,
                    LiquidFilling = liquidFilling,
                    ProcessEquipment = processEuipments,
                    Quotes = quotes,
                    Tablets = tablets,
                    UsedEquipment = usedEuipments,
                    Users = users,
                };

                return View(viewModel);
            }
            catch(Exception ex)
            {
              return View(ex);
            }
        }

        //public IActionResult Index()
        //{
        //    if (HttpContext.Session.GetString("name") == null)
        //    {
        //        return Redirect("~/Auth/Login");
        //    }
        //    return View();
        //}


        //    if (HttpContext.Session.GetString("role") == "Admin")
        //    {
        //         return View();
        //   }
        //       return Redirect("~/Auth/Login");
        //}

        //private ApplicationDbContext _dbContext;

        //public DashboardController(ApplicationDbContext dbContext)
        //{
        //    _dbContext = dbContext;
        //}

        //public IActionResult Index()
        //{
        //    // Fetch data from the database
        //    var users = _dbContext.Users.Include(u => u.UserName).ToList();

        //    // Create a view model to pass data to the view
        //    var viewModel = new ChartViewModel
        //    {
        //        Users = users
        //    };

        //    return View(viewModel);
        //}
    }
}
