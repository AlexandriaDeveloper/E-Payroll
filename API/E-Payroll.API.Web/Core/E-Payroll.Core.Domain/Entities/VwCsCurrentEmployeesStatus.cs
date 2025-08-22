using System;
using System.Collections.Generic;

namespace E_Payroll.API.Web.Core.E_Payroll.Core.Domain.Entities;

public partial class VwCsCurrentEmployeesStatus
{
    public long PersonId { get; set; }

    public string EmployeeName { get; set; } = null!;

    public string? NationalId { get; set; }

    public string PersonStatus { get; set; } = null!;

    public string CurrentPosition { get; set; } = null!;

    public string CurrentGrade { get; set; } = null!;

    public string? FullGradeCode { get; set; }

    public string Department { get; set; } = null!;

    public string College { get; set; } = null!;

    public DateOnly CurrentAssignmentStart { get; set; }

    public string? AssignmentType { get; set; }

    public decimal? CurrentSalary { get; set; }

    public int? TotalServiceYears { get; set; }

    public int? YearsInCurrentPosition { get; set; }

    public string PromotionEligibility { get; set; } = null!;

    public string? Email { get; set; }

    public string? Phone { get; set; }
}
