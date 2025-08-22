using System;
using System.Collections.Generic;

namespace E_Payroll.API.Web.Core.E_Payroll.Core.Domain.Entities;

public partial class PayrollLineDetail
{
    public long LineDetailId { get; set; }

    public long LineId { get; set; }

    public long ElementId { get; set; }

    public decimal? Quantity { get; set; }

    public decimal? Rate { get; set; }

    public decimal Amount { get; set; }

    public string? CalculationMethod { get; set; }

    public string? FormulaUsed { get; set; }

    public decimal? BaseAmount { get; set; }

    public bool IsEarning { get; set; }

    public bool IsDeduction { get; set; }

    public bool? IsTaxable { get; set; }

    public bool? IsInsurable { get; set; }

    public string? Description { get; set; }

    public string? Notes { get; set; }

    public virtual PayElement Element { get; set; } = null!;

    public virtual PayrollLine Line { get; set; } = null!;
}
