using System;
using System.Collections.Generic;

namespace E_Payroll.API.Web.Core.E_Payroll.Core.Domain.Entities;

public partial class LegalReference
{
    public long LegalId { get; set; }

    public string ReferenceType { get; set; } = null!;

    public string LawNumber { get; set; } = null!;

    public int LawYear { get; set; }

    public string IssuingAuthority { get; set; } = null!;

    public string Title { get; set; } = null!;

    public string? Subject { get; set; }

    public string? Scope { get; set; }

    public DateOnly IssueDate { get; set; }

    public DateOnly EffectiveDate { get; set; }

    public DateOnly? EndDate { get; set; }

    public string? Status { get; set; }

    public long? SupersededBy { get; set; }

    public long? AmendsLegalId { get; set; }

    public string? Category { get; set; }

    public int? Priority { get; set; }

    public bool? ApplicableToEmployees { get; set; }

    public bool? ApplicableToFaculty { get; set; }

    public string? FullText { get; set; }

    public string? Summary { get; set; }

    public string? KeyProvisions { get; set; }

    public string? FilePath { get; set; }

    public long? DocumentSize { get; set; }

    public string? RelatedSystems { get; set; }

    public string? ImplementationNotes { get; set; }

    public long CreatedBy { get; set; }

    public DateTime? CreatedAt { get; set; }

    public long? UpdatedBy { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual LegalReference? AmendsLegal { get; set; }

    public virtual ICollection<LegalReference> InverseAmendsLegal { get; set; } = new List<LegalReference>();

    public virtual ICollection<LegalReference> InverseSupersededByNavigation { get; set; } = new List<LegalReference>();

    public virtual ICollection<LegalArticle> LegalArticles { get; set; } = new List<LegalArticle>();

    public virtual LegalReference? SupersededByNavigation { get; set; }
}
