using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PhoneApp.Models
{
    public class EventType
    {
        [Display(Name="Event Type ID")]
        public string EventTypeID { get; set; }
        [Display(Name="Event Name")]
        public string EventName { get; set; }

        public ICollection<Event> Events { get; set; }
    }
}