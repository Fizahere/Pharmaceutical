using Microsoft.AspNetCore.Mvc;
using Pharmaceutical.Data;
using Pharmaceutical.Models;

namespace Pharmaceutical.Controllers
{
    public class AuthController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IWebHostEnvironment _env;

        public AuthController(ApplicationDbContext dbContext, IWebHostEnvironment env)
        {
            _dbContext = dbContext;     
            _env = env;
        }

        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignUp(User request)
        {
            try
            {
                var user = _dbContext.Users.Where(e => e.UserName == request.UserName).FirstOrDefault();
                if (user == null)
                {
                    _dbContext.Users.Add(request);
                    _dbContext.SaveChanges();

                    return RedirectToAction("Login");
                }
                ViewBag.error = "this username is'nt available!";
                return View(request);
            }
            catch(Exception ex)
            {
                ViewBag.error = "something went wrong";
                return View(request);
            }
        }
        public IActionResult Login()
        {
            if (HttpContext.Session.GetString("role") == null)
            {
            return View();
            }
            else if(HttpContext.Session.GetString("role") == "Admin" )
            {
                return Redirect("~/dashboard/Index");
            }
            return Redirect("~/clientPanel/Index");
        }

        [HttpPost]
        public IActionResult Login(User request)
        {
            try
                {
                    var user = _dbContext.Users.Where(e => e.UserName == request.UserName && e.Password == request.Password).FirstOrDefault();
                //HttpContext.Session.SetString("name", user.UserName);
                    if (user != null)
                    {
                    HttpContext.Session.SetString("userId", user.UserID.ToString());
                    HttpContext.Session.SetString("role", user.Role);
                    if (user.Role == "Admin")
                        {
                            return Redirect("~/Dashboard/Index");
                        }
                        else
                        {
                            return Redirect("~/clientPanel/Index");
                        }
                    }
                    else
                    {
                        ViewBag.error = "invalid credantials";
                        return View(request);
                    }
                }

                catch (Exception ex)
                {
                    return ViewBag.error = "something went wrong";
                }
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("role");
            return Redirect("~/Auth/Login");
        }
    }
}
