using Microsoft.AspNetCore.Mvc;
using CRUD_Operation.Models;
using CRUD_Operation.Data;
using System.Collections.Generic;

namespace CRUD_Operation.Controllers
{
    public class CategoryController : Controller
    {
        private readonly DataAccessLayer _dataAccess;

        public CategoryController(DataAccessLayer dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public IActionResult Index()
        {
            List<Category> categories = _dataAccess.GetAllCategories();
            return View(categories);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                _dataAccess.InsertCategory(category);
                return RedirectToAction("Index", "Category");
            }
            return View(category);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Category category = _dataAccess.GetCategoryById(id);
            if (category == null)
                return NotFound();
            return View(category);
        }

        [HttpPost]
        public IActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                _dataAccess.UpdateCategory(category);
                return RedirectToAction("Index", "Category");
            }
            return View(category);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            Category category = _dataAccess.GetCategoryById(id);
            if (category == null)
                return NotFound();
            return View(category);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _dataAccess.DeleteCategory(id);
            return RedirectToAction("Index", "Category");
        }
    }


}
