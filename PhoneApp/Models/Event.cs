using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhoneApp.Models
{
    public class Event
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EventID { get; set; }
        [Display(Name = "Event Type ID")]
        public string EventTypeID { get; set; }
        [Display(Name="Record Date")]
        public DateTime RecordDate { get; set; }
        [Display(Name = "Call ID")]
        public int CallID { get; set; }

        public EventType EventType { get; set; }
        public Call Call { get; set; }
    }
}