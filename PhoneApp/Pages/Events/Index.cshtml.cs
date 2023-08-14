using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PhoneApp.Data;
using PhoneApp.Models;
using OfficeOpenXml;

namespace PhoneApp.Pages.Events
{
    public class IndexModel : PageModel
    {
        private readonly PhoneContext _context;

        public IndexModel(PhoneContext context)
        {
            _context = context;
        }

        public string CallerSort { get; set; }
        public string ReceiverSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }
        public PaginatedList<Event> Event { get;set; }

        public async Task OnGetAsync(string sortOrder, string searchString, string currentFilter, int? pageIndex)
        {
            CurrentSort = sortOrder;

            CallerSort = sortOrder == "caller_asc" ? "caller_desc" : "caller_asc";
            ReceiverSort = sortOrder == "receiver_asc" ? "receiver_desc" : "receiver_asc";

            if (searchString != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            CurrentFilter = searchString;

            IQueryable<Event> eventsIQ = from e in _context.Events select e;

            if (!String.IsNullOrEmpty(searchString))
            {
                eventsIQ = eventsIQ.Where(e => e.Call.Caller.Contains(searchString) || e.Call.Receiver.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "caller_desc":
                    eventsIQ = eventsIQ.OrderByDescending(e => e.Call.Caller);
                    break;
                case "receiver_desc":
                    eventsIQ = eventsIQ.OrderByDescending(e => e.Call.Receiver);
                    break;
                case "caller_asc":
                    eventsIQ = eventsIQ.OrderBy(e => e.Call.Caller);
                    break;
                case "receiver_asc":
                    eventsIQ = eventsIQ.OrderBy(e => e.Call.Receiver);
                    break;
                default:
                    eventsIQ = eventsIQ.OrderBy(e => e.EventID);
                    break;
            }

            int pageSize = 10;

            //Event = await eventsIQ.Include(a => a.Call).Include(a => a.EventType).AsNoTracking().ToListAsync();
            Event = await PaginatedList<Event>.CreateAsync(eventsIQ.Include(a => a.Call).Include(a => a.EventType).AsNoTracking(), pageIndex ?? 1, pageSize);
        }

        public async Task<IActionResult> OnPostExportExcelAsync()
        {
            var events = await _context.Events.Include(e => e.Call).Include(a => a.EventType).
                Select(e => new
                {
                    e.Call.Caller,
                    e.EventType.EventName,
                    e.Call.Receiver,
                    e.RecordDate
                })
                .ToListAsync();
            var stream = new MemoryStream();

            using (var package  = new  ExcelPackage(stream))
            {
                var workSheet = package.Workbook.Worksheets.Add("Sheet1");
                workSheet.Cells.LoadFromCollection(events, true);
                //workSheet.Cells.LoadFromCollection(events, true);
                package.Save();
            }

            stream.Position = 0;

            string excelName = $"all_records_{DateTime.Now.ToString("yyyyMMddHHmmss")}.csv";

            return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", excelName);
        }
    }
}
