using ComplaintsAPI.Models;
using ComplaintsAPI.Repositories;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace ComplaintsUnitTestingProject
{
    public class Tests
    {
        List<Complaints> complaints = new List<Complaints>();
        IQueryable<Complaints> complaintsdata;
        Mock<DbSet<Complaints>> mockSet;
        Mock<CommunityGateDatabaseContext> communityGateContextMock;
        [SetUp]
        public void Setup()
        {

            complaints = new List<Complaints>()
            {
                new Complaints{ComplaintId = 6001, ComplaintRegarding = "Plumbing",ComplaintStatus = "Unresolved", ResidentId = 101},
                new Complaints{ComplaintId = 6002, ComplaintRegarding = "Elevetor",ComplaintStatus = "Resolved", ResidentId = 102},
                new Complaints{ComplaintId = 6003, ComplaintRegarding = "Waste Disposal",ComplaintStatus = "Resolved", ResidentId = 101}
            };
            complaintsdata = complaints.AsQueryable();
            mockSet = new Mock<DbSet<Complaints>>();
            mockSet.As<IQueryable<Complaints>>().Setup(m => m.Provider).Returns(complaintsdata.Provider);
            mockSet.As<IQueryable<Complaints>>().Setup(m => m.Expression).Returns(complaintsdata.Expression);
            mockSet.As<IQueryable<Complaints>>().Setup(m => m.ElementType).Returns(complaintsdata.ElementType);
            mockSet.As<IQueryable<Complaints>>().Setup(m => m.GetEnumerator()).Returns(complaintsdata.GetEnumerator());
            var p = new DbContextOptions<CommunityGateDatabaseContext>();
            communityGateContextMock = new Mock<CommunityGateDatabaseContext>(p);
            communityGateContextMock.Setup(x => x.Complaints).Returns(mockSet.Object);
        }

        [Test]
        public void GetAllComplaintsTest()
        {

            var compRepo = new CompRepos(communityGateContextMock.Object);
            var compList = compRepo.GetAllComplaints();
            Assert.AreEqual(3, compList.Count());
        }
        //[Test]
        //public void GetComplaintsByIdTest()
        //{
        //    var compRepo = new CompRepos(communityGateContextMock.Object);
        //    var result = compRepo.GetComplaintById(6001);
        //    string complaintRegarding = result.ComplaintRegarding;
        //    Assert.AreEqual("Plumbing", complaintRegarding);
        //}
        [Test]
        public void GetComplaintByResidentIdTest()
        {
            var compRepo = new CompRepos(communityGateContextMock.Object);
            var compList = compRepo.GetComplaintsByResidentId(101);
            Assert.AreEqual(1, compList.Count());
        }
        [Test]
        public void PostComplaintsTest()
        {
            var compRepo = new CompRepos(communityGateContextMock.Object);
            var compObj = compRepo.PostComplaint(new Complaints { ComplaintId = 6004, ComplaintRegarding = "Cleaning", ComplaintStatus = "Unresolved", ResidentId = 102 });
            Assert.IsNotNull(compObj);
        }
        [Test]
        public void UpdateComplaintStatusTest()
        {
            var compRepo = new CompRepos(communityGateContextMock.Object);
            var compObj = compRepo.UpdateComplaint(6001);
            Assert.IsNotNull(compObj);
        }
    }
}