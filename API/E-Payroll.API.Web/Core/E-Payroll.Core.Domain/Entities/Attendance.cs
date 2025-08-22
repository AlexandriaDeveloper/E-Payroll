using System;
using System.Collections.Generic;

namespace E_Payroll.API.Web.Core.E_Payroll.Core.Domain.Entities;

public partial class Attendance
{
    public long AttendanceId { get; set; }

    public long PersonId { get; set; }

    public DateOnly AttendanceDate { get; set; }

    public TimeOnly? InTime { get; set; }

    public TimeOnly? OutTime { get; set; }

    public TimeOnly? ScheduledInTime { get; set; }

    public TimeOnly? ScheduledOutTime { get; set; }

    public decimal? WorkHours { get; set; }

    public decimal? ScheduledWorkHours { get; set; }

    public decimal? Overtime { get; set; }

    public decimal? Undertime { get; set; }

    public string? AttendanceStatus { get; set; }

    public string? AbsenceType { get; set; }

    public bool? IsLateArrival { get; set; }

    public int? LateMinutes { get; set; }

    public bool? IsEarlyDeparture { get; set; }

    public int? EarlyDepartureMinutes { get; set; }

    public string? DataSource { get; set; }

    public string? DeviceId { get; set; }

    public string? DeviceLocation { get; set; }

    public string? ImportBatchId { get; set; }

    public bool? IsManualAdjustment { get; set; }

    public string? AdjustmentReason { get; set; }

    public long? ApprovedBy { get; set; }

    public DateTime? ApprovalDate { get; set; }

    public string? Notes { get; set; }

    public DateTime? CreatedAt { get; set; }

    public long? CreatedBy { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public long? UpdatedBy { get; set; }

    public virtual Person Person { get; set; } = null!;
}
