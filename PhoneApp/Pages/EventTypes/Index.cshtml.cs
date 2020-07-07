using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PhoneApp.Data;
using PhoneApp.Models;

namespace PhoneApp.Pages.EventTypes
{
    public class IndexModel : PageModel
    {
        private readonly PhoneContext _context;

        public IndexModel(PhoneContext context)
        {
            _context = context;
        }

        public IList<EventType> EventType { get;set; }

        public async Task OnGetAsync()
        {
            EventType = await _context.EventTypes.ToListAsync();
        }
    }
}
