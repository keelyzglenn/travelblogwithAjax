using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TravelBlog.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace TravelBlog.Controllers
{
    public class SuggestionController : Controller
    {
        private ISuggestionRepository suggestionRepo;
        public SuggestionController(ISuggestionRepository thisRepo = null)
        {
            if (thisRepo == null)
            {
                this.suggestionRepo = new EFSuggestionRepository();
            }
            else
            {
                this.suggestionRepo = thisRepo;
            }
        }

        

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View(suggestionRepo.Suggestions.ToList());
        }

        public IActionResult HelloAjax()
        {
            return Content("Hello from the controller!", "text/plain");
        }

        [HttpPost]
        public IActionResult Create(string newDestination, string newDescription)
        {
            Suggestion newSuggestion = new Suggestion(newDestination, newDescription);
            suggestionRepo.Save(newSuggestion);
            return Json(newSuggestion);
        } 

        public IActionResult Search(string newSearch)
        {
            return Json(suggestionRepo.Search(newSearch));
        }
    }
}
