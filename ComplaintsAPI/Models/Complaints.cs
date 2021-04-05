using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ComplaintsAPI.Models
{
    public partial class Complaints
    {
        public int ComplaintId { get; set; }
        public int? ResidentId { get; set; }
        public string ComplaintRegarding { get; set; }
        public string ComplaintStatus { get; set; }

        public virtual Residents Resident { get; set; }
    }
}
