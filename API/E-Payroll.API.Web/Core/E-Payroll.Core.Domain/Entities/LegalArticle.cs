using System;
using System.Collections.Generic;

namespace E_Payroll.API.Web.Core.E_Payroll.Core.Domain.Entities;

public partial class LegalArticle
{
    public long ArticleId { get; set; }

    public long LegalId { get; set; }

    public string ArticleNumber { get; set; } = null!;

    public string? ChapterNumber { get; set; }

    public string? SectionNumber { get; set; }

    public string? ArticleTitle { get; set; }

    public string ArticleText { get; set; } = null!;

    public string? SubArticles { get; set; }

    public string? Subject { get; set; }

    public string? Keywords { get; set; }

    public string? Scope { get; set; }

    public long? ReferencesArticleId { get; set; }

    public long? SupersededByArticleId { get; set; }

    public string? Status { get; set; }

    public DateOnly? EffectiveDate { get; set; }

    public DateOnly? EndDate { get; set; }

    public string? RelatedTables { get; set; }

    public string? ImplementationNotes { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<LegalArticle> InverseReferencesArticle { get; set; } = new List<LegalArticle>();

    public virtual ICollection<LegalArticle> InverseSupersededByArticle { get; set; } = new List<LegalArticle>();

    public virtual LegalReference Legal { get; set; } = null!;

    public virtual LegalArticle? ReferencesArticle { get; set; }

    public virtual LegalArticle? SupersededByArticle { get; set; }
}
