using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ComplaintsAPI.Models
{
    public partial class CommunityGateDatabaseContext : DbContext
    {
        public CommunityGateDatabaseContext()
        {
        }

        public CommunityGateDatabaseContext(DbContextOptions<CommunityGateDatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Complaints> Complaints { get; set; }
        public virtual DbSet<DashBoardPosts> DashBoardPosts { get; set; }
        public virtual DbSet<Employees> Employees { get; set; }
        public virtual DbSet<FriendsAndFamily> FriendsAndFamily { get; set; }
        public virtual DbSet<HouseList> HouseList { get; set; }
        public virtual DbSet<Payments> Payments { get; set; }
        public virtual DbSet<Residents> Residents { get; set; }
        public virtual DbSet<Services> Services { get; set; }
        public virtual DbSet<Visitors> Visitors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.;Database=CommunityGateDatabase;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Complaints>(entity =>
            {
                entity.HasKey(e => e.ComplaintId);

                entity.Property(e => e.ComplaintId).HasColumnName("ComplaintID");

                entity.Property(e => e.ComplaintRegarding)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ComplaintStatus)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ResidentId).HasColumnName("ResidentID");

                entity.HasOne(d => d.Resident)
                    .WithMany(p => p.Complaints)
                    .HasForeignKey(d => d.ResidentId)
                    .HasConstraintName("FK_Complaints_Residents");
            });

            modelBuilder.Entity<DashBoardPosts>(entity =>
            {
                entity.HasKey(e => e.DashItemId);

                entity.Property(e => e.DashItemId).HasColumnName("DashItemID");

                entity.Property(e => e.DashBody)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DashIntendedFor)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DashTime).HasColumnType("datetime");

                entity.Property(e => e.DashTitle)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DashType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ResidentId).HasColumnName("ResidentID");

                entity.HasOne(d => d.Resident)
                    .WithMany(p => p.DashBoardPosts)
                    .HasForeignKey(d => d.ResidentId)
                    .HasConstraintName("FK_DashBoardPosts_Residents");
            });

            modelBuilder.Entity<Employees>(entity =>
            {
                entity.HasKey(e => e.EmployeeId);

                entity.Property(e => e.EmployeeDept)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EmployeeEmail)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EmployeeMobile)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EmployeeName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EmployeePassword)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IsApproved)
                    .HasColumnName("isApproved")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<FriendsAndFamily>(entity =>
            {
                entity.HasKey(e => e.FaFid);

                entity.Property(e => e.FaFid).HasColumnName("FaFID");

                entity.Property(e => e.FaFname)
                    .HasColumnName("FaFName")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Relation)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ResidentId).HasColumnName("ResidentID");

                entity.HasOne(d => d.Resident)
                    .WithMany(p => p.FriendsAndFamily)
                    .HasForeignKey(d => d.ResidentId)
                    .HasConstraintName("FK_FriendsAndFamily_Residents");
            });

            modelBuilder.Entity<HouseList>(entity =>
            {
                entity.HasKey(e => e.HouseId);

                entity.Property(e => e.HouseId).HasColumnName("HouseID");

                entity.Property(e => e.IsFree)
                    .HasColumnName("isFree")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Payments>(entity =>
            {
                entity.HasKey(e => e.PaymentId);

                entity.Property(e => e.PaymentId).HasColumnName("PaymentID");

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.PaymentFor)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PaymentStatus)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ResidentId).HasColumnName("ResidentID");

                entity.Property(e => e.ServiceId).HasColumnName("ServiceID");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Payments)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK_Payments_Employees");

                entity.HasOne(d => d.Resident)
                    .WithMany(p => p.Payments)
                    .HasForeignKey(d => d.ResidentId)
                    .HasConstraintName("FK_Payments_Residents");

                entity.HasOne(d => d.Service)
                    .WithMany(p => p.Payments)
                    .HasForeignKey(d => d.ServiceId)
                    .HasConstraintName("FK_Payments_Services");
            });

            modelBuilder.Entity<Residents>(entity =>
            {
                entity.HasKey(e => e.ResidentId);

                entity.Property(e => e.ResidentId).HasColumnName("ResidentID");

                entity.Property(e => e.IsApproved)
                    .HasColumnName("isApproved")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ResidentEmail)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ResidentMobileNo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ResidentName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ResidentPassword)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ResidentType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.ResidentHouseNoNavigation)
                    .WithMany(p => p.Residents)
                    .HasForeignKey(d => d.ResidentHouseNo)
                    .HasConstraintName("FK_Residents_HouseList");
            });

            modelBuilder.Entity<Services>(entity =>
            {
                entity.HasKey(e => e.ServiceId);

                entity.Property(e => e.ServiceId).HasColumnName("ServiceID");

                entity.Property(e => e.AppointmentTime).HasColumnType("datetime");

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.ResidentId).HasColumnName("ResidentID");

                entity.Property(e => e.ServiceMessage)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ServiceStatus)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ServiceType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Services)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK_Services_Employees");

                entity.HasOne(d => d.Resident)
                    .WithMany(p => p.Services)
                    .HasForeignKey(d => d.ResidentId)
                    .HasConstraintName("FK_Services_Residents");
            });

            modelBuilder.Entity<Visitors>(entity =>
            {
                entity.HasKey(e => e.VisitorId);

                entity.Property(e => e.VisitorId).HasColumnName("VisitorID");

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.ResidentId).HasColumnName("ResidentID");

                entity.Property(e => e.VisitEndTime).HasColumnType("datetime");

                entity.Property(e => e.VisitStartTime).HasColumnType("datetime");

                entity.Property(e => e.VisitorEntryStatus)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.VisitorName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.VisitorResaon)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Visitors)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK_Visitors_Employees");

                entity.HasOne(d => d.Resident)
                    .WithMany(p => p.Visitors)
                    .HasForeignKey(d => d.ResidentId)
                    .HasConstraintName("FK_Visitors_Residents");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
