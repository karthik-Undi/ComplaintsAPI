using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ComplaintsAPI.Models
{
    public partial class HouseList
    {
        public HouseList()
        {
            Residents = new HashSet<Residents>();
        }

        public int HouseId { get; set; }
        public string IsFree { get; set; }

        public virtual ICollection<Residents> Residents { get; set; }
    }
}
