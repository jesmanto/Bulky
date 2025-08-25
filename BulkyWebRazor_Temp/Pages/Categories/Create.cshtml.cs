using BulkyWebRazor_Temp.Data;
using BulkyWebRazor_Temp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BulkyWebRazor_Temp.Pages.Categories;

public class Create(ApplicationDbContext db) : PageModel
{
    private readonly ApplicationDbContext _db = db;
    [BindProperty]
    public Category Category { get; set; }

    public void OnGet()
    {
    }

    public IActionResult OnPost()
    {
        _db.Categories.Add(Category);
        _db.SaveChanges();
        TempData["success"] = "Category added successfully";
        return RedirectToPage("/Categories/Index");
    }
}