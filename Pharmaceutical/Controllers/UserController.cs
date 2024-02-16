using Microsoft.AspNetCore.Mvc;
using Pharmaceutical.Data;
using Pharmaceutical.Models;

namespace Pharmaceutical.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public UserController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Users()
        {
            var usersData = _dbContext.Users.ToList();
            return View(usersData);
        }

        public IActionResult DeleteUser(int id)
        {
            User userToDelete = _dbContext.Users.Find(id);
            _dbContext.Users.Remove(userToDelete);
            _dbContext.SaveChanges();

            return RedirectToAction("Users");   
        }

    }
}
