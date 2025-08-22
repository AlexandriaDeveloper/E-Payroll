using System;
using System.Collections.Generic;

namespace E_Payroll.API.Web.Core.E_Payroll.Core.Domain.Entities;

public partial class PayrollRun
{
    public long RunId { get; set; }

    public long PeriodId { get; set; }

    public int RunNumber { get; set; }

    public string RunType { get; set; } = null!;

    public string? RunName { get; set; }

    public DateTime? StartedAt { get; set; }

    public DateTime? CompletedAt { get; set; }

    public string? Status { get; set; }

    public string? EmployeeFilter { get; set; }

    public bool? IncludeEmployees { get; set; }

    public bool? IncludeFaculty { get; set; }

    public int? RecordsProcessed { get; set; }

    public int? RecordsSuccessful { get; set; }

    public int? RecordsWithErrors { get; set; }

    public decimal? TotalGrossAmount { get; set; }

    public decimal? TotalNetAmount { get; set; }

    public decimal? TotalTaxAmount { get; set; }

    public decimal? TotalInsuranceAmount { get; set; }

    public decimal? TotalDeductionsAmount { get; set; }

    public long CreatedBy { get; set; }

    public DateTime? CreatedAt { get; set; }

    public long? ProcessedBy { get; set; }

    public long? ApprovedBy { get; set; }

    public DateTime? ApprovedAt { get; set; }

    public string? Notes { get; set; }

    public string? ErrorLog { get; set; }

    public virtual ICollection<PayrollLine> PayrollLines { get; set; } = new List<PayrollLine>();

    public virtual PayrollCalendar Period { get; set; } = null!;
}
