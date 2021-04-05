using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ComplaintsAPI.Models
{
    public partial class Employees
    {
        public Employees()
        {
            Payments = new HashSet<Payments>();
            Services = new HashSet<Services>();
            Visitors = new HashSet<Visitors>();
        }

        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeDept { get; set; }
        public string EmployeeMobile { get; set; }
        public string EmployeeEmail { get; set; }
        public string EmployeePassword { get; set; }
        public string IsApproved { get; set; }
        public int? EmployeeWallet { get; set; }
        public int? EmployeeRating { get; set; }

        public virtual ICollection<Payments> Payments { get; set; }
        public virtual ICollection<Services> Services { get; set; }
        public virtual ICollection<Visitors> Visitors { get; set; }
    }
}
