using System;
using System.Collections.Generic;

namespace MyApp.Models;

public partial class Submission
{
    public int SubmissionId { get; set; }

    public DateTime? SubmissionDate { get; set; }

    public string? SubmissionStatus { get; set; }

    public string? SubmissionComment { get; set; }

    public int? AssignmentId { get; set; }

    public int? StudentId { get; set; }

    public virtual Assignment? Assignment { get; set; }

    public virtual ICollection<File> Files { get; } = new List<File>();

    public virtual Student? Student { get; set; }
}
