using System;
using System.Collections.Generic;

namespace E_Payroll.API.Web.Core.E_Payroll.Core.Domain.Entities;

public partial class PersonPayAssignment
{
    public long PayAssignId { get; set; }

    public long PersonId { get; set; }

    public long ElementId { get; set; }

    public decimal? Amount { get; set; }

    public decimal? Percentage { get; set; }

    public string? Formula { get; set; }

    public decimal? Quantity { get; set; }

    public decimal? Rate { get; set; }

    public DateOnly EffectiveFrom { get; set; }

    public DateOnly? EffectiveTo { get; set; }

    public string? DecisionRef { get; set; }

    public long? ApprovedBy { get; set; }

    public DateOnly? ApprovalDate { get; set; }

    public string? Status { get; set; }

    public bool? IsTemporary { get; set; }

    public string? Notes { get; set; }

    public long? CreatedBy { get; set; }

    public DateTime? CreatedAt { get; set; }

    public long? UpdatedBy { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual PayElement Element { get; set; } = null!;

    public virtual Person Person { get; set; } = null!;
}
