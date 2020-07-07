using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PhoneApp.Data;
using PhoneApp.Models;

namespace PhoneApp.Pages.Events
{
    public class CreateModel : PageModel
    {
        private readonly PhoneContext _context;

        public CreateModel(PhoneContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["CallID"] = new SelectList(_context.Calls, "CallID", "CallID");
        ViewData["EventTypeID"] = new SelectList(_context.EventTypes, "EventTypeID", "EventTypeID");
            return Page();
        }

        [BindProperty]
        public Event Event { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Events.Add(Event);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
