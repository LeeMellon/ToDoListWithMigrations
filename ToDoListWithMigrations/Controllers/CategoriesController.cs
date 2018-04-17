using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ToDoListWithMigrations.Models;

namespace ToDoListWithMigrations.Controllers
{
    public class CategoriesController : Controller
    {
        private ToDoDbContext db = new ToDoDbContext();
        public IActionResult Index()
        {
            List<Category> model = db.Categories.ToList();
            return View(model);
        }
        public IActionResult Details(int id)
        {
            var thisCategory = db.Categories.FirstOrDefault(categories => categories.CategoryId == id);
            return View(thisCategory);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category category)
        {
            db.Categories.Add(category);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            var thisCategory = db.Categories.FirstOrDefault(categories => categories.CategoryId == id);
            return View(thisCategory);
        }
        [HttpPost]
        public IActionResult Edit(Category category)
        {
            db.Entry(category).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            var thisCategory = db.Categories.FirstOrDefault(categories => categories.CategoryId == id);
            return View(thisCategory);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var thisCategory = db.Categories.FirstOrDefault(categories => categories.CategoryId == id);
            db.Categories.Remove(thisCategory);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
