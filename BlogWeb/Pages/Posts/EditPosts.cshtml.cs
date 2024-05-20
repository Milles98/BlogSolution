using BlogLibrary.Data;
using BlogWeb.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BlogWeb.Pages.Posts;

public class EditPosts : PageModel
{
    private readonly ApplicationDbContext _context;

    public EditPosts(ApplicationDbContext context)
    {
        _context = context;
    }
    
    [BindProperty]
    public BlogPost Post { get; set; }
            
    public void OnGet()
    {
        
    }
    
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        _context.Attach(Post).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!PostExists(Post.Id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return RedirectToPage("./Index");
    }

    private bool PostExists(int id)
    {
        return _context.BlogPosts.Any(e => e.Id == id);
    }
}