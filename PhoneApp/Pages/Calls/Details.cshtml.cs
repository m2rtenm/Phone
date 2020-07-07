using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PhoneApp.Data;
using PhoneApp.Models;

namespace PhoneApp.Pages.Calls
{
    public class DetailsModel : PageModel
    {
        private readonly PhoneContext _context;

        public DetailsModel(PhoneContext context)
        {
            _context = context;
        }
        
        [ViewData] public string CallType { get; set; }
        public Call Call { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            IQueryable<Call> callIQ = from c in _context.Calls.Include(e => e.Events).ThenInclude(c => c.EventType) where c.CallID == id select c;

            //Call = await _context.Calls.FirstOrDefaultAsync(m => m.CallID == id);
            Call = await callIQ.FirstOrDefaultAsync(m => m.CallID == id);

            if (Call == null)
            {
                return NotFound();
            }

            var call = await _context.Calls.FindAsync(id);
            var eventcount = _context.Entry(call).Collection(e => e.Events).Query().Count();

            switch (eventcount)
            {
                case 2:
                    CallType = "Non-dialled call";
                    break;
                case 4:
                    CallType = "Cancelled call";
                    break;
                case 0:
                    CallType = "Not defined yet";
                    break;
                default:
                    CallType = "Regular call";
                    break;
            }

            return Page();
        }
    }
}
