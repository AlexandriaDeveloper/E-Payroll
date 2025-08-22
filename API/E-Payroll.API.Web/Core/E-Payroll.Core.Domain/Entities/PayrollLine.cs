using System;
using System.Collections.Generic;

namespace E_Payroll.API.Web.Core.E_Payroll.Core.Domain.Entities;

public partial class PayrollLine
{
    public long LineId { get; set; }

    public long RunId { get; set; }

    public long PersonId { get; set; }

    public decimal GrossAmount { get; set; }

    public decimal TotalEarnings { get; set; }

    public decimal TotalDeductions { get; set; }

    public decimal TaxableIncome { get; set; }

    public decimal TaxAmount { get; set; }

    public decimal InsurableIncome { get; set; }

    public decimal InsuranceAmount { get; set; }

    public decimal? HealthInsuranceAmount { get; set; }

    public decimal NetAmount { get; set; }

    public decimal? WorkingDays { get; set; }

    public decimal? ActualWorkingDays { get; set; }

    public decimal? AbsentDays { get; set; }

    public decimal? OvertimeHours { get; set; }

    public string? Status { get; set; }

    public DateTime? CalculatedAt { get; set; }

    public long? CalculatedBy { get; set; }

    public string? Notes { get; set; }

    public bool? HasErrors { get; set; }

    public string? ErrorDetails { get; set; }

    public virtual ICollection<PayrollLineDetail> PayrollLineDetails { get; set; } = new List<PayrollLineDetail>();

    public virtual Person Person { get; set; } = null!;

    public virtual PayrollRun Run { get; set; } = null!;
}
