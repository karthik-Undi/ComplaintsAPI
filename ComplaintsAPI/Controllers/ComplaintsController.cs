using ComplaintsAPI.Models;
using ComplaintsAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComplaintsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComplaintsController : ControllerBase
    {
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(ComplaintsController));
        private readonly ICompRepos _context;

        public ComplaintsController(ICompRepos context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Complaints> GetAllComplaints()
        {
            _log4net.Info("Get All Complaints Was Called !!");
            return _context.GetAllComplaints();
        }

        [HttpGet("{id}")]
        public IActionResult GetComplaintById(int id)
        {
            _log4net.Info("Get Complaint By Id Was Called !!");
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var complaint = _context.GetComplaintById(id);
                _log4net.Info("Complaint of Id " + id + " Was Called");
                if (complaint == null)
                {
                    return NotFound();
                }
                return Ok(complaint);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("GetComplaintByResidentId/{id}")]
        public IActionResult GetComplaintsByResidentId(int id)
        {
            _log4net.Info("Get Complaints By Resident Id Was Called !!");
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            try
            {
                var complaints = _context.GetComplaintsByResidentId(id);
                _log4net.Info("Complaitns Of Resident Id " + id + " Was Called !!");
                if (complaints == null)
                {
                    return NotFound();
                }
                return Ok(complaints);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpPost]
        public async Task<IActionResult> PostComplaint(Complaints item)
        {
            _log4net.Info("Post Complaints Was Called !!");
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var addComplaint = await _context.PostComplaint(item);
                return Ok(addComplaint);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> UpdateComplaint(int id)
        {
            _log4net.Info("Update Complaint Was Called !!");
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var updateComplaint = await _context.UpdateComplaint(id);
                _log4net.Info("Update Complaint By Id " + id + " Was Called !!");
                return Ok(updateComplaint);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
