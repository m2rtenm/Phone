using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PhoneApp.Data;
using PhoneApp.Models;

namespace PhoneApp.Pages.EventTypes
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
            return Page();
        }

        [BindProperty]
        public EventType EventType { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.EventTypes.Add(EventType);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
