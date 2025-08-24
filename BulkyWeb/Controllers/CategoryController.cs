using BulkyWeb.Data;
using BulkyWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyWeb.Controllers;

public class CategoryController(ApplicationDbContext db) : Controller
{
    // GET

    public IActionResult Index()
    {
        List<Category> categories = db.Categories.ToList();
        return View(categories);
    }

    public IActionResult Create()
    {
        return View();
    }
    [HttpPost]
    public IActionResult Create(Category category)
    {
        if (!ModelState.IsValid) return View();
        db.Categories.Add(category);
        db.SaveChanges();
        TempData["success"] = "Category created successfully";
        return RedirectToAction("Index");
    }
    
    public IActionResult Edit(int? id)
    {  
        if (id is null or 0) return NotFound();
        Category? category = db.Categories.Find(id);
        if (category == null) return NotFound();
        return View(category);
    }
    [HttpPost]
    public IActionResult Edit(Category category)
    {
        if (!ModelState.IsValid) return View();
        db.Categories.Update(category);
        db.SaveChanges();
        TempData["success"] = "Category updated successfully";
        return RedirectToAction("Index");
    }

    public IActionResult Delete(int? id)
    {
        if (id is null or 0) return NotFound();
        Category? category = db.Categories.Find(id);
        if (category == null) return NotFound();
        return View(category);
    }

    [HttpPost, ActionName("Delete")]
    public IActionResult Delete(Category category)
    {
        db.Categories.Remove(category);
        db.SaveChanges();
        TempData["success"] = "Category deleted successfully";
        return RedirectToAction("Index");
    }
}