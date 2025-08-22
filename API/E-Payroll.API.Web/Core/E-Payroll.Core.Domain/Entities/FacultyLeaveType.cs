using System;
using System.Collections.Generic;

namespace E_Payroll.API.Web.Core.E_Payroll.Core.Domain.Entities;

public partial class FacultyLeaveType
{
    public long LeaveTypeId { get; set; }

    public string Code { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public int? MaxDaysPerYear { get; set; }

    public int? MaxConsecutiveDays { get; set; }

    public int? MinDaysPerRequest { get; set; }

    public bool? RequiresApproval { get; set; }

    public string? EligibilityConditions { get; set; }

    public int? MinServiceYears { get; set; }

    public int? MaxTimesPerYear { get; set; }

    public bool? CanBeTakenDuringExams { get; set; }

    public bool? CanBeTakenDuringSemester { get; set; }

    public string? RestrictedPeriods { get; set; }

    public bool? IsPaid { get; set; }

    public bool? AffectsAllowances { get; set; }

    public string? LegalBasis { get; set; }

    public bool? IsActive { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual ICollection<FacultyLeaveApplication> FacultyLeaveApplications { get; set; } = new List<FacultyLeaveApplication>();

    public virtual ICollection<FacultyLeaveDeductionRule> FacultyLeaveDeductionRules { get; set; } = new List<FacultyLeaveDeductionRule>();
}
