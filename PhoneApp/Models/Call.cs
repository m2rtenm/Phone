using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhoneApp.Models
{
    public class Call
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CallID { get; set; }
        [RegularExpression(@"(^3|^5|^8)")]
        [StringLength(6, MinimumLength = 6)]
        public string Caller { get; set; }
#nullable enable
        [RegularExpression(@"(^3|^5|^8)")]
        [StringLength(6, MinimumLength = 6)]
        [DisplayFormat(NullDisplayText = "Not dialled")]
        public string? Receiver { get; set; }
#nullable disable
        public ICollection<Event> Events { get; set; }

    }
}