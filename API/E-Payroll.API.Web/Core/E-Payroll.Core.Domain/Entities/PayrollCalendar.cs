using System;
using System.Collections.Generic;

namespace E_Payroll.API.Web.Core.E_Payroll.Core.Domain.Entities;

public partial class PayrollCalendar
{
    public long PeriodId { get; set; }

    public string PeriodCode { get; set; } = null!;

    public string PeriodName { get; set; } = null!;

    public DateOnly StartDate { get; set; }

    public DateOnly EndDate { get; set; }

    public DateOnly PayDate { get; set; }

    public DateOnly CutoffDate { get; set; }

    public DateOnly? ProcessingStartDate { get; set; }

    public DateOnly? ProcessingEndDate { get; set; }

    public DateOnly? ApprovalDate { get; set; }

    public string? Status { get; set; }

    public bool? IsAdjustmentPeriod { get; set; }

    public int? TotalEmployees { get; set; }

    public int? TotalFaculty { get; set; }

    public decimal? TotalGrossAmount { get; set; }

    public decimal? TotalNetAmount { get; set; }

    public decimal? TotalTaxAmount { get; set; }

    public decimal? TotalInsuranceAmount { get; set; }

    public long? ProcessedBy { get; set; }

    public long? ApprovedBy { get; set; }

    public string? Notes { get; set; }

    public long? CreatedBy { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual ICollection<PayrollRun> PayrollRuns { get; set; } = new List<PayrollRun>();
}
