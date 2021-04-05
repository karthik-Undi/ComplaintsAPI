using ComplaintsAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComplaintsAPI.Repositories
{
    public interface ICompRepos
    {
        IEnumerable<Complaints> GetAllComplaints();
        Complaints GetComplaintById(int id);
        Task<Complaints> PostComplaint(Complaints item);
        Task<Complaints> UpdateComplaint(Complaints item, int id);
        IEnumerable<Complaints> GetComplaintsByResidentId(int id);
    }
}
