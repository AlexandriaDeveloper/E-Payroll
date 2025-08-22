using System;
using System.Collections.Generic;

namespace E_Payroll.API.Web.Core.E_Payroll.Core.Domain.Entities;

public partial class PayElement
{
    public long ElementId { get; set; }

    public string Code { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string? NameEn { get; set; }

    public string Type { get; set; } = null!;

    public string Track { get; set; } = null!;

    public string? Category { get; set; }

    public bool Taxable { get; set; }

    public bool SubjectToInsurance { get; set; }

    public bool Recurring { get; set; }

    public string? Formula { get; set; }

    public string? BaseElement { get; set; }

    public decimal? MinAmount { get; set; }

    public decimal? MaxAmount { get; set; }

    public decimal? DefaultAmount { get; set; }

    public string? LegalBasis { get; set; }

    public string? TaxCode { get; set; }

    public string? AccountCode { get; set; }

    public int? DisplayOrder { get; set; }

    public bool? ShowInPayslip { get; set; }

    public string? PayslipDescription { get; set; }

    public bool? IsActive { get; set; }

    public DateOnly? EffectiveFrom { get; set; }

    public DateOnly? EffectiveTo { get; set; }

    public long? CreatedBy { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual ICollection<FacultyAllowanceDeduction> FacultyAllowanceDeductions { get; set; } = new List<FacultyAllowanceDeduction>();

    public virtual ICollection<FacultyLeaveDeductionRule> FacultyLeaveDeductionRules { get; set; } = new List<FacultyLeaveDeductionRule>();

    public virtual ICollection<PayrollLineDetail> PayrollLineDetails { get; set; } = new List<PayrollLineDetail>();

    public virtual ICollection<PersonPayAssignment> PersonPayAssignments { get; set; } = new List<PersonPayAssignment>();
}
