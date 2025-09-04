using DockerLabb1.Data;
using DockerLabb1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace DockerLabb1.Pages;

public class TodosModel(AppDbContext db) : PageModel
{
    public List<TodoItem> Items { get; set; } = new();
    [BindProperty] public string NewTitle { get; set; } = "";

    public async Task OnGet()
        => Items = await db.Todos.AsNoTracking().OrderBy(t => t.Id).ToListAsync();

    public async Task<IActionResult> OnPost()
    {
        if (!string.IsNullOrWhiteSpace(NewTitle))
        {
            db.Todos.Add(new TodoItem { Title = NewTitle });
            await db.SaveChangesAsync();
        }
        return RedirectToPage();
    }

    public async Task<IActionResult> OnPostToggle(int id)
    {
        var t = await db.Todos.FindAsync(id);
        if (t is not null) { t.Done = !t.Done; await db.SaveChangesAsync(); }
        return RedirectToPage();
    }

    public async Task<IActionResult> OnPostDelete(int id)
    {
        var t = await db.Todos.FindAsync(id);
        if (t is not null) { db.Todos.Remove(t); await db.SaveChangesAsync(); }
        return RedirectToPage();
    }
}
