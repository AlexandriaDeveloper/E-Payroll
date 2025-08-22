using System;
using System.Collections.Generic;
using E_Payroll.API.Web.Core.E_Payroll.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace E_Payroll.API.Web.Infrastructure.E_Payroll.Infrastructure.Persistence;

public partial class ApplicationDbContext : DbContext
{
    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Attendance> Attendances { get; set; }

    public virtual DbSet<AuditLog> AuditLogs { get; set; }

    public virtual DbSet<College> Colleges { get; set; }

    public virtual DbSet<Contact> Contacts { get; set; }

    public virtual DbSet<CsDisciplinaryAction> CsDisciplinaryActions { get; set; }

    public virtual DbSet<CsDisciplinaryActionType> CsDisciplinaryActionTypes { get; set; }

    public virtual DbSet<CsEmployeeAssignment> CsEmployeeAssignments { get; set; }

    public virtual DbSet<CsGrade> CsGrades { get; set; }

    public virtual DbSet<CsPosition> CsPositions { get; set; }

    public virtual DbSet<CsPromotion> CsPromotions { get; set; }

    public virtual DbSet<CsSalaryStructure> CsSalaryStructures { get; set; }

    public virtual DbSet<CsSecondment> CsSecondments { get; set; }

    public virtual DbSet<CsSecondmentType> CsSecondmentTypes { get; set; }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Document> Documents { get; set; }

    public virtual DbSet<FacultyAllowanceDeduction> FacultyAllowanceDeductions { get; set; }

    public virtual DbSet<FacultyAppointment> FacultyAppointments { get; set; }

    public virtual DbSet<FacultyCurrentSalaryLevel> FacultyCurrentSalaryLevels { get; set; }

    public virtual DbSet<FacultyLeaveApplication> FacultyLeaveApplications { get; set; }

    public virtual DbSet<FacultyLeaveDeductionRule> FacultyLeaveDeductionRules { get; set; }

    public virtual DbSet<FacultyLeaveType> FacultyLeaveTypes { get; set; }

    public virtual DbSet<FacultyRank> FacultyRanks { get; set; }

    public virtual DbSet<FacultySalaryScale> FacultySalaryScales { get; set; }

    public virtual DbSet<LegalArticle> LegalArticles { get; set; }

    public virtual DbSet<LegalReference> LegalReferences { get; set; }

    public virtual DbSet<PayElement> PayElements { get; set; }

    public virtual DbSet<PayrollCalendar> PayrollCalendars { get; set; }

    public virtual DbSet<PayrollLine> PayrollLines { get; set; }

    public virtual DbSet<PayrollLineDetail> PayrollLineDetails { get; set; }

    public virtual DbSet<PayrollRun> PayrollRuns { get; set; }

    public virtual DbSet<Person> Persons { get; set; }

    public virtual DbSet<PersonPayAssignment> PersonPayAssignments { get; set; }

    public virtual DbSet<Request> Requests { get; set; }

    public virtual DbSet<RequestApproval> RequestApprovals { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserRole> UserRoles { get; set; }

    public virtual DbSet<VwCsCurrentEmployeesStatus> VwCsCurrentEmployeesStatuses { get; set; }

    public virtual DbSet<VwPayrollSummaryReport> VwPayrollSummaryReports { get; set; }

    public virtual DbSet<VwPersonsBasicInfo> VwPersonsBasicInfos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:DefaultConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("Arabic_CI_AS");

        modelBuilder.Entity<Attendance>(entity =>
        {
            entity.HasKey(e => e.AttendanceId).HasName("PK__Attendan__8B69261C5F7B32C5");

            entity.ToTable("Attendance");

            entity.HasIndex(e => e.AttendanceDate, "IX_Attendance_Date");

            entity.HasIndex(e => new { e.PersonId, e.AttendanceDate }, "IX_Attendance_PersonMonth");

            entity.HasIndex(e => new { e.PersonId, e.AttendanceDate }, "UQ_Attendance_PersonDate").IsUnique();

            entity.Property(e => e.AbsenceType)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.AdjustmentReason).HasMaxLength(500);
            entity.Property(e => e.AttendanceStatus)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValue("Present");
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysdatetime())");
            entity.Property(e => e.DataSource)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValue("Manual");
            entity.Property(e => e.DeviceId)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.DeviceLocation)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.EarlyDepartureMinutes).HasDefaultValue(0);
            entity.Property(e => e.ImportBatchId)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.IsEarlyDeparture).HasDefaultValue(false);
            entity.Property(e => e.IsLateArrival).HasDefaultValue(false);
            entity.Property(e => e.IsManualAdjustment).HasDefaultValue(false);
            entity.Property(e => e.LateMinutes).HasDefaultValue(0);
            entity.Property(e => e.Notes).HasMaxLength(500);
            entity.Property(e => e.Overtime)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(4, 2)");
            entity.Property(e => e.ScheduledInTime).HasDefaultValue(new TimeOnly(8, 0, 0));
            entity.Property(e => e.ScheduledOutTime).HasDefaultValue(new TimeOnly(16, 0, 0));
            entity.Property(e => e.ScheduledWorkHours)
                .HasDefaultValue(8m)
                .HasColumnType("decimal(4, 2)");
            entity.Property(e => e.Undertime)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(4, 2)");
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(sysdatetime())");
            entity.Property(e => e.WorkHours)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(4, 2)");

            entity.HasOne(d => d.Person).WithMany(p => p.Attendances)
                .HasForeignKey(d => d.PersonId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Attendance_Person");
        });

        modelBuilder.Entity<AuditLog>(entity =>
        {
            entity.HasKey(e => e.AuditId).HasName("PK__AuditLog__A17F23985382F35D");

            entity.HasIndex(e => e.TableName, "IX_AuditLogs_Table");

            entity.HasIndex(e => e.Timestamp, "IX_AuditLogs_Timestamp");

            entity.HasIndex(e => e.UserId, "IX_AuditLogs_User");

            entity.Property(e => e.ChangedFields).HasMaxLength(500);
            entity.Property(e => e.Ipaddress)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("IPAddress");
            entity.Property(e => e.Operation)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.TableName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Timestamp).HasDefaultValueSql("(sysdatetime())");
            entity.Property(e => e.UserAgent)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.UserName)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<College>(entity =>
        {
            entity.HasKey(e => e.CollegeId).HasName("PK__Colleges__294095397525D628");

            entity.HasIndex(e => e.Code, "UQ__Colleges__A25C5AA72DBC14FB").IsUnique();

            entity.Property(e => e.Code)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CreatedDate).HasDefaultValueSql("(sysdatetime())");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.Name)
                .HasMaxLength(200)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Contact>(entity =>
        {
            entity.HasKey(e => e.ContactId).HasName("PK__Contacts__5C66259BE5690833");

            entity.Property(e => e.Address)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.City)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.EmergencyContact)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.EmergencyPhone)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.EmergencyRelation)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.HomePhone)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PostalCode)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(sysdatetime())");
            entity.Property(e => e.WorkExtension)
                .HasMaxLength(10)
                .IsUnicode(false);

            entity.HasOne(d => d.Person).WithMany(p => p.Contacts)
                .HasForeignKey(d => d.PersonId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Contacts_Person");
        });

        modelBuilder.Entity<CsDisciplinaryAction>(entity =>
        {
            entity.HasKey(e => e.ActionId).HasName("PK__CS_Disci__FFE3F4D99BEE09CC");

            entity.ToTable("CS_DisciplinaryActions");

            entity.HasIndex(e => e.CaseNumber, "UQ__CS_Disci__103BB8D8C2E87BDF").IsUnique();

            entity.Property(e => e.AllowancesSuspended).HasDefaultValue(false);
            entity.Property(e => e.AppealDecision)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.AppealResult).HasMaxLength(500);
            entity.Property(e => e.AppealSubmitted).HasDefaultValue(false);
            entity.Property(e => e.CaseNumber)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysdatetime())");
            entity.Property(e => e.DecisionMaker)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.DecisionRef)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.DeductionAmount)
                .HasDefaultValue(0.00m)
                .HasColumnType("decimal(18, 2)");
            entity.Property(e => e.DeductionDays).HasDefaultValue(0);
            entity.Property(e => e.InvestigationRef)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.IsReversed).HasDefaultValue(false);
            entity.Property(e => e.PromotionBan).HasDefaultValue(false);
            entity.Property(e => e.ReversalReason).HasMaxLength(500);
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValue("Active");
            entity.Property(e => e.SuspensionWithoutPay).HasDefaultValue(false);
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(sysdatetime())");

            entity.HasOne(d => d.ActionType).WithMany(p => p.CsDisciplinaryActions)
                .HasForeignKey(d => d.ActionTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CS_DisciplinaryActions_Type");

            entity.HasOne(d => d.Person).WithMany(p => p.CsDisciplinaryActions)
                .HasForeignKey(d => d.PersonId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CS_DisciplinaryActions_Person");
        });

        modelBuilder.Entity<CsDisciplinaryActionType>(entity =>
        {
            entity.HasKey(e => e.ActionTypeId).HasName("PK__CS_Disci__62FE4C6413120BFF");

            entity.ToTable("CS_DisciplinaryActionTypes");

            entity.HasIndex(e => e.Code, "UQ__CS_Disci__A25C5AA7DAE32F1B").IsUnique();

            entity.Property(e => e.AffectsAllowances).HasDefaultValue(false);
            entity.Property(e => e.AffectsAnnualIncrease).HasDefaultValue(false);
            entity.Property(e => e.AffectsPromotion).HasDefaultValue(false);
            entity.Property(e => e.AppealPeriodDays).HasDefaultValue(30);
            entity.Property(e => e.ApplicableToGrades).HasMaxLength(200);
            entity.Property(e => e.CanBeAppealed).HasDefaultValue(true);
            entity.Property(e => e.Category)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Code)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysdatetime())");
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LegalBasis)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.MaxApplicationsPerYear).HasDefaultValue(1);
            entity.Property(e => e.MaxDeductionAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.MaxDeductionPercentage).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.MinDeductionAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Name)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.RequiresCouncilDecision).HasDefaultValue(false);
            entity.Property(e => e.RequiresHearing).HasDefaultValue(false);
            entity.Property(e => e.RequiresInvestigation).HasDefaultValue(false);
            entity.Property(e => e.SalaryImpactType)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<CsEmployeeAssignment>(entity =>
        {
            entity.HasKey(e => e.AssignmentId).HasName("PK__CS_Emplo__32499E77427ACEA5");

            entity.ToTable("CS_EmployeeAssignments");

            entity.Property(e => e.AssignmentType)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValue("Permanent");
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysdatetime())");
            entity.Property(e => e.CurrentSalary).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.DecisionRef)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Notes).HasMaxLength(500);

            entity.HasOne(d => d.Person).WithMany(p => p.CsEmployeeAssignments)
                .HasForeignKey(d => d.PersonId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CS_Assignments_Person");

            entity.HasOne(d => d.Position).WithMany(p => p.CsEmployeeAssignments)
                .HasForeignKey(d => d.PositionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CS_Assignments_Position");
        });

        modelBuilder.Entity<CsGrade>(entity =>
        {
            entity.HasKey(e => e.GradeId).HasName("PK__CS_Grade__54F87A57CE827F72");

            entity.ToTable("CS_Grades");

            entity.HasIndex(e => e.Code, "UQ__CS_Grade__A25C5AA7D1E879EA").IsUnique();

            entity.Property(e => e.Code)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CreatedDate).HasDefaultValueSql("(sysdatetime())");
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.FullGradeCode)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.SubLevel)
                .HasMaxLength(2)
                .IsUnicode(false);
        });

        modelBuilder.Entity<CsPosition>(entity =>
        {
            entity.HasKey(e => e.PositionId).HasName("PK__CS_Posit__60BB9A799D537303");

            entity.ToTable("CS_Positions");

            entity.HasIndex(e => e.Code, "UQ__CS_Posit__A25C5AA754333C16").IsUnique();

            entity.Property(e => e.Code)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CreatedDate).HasDefaultValueSql("(sysdatetime())");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.IsSupervision).HasDefaultValue(false);
            entity.Property(e => e.MaxPositions).HasDefaultValue(1);
            entity.Property(e => e.RequiredQualifications).HasMaxLength(500);
            entity.Property(e => e.Title)
                .HasMaxLength(200)
                .IsUnicode(false);

            entity.HasOne(d => d.Department).WithMany(p => p.CsPositions)
                .HasForeignKey(d => d.DepartmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CS_Positions_Department");

            entity.HasOne(d => d.Grade).WithMany(p => p.CsPositions)
                .HasForeignKey(d => d.GradeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CS_Positions_Grade");
        });

        modelBuilder.Entity<CsPromotion>(entity =>
        {
            entity.HasKey(e => e.PromotionId).HasName("PK__CS_Promo__52C42FCF6021C72B");

            entity.ToTable("CS_Promotions");

            entity.Property(e => e.BackpayAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.CommitteeMinutes)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.CouncilDecisionRef)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysdatetime())");
            entity.Property(e => e.DecisionRef)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.IsReversed).HasDefaultValue(false);
            entity.Property(e => e.NewSalary).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Notes).HasMaxLength(500);
            entity.Property(e => e.OldSalary).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.PerformanceRating)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.PromotionType)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.ReversalReason).HasMaxLength(500);
            entity.Property(e => e.SalaryIncrease).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.FromGrade).WithMany(p => p.CsPromotionFromGrades)
                .HasForeignKey(d => d.FromGradeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CS_Promotions_FromGrade");

            entity.HasOne(d => d.Person).WithMany(p => p.CsPromotions)
                .HasForeignKey(d => d.PersonId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CS_Promotions_Person");

            entity.HasOne(d => d.ToGrade).WithMany(p => p.CsPromotionToGrades)
                .HasForeignKey(d => d.ToGradeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CS_Promotions_ToGrade");
        });

        modelBuilder.Entity<CsSalaryStructure>(entity =>
        {
            entity.HasKey(e => e.StructureId).HasName("PK__CS_Salar__4A1C07ABA1D030BE");

            entity.ToTable("CS_SalaryStructure");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysdatetime())");
            entity.Property(e => e.DecisionRef)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.JobWage).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.NatureAllowance)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(18, 2)");
            entity.Property(e => e.RepresentationAllowance)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(18, 2)");
            entity.Property(e => e.SupervisionAllowance)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TransportAllowanceMax)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TransportAllowanceMin)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(18, 2)");
            entity.Property(e => e.VariableAllowance)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Grade).WithMany(p => p.CsSalaryStructures)
                .HasForeignKey(d => d.GradeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CS_SalaryStructure_Grade");

            entity.HasOne(d => d.Position).WithMany(p => p.CsSalaryStructures)
                .HasForeignKey(d => d.PositionId)
                .HasConstraintName("FK_CS_SalaryStructure_Position");
        });

        modelBuilder.Entity<CsSecondment>(entity =>
        {
            entity.HasKey(e => e.SecondmentId).HasName("PK__CS_Secon__55EDDA6378945E3F");

            entity.ToTable("CS_Secondments");

            entity.Property(e => e.AdditionalAllowance)
                .HasDefaultValue(0.00m)
                .HasColumnType("decimal(18, 2)");
            entity.Property(e => e.ApprovalLevel)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysdatetime())");
            entity.Property(e => e.DecisionRef)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Department)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.HostEntity)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.HostEntitySalary).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.HostEntityType)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.MinisterialApprovalRef)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.OriginalSalary).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.PerformanceRating)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Position)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.RenewalCount).HasDefaultValue(0);
            entity.Property(e => e.ReturnReason).HasMaxLength(500);
            entity.Property(e => e.SecondmentHoursPerDay)
                .HasDefaultValue(8.00m)
                .HasColumnType("decimal(4, 2)");
            entity.Property(e => e.SecondmentPercentage)
                .HasComputedColumnSql("(([SecondmentHoursPerDay]*(100.0))/[WorkingHoursPerDay])", true)
                .HasColumnType("numeric(16, 8)");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValue("Active");
            entity.Property(e => e.TransportAllowance)
                .HasDefaultValue(0.00m)
                .HasColumnType("decimal(18, 2)");
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(sysdatetime())");
            entity.Property(e => e.WorkingHoursPerDay)
                .HasDefaultValue(8.00m)
                .HasColumnType("decimal(4, 2)");

            entity.HasOne(d => d.Person).WithMany(p => p.CsSecondments)
                .HasForeignKey(d => d.PersonId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CS_Secondments_Person");

            entity.HasOne(d => d.SecondmentType).WithMany(p => p.CsSecondments)
                .HasForeignKey(d => d.SecondmentTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CS_Secondments_Type");
        });

        modelBuilder.Entity<CsSecondmentType>(entity =>
        {
            entity.HasKey(e => e.SecondmentTypeId).HasName("PK__CS_Secon__8299AD089B8937D6");

            entity.ToTable("CS_SecondmentTypes");

            entity.HasIndex(e => e.Code, "UQ__CS_Secon__A25C5AA77A91747B").IsUnique();

            entity.Property(e => e.Code)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysdatetime())");
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.HostEntityPaysPercentage)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(5, 2)");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LegalBasis)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.MinDurationMonths).HasDefaultValue(1);
            entity.Property(e => e.Name)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.OriginalEntityPaysPercentage)
                .HasDefaultValue(100m)
                .HasColumnType("decimal(5, 2)");
            entity.Property(e => e.RenewableWithoutReapproval).HasDefaultValue(true);
            entity.Property(e => e.RequiredQualifications).HasMaxLength(500);
            entity.Property(e => e.RequiresCouncilApproval).HasDefaultValue(false);
            entity.Property(e => e.RequiresMinisterialApproval).HasDefaultValue(false);
            entity.Property(e => e.SalaryImpactType)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.DepartmentId).HasName("PK__Departme__B2079BEDA839C629");

            entity.HasIndex(e => e.Code, "UQ__Departme__A25C5AA7399DCD7B").IsUnique();

            entity.Property(e => e.Code)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CreatedDate).HasDefaultValueSql("(sysdatetime())");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.Name)
                .HasMaxLength(200)
                .IsUnicode(false);

            entity.HasOne(d => d.College).WithMany(p => p.Departments)
                .HasForeignKey(d => d.CollegeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Departments_College");

            entity.HasOne(d => d.ParentDepartment).WithMany(p => p.InverseParentDepartment)
                .HasForeignKey(d => d.ParentDepartmentId)
                .HasConstraintName("FK_Departments_Parent");
        });

        modelBuilder.Entity<Document>(entity =>
        {
            entity.HasKey(e => e.DocumentId).HasName("PK__Document__1ABEEF0FBD783F9F");

            entity.Property(e => e.DocNumber)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.DocType)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.FilePath)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.IsOriginal).HasDefaultValue(true);
            entity.Property(e => e.Issuer)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Title)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.UploadedAt).HasDefaultValueSql("(sysdatetime())");

            entity.HasOne(d => d.Person).WithMany(p => p.Documents)
                .HasForeignKey(d => d.PersonId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Documents_Person");
        });

        modelBuilder.Entity<FacultyAllowanceDeduction>(entity =>
        {
            entity.HasKey(e => e.DeductionId).HasName("PK__Faculty___E2604C57B4665512");

            entity.ToTable("Faculty_AllowanceDeductions");

            entity.Property(e => e.CalculatedAt).HasDefaultValueSql("(sysdatetime())");
            entity.Property(e => e.CalculationMethod)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.DeductionAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.DeductionDays).HasComputedColumnSql("(datediff(day,[DeductionStartDate],[DeductionEndDate])+(1))", true);
            entity.Property(e => e.DeductionPercentage).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.DeductionType)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Formula).HasMaxLength(500);
            entity.Property(e => e.GraceDaysApplied).HasDefaultValue(0);
            entity.Property(e => e.NetAmount)
                .HasComputedColumnSql("([OriginalAmount]-[DeductionAmount])", true)
                .HasColumnType("decimal(19, 2)");
            entity.Property(e => e.Notes).HasMaxLength(500);
            entity.Property(e => e.OriginalAmount).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Application).WithMany(p => p.FacultyAllowanceDeductions)
                .HasForeignKey(d => d.ApplicationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_FacAllowDeduct_Application");

            entity.HasOne(d => d.PayElement).WithMany(p => p.FacultyAllowanceDeductions)
                .HasForeignKey(d => d.PayElementId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_FacAllowDeduct_PayElement");

            entity.HasOne(d => d.Person).WithMany(p => p.FacultyAllowanceDeductions)
                .HasForeignKey(d => d.PersonId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_FacAllowDeduct_Person");

            entity.HasOne(d => d.Rule).WithMany(p => p.FacultyAllowanceDeductions)
                .HasForeignKey(d => d.RuleId)
                .HasConstraintName("FK_FacAllowDeduct_Rule");
        });

        modelBuilder.Entity<FacultyAppointment>(entity =>
        {
            entity.HasKey(e => e.AppointmentId).HasName("PK__Faculty___8ECDFCC22D081A4E");

            entity.ToTable("Faculty_Appointments");

            entity.Property(e => e.AppointmentType)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValue("Permanent");
            entity.Property(e => e.CouncilMinutes)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysdatetime())");
            entity.Property(e => e.DecisionRef)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Notes).HasMaxLength(500);
            entity.Property(e => e.StartingSalaryLevel).HasDefaultValue(1);

            entity.HasOne(d => d.Department).WithMany(p => p.FacultyAppointments)
                .HasForeignKey(d => d.DepartmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_FacAppoint_Department");

            entity.HasOne(d => d.Person).WithMany(p => p.FacultyAppointments)
                .HasForeignKey(d => d.PersonId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_FacAppoint_Person");

            entity.HasOne(d => d.Rank).WithMany(p => p.FacultyAppointments)
                .HasForeignKey(d => d.RankId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_FacAppoint_Rank");
        });

        modelBuilder.Entity<FacultyCurrentSalaryLevel>(entity =>
        {
            entity.HasKey(e => e.LevelId).HasName("PK__Faculty___09F03C26DBCF9BAF");

            entity.ToTable("Faculty_CurrentSalaryLevel");

            entity.Property(e => e.CanProgress).HasDefaultValue(true);
            entity.Property(e => e.LastIncrementAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.LastPerformanceRating)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.LastUpdated).HasDefaultValueSql("(sysdatetime())");
            entity.Property(e => e.NextIncrementAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Notes).HasMaxLength(500);
            entity.Property(e => e.ReachedMaximum).HasDefaultValue(false);

            entity.HasOne(d => d.Person).WithMany(p => p.FacultyCurrentSalaryLevels)
                .HasForeignKey(d => d.PersonId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_FacCurrentLevel_Person");

            entity.HasOne(d => d.Rank).WithMany(p => p.FacultyCurrentSalaryLevels)
                .HasForeignKey(d => d.RankId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_FacCurrentLevel_Rank");
        });

        modelBuilder.Entity<FacultyLeaveApplication>(entity =>
        {
            entity.HasKey(e => e.ApplicationId).HasName("PK__Faculty___C93A4C994493814E");

            entity.ToTable("Faculty_LeaveApplications");

            entity.Property(e => e.ActualDays).HasComputedColumnSql("(datediff(day,[ActualStartDate],[ActualEndDate])+(1))", true);
            entity.Property(e => e.AllowancesAffected).HasDefaultValue(false);
            entity.Property(e => e.ApprovalStatus)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValue("Pending");
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysdatetime())");
            entity.Property(e => e.DeductionCalculated).HasDefaultValue(false);
            entity.Property(e => e.ImplementationStatus)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValue("NotStarted");
            entity.Property(e => e.TotalDays).HasComputedColumnSql("(datediff(day,[StartDate],[EndDate])+(1))", true);
            entity.Property(e => e.TotalDeductionAmount)
                .HasDefaultValue(0.00m)
                .HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.LeaveType).WithMany(p => p.FacultyLeaveApplications)
                .HasForeignKey(d => d.LeaveTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_FacLeaveApp_LeaveType");

            entity.HasOne(d => d.Person).WithMany(p => p.FacultyLeaveApplications)
                .HasForeignKey(d => d.PersonId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_FacLeaveApp_Person");

            entity.HasOne(d => d.Request).WithMany(p => p.FacultyLeaveApplications)
                .HasForeignKey(d => d.RequestId)
                .HasConstraintName("FK_FacLeaveApp_Request");
        });

        modelBuilder.Entity<FacultyLeaveDeductionRule>(entity =>
        {
            entity.HasKey(e => e.RuleId).HasName("PK__Faculty___110458E2AF868483");

            entity.ToTable("Faculty_LeaveDeductionRules");

            entity.Property(e => e.AppliesOnlyToExcessDays).HasDefaultValue(false);
            entity.Property(e => e.DeductionPercentage)
                .HasDefaultValue(100.00m)
                .HasColumnType("decimal(5, 2)");
            entity.Property(e => e.DeductionType)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.EffectiveFrom).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.ExemptionConditions).HasMaxLength(300);
            entity.Property(e => e.Formula).HasMaxLength(500);
            entity.Property(e => e.GraceDays).HasDefaultValue(0);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.Notes).HasMaxLength(500);

            entity.HasOne(d => d.LeaveType).WithMany(p => p.FacultyLeaveDeductionRules)
                .HasForeignKey(d => d.LeaveTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_LeaveDeduction_LeaveType");

            entity.HasOne(d => d.PayElement).WithMany(p => p.FacultyLeaveDeductionRules)
                .HasForeignKey(d => d.PayElementId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_LeaveDeduction_PayElement");
        });

        modelBuilder.Entity<FacultyLeaveType>(entity =>
        {
            entity.HasKey(e => e.LeaveTypeId).HasName("PK__Faculty___43BE8F1423258312");

            entity.ToTable("Faculty_LeaveTypes");

            entity.HasIndex(e => e.Code, "UQ__Faculty___A25C5AA7A1306FEF").IsUnique();

            entity.Property(e => e.AffectsAllowances).HasDefaultValue(false);
            entity.Property(e => e.CanBeTakenDuringExams).HasDefaultValue(false);
            entity.Property(e => e.CanBeTakenDuringSemester).HasDefaultValue(true);
            entity.Property(e => e.Code)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysdatetime())");
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.EligibilityConditions).HasMaxLength(500);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.IsPaid).HasDefaultValue(true);
            entity.Property(e => e.LegalBasis)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.MaxTimesPerYear).HasDefaultValue(1);
            entity.Property(e => e.MinDaysPerRequest).HasDefaultValue(1);
            entity.Property(e => e.MinServiceYears).HasDefaultValue(0);
            entity.Property(e => e.Name)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.RequiresApproval).HasDefaultValue(true);
            entity.Property(e => e.RestrictedPeriods).HasMaxLength(300);
        });

        modelBuilder.Entity<FacultyRank>(entity =>
        {
            entity.HasKey(e => e.RankId).HasName("PK__Faculty___B37AF876E483E4B6");

            entity.ToTable("Faculty_Ranks");

            entity.HasIndex(e => e.Code, "UQ__Faculty___A25C5AA75E79E80B").IsUnique();

            entity.Property(e => e.Code)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CreatedDate).HasDefaultValueSql("(sysdatetime())");
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.NameEn)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.RequiredDegree)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.RequiredExperience).HasMaxLength(500);
            entity.Property(e => e.ResearchRequirement).HasMaxLength(500);
        });

        modelBuilder.Entity<FacultySalaryScale>(entity =>
        {
            entity.HasKey(e => e.ScaleId).HasName("PK__Faculty___27D595667D8B7FE3");

            entity.ToTable("Faculty_SalaryScale");

            entity.HasIndex(e => new { e.RankId, e.ScaleLevel, e.EffectiveTo }, "UQ_FacultySalary_RankLevel").IsUnique();

            entity.Property(e => e.AcademicAllowance)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(18, 2)");
            entity.Property(e => e.BasicSalary).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysdatetime())");
            entity.Property(e => e.DecisionRef)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.IncrementPercentage)
                .HasDefaultValue(7.00m)
                .HasColumnType("decimal(5, 2)");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.MaxBasicSalary).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.MinBasicSalary).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.PerformanceRequired)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValue("مقبول");
            entity.Property(e => e.ResearchAllowance)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(18, 2)");
            entity.Property(e => e.SupervisionAllowance)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TeachingAllowance)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(18, 2)");
            entity.Property(e => e.YearsForNextLevel).HasDefaultValue(2);

            entity.HasOne(d => d.Rank).WithMany(p => p.FacultySalaryScales)
                .HasForeignKey(d => d.RankId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_FacultySalaryScale_Rank");
        });

        modelBuilder.Entity<LegalArticle>(entity =>
        {
            entity.HasKey(e => e.ArticleId).HasName("PK__LegalArt__9C6270E8BDD42C4E");

            entity.HasIndex(e => new { e.LegalId, e.ArticleNumber }, "UQ_LegalArticles_Number").IsUnique();

            entity.Property(e => e.ArticleNumber)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.ArticleTitle).HasMaxLength(300);
            entity.Property(e => e.ChapterNumber)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysdatetime())");
            entity.Property(e => e.ImplementationNotes).HasMaxLength(500);
            entity.Property(e => e.Keywords).HasMaxLength(300);
            entity.Property(e => e.RelatedTables).HasMaxLength(300);
            entity.Property(e => e.Scope)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.SectionNumber)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValue("Active");
            entity.Property(e => e.Subject)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(sysdatetime())");

            entity.HasOne(d => d.Legal).WithMany(p => p.LegalArticles)
                .HasForeignKey(d => d.LegalId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_LegalArticles_Legal");

            entity.HasOne(d => d.ReferencesArticle).WithMany(p => p.InverseReferencesArticle)
                .HasForeignKey(d => d.ReferencesArticleId)
                .HasConstraintName("FK_LegalArticles_References");

            entity.HasOne(d => d.SupersededByArticle).WithMany(p => p.InverseSupersededByArticle)
                .HasForeignKey(d => d.SupersededByArticleId)
                .HasConstraintName("FK_LegalArticles_Superseded");
        });

        modelBuilder.Entity<LegalReference>(entity =>
        {
            entity.HasKey(e => e.LegalId).HasName("PK__LegalRef__C23AAA4F1142D72B");

            entity.Property(e => e.ApplicableToEmployees).HasDefaultValue(true);
            entity.Property(e => e.ApplicableToFaculty).HasDefaultValue(true);
            entity.Property(e => e.Category)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysdatetime())");
            entity.Property(e => e.FilePath)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.IssuingAuthority)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.LawNumber)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Priority).HasDefaultValue(5);
            entity.Property(e => e.ReferenceType)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.RelatedSystems).HasMaxLength(300);
            entity.Property(e => e.Scope).HasMaxLength(300);
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValue("Active");
            entity.Property(e => e.Subject).HasMaxLength(200);
            entity.Property(e => e.Summary).HasMaxLength(1000);
            entity.Property(e => e.Title).HasMaxLength(500);
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(sysdatetime())");

            entity.HasOne(d => d.AmendsLegal).WithMany(p => p.InverseAmendsLegal)
                .HasForeignKey(d => d.AmendsLegalId)
                .HasConstraintName("FK_LegalReferences_Amends");

            entity.HasOne(d => d.SupersededByNavigation).WithMany(p => p.InverseSupersededByNavigation)
                .HasForeignKey(d => d.SupersededBy)
                .HasConstraintName("FK_LegalReferences_Superseded");
        });

        modelBuilder.Entity<PayElement>(entity =>
        {
            entity.HasKey(e => e.ElementId).HasName("PK__PayEleme__A429721A352C25A3");

            entity.HasIndex(e => e.Code, "UQ__PayEleme__A25C5AA7BDD9F6F8").IsUnique();

            entity.Property(e => e.AccountCode)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.BaseElement)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Category)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Code)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysdatetime())");
            entity.Property(e => e.DefaultAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.DisplayOrder).HasDefaultValue(999);
            entity.Property(e => e.EffectiveFrom).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Formula).HasMaxLength(500);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LegalBasis)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.MaxAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.MinAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Name)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.NameEn)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.PayslipDescription)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Recurring).HasDefaultValue(true);
            entity.Property(e => e.ShowInPayslip).HasDefaultValue(true);
            entity.Property(e => e.TaxCode)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Track)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Type)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<PayrollCalendar>(entity =>
        {
            entity.HasKey(e => e.PeriodId).HasName("PK__PayrollC__E521BB166CD6DBDF");

            entity.ToTable("PayrollCalendar");

            entity.HasIndex(e => e.PeriodCode, "UQ__PayrollC__EC2A5D67E575B291").IsUnique();

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysdatetime())");
            entity.Property(e => e.IsAdjustmentPeriod).HasDefaultValue(false);
            entity.Property(e => e.Notes).HasMaxLength(500);
            entity.Property(e => e.PeriodCode)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.PeriodName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValue("Open");
            entity.Property(e => e.TotalEmployees).HasDefaultValue(0);
            entity.Property(e => e.TotalFaculty).HasDefaultValue(0);
            entity.Property(e => e.TotalGrossAmount)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TotalInsuranceAmount)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TotalNetAmount)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TotalTaxAmount)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(18, 2)");
        });

        modelBuilder.Entity<PayrollLine>(entity =>
        {
            entity.HasKey(e => e.LineId).HasName("PK__PayrollL__2EAE65296CAEFD9E");

            entity.HasIndex(e => e.RunId, "IX_PayrollLines_Period");

            entity.HasIndex(e => new { e.RunId, e.PersonId }, "UQ_PayrollLines_RunPerson").IsUnique();

            entity.Property(e => e.AbsentDays)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(5, 2)");
            entity.Property(e => e.ActualWorkingDays)
                .HasDefaultValue(30m)
                .HasColumnType("decimal(5, 2)");
            entity.Property(e => e.CalculatedAt).HasDefaultValueSql("(sysdatetime())");
            entity.Property(e => e.GrossAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.HasErrors).HasDefaultValue(false);
            entity.Property(e => e.HealthInsuranceAmount)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(18, 2)");
            entity.Property(e => e.InsurableIncome).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.InsuranceAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.NetAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Notes).HasMaxLength(500);
            entity.Property(e => e.OvertimeHours)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(5, 2)");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValue("Calculated");
            entity.Property(e => e.TaxAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TaxableIncome).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TotalDeductions).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TotalEarnings).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.WorkingDays)
                .HasDefaultValue(30m)
                .HasColumnType("decimal(5, 2)");

            entity.HasOne(d => d.Person).WithMany(p => p.PayrollLines)
                .HasForeignKey(d => d.PersonId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PayrollLines_Person");

            entity.HasOne(d => d.Run).WithMany(p => p.PayrollLines)
                .HasForeignKey(d => d.RunId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PayrollLines_Run");
        });

        modelBuilder.Entity<PayrollLineDetail>(entity =>
        {
            entity.HasKey(e => e.LineDetailId).HasName("PK__PayrollL__B5F62716CE90422D");

            entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.BaseAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.CalculationMethod)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValue("Fixed");
            entity.Property(e => e.Description)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.FormulaUsed).HasMaxLength(500);
            entity.Property(e => e.IsInsurable).HasDefaultValue(false);
            entity.Property(e => e.IsTaxable).HasDefaultValue(false);
            entity.Property(e => e.Notes).HasMaxLength(500);
            entity.Property(e => e.Quantity)
                .HasDefaultValue(1.00m)
                .HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Rate).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Element).WithMany(p => p.PayrollLineDetails)
                .HasForeignKey(d => d.ElementId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PayrollLineDetails_Element");

            entity.HasOne(d => d.Line).WithMany(p => p.PayrollLineDetails)
                .HasForeignKey(d => d.LineId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PayrollLineDetails_Line");
        });

        modelBuilder.Entity<PayrollRun>(entity =>
        {
            entity.HasKey(e => e.RunId).HasName("PK__PayrollR__A259D4DD87036B99");

            entity.HasIndex(e => new { e.PeriodId, e.RunNumber }, "UQ_PayrollRuns_PeriodNumber").IsUnique();

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysdatetime())");
            entity.Property(e => e.EmployeeFilter).HasMaxLength(500);
            entity.Property(e => e.IncludeEmployees).HasDefaultValue(true);
            entity.Property(e => e.IncludeFaculty).HasDefaultValue(true);
            entity.Property(e => e.RecordsProcessed).HasDefaultValue(0);
            entity.Property(e => e.RecordsSuccessful).HasDefaultValue(0);
            entity.Property(e => e.RecordsWithErrors).HasDefaultValue(0);
            entity.Property(e => e.RunName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.RunType)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValue("Pending");
            entity.Property(e => e.TotalDeductionsAmount)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TotalGrossAmount)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TotalInsuranceAmount)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TotalNetAmount)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TotalTaxAmount)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Period).WithMany(p => p.PayrollRuns)
                .HasForeignKey(d => d.PeriodId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PayrollRuns_Period");
        });

        modelBuilder.Entity<Person>(entity =>
        {
            entity.HasKey(e => e.PersonId).HasName("PK__Persons__AA2FFBE52E22A1EF");

            entity.ToTable(tb => tb.HasTrigger("TR_Persons_UpdatedAt"));

            entity.HasIndex(e => e.DepartmentId, "IX_Persons_Department");

            entity.HasIndex(e => e.NationalId, "IX_Persons_NationalId").HasFilter("([NationalId] IS NOT NULL)");

            entity.HasIndex(e => e.Status, "IX_Persons_Status");

            entity.HasIndex(e => e.PersonType, "IX_Persons_Type");

            entity.HasIndex(e => e.NationalId, "UQ__Persons__E9AA32FAE549E371").IsUnique();

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysdatetime())");
            entity.Property(e => e.Email)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Gender)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.NationalId)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.PersonType)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Phone)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValue("Active");
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(sysdatetime())");

            entity.HasOne(d => d.College).WithMany(p => p.People)
                .HasForeignKey(d => d.CollegeId)
                .HasConstraintName("FK_Persons_College");

            entity.HasOne(d => d.Department).WithMany(p => p.People)
                .HasForeignKey(d => d.DepartmentId)
                .HasConstraintName("FK_Persons_Department");
        });

        modelBuilder.Entity<PersonPayAssignment>(entity =>
        {
            entity.HasKey(e => e.PayAssignId).HasName("PK__PersonPa__582E4F9B2D603E3E");

            entity.HasIndex(e => e.ElementId, "IX_PersonPayAssignments_Element");

            entity.HasIndex(e => e.PersonId, "IX_PersonPayAssignments_Person");

            entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysdatetime())");
            entity.Property(e => e.DecisionRef)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Formula).HasMaxLength(500);
            entity.Property(e => e.IsTemporary).HasDefaultValue(false);
            entity.Property(e => e.Notes).HasMaxLength(500);
            entity.Property(e => e.Percentage).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.Quantity)
                .HasDefaultValue(1m)
                .HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Rate).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValue("Active");
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(sysdatetime())");

            entity.HasOne(d => d.Element).WithMany(p => p.PersonPayAssignments)
                .HasForeignKey(d => d.ElementId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PersonPay_Element");

            entity.HasOne(d => d.Person).WithMany(p => p.PersonPayAssignments)
                .HasForeignKey(d => d.PersonId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PersonPay_Person");
        });

        modelBuilder.Entity<Request>(entity =>
        {
            entity.HasKey(e => e.RequestId).HasName("PK__Requests__33A8517AF46FE1BA");

            entity.HasIndex(e => e.Status, "IX_Requests_Status");

            entity.HasIndex(e => e.RequestType, "IX_Requests_Type");

            entity.HasIndex(e => e.RequestNumber, "UQ__Requests__9ADA6BE069951F30").IsUnique();

            entity.Property(e => e.ApprovedAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.AttachmentsCount).HasDefaultValue(0);
            entity.Property(e => e.Category)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysdatetime())");
            entity.Property(e => e.CurrentStage)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasDefaultValue("Submitted");
            entity.Property(e => e.DecisionRef)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.FinalDecision)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.LegalBasis).HasMaxLength(300);
            entity.Property(e => e.Priority)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasDefaultValue("Normal");
            entity.Property(e => e.RejectionReason).HasMaxLength(500);
            entity.Property(e => e.RequestNumber)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.RequestType)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.RequestedAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.RequiredDocuments).HasMaxLength(500);
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValue("Submitted");
            entity.Property(e => e.Subject).HasMaxLength(200);
            entity.Property(e => e.SubmittedAt).HasDefaultValueSql("(sysdatetime())");
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(sysdatetime())");

            entity.HasOne(d => d.Person).WithMany(p => p.Requests)
                .HasForeignKey(d => d.PersonId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Requests_Person");
        });

        modelBuilder.Entity<RequestApproval>(entity =>
        {
            entity.HasKey(e => e.ApprovalId).HasName("PK__RequestA__328477F45543BF25");

            entity.Property(e => e.AmountAdjustment).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.ApprovalStage)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.ApproverRole)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ApproverTitle)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysdatetime())");
            entity.Property(e => e.DateAdjustment).HasMaxLength(200);
            entity.Property(e => e.Decision)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.DecisionNotes).HasMaxLength(500);
            entity.Property(e => e.IsDelegate).HasDefaultValue(false);

            entity.HasOne(d => d.Approver).WithMany(p => p.RequestApprovals)
                .HasForeignKey(d => d.ApproverId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RequestApprovals_Approver");

            entity.HasOne(d => d.Request).WithMany(p => p.RequestApprovals)
                .HasForeignKey(d => d.RequestId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RequestApprovals_Request");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__Roles__8AFACE1AD2AF7F48");

            entity.HasIndex(e => e.RoleName, "UQ__Roles__8A2B616073473617").IsUnique();

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysdatetime())");
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.IsSystemRole).HasDefaultValue(false);
            entity.Property(e => e.RoleName)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CC4C78A58A17");

            entity.HasIndex(e => e.Username, "UQ__Users__536C85E46AEB7C18").IsUnique();

            entity.HasIndex(e => e.Email, "UQ__Users__A9D105341DB11DF4").IsUnique();

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysdatetime())");
            entity.Property(e => e.Email)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LoginAttempts).HasDefaultValue(0);
            entity.Property(e => e.MustChangePassword).HasDefaultValue(true);
            entity.Property(e => e.PasswordHash)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(sysdatetime())");
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Person).WithMany(p => p.Users)
                .HasForeignKey(d => d.PersonId)
                .HasConstraintName("FK_Users_Person");
        });

        modelBuilder.Entity<UserRole>(entity =>
        {
            entity.HasKey(e => e.UserRoleId).HasName("PK__UserRole__3D978A35735E53D3");

            entity.HasIndex(e => new { e.UserId, e.RoleId }, "UQ_UserRoles_UserRole").IsUnique();

            entity.Property(e => e.AssignedAt).HasDefaultValueSql("(sysdatetime())");
            entity.Property(e => e.IsActive).HasDefaultValue(true);

            entity.HasOne(d => d.Role).WithMany(p => p.UserRoles)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserRoles_Role");

            entity.HasOne(d => d.User).WithMany(p => p.UserRoles)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserRoles_User");
        });

        modelBuilder.Entity<VwCsCurrentEmployeesStatus>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_CS_CurrentEmployeesStatus");

            entity.Property(e => e.AssignmentType)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.College)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.CurrentGrade)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.CurrentPosition)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.CurrentSalary).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Department)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.EmployeeName)
                .HasMaxLength(201)
                .IsUnicode(false);
            entity.Property(e => e.FullGradeCode)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.NationalId)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.PersonStatus)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Phone)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PromotionEligibility)
                .HasMaxLength(12)
                .IsUnicode(false);
        });

        modelBuilder.Entity<VwPayrollSummaryReport>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_PayrollSummaryReport");

            entity.Property(e => e.AbsentDays).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.ActualWorkingDays).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.EmployeeName)
                .HasMaxLength(201)
                .IsUnicode(false);
            entity.Property(e => e.GradeOrRank)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.GrossAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.InsuranceAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.NetAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.OvertimeHours).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.PeriodName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.PersonType)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.RunName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.RunType)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.TaxAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TaxableIncome).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TotalDeductions).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.WorkingDays).HasColumnType("decimal(5, 2)");
        });

        modelBuilder.Entity<VwPersonsBasicInfo>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_PersonsBasicInfo");

            entity.Property(e => e.Address)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.CollegeName)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.DepartmentName)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.EmergencyContact)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.EmergencyPhone)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FullName)
                .HasMaxLength(201)
                .IsUnicode(false);
            entity.Property(e => e.NationalId)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.PersonType)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Phone)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
