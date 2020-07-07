using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PhoneApp.Data;
using PhoneApp.Models;

namespace PhoneApp.Pages.Calls
{
    public class DeleteModel : PageModel
    {
        private readonly PhoneContext _context;

        public DeleteModel(PhoneContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Call Call { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Call = await _context.Calls.FirstOrDefaultAsync(m => m.CallID == id);

            if (Call == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Call = await _context.Calls.FindAsync(id);

            if (Call != null)
            {
                _context.Calls.Remove(Call);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
