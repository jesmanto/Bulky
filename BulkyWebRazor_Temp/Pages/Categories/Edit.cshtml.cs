using BulkyWebRazor_Temp.Data;
using BulkyWebRazor_Temp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BulkyWebRazor_Temp.Pages.Categories;
[BindProperties]
public class Edit(ApplicationDbContext db) : PageModel
{
    public Category Category { get; set; }

    public void OnGet(int? id)
    {
        if (id is > 0)
            Category = db.Categories.Find(id);
    }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid) return Page();
        db.Categories.Update(Category);
        db.SaveChanges();
        TempData["success"] = "Category updated successfully";
        return RedirectToPage("Index");

    }
}