using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pharmaceutical.Data;
using Pharmaceutical.Models;

namespace Pharmaceutical.Controllers
{
    public class QuotesController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IWebHostEnvironment _env;

        public QuotesController(ApplicationDbContext dbContext, IWebHostEnvironment env)
        {
            _dbContext = dbContext;
            _env = env;
        }

        public IActionResult Quotes()
        {
            var QuotesData = _dbContext.Quotes.ToList();
            return View(QuotesData);
        }
        [HttpPost]
        public IActionResult AddQuotes(Quote request)
        {
            _dbContext.Quotes.Add(request);
            _dbContext.SaveChanges();
            return RedirectToAction("Quotes");
        }
        public IActionResult DeleteQuote(int id)
        {
            Quote QuoteToDelete = _dbContext.Quotes.Find(id);
            _dbContext.Quotes.Remove(QuoteToDelete);
            _dbContext.SaveChanges();
            return RedirectToAction("Quotes");
        }
    }
}
