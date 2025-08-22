using System;
using System.Collections.Generic;

namespace E_Payroll.API.Web.Core.E_Payroll.Core.Domain.Entities;

public partial class VwPayrollSummaryReport
{
    public string PeriodName { get; set; } = null!;

    public string RunType { get; set; } = null!;

    public string? RunName { get; set; }

    public string EmployeeName { get; set; } = null!;

    public string PersonType { get; set; } = null!;

    public string? GradeOrRank { get; set; }

    public decimal GrossAmount { get; set; }

    public decimal TaxableIncome { get; set; }

    public decimal TaxAmount { get; set; }

    public decimal InsuranceAmount { get; set; }

    public decimal TotalDeductions { get; set; }

    public decimal NetAmount { get; set; }

    public decimal? WorkingDays { get; set; }

    public decimal? ActualWorkingDays { get; set; }

    public decimal? AbsentDays { get; set; }

    public decimal? OvertimeHours { get; set; }

    public string? Status { get; set; }
}
