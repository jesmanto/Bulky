using BulkyWebRazor_Temp.Data;
using BulkyWebRazor_Temp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BulkyWebRazor_Temp.Pages.Categories;

[BindProperties]
public class Delete(ApplicationDbContext db) : PageModel
{
    public Category category {set; get;}
    public void OnGet(int? id)
    {
        if(id!=null && id > 0)
            category = db.Categories.Find(id);
    }

    public IActionResult OnPost()
    {
        db.Categories.Remove(category);
        db.SaveChanges();
        TempData["success"] = "Category deleted successfully";
        return RedirectToPage("Index");
    }
}