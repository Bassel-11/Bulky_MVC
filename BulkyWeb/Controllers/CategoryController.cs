using Bulky.DataAccess.Repository.IRepository;
using Bulky.DataAccess.Data;
using Bulky.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository categoryRepo;
        public CategoryController(ICategoryRepository categoryRepo)
        {
            this.categoryRepo = categoryRepo;
        }
        public IActionResult Index()
        {
            List<Category> objCategoryList = categoryRepo.GetAll().ToList();
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
                categoryRepo.Add(obj);
                categoryRepo.Save();
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
            Category categoryFromDb = categoryRepo.Get(u=>u.CatigoryId == id);
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
                categoryRepo.Update(obj);
                categoryRepo.Save();
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
            Category? categoryFromDb = categoryRepo.Get(u=> u.CatigoryId == id);
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            Category obj = categoryRepo.Get(u => u.CatigoryId == id);
            if (obj == null)
            {
                return NotFound();
            }
            categoryRepo.Remove(obj);
            categoryRepo.Save();
            TempData["Success"] = "Category Deleted Successfully";
            return RedirectToAction("Index");

        }
    }
}
