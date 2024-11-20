using BulkyWeb.Data;
using BulkyWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyWeb.Controllers
{
    public class CategoryController : Controller
    {
        private ApplicationDbContext db;
        public CategoryController(ApplicationDbContext db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            List<Category> objCategoryList = db.Categories.ToList();
            return View(objCategoryList);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category obj)
        {
            if (obj.Name.ToLower() == obj.DisplayOrder.ToString()) { 
                ModelState.AddModelError("Name", "Category Name and Display Order cannot be the same"); 
            }
            if(ModelState.IsValid)
            {
                db.Categories.Add(obj);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
            
            
        }
    }
}
