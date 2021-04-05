using ComplaintsAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComplaintsAPI.Repositories
{
    public class CompRepos : ICompRepos
    {
        private readonly CommunityGateDatabaseContext _context;

        public CompRepos()
        {

        }

        public CompRepos(CommunityGateDatabaseContext context)
        {
            _context = context;
        }

        public IEnumerable<Complaints> GetAllComplaints()
        {
            return _context.Complaints.ToList();
        }

        public Complaints GetComplaintById(int id)
        {
            Complaints item = _context.Complaints.Find(id);
            return item;
        }

        public IEnumerable<Complaints> GetComplaintsByResidentId(int id)
        {
            var item = _context.Complaints.Where(t => t.ResidentId == id && t.ComplaintStatus == "Unresolved").ToList();
            return item;
        }

        public async Task<Complaints> PostComplaint(Complaints item)
        {
            Complaints complaint = null;
            if(item==null)
            {
                throw new NullReferenceException();
            }
            else
            {
                complaint = new Complaints() { ResidentId = item.ResidentId, ComplaintRegarding = item.ComplaintRegarding, ComplaintStatus = "Unresolved" };
                await _context.Complaints.AddAsync(complaint);
                await _context.SaveChangesAsync();
            }
            return complaint;
        }

        public async Task<Complaints> UpdateComplaint(Complaints item,int id)
        {
            Complaints complaint = await _context.Complaints.FindAsync(id);
            complaint.ComplaintStatus = item.ComplaintStatus;
            await _context.SaveChangesAsync();
            return complaint;
        }
    }
}
