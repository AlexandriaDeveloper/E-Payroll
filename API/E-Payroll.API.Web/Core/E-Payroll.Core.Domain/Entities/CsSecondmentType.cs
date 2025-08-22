using System;
using System.Collections.Generic;

namespace E_Payroll.API.Web.Core.E_Payroll.Core.Domain.Entities;

public partial class CsSecondmentType
{
    public long SecondmentTypeId { get; set; }

    public string Code { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public string SalaryImpactType { get; set; } = null!;

    public decimal? HostEntityPaysPercentage { get; set; }

    public decimal? OriginalEntityPaysPercentage { get; set; }

    public int? MaxDurationMonths { get; set; }

    public int? MinDurationMonths { get; set; }

    public bool? RequiresMinisterialApproval { get; set; }

    public bool? RequiresCouncilApproval { get; set; }

    public bool? RenewableWithoutReapproval { get; set; }

    public string? RequiredQualifications { get; set; }

    public int? RequiredExperience { get; set; }

    public string? LegalBasis { get; set; }

    public bool? IsActive { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual ICollection<CsSecondment> CsSecondments { get; set; } = new List<CsSecondment>();
}
