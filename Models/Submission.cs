using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyApp.Models;

public partial class Submission
{
    public Guid SubmissionId { get; set; }

    public DateTime? SubmissionDate { get; set; }
    [EnumDataType(typeof(StatusValues))]
    public string? SubmissionStatus { get; set; }

    public string? SubmissionComment { get; set; }

    public Guid? AssignmentId { get; set; }

    public Guid? StudentId { get; set; }

    public virtual Assignment? Assignment { get; set; }

    public virtual ICollection<File> Files { get; } = new List<File>();

    public virtual Student? Student { get; set; }
}
    public enum StatusValues
    {
        returned,
        rejected,
        accepted
    }