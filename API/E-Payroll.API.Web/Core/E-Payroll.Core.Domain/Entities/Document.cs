using System;
using System.Collections.Generic;

namespace E_Payroll.API.Web.Core.E_Payroll.Core.Domain.Entities;

public partial class Document
{
    public long DocumentId { get; set; }

    public long PersonId { get; set; }

    public string DocType { get; set; } = null!;

    public string? DocNumber { get; set; }

    public string? Title { get; set; }

    public DateOnly? IssueDate { get; set; }

    public DateOnly? ExpiryDate { get; set; }

    public string? FilePath { get; set; }

    public long? FileSize { get; set; }

    public string? Issuer { get; set; }

    public bool? IsOriginal { get; set; }

    public string? Notes { get; set; }

    public long? UploadedBy { get; set; }

    public DateTime? UploadedAt { get; set; }

    public virtual Person Person { get; set; } = null!;
}
