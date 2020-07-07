using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PhoneApp.Data;
using PhoneApp.Models;

namespace PhoneApp.Pages.Calls
{
    public class IndexModel : PageModel
    {
        private readonly PhoneContext _context;

        public IndexModel(PhoneContext context)
        {
            _context = context;
        }

        public IList<Call> Call { get;set; }

        public async Task OnGetAsync()
        {
            Call = await _context.Calls.ToListAsync();
        }
    }
}
