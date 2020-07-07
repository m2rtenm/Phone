using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PhoneApp.Data;
using PhoneApp.Models;

namespace PhoneApp.Pages.EventTypes
{
    public class DeleteModel : PageModel
    {
        private readonly PhoneContext _context;

        public DeleteModel(PhoneContext context)
        {
            _context = context;
        }

        [BindProperty]
        public EventType EventType { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            EventType = await _context.EventTypes.FirstOrDefaultAsync(m => m.EventTypeID == id);

            if (EventType == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            EventType = await _context.EventTypes.FindAsync(id);

            if (EventType != null)
            {
                _context.EventTypes.Remove(EventType);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
