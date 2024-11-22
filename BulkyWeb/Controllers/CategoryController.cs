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
            if (obj.Name.ToLower() == obj.DisplayOrder.ToString())
            { 
                ModelState.AddModelError("Name", "Category Name and Display Order cannot be the same"); 
            }

            if(ModelState.IsValid)
            {
                db.Categories.Add(obj);
                db.SaveChanges();
                TempData["Success"] = "Category Added Successfully";
                return RedirectToAction("Index");
            }
            return View();
                        
        }
        public IActionResult Edit(int? id) 
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category categoryFromDb = db.Categories.Find(id);
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }

        [HttpPost]
        public IActionResult Edit(Category obj) 
        {
            if(ModelState.IsValid)
            {
                db.Categories.Update(obj);
                db.SaveChanges();
                TempData["Success"] = "Category Updated Successfully";
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category? categoryFromDb = db.Categories.Find(id);
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            Category obj = db.Categories.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            db.Categories.Remove(obj);
            db.SaveChanges();
            TempData["Success"] = "Category Deleted Successfully";
            return RedirectToAction("Index");

        }
    }
}
