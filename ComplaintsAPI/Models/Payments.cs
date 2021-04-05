using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ComplaintsAPI.Models
{
    public partial class Payments
    {
        public int PaymentId { get; set; }
        public string PaymentFor { get; set; }
        public int? Amount { get; set; }
        public int? ResidentId { get; set; }
        public int? EmployeeId { get; set; }
        public string PaymentStatus { get; set; }
        public int? ServiceId { get; set; }

        public virtual Employees Employee { get; set; }
        public virtual Residents Resident { get; set; }
        public virtual Services Service { get; set; }
    }
}
