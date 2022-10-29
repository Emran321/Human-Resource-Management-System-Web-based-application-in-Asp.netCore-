using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace HRMSProject.Data
{
    public partial class HRMSDbContext : DbContext
    {
        public HRMSDbContext()
        {
        }

        public HRMSDbContext(DbContextOptions<HRMSDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Attendance> Attendances { get; set; }
        public virtual DbSet<Bank> Banks { get; set; }
        public virtual DbSet<Branch> Branches { get; set; }
        public virtual DbSet<CompanySetup> CompanySetups { get; set; }
        public virtual DbSet<CompanyType> CompanyTypes { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Designation> Designations { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<EmployeeLeave> EmployeeLeaves { get; set; }
        public virtual DbSet<EmployeeOverTimeRate> EmployeeOverTimeRates { get; set; }
        public virtual DbSet<EmployeeType> EmployeeTypes { get; set; }
        public virtual DbSet<EmployeeWiseOverTimeHour> EmployeeWiseOverTimeHours { get; set; }
        public virtual DbSet<Gender> Genders { get; set; }
        public virtual DbSet<GeneralOverTimeHour> GeneralOverTimeHours { get; set; }
        public virtual DbSet<Grade> Grades { get; set; }
        public virtual DbSet<LeaveType> LeaveTypes { get; set; }
        public virtual DbSet<MaritialStatus> MaritialStatuses { get; set; }
        public virtual DbSet<Nationality> Nationalities { get; set; }
        public virtual DbSet<OverTimeRate> OverTimeRates { get; set; }
        public virtual DbSet<Religion> Religions { get; set; }
        public virtual DbSet<Salary> Salaries { get; set; }
        public virtual DbSet<SalaryBreakeDown> SalaryBreakeDowns { get; set; }
        public virtual DbSet<SalaryHead> SalaryHeads { get; set; }
        public virtual DbSet<SalaryRole> SalaryRoles { get; set; }
        public virtual DbSet<Shift> Shifts { get; set; }
        public virtual DbSet<WeekDay> WeekDays { get; set; }
        public virtual DbSet<WorkStation> WorkStations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-9F3H6K0;Database=HRMSDb;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Attendance>(entity =>
            {
                entity.ToTable("Attendance");

                entity.Property(e => e.AttendanceId).HasColumnName("AttendanceID");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.InTime).HasColumnType("datetime");

                entity.Property(e => e.LateTime).HasColumnType("datetime");

                entity.Property(e => e.OutTime).HasColumnType("datetime");

                entity.Property(e => e.OverTimeHour)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TotalWorkingHour)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Attendances)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK__Attendanc__Emplo__693CA210");
            });

            modelBuilder.Entity<Bank>(entity =>
            {
                entity.ToTable("Bank");

                entity.Property(e => e.BankId).HasColumnName("BankID");

                entity.Property(e => e.BankName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Branch>(entity =>
            {
                entity.ToTable("Branch");

                entity.Property(e => e.BranchId).HasColumnName("BranchID");

                entity.Property(e => e.BranchLocation)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.BranchName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CompanyId).HasColumnName("CompanyID");

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.Branches)
                    .HasForeignKey(d => d.CompanyId)
                    .HasConstraintName("FK__Branch__CompanyI__6A30C649");
            });

            modelBuilder.Entity<CompanySetup>(entity =>
            {
                entity.HasKey(e => e.CompanyId)
                    .HasName("PK__CompanyS__2D971CAC1FC5EBB0");

                entity.ToTable("CompanySetup");

                entity.Property(e => e.Address).HasMaxLength(50);

                entity.Property(e => e.CompanyName).HasMaxLength(50);

                entity.Property(e => e.CompanyStartDate).HasColumnType("date");

                entity.Property(e => e.CompanyTypeId).HasColumnName("CompanyTypeID");

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Fax).HasMaxLength(50);

                entity.Property(e => e.PhoneNumber).HasMaxLength(50);

                entity.Property(e => e.RegistrationNo).HasMaxLength(50);

                entity.HasOne(d => d.CompanyType)
                    .WithMany(p => p.CompanySetups)
                    .HasForeignKey(d => d.CompanyTypeId)
                    .HasConstraintName("FK__CompanySe__Compa__6B24EA82");
            });

            modelBuilder.Entity<CompanyType>(entity =>
            {
                entity.ToTable("CompanyType");

                entity.Property(e => e.CompanyTypeId).HasColumnName("CompanyTypeID");

                entity.Property(e => e.CompanyTypeName).HasMaxLength(50);
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.ToTable("Department");

                entity.Property(e => e.BranchId).HasColumnName("BranchID");

                entity.Property(e => e.DepartmentName).HasMaxLength(50);

                entity.HasOne(d => d.Branch)
                    .WithMany(p => p.Departments)
                    .HasForeignKey(d => d.BranchId)
                    .HasConstraintName("FK__Departmen__Branc__6C190EBB");
            });

            modelBuilder.Entity<Designation>(entity =>
            {
                entity.ToTable("Designation");

                entity.Property(e => e.DesignationName).HasMaxLength(50);
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("Employee");

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.DateOfBirth).HasColumnType("date");

                entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");

                entity.Property(e => e.DesignationId).HasColumnName("DesignationID");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EmployeeName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EmployeeTypeId).HasColumnName("EmployeeTypeID");

                entity.Property(e => e.FatherName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.GradeId).HasColumnName("GradeID");

                entity.Property(e => e.HomePhone)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MaritialStatusId).HasColumnName("MaritialStatusID");

                entity.Property(e => e.Mobile)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MotherName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NationalityId).HasColumnName("NationalityID");

                entity.Property(e => e.ParmanentAddress)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PresentAddress)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ReligionId).HasColumnName("ReligionID");

                entity.Property(e => e.ShiftId).HasColumnName("ShiftID");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.DepartmentId)
                    .HasConstraintName("FK__Employee__Depart__6D0D32F4");

                entity.HasOne(d => d.Designation)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.DesignationId)
                    .HasConstraintName("FK__Employee__Design__6E01572D");

                entity.HasOne(d => d.EmployeeType)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.EmployeeTypeId)
                    .HasConstraintName("FK__Employee__Employ__70DDC3D8");

                entity.HasOne(d => d.Grade)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.GradeId)
                    .HasConstraintName("FK__Employee__GradeI__6EF57B66");

                entity.HasOne(d => d.MaritialStatus)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.MaritialStatusId)
                    .HasConstraintName("FK__Employee__Mariti__73BA3083");

                entity.HasOne(d => d.Nationality)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.NationalityId)
                    .HasConstraintName("FK__Employee__Nation__71D1E811");

                entity.HasOne(d => d.Religion)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.ReligionId)
                    .HasConstraintName("FK__Employee__Religi__72C60C4A");

                entity.HasOne(d => d.Shift)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.ShiftId)
                    .HasConstraintName("FK__Employee__ShiftI__6FE99F9F");
            });

            modelBuilder.Entity<EmployeeLeave>(entity =>
            {
                entity.HasKey(e => e.EmplaoyeeLeaveId)
                    .HasName("PK__Employee__B310F72B3A1C3B36");

                entity.ToTable("EmployeeLeave");

                entity.Property(e => e.EmplaoyeeLeaveId).HasColumnName("EmplaoyeeLeaveID");

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.FromDate).HasColumnType("date");

                entity.Property(e => e.LeaveTypeId).HasColumnName("LeaveTypeID");

                entity.Property(e => e.Status)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ToDate).HasColumnType("date");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.EmployeeLeaves)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK__EmployeeL__Emplo__74AE54BC");

                entity.HasOne(d => d.LeaveType)
                    .WithMany(p => p.EmployeeLeaves)
                    .HasForeignKey(d => d.LeaveTypeId)
                    .HasConstraintName("FK__EmployeeL__Leave__75A278F5");
            });

            modelBuilder.Entity<EmployeeOverTimeRate>(entity =>
            {
                entity.ToTable("EmployeeOverTimeRate");

                entity.Property(e => e.EmployeeOverTimeRateId).HasColumnName("EmployeeOverTimeRateID");

                entity.Property(e => e.Days)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.OverTimeRateId).HasColumnName("OverTimeRateID");

                entity.Property(e => e.RateAmount)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.EmployeeOverTimeRates)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK__EmployeeO__Emplo__76969D2E");

                entity.HasOne(d => d.OverTimeRate)
                    .WithMany(p => p.EmployeeOverTimeRates)
                    .HasForeignKey(d => d.OverTimeRateId)
                    .HasConstraintName("FK__EmployeeO__OverT__778AC167");
            });

            modelBuilder.Entity<EmployeeType>(entity =>
            {
                entity.ToTable("EmployeeType");

                entity.Property(e => e.EmployeeTypeId).HasColumnName("EmployeeTypeID");

                entity.Property(e => e.EmployeeTypeName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.OverTimeAllowed)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<EmployeeWiseOverTimeHour>(entity =>
            {
                entity.ToTable("EmployeeWiseOverTimeHour");

                entity.Property(e => e.EmployeeWiseOverTimeHourId).HasColumnName("EmployeeWiseOverTimeHourID");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.EmployeeWiseOverTimeHours)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK__EmployeeW__Emplo__787EE5A0");
            });

            modelBuilder.Entity<Gender>(entity =>
            {
                entity.ToTable("Gender");

                entity.Property(e => e.GenderId).HasColumnName("GenderID");

                entity.Property(e => e.GenderName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<GeneralOverTimeHour>(entity =>
            {
                entity.ToTable("GeneralOverTimeHour");

                entity.Property(e => e.GeneralOverTimeHourId).HasColumnName("GeneralOverTimeHourID");

                entity.Property(e => e.Date).HasColumnType("datetime");
            });

            modelBuilder.Entity<Grade>(entity =>
            {
                entity.ToTable("Grade");

                entity.Property(e => e.GradeId).HasColumnName("GradeID");

                entity.Property(e => e.GradeName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.GradeSalary).HasColumnType("decimal(18, 0)");
            });

            modelBuilder.Entity<LeaveType>(entity =>
            {
                entity.ToTable("LeaveType");

                entity.Property(e => e.LeaveTypeId).HasColumnName("LeaveTypeID");

                entity.Property(e => e.GenderId).HasColumnName("GenderID");

                entity.Property(e => e.LeaveTypeName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Gender)
                    .WithMany(p => p.LeaveTypes)
                    .HasForeignKey(d => d.GenderId)
                    .HasConstraintName("FK__LeaveType__Gende__797309D9");
            });

            modelBuilder.Entity<MaritialStatus>(entity =>
            {
                entity.ToTable("MaritialStatus");

                entity.Property(e => e.MaritialStatusId).HasColumnName("MaritialStatusID");

                entity.Property(e => e.MaritialStatusName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Nationality>(entity =>
            {
                entity.ToTable("Nationality");

                entity.Property(e => e.NationalityId).HasColumnName("NationalityID");

                entity.Property(e => e.NationalityName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<OverTimeRate>(entity =>
            {
                entity.ToTable("OverTimeRate");

                entity.Property(e => e.OverTimeRateId).HasColumnName("OverTimeRateID");

                entity.Property(e => e.Rate)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Religion>(entity =>
            {
                entity.ToTable("Religion");

                entity.Property(e => e.ReligionId).HasColumnName("ReligionID");

                entity.Property(e => e.ReligionName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Salary>(entity =>
            {
                entity.ToTable("Salary");

                entity.Property(e => e.SalaryId).HasColumnName("SalaryID");

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.GrandTotal).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Month).HasColumnName("month");

                entity.Property(e => e.OverTime).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.OvertimeHour).HasColumnType("datetime");

                entity.Property(e => e.TotalSalary).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Salaries)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK__Salary__Employee__7A672E12");
            });

            modelBuilder.Entity<SalaryBreakeDown>(entity =>
            {
                entity.HasKey(e => e.BreakdownId)
                    .HasName("PK__SalaryBr__B4C97408DC3E36AF");

                entity.ToTable("SalaryBreakeDown");

                entity.Property(e => e.BreakdownId).HasColumnName("BreakdownID");

                entity.Property(e => e.Amount).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.GradeId).HasColumnName("GradeID");

                entity.Property(e => e.SalaryHeadId).HasColumnName("SalaryHeadID");

                entity.HasOne(d => d.Grade)
                    .WithMany(p => p.SalaryBreakeDowns)
                    .HasForeignKey(d => d.GradeId)
                    .HasConstraintName("FK__SalaryBre__Grade__7B5B524B");

                entity.HasOne(d => d.SalaryHead)
                    .WithMany(p => p.SalaryBreakeDowns)
                    .HasForeignKey(d => d.SalaryHeadId)
                    .HasConstraintName("FK__SalaryBre__Salar__7C4F7684");
            });

            modelBuilder.Entity<SalaryHead>(entity =>
            {
                entity.ToTable("SalaryHead");

                entity.Property(e => e.SalaryHeadId).HasColumnName("SalaryHeadID");

                entity.Property(e => e.SalaryHeadName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SalaryHeadType)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SalaryRole>(entity =>
            {
                entity.Property(e => e.SalaryRoleId).HasColumnName("SalaryRoleID");

                entity.Property(e => e.Formula).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.GradeId).HasColumnName("GradeID");

                entity.Property(e => e.SalaryHeadId).HasColumnName("SalaryHeadID");

                entity.HasOne(d => d.SalaryHead)
                    .WithMany(p => p.SalaryRoles)
                    .HasForeignKey(d => d.SalaryHeadId)
                    .HasConstraintName("FK__SalaryRol__Salar__7D439ABD");
            });

            modelBuilder.Entity<Shift>(entity =>
            {
                entity.ToTable("Shift");

                entity.Property(e => e.ShiftId).HasColumnName("ShiftID");

                entity.Property(e => e.FromDate).HasColumnType("date");

                entity.Property(e => e.ShiftEndTime).HasColumnType("datetime");

                entity.Property(e => e.ShiftName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ShiftStartTime).HasColumnType("datetime");

                entity.Property(e => e.ToDate).HasColumnType("date");

                entity.Property(e => e.TotalTime)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<WeekDay>(entity =>
            {
                entity.HasKey(e => e.WeekDaysId)
                    .HasName("PK__WeekDays__2462ED64761BB122");

                entity.Property(e => e.WeekDaysId).HasColumnName("WeekDaysID");

                entity.Property(e => e.DayName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<WorkStation>(entity =>
            {
                entity.ToTable("WorkStation");

                entity.Property(e => e.BranchId).HasColumnName("BranchID");

                entity.Property(e => e.Location).HasMaxLength(50);

                entity.Property(e => e.PhoneNumber).HasMaxLength(50);

                entity.Property(e => e.WorkStationName).HasMaxLength(50);

                entity.HasOne(d => d.Branch)
                    .WithMany(p => p.WorkStations)
                    .HasForeignKey(d => d.BranchId)
                    .HasConstraintName("FK__WorkStati__Branc__7E37BEF6");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
